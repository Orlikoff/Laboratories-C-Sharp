using System;

namespace Lab_3
{
    class Human
    {
        private static 
        private int DNA;
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Weight { get; private set; }

        private static void CreateDNA()
        {

        }

        public Human(string Name, int Age, double Weight)
        {
            this.Name = Name;
            this.Age = Age;
            this.Weight = Weight;
        }
        public Human(int Age, double Weight)
        {
            this.Name = "-Undefined Name-";
            this.Age = Age;
            this.Weight = Weight;
        }
        public Human(double Weight)
        {
            this.Name = "-Undefined Name-";
            this.Age = 30;
            this.Weight = Weight;
        }
        public Human()
        {
            this.Name = "-Undefined Name-";
            this.Age = 30;
            this.Weight = 80;
        }

        public void Introduce()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Hello, my name is {this.Name}, my age is {this.Age} and my weight is {this.Weight}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human H = new Human();
            H.Introduce();
        }
    }
}
