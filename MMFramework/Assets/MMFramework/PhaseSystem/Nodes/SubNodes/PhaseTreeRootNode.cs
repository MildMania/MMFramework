public class PhaseTreeRootNode : PhaseBaseNode
{
    protected PhaseBaseNode _rootNode;

    public PhaseTreeRootNode(PhaseBaseNode rootNode)
    {
        _rootNode = rootNode;
    }

    protected override void TraverseNode()
    {
        _rootNode.OnTraverseFinished += OnRootNodeTraversed;

        _rootNode.Traverse();
    }

    void OnRootNodeTraversed(PhaseBaseNode n)
    {
        n.OnTraverseFinished -= OnRootNodeTraversed;

        TraverseCompleted();
    }
}
