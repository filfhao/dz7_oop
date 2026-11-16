using System;
using System.Collections.Generic;

// Завдання 6, шаблон Composite.
// Умова: файлова система складається з файлів і папок, у папці можуть бути
// інші файли та папки. З файлом і папкою треба працювати однаково:
// виводити на екран та рахувати розмір.
namespace Lab8.Task6_Composite
{
    abstract class FileSystemItem
    {
        protected string name;

        public FileSystemItem(string name)
        {
            this.name = name;
        }

        public abstract int GetSize();
        public abstract void Print(string indent);
    }

    class FileItem : FileSystemItem
    {
        private int size;

        public FileItem(string name, int size) : base(name)
        {
            this.size = size;
        }

        public override int GetSize()
        {
            return size;
        }

        public override void Print(string indent)
        {
            Console.WriteLine(indent + name + " (" + size + " КБ)");
        }
    }

    class FolderItem : FileSystemItem
    {
        private List<FileSystemItem> items = new List<FileSystemItem>();

        public FolderItem(string name) : base(name)
        {
        }

        public void Add(FileSystemItem item)
        {
            items.Add(item);
        }

        public void Remove(FileSystemItem item)
        {
            items.Remove(item);
        }

        public override int GetSize()
        {
            int sum = 0;
            foreach (FileSystemItem item in items)
            {
                sum += item.GetSize();
            }
            return sum;
        }

        public override void Print(string indent)
        {
            Console.WriteLine(indent + "[" + name + "] (" + GetSize() + " КБ)");
            foreach (FileSystemItem item in items)
            {
                item.Print(indent + "    ");
            }
        }
    }

    static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("Composite:");

            FolderItem root = new FolderItem("Lab8");
            FolderItem src = new FolderItem("src");
            FolderItem docs = new FolderItem("docs");

            src.Add(new FileItem("Program.cs", 4));
            src.Add(new FileItem("Tree.cs", 6));
            docs.Add(new FileItem("report.docx", 120));
            docs.Add(new FileItem("uml.png", 340));

            root.Add(src);
            root.Add(docs);
            root.Add(new FileItem("README.md", 2));

            root.Print("");
            Console.WriteLine("Загальний розмір: " + root.GetSize() + " КБ");
            Console.WriteLine();
        }
    }
}
