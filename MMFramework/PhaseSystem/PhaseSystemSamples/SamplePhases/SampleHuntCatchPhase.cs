using System;

public class SampleHuntCatchPhaseCondNode : PhaseConditionalNode
{
    public SampleHuntCatchPhaseCondNode(int id, params PhaseBaseNode[] nodes)
        : base(id, nodes)
    {
    }

    protected override void CheckConditions(Action<int> callback)
    {
        //callback?.Invoke(4);
        // OR
        //callback?.Invoke(5);
    }
}
