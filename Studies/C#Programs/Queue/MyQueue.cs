namespace Queue
{
    public class MyQueue : IQueue
    {
        public object[] elements;
        private int startOfQueue;
        private int endOfQueue;
        private int queueSize;

        public MyQueue()
        {
            startOfQueue = 0;
            endOfQueue = 0;
            queueSize = 20;
            elements = new object[queueSize];
        }
        public MyQueue(int capacity)
        {
            startOfQueue = 0;
            endOfQueue = 0;
            queueSize = capacity;
            elements = new object[capacity];
        }
        private int Increase(int a)
        {
            return (a + 1) % queueSize;
        }
        public bool isEmpty()
        {
            if (startOfQueue == endOfQueue) return true;

            return false;
        }
        public bool isFull()
        {
            if (Increase(endOfQueue) == startOfQueue) return true;

            return false;
        }
        public void Enqueue(object element)
        {
            if (isFull())
            {
                Console.WriteLine("The queue is full!");
            }
            else
            {
                elements[endOfQueue] = element;
                endOfQueue = Increase(endOfQueue);
                Console.WriteLine("The item has been successfully added!!");
            }
        }
        public object Dequeue()
        {
            if (isEmpty())
            {
                Console.WriteLine("The queue is empty!");
                return "No elements";
            }
            else
            {
                object wynik = elements[startOfQueue];
                startOfQueue = Increase(startOfQueue);
                return wynik;
            }
        }
        public object Peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("The queue is empty!");
                return "No elements";
            }
            else
                return elements[startOfQueue];
        }
        public void Display()
        {
            if (isEmpty())
                Console.WriteLine("No items to display");

            for (int i = startOfQueue; i< endOfQueue; i++)
                Console.WriteLine("Element{0}: {1}", (i + 1), elements[i]);
        }
    }
}
