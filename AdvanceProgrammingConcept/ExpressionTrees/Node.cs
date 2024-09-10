namespace ExpressionTrees;

public class Node
{
    public char data;
    public Node? left, right;
    public Node(Char data)
    {
        this.data = data;
        left = right = null;
    }

}
