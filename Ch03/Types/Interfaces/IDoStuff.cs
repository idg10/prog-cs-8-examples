using System;

namespace Interfaces
{
    public interface IDoStuff
    {
        string this[int i] { get; set; }
        string Name { get; set; }
        int Id { get; }
        int SomeMethod(string arg);
        event EventHandler Click;
    }
}