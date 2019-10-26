using System;

namespace Virtuals
{
    public class DeriveWithoutOverride : BaseWithVirtual
    {
    }

    public class DeriveAndOverride : BaseWithVirtual
    {
        public override void ShowMessage()
        {
            Console.WriteLine("This is an override");
        }
    }
}