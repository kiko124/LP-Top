using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._4
{
    public interface IFileSystemComponent
    {
        string Name { get; }
        double GetSize();
        void Display(int depth = 0);
    }


    public class File : IFileSystemComponent
    {
        public string Name { get; }
        private readonly double _size;

        public File(string name, double size)
        {
            Name = name;
            _size = size;
        }

        public double GetSize() => _size;

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}📄 {Name} ({_size} MB)");
        }
    }


    public class Directory : IFileSystemComponent
    {
        public string Name { get; }
        private readonly List<IFileSystemComponent> _children = new List<IFileSystemComponent>();

        public Directory(string name)
        {
            Name = name;
        }

        public void Add(IFileSystemComponent component) => _children.Add(component);
        public void Remove(IFileSystemComponent component) => _children.Remove(component);

        public double GetSize()
        {
            double totalSize = 0;
            foreach (var child in _children)
            {
                totalSize += child.GetSize();
            }
            return totalSize;
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth * 2)}📁 {Name} ({GetSize()} MB)");
            foreach (var child in _children)
            {
                child.Display(depth + 1);
            }
        }
    }

    class CompositeExample
    {
        static void Main()
        {
  
            var file1 = new File("document.txt", 1.5);
            var file2 = new File("image.jpg", 2.3);
            var file3 = new File("video.mp4", 150.0);
            var file4 = new File("notes.txt", 0.8);

            var root = new Directory("Root");
            var docs = new Directory("Documents");
            var media = new Directory("Media");

          
            docs.Add(file1);
            docs.Add(file4);
            media.Add(file2);
            media.Add(file3);

          
            root.Add(docs);
            root.Add(media);

            root.Add(new File("readme.md", 0.3));

           
            Console.WriteLine("Файловая система:");
            root.Display();

           
            Console.WriteLine($"\nРазмер директории 'Documents': {docs.GetSize()} MB");
            Console.WriteLine($"Размер файла 'video.mp4': {file3.GetSize()} MB");
            Console.WriteLine($"Общий размер корневой директории: {root.GetSize()} MB");
        }
    }
}
