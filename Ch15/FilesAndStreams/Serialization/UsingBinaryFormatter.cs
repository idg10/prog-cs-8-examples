using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public static class UsingBinaryFormatter
    {
        internal static Stream Serialize(Person person)
        {
            var stream = new MemoryStream();
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, person);

            return stream;
        }

        internal static Person Deserialize(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var serializer = new BinaryFormatter();
            var personCopy = (Person)serializer.Deserialize(stream);

            return personCopy;
        }
    }
}