using Dumpify;

namespace ExpressionTrees;


public static class GFG
{
    public static void GFGMain()
    {
        string postFix = "ABC*+D/";
        Node r = expressionTree(postFix);
        inorder(r);
    }

    private static void inorder(Node root)
    {
        if (root is null) return;
        inorder(root.left!);
        root.data.Dump();
        inorder(root.right!);
    }
    private static bool isOperator(char ch)
    {
        if ((ch == '+') || (ch == '-') || ch == '*' || ch == '/' || ch == '^') 
            return true;
        return false;
    }
    private static Node expressionTree(string postFix)
    {
        Stack<Node> st = new();
        Node t1, t2, temp;
        for (int i = 0; i < postFix.Length; i++)
        {
            if (!isOperator(postFix[i]))
            {
                temp = new Node(postFix[i]);
                st.Push(temp);
            }
            else
            {
                temp = new Node(postFix[i]);

                t1 = st.Pop();
                t2 = st.Pop();

                temp.left = t2;
                temp.right = t1;

                st.Push(temp);
            }
        }
        temp = st.Pop();
        return temp;
    }
}
