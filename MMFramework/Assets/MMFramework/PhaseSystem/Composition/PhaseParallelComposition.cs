public class PhaseParallelComposition : PhaseComposition
{
    public PhaseParallelComposition(params PhaseBaseNode[] childNodeArr)
    : base(childNodeArr)
    {
    }

    protected override void TraverseComposition()
    {
        for (int i = 0; i < ChildPhaseNodes.Count; i++)
        {
            TraverseChildNode(ChildPhaseNodes[i]);
        }
    }

    void TraverseChildNode(PhaseBaseNode node)
    {
        node.OnTraverseFinished += OnChildNodeTraverseFinished;

        node.Traverse();
    }

    void OnChildNodeTraverseFinished(PhaseBaseNode node)
    {
        if (HasAnyNotTraversedNodes())
            return;

        TraverseCompleted();
    }
}