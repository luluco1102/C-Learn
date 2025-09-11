namespace _20250911
{
    internal class Program
    {
        static void CountingStar(string s)
        {
            

        }

        static void Main(string[] args)
        {
            int[,] arr = {
                { 1, 2, 3},
                { 4,5,6},
                { 7,8,9}
            };

            for(int i=0; i<arr.GetLength(0); i++)
            {
                for(int j =0; j<arr.GetLength(1); j++)
                {
                    Console.Write(arr[j,i]);
                    
                }
                Console.WriteLine();
            }

            Add(2, 2);
        }

        static void Add(int Y, int X)
        {
            int[] dY = { -1, 0, 1, 0 };
            int[] dX = { 0, -1, 0, 1 };

            int[,] map =
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };

            
            
            // y x 의 값을 받는다 
            // 그리고 그 값에 상하좌우에 값을 더해줘야된다.
            for( int i =0; i < 4; i++)
            {
                // 조건 0,0 일때 위에랑 왼쪽 값이 없다 그 값일때는 더해주지 않도록 해야된다.
                int pY = dY[i];
                int pX = dX[i];
                if(Y-pY >=0 && X-pX >=0 && Y-pY <=2 && X-pX <=2)
                {
                    map[Y - pY, X - pX]++;
                }
                
            }

            for(int j =0; j<map.GetLength(0); j++)
            {
                for(int k =0;k<map.GetLength(1); k++)
                {
                    Console.Write(map[j,k]);
                }
                Console.WriteLine();
            }
        }
    }
}
