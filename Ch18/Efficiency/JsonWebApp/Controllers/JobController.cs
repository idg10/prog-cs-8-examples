using System;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebApp.Controllers
{
    [ApiController]
    public class JobController : ControllerBase
    {
        // Change to #if false to switch to low-allocation version from Example 8
#if true
        [HttpPost]
        [Route("/jobs/create")]
        public void CreateJob([FromBody] JobDescription requestBody)
        {
            switch (requestBody.JobCategory)
            {
                case "arduous":
                    CreateArduousJob(requestBody.DepartmentId);
                    break;

                case "tedious":
                    CreateTediousJob(requestBody.DepartmentId);
                    break;
            }
        }

        public class JobDescription
        {
            public int DepartmentId { get; set; }
            public string JobCategory { get; set; }
        }

#else

        private static readonly byte[] Utf8TextJobCategory =
            Encoding.UTF8.GetBytes("JobCategory");
        private static readonly byte[] Utf8TextDepartmentId =
            Encoding.UTF8.GetBytes("DepartmentId");
        private static readonly byte[] Utf8TextArduous = Encoding.UTF8.GetBytes("arduous");
        private static readonly byte[] Utf8TextTedious = Encoding.UTF8.GetBytes("tedious");

        [HttpPost]
        [Route("/jobs/create")]
        public async ValueTask CreateJobFrugalAsync()
        {
            bool inDepartmentIdProperty = false;
            bool inJobCategoryProperty = false;
            int? departmentId = null;
            bool? isArduous = null;

            PipeReader reader = this.Request.BodyReader;
            JsonReaderState jsonState = default;
            while (true)
            {
                ReadResult result = await reader.ReadAsync().ConfigureAwait(false);
                jsonState = ProcessBuffer(
                    result,
                    jsonState,
                    out SequencePosition position);

                if (departmentId.HasValue && isArduous.HasValue)
                {
                    if (isArduous.Value)
                    {
                        CreateArduousJob(departmentId.Value);
                    }
                    else
                    {
                        CreateTediousJob(departmentId.Value);
                    }

                    return;
                }

                reader.AdvanceTo(position);

                if (result.IsCompleted)
                {
                    break;
                }
            }

            JsonReaderState ProcessBuffer(
                in ReadResult result,
                in JsonReaderState jsonState,
                out SequencePosition position)
            {
                // This is a ref struct, so this has no GC overhead
                var r = new Utf8JsonReader(result.Buffer, result.IsCompleted, jsonState);

                while (r.Read())
                {
                    if (inDepartmentIdProperty)
                    {
                        if (r.TokenType == JsonTokenType.Number)
                        {
                            if (r.TryGetInt32(out int v))
                            {
                                departmentId = v;
                            }
                        }
                    }
                    else if (inJobCategoryProperty)
                    {
                        if (r.TokenType == JsonTokenType.String)
                        {
                            if (r.ValueSpan.SequenceEqual(Utf8TextArduous))
                            {
                                isArduous = true;
                            }
                            else if (r.ValueSpan.SequenceEqual(Utf8TextTedious))
                            {
                                isArduous = false;
                            }
                        }
                    }

                    inDepartmentIdProperty = false;
                    inJobCategoryProperty = false;

                    if (r.TokenType == JsonTokenType.PropertyName)
                    {
                        if (r.ValueSpan.SequenceEqual(Utf8TextJobCategory))
                        {
                            inJobCategoryProperty = true;
                        }
                        else if (r.ValueSpan.SequenceEqual(Utf8TextDepartmentId))
                        {
                            inDepartmentIdProperty = true;
                        }
                    }
                }

                position = r.Position;
                return r.CurrentState;
            }
        }

        public class JobDescription
        {
            public int DepartmentId { get; set; }
            public string JobCategory { get; set; }
        }
#endif
        private void CreateTediousJob(int departmentId)
        {
            Debug.WriteLine($"Real code would be creating a tedious job for {departmentId} at this point");
        }

        private void CreateArduousJob(int departmentId)
        {
            Debug.WriteLine($"Real code would be creating an arduous job for {departmentId} at this point");
        }
    }
