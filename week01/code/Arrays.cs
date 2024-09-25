using System;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // MY PROCESS:
        // The function needs to be given a number to find multiples for (x), and a number to represent the number of multiples to generate (y). This can be done with a loop, that goes until i reaches y. When the loop runs, the current i will be multiplied by x to find the number of multiples. Those multiples will be added to a list, as long as i, which starts at 1, is less than or equal to y. Once all of the multiples have been added to a list, the list is converted into the returned array.

        List<double> multiples = new List<double>();

        for (double i = 1; i <= length; i++)
        {
            double currentNumber = number * i;
            multiples.Add(currentNumber);
        }

        double[] array = multiples.ToArray();

        return array; // replace this return statement with your own
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // MY PROCESS

        // To rotate to the right, the last number needs to move to the beginning of the list. This can be done by removing the last number at placing it at the first index. A for loop should be made, with i starting at 0, increasing by one with each run, until the amount of moves to the right have been reached. Within the loop, the last index needs to be found, and this can be done by finding the amount of items in the list and subracting one, as the list starts with an index of 0. Using that index, the current last digit can be stored as a new variable. The last index is then removed, and the value of the last index at the beginning of the loop will be added to the first index of the list. The list is then used again, with the new values and numbers can continue to shift until the amount of rotations has been reached.
        for (int i = 0; i < amount; i++)
        {
            int dataEndIndex = data.Count - 1;
            int lastIndexValue = data[dataEndIndex];
            data.RemoveAt(dataEndIndex);
            data.Insert(0, lastIndexValue);
        }
    }
}
