namespace _20250916
{
    /*class MyList<T>
    {
        public int count;
        public T[] _data = new T[1];
        public int capacity { get { return _data.Length; } }

        public void Add(T item)
        {
            if (count >= capacity)
            {
                T[] _temp = new T[count * 2];
                for (int i = 0; i< count; i++)
                {
                    _temp[i] = _data[i];
                }
                _data = _temp;
            }

            _data[count] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count-1; i++)
            {
                _data[i] = _data[i+1];
            }
            _data[count - 1] = default;
            count--;
        }
    }

    class Node
    {
        public int data;
        public Node Next;
        public Node Prev;
    }

    class MyLinkedList
    {
        public int count;
        public Node Head;
        public Node Tail;

        public Node AddLast(int Data)
        {
            Node newnode = new Node();
            newnode.data = Data;
            if (Head == null)
            {
                Head = newnode;
            }

            if (Tail != null)
            {
                Tail.Next = newnode;
                newnode.Prev = Tail;
            }

            Tail = newnode;
            count++;
            return newnode;
        }

        public void Remove(Node node)
        {
            if (Head == node)
            {
                Head = Head.Next;
            }

            if (Tail == node)
            {
                Tail.Prev = Tail;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            count--;
        }
    }*/

    /*class Graph
    {
        int[,] map = new int[,]
        {
            {0, 1, 0, 1, 0, 0 },
            {1, 0, 1, 1, 0, 0 },
            {0, 1, 0, 0, 0, 0 },
            {1, 1, 0, 0, 1, 0 },
            {0, 0, 0, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0 }
        };

        // 방문 목록 만들기
        public bool[] visited = new bool[6];
        public int[] distance = new int[6];

        public void BFS(int start)
        {
            // 예약 목록 만들기
            Queue<int> queue = new Queue<int>();

            // 예약 목록에 예약 하기
            queue.Enqueue(start);
            visited[start] = true;
            distance[start] = 0;

            // 예약 목록에서 예약을 꺼내서 아직 예약 
            // 안했고 연결되어있고 방문안한 얘들 예약하기
            while( queue.Count > 0 )
            {
                int now = queue.Dequeue();
                Console.WriteLine($"방문 : {now}");
                

                for (int next = 0; next < map.GetLength(0); next++)
                {
                    // 연결이 되어있는지
                    if (map[now, next] == 0)
                        continue;
                    // 방문이 되어있는지
                    if (visited[next] == true)
                        continue;

                    // 예약하기
                    queue.Enqueue(next);
                    visited[next] = true;
                    distance[next] = distance[now] + 1;
                }
            }

            Console.WriteLine(distance[map.GetLength(0) -1]);
        }
    }*/

    class Graph
    {
        int[,] map = new int[,]
        {
             { -1, 10, -1, 18, -1, -1, -1, -1 },
            { 10, -1, 05, 06, -1, -1, -1, -1 },
            { -1, 05, -1, -1, -1, -1, -1, -1 },
            { 18, 06, -1, -1, 13, -1, -1, -1 },
            { -1, -1, -1, 13, -1, 14, 08, -1 },
            { -1, -1, -1, -1, 14, -1, -1, 17 },
            { -1, -1, -1, -1, 08, -1, -1, 26 },
            { -1, -1, -1, -1, -1, 17, 26, -1 },
        };
        
        

        bool[] visited = new bool[8];
        int[] distance = new int[8];
        int[] parents = new int[8];

