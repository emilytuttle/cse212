public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        

        if (value < Data && value != Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data && value != Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    
    }

    public bool Contains(int value)
    {
        // def contains(self, value):
        // current_node = self
        // while current_node is not None:
        //     if value < current_node.value:
        //         current_node = current_node.left
        //     elif value > current_node.value:
        //         current_node = current_node.right
        //     else:
        //         return True
        // return False
        // TODO Start Problem 2
        return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        return 0; // Replace this line with the correct return statement(s)
    }
}