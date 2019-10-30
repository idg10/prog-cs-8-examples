using System;

namespace Attributes
{
    public class ForCompilerGeneratedMembers
    {
        [field: NonSerialized]
        public int DynamicId { get; set; }

        [field: NonSerialized]
        public event EventHandler Frazzled;
    }
}