        public void Dijkstra(int start)
        {
            Array.Fill(distance, Int32.MaxValue);
            distance[start] = 0;
            parents[start] = start;

            while (true)
            {
                // 제일 좋은 후보 찾기 (최단 거리 후보)

                // 가장 유력한 후보의 거리와 번호를 저장
                int closet = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 8; i++)
                {
                    // 이미 방문한 정점은 스킵
                    if (visited[i] == true)
                        continue;

                    // 아직 발견된 적이 없거나, 기존 후보보다 멀면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closet)
                        continue;

                    // 발견한 후보중 가장 좋은 후보를 찾음, 정보를 갱신
                    closet = distance[i];
                    now = i;
                }

                if (now == -1)
                    break;

                // 제일 좋은 후보 방문
                visited[now] = true;

                // 방문한 정점의 인접점 확인해서 최단거리를 갱신한다
                for (int next =0; next < 8; next++)
                {
                    // 연결이 되어있지 않으면 스킵
                    if (map[now, next] == -1)
                        continue;
                    // 이미 방문한 정점도 스킵
                    if (visited[next] == true)
                        continue;

                    // 새로 조사된 인접 정점의 최단거리 계산
                    int nextDist = distance[now] + map[now, next];
                    // 위의 인접 정점의 최단거리를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parents[next] = now;
                    }
                       
                }
            }
        }
    }

    class Program
    {
        /*#region DFS
        static int M, N, K;
        static int[] dy = { -1, 0, 1, 0 };
        static int[] dx = { 0, -1, 0, 1 };
        static int[,] adj = new int[50, 50];
        static bool[,] visited = new bool[50, 50];
       
        static void DFS(int y, int x)
        {
            visited[y, x] = true;
            for (int i = 0; i <4; i++)
            {
                int newY = y + dy[i];
                int newX = x + dx[i];

                if (newY < 0 || newY >= N || newX < 0 || newX >= M)
                    continue;
                if (adj[newY, newX] == 0)
                    continue;
                if (visited[newY, newX] == true)
                    continue;

                DFS(newY, newX);
            }
        }
        #endregion*/
        
        
        static void Main(string[] args)
        {
            /*#region List
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.RemoveAt(0);
            list.RemoveAt(1);
            #endregion
            #region LinkedList
            MyLinkedList myLinkedList = new MyLinkedList();
            Node node1 = myLinkedList.AddLast(6);
            Node node2 = myLinkedList.AddLast(7);
            Node node3 = myLinkedList.AddLast(8);
            Node node4 = myLinkedList.AddLast(9);
            myLinkedList.AddLast(1);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddLast(4);
            myLinkedList.AddLast(5);
            myLinkedList.Remove(node1);
            myLinkedList.Remove(node2);
            myLinkedList.Remove(node3);
            myLinkedList.Remove(node4);
            #endregion
            int t = int.Parse(Console.ReadLine());

            while(t-- > 0)
            {
                string[] input = Console.ReadLine().Split();
                M = int.Parse(input[0]);
                N = int.Parse(input[1]);
                K = int.Parse(input[2]);
                int rat =0;
                int x, y;

                for ( int i =0; i < K; i++)
                {
                    input = Console.ReadLine().Split();
                    x = int.Parse(input[0]);
                    y = int.Parse(input[1]);

                    adj[y, x] = 1;
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (adj[i, j] == 0)
                            continue;
                        if (visited[i, j] == true)
                            continue;

                        DFS(i,j);
                        rat++;
                    }
                }
                Console.WriteLine(rat);*/
            /*Graph graph = new Graph();
            graph.BFS(0);*/
            /*string[] input = Console.ReadLine().Split();
            static int[,] visited;
            static int[,] map;
            int n, m;
            n = int.Parse(input[0]);
            m = int.Parse(input[1]);
     
            int[] dy = { -1, 0, 1, 0 };
            int[] dx = { 0, -1, 0, 1 };

            map = new int[n, m];
            visited = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    map[i, j] = line[j] - '0';
                }
            }

            // 예약목록 만들기
            Queue<(int , int)> queue = new Queue<(int, int)>();

            // 시작지점 방문처리
            visited[0, 0] = 1;
            // 시작지점 예약
            queue.Enqueue((0, 0));
            // 예약목록 꺼내서 돌리기
            while (queue.Count >0)
            {
                (int y,int x) = queue.Dequeue();

                for (int dir = 0; dir < 4; dir++)
                {
                    int nextY = y + dy[dir];
                    int nextX = x + dx[dir];

                    if (nextY < 0 || nextY >= n || nextX < 0 || nextX >= m)
                        continue;
                    if (map[nextY, nextX] == 0)
                        continue;
                    if (visited[nextY, nextX] >0)
                        continue;

                    queue.Enqueue((nextY, nextX));
                    visited[nextY, nextX] = visited[y, x] + 1;
                    
                }
            }
            Console.WriteLine(visited[n-1,m-1]);*/
            Graph graph = new Graph();
            graph.Dijkstra(0);

        }


    }
}
