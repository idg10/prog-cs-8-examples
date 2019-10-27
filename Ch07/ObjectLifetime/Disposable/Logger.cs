using System;
using System.IO;

namespace Disposable
{
    public sealed class Logger : IDisposable
    {
        private StreamWriter _file;

        public Logger(string filePath)
        {
            _file = File.CreateText(filePath);
        }

        public void Dispose()
        {
            if (_file != null)
            {
                _file.Dispose();
                _file = null;
            }
        }
        // A real class would go on to do something with the StreamWriter, of course
    }
}