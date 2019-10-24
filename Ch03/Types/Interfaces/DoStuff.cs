using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class DoStuff : IDoStuff
    {
        public string this[int i] { get { return i.ToString(); } set { } }
        public string Name { get; set; }

        int IDoStuff.SomeMethod(string arg)
        {
            return 42;
        }


        public int Id { get; }

        public event EventHandler Click;
    }
}