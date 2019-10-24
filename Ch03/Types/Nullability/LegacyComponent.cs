using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace Nullability
{
    internal class LegacyComponent
    {
        public string GetReferenceWeKnowWontBeNull() => "Definitely not null";
    }
}
