using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

namespace LinqQueries
{
    public static class Grouping
    {
        public static void GroupingEvents()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var w = new FileSystemWatcher(path);
            IObservable<EventPattern<FileSystemEventArgs>> changes =
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                    h => w.Changed += h, h => w.Changed -= h);
            w.IncludeSubdirectories = true;
            w.EnableRaisingEvents = true;

            IObservable<IGroupedObservable<string, string>> folders =
                from change in changes
                group Path.GetFileName(change.EventArgs.FullPath)
                   by Path.GetDirectoryName(change.EventArgs.FullPath);

            folders.Subscribe(f =>
            {
                Console.WriteLine("New folder ({0})", f.Key);
                f.Subscribe(file =>
                    Console.WriteLine("File changed in folder {0}, {1}", f.Key, file));
            });
        }
    }
}