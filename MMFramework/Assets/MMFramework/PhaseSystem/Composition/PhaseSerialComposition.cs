public class PhaseSerialComposition : PhaseComposition
{
    public PhaseSerialComposition(params PhaseBaseNode[] childNodeArr)
        : base(childNodeArr)
    {
    }

    protected override void TraverseComposition()
    {
        TraverseChildNode(ChildPhaseNodes[0]);
    }

    void TraverseChildNode(PhaseBaseNode node)
    {
        node.OnTraverseFinished += OnChildNodeTraverseFinished;

        node.Traverse();
    }

    void OnChildNodeTraverseFinished(PhaseBaseNode n)
    {
        n.OnTraverseFinished -= OnChildNodeTraverseFinished;

        if (HasAnyNotTraversedNodes())
        {
            int traversedNodeIndex = ChildPhaseNodes.IndexOf(n);

            PhaseBaseNode nextNode = ChildPhaseNodes[traversedNodeIndex + 1];

            TraverseChildNode(nextNode);

            return;
        }

        TraverseCompleted();
    }
}