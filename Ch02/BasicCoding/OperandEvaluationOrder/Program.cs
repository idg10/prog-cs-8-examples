using System;

namespace OperandEvaluationOrder
{
    class Program
    {
        static int X(string label, int i)
        {
            Console.Write(label);
            return i;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(X("a", 1) + X("b", 1) + X("c", 1) + X("d", 1));
        }
    }
}
