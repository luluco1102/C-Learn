namespace PriorityQueue
{
    class PriorityQueue
    {
        List<int> _heap = new List<int>();
        
        public void Push(int data)
        {
            _heap.Add(data);

            int now = _heap.Count - 1;
            while ( now >0)
            {
                int next = (now - 1) / 2; // 부모 찾는 공식 (i -1) / 2

                if (_heap[now] < _heap[next]) // 작다면 그 자리에 있고 크면 바꿔준다
                    break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;
            }
        }

        public int Pop()
        {
            int ret = _heap[0]; // 기존에 0 번에 있는 값을 저장해준다

            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex]; // 마지막꺼를 맨 앞으로 가져와서 삭제한다
            _heap.RemoveAt(lastIndex);
            lastIndex--; // 삭제가 되었으므로 하나 감소

            int now = 0;

            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                if (left <= lastIndex && _heap[next] < _heap[left]) // _heap[0] < _heap[1] 비교 하고 [0]이 작으면 스왑
                    next = left;

                if (right <= lastIndex && _heap[next] < _heap[right])
                    next = right;

                if (next == now)
                    break;

                int temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                now = next;

            }
            return ret;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
