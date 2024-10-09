using Microsoft.VisualStudio.TestTools.UnitTesting;


// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Enqueue function shall add an item (which contains both data and priority) to the back of the queue.
    // Expected Result: Tests that data and priority are added to the end of the queue. Items should all be added so the last one added is at the back.
    // Defect(s) Found: Functions as it should now
    public void TestPriorityQueue_EnqueueFunctions()
    {
        var myQueue = new PriorityQueue();
        var item1 = new PriorityItem("i1", 5);
        var item2 = new PriorityItem("i2", 2);
        var item3 = new PriorityItem("i3", 8);

        myQueue.Enqueue(item1.Value, item1.Priority);
        myQueue.Enqueue(item2.Value, item2.Priority);
        myQueue.Enqueue(item3.Value, item3.Priority);

        PriorityItem[] expectedResult = [item1, item2, item3];
       
       
        for (int i = 0; i < 3; i++)
        {
            PriorityItem itemTest = myQueue._queue[i];
            Assert.AreEqual($"{expectedResult[i].Value}, (Pri:{expectedResult[i].Priority})", $"{itemTest.Value}, (Pri:{itemTest.Priority})");
        }
       
    }
    

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
    // Expected Result: i3
    // Defect(s) Found: High priority is not removed, the highest value is not taken
    public void TestPriorityQueue_2()
    {
        var myQueue = new PriorityQueue();

        var item1 = new PriorityItem("i1", 5);
        var item2 = new PriorityItem("i2", 2);
        var item3 = new PriorityItem("i3", 8);

        myQueue.Enqueue(item1.Value, item1.Priority);
        myQueue.Enqueue(item2.Value, item2.Priority);
        myQueue.Enqueue(item3.Value, item3.Priority);

        string expectedResult = item3.Value;

        string choice = myQueue.Dequeue();

        Assert.AreEqual(expectedResult, choice);
        
    }

    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
    // Expected Result: i3
    // Defect(s) Found: High priority is not removed, the highest value is not taken
    public void TestPriorityQueue_CheckForMultipleHighPriority()
    {
        var myQueue = new PriorityQueue();

        var item1 = new PriorityItem("i1", 5);
        var item2 = new PriorityItem("i2", 8);
        var item3 = new PriorityItem("i3", 2);
        var item4 = new PriorityItem("i4", 8);
        var item5 = new PriorityItem("i5", 1);

        myQueue.Enqueue(item1.Value, item1.Priority);
        myQueue.Enqueue(item2.Value, item2.Priority);
        myQueue.Enqueue(item3.Value, item3.Priority);
        myQueue.Enqueue(item4.Value, item4.Priority);
        myQueue.Enqueue(item5.Value, item5.Priority);

        string expectedResult = item2.Value;

        string choice = myQueue.Dequeue();

        Assert.AreEqual(expectedResult, choice);
        
    }

    [TestMethod]
    // Scenario: Try to get the next item from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message.
    // Defect(s) Found: Passed initially
    public void TestPriorityQueue_Empty()
    {
        var items = new PriorityQueue();

        try
        {
            items.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}

