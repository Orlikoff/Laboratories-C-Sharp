// Пример обощенного метода

namespace Test
{
    class Test
    {
        public static void PrintInfo<T>(T obj) // Обобщенный метод
        {
            Console.WriteLine(obj.ToString());
        }
    }

    class Program
    {
        static void Main()
        {
            int a = 5;
            float b = 6.7f;
            Test.PrintInfo<int>(a);
            Test.PrintInfo<float>(b);
        }
    }
}
