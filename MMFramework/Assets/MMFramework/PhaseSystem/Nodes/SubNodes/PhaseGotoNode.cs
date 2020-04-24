public class PhaseGotoNode : PhaseBaseNode
{
    private PhaseBaseNode _gotoNode;

    public PhaseGotoNode(PhaseBaseNode loopNode)
    {
        _gotoNode = loopNode;
    }

    protected sealed override void TraverseNode()
    {
        ResetLoopNode();

        _gotoNode.Traverse();
    }

    private void ResetLoopNode()
    {
        _gotoNode.ResetNode();
    }
}
