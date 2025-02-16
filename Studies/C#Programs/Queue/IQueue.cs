namespace Queue
{
    interface IQueue
    {
        void Enqueue(object element);
        object Dequeue();
        object Peek();
        bool isEmpty();
        bool isFull();
        void Display();
    }
}
