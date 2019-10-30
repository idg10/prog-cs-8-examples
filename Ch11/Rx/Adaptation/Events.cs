using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;

namespace Adaptation
{
    public static class Events
    {
        public static void NameBasedWrapping()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var watcher = new FileSystemWatcher(path);
            watcher.EnableRaisingEvents = true;

            IObservable<EventPattern<FileSystemEventArgs>> changes =
                Observable.FromEventPattern<FileSystemEventArgs>(
                    watcher, nameof(watcher.Created));
            changes.Subscribe(evt => Console.WriteLine(evt.EventArgs.FullPath));
        }

        public static void DelegateBasedWrapping()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var watcher = new FileSystemWatcher(path);
            watcher.EnableRaisingEvents = true;

            IObservable<EventPattern<FileSystemEventArgs>> changes =
                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                h => watcher.Created += h, h => watcher.Created -= h);

            changes.Subscribe(evt => Console.WriteLine(evt.EventArgs.FullPath));
        }
    }
}