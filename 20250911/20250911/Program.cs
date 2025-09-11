namespace _20250911
{
    internal class Program
    {
        static void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
            Swap(ref x,ref y);

            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
