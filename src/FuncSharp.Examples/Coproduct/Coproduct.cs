namespace FuncSharp.Examples;

public class Tree<A> : Coproduct2<Node<A>, Leaf>
{
    public Tree(Node<A> node) : base(node) { }
    public Tree(Leaf leaf) : base(leaf) { }
}

public class Leaf : Product0
{
}

public class Node<A> : Product3<A, Tree<A>, Tree<A>>
{
    public Node(A value, Tree<A> left, Tree<A> right)
        : base(value, left, right)
    {
    }

    public A Value { get { return ProductValue1; } }
    public Tree<A> Left { get { return ProductValue2; } }
    public Tree<A> Right { get { return ProductValue3; } }
}

public static class TreeUtilities
{
    public static int LeafCount<A>(Tree<A> tree)
    {
        return tree.Match(
            node => LeafCount(node.Left) + LeafCount(node.Right),
            leaf => 1
        );
    }
}