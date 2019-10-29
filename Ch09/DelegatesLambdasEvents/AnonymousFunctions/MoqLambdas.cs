using System;
using System.Collections.Generic;
using Moq;

namespace AnonymousFunctions
{
    public static class MoqLambdas
    {
        public static void UseMoq()
        {
            var fakeComparer = new Mock<IEqualityComparer<string>>();
            fakeComparer
                .Setup(c => c.Equals("Color", "Colour"))
                .Returns(true);

            IEqualityComparer<string> c = fakeComparer.Object;
            Console.WriteLine(c.Equals("Color", "Colour"));
        }
    }
}