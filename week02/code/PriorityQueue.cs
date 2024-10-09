using System; 
using System.Collections; 

public class PriorityQueue
{
    public List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }
        
        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        var highPriorityNumber = 0;
        PriorityItem[] arrayVersion = _queue.ToArray();
        
        for (int i= 0; i < arrayVersion.Length; i++)
        {
            Console.WriteLine(arrayVersion[i].Value);
            
        
            if (arrayVersion[i].Priority > highPriorityNumber) {
                highPriorityNumber = arrayVersion[i].Priority;
                highPriorityIndex = i;
            }
            
        }

        // Remove and return the item with the highest priority
        var value = arrayVersion[highPriorityIndex].Value;
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }

    public PriorityItem[] MakeArray()
    {
        return [];
    }
}

public class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}