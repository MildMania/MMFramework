using System;

public abstract class PhaseConditionalNode : PhaseComposition
{
    public PhaseConditionalNode(params PhaseBaseNode[] childNodeArr)
        : base(childNodeArr)
    {
    }

    protected sealed override void TraverseComposition()
    {
        CheckConditions(OnConditionReturn);
    }

    private void OnConditionReturn(Type resultPhaseType)
    {
        PhaseBaseNode resultNode = GetPhaseByType(resultPhaseType);

        resultNode.OnTraverseFinished += OnChildNodeTraverseFinished;

        resultNode.Traverse();
    }

    private void OnChildNodeTraverseFinished(PhaseBaseNode n)
    {
        n.OnTraverseFinished -= OnChildNodeTraverseFinished;

        TraverseCompleted();
    }

    /// <summary>
    /// A method to allow registering events or invoking callback directly.
    /// After conditional check, INVOKE callback to continue to the next phase.
    /// </summary>
    /// <param name="callback">Condition result callback with the next phase's type.</param>
    protected abstract void CheckConditions(Action<Type> callback);
}
