using System;

namespace _20250915
{
    class Program
    {
        static int[] dY = { -1, 0, 1, 0 };
        static int[] dX = { 0, -1, 0, 1 };
        static int[,] adj = new int[50, 50];
        static bool[,] visited = new bool[50, 50];
        static int m, n, k;

        static public void DFS(int y, int x)
        {
            visited[y, x] = true;
            

            for (int i =0; i<4; i++)
            {
                int newY = y + dY[i];
                int newX = x + dX[i];

                if (newY < 0 || newY >= n || newX < 0 || newX >= m)
                    continue;

                if (visited[newY, newX] == true)
                    continue;

                if (adj[newY, newX] == 0)
                    continue;

                DFS(newY, newX);

            }
        }


        static void Main(string[] args)
        {
            
            int t = int.Parse(Console.ReadLine());

            

            while(t-- >0)
            {
                int x, y;
                int ret = 0;

                string[] input = Console.ReadLine().Split();

                m = int.Parse(input[0]);
                n = int.Parse(input[1]);
                k = int.Parse(input[2]);

                for (int i = 0; i < k; i++)
                {
                    input = Console.ReadLine().Split();
                    x = int.Parse(input[0]);
                    y = int.Parse(input[1]);
                    adj[y, x] = 1;
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j =0; j<m; j++)
                    {
                        if (adj[j,i] == 0)
                            continue;
                        if (visited[j, i] == true)
                            continue;
                        DFS(j,i);
                        
                        ret++;
                    }
                }
                Console.WriteLine(ret);
            }


        }
    }

}
