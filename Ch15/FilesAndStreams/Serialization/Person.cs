using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
class Person
{
    public string Name { get; set; }

    public IList<Person> Friends { get; } = new List<Person>();

    public override string ToString() =>
        $"{Name} (friends: {string.Join(", ", Friends.Select(f => f.Name))})";
}