using System;
using System.Threading.Tasks;

namespace Tpl
{
    internal class ParallelFor
    {
        static float[] ParallelConvolution(float[] input, float[] kernel)
        {
            float[] output = new float[input.Length];
            Parallel.For(0, input.Length, i =>
            {
                float total = 0;
                for (int k = 0; k < Math.Min(kernel.Length, i + 1); ++k)
                {
                    total += input[i - k] * kernel[k];
                }
                output[i] = total;
            });

            return output;
        }
    }
}