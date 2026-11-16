using System;

// Завдання 4: ялинка з прикрасами і гірляндою (Decorator)
namespace Lab8.Task4_Decorator
{
    abstract class Tree
    {
        public abstract string GetDescription();
        public abstract void Shine();
    }

    class ChristmasTree : Tree
    {
        public override string GetDescription()
        {
            return "Ялинка";
        }

        public override void Shine()
        {
            Console.WriteLine("Ялинка не світиться, гірлянди немає");
        }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        public TreeDecorator(Tree tree)
        {
            this.tree = tree;
        }

        public override string GetDescription()
        {
            return tree.GetDescription();
        }

        public override void Shine()
        {
            tree.Shine();
        }
    }

    // прикраси - зберігаємо у полях назву і кількість
    class OrnamentDecorator : TreeDecorator
    {
        private string name;
        private int count;

        public OrnamentDecorator(Tree tree, string name, int count) : base(tree)
        {
            this.name = name;
            this.count = count;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() + ", прикраси: " + name + " (" + count + " шт.)";
        }
    }

    // гірлянда - додає світіння
    class GarlandDecorator : TreeDecorator
    {
        private string color;

        public GarlandDecorator(Tree tree, string color) : base(tree)
        {
            this.color = color;
        }

        public override string GetDescription()
        {
            return tree.GetDescription() + ", гірлянда (" + color + ")";
        }

        public override void Shine()
        {
            tree.Shine();
            Console.WriteLine("Гірлянда (" + color + ") світиться!");
        }
    }

    static class Demo
    {
        public static void Run()
        {
            Tree tree = new ChristmasTree();
            Console.WriteLine(tree.GetDescription());
            tree.Shine();
            Console.WriteLine();

            tree = new OrnamentDecorator(tree, "кульки", 10);
            Console.WriteLine(tree.GetDescription());
            tree.Shine();
            Console.WriteLine();

            tree = new OrnamentDecorator(tree, "зірки", 3);
            tree = new GarlandDecorator(tree, "різнокольорова");
            Console.WriteLine(tree.GetDescription());
            tree.Shine();
        }
    }
}
