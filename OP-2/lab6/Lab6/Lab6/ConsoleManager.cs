namespace Lab6;

public class ConsoleManager
{
    private readonly Random _random = new Random();
    public void AddElementToQueue(CircularQueue<int> queue, int count) // додавання нових елементів у чергу
    {
        for (int i = 1; i <= count; i++)
        {
            int randomNumber = _random.Next(1, 100);
            queue.Enqueue(randomNumber);
            // queue.DisplayInternal();
        }
    }
}