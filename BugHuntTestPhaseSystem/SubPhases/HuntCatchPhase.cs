using System;

public class HuntCatchPhase : PhaseConditionalNode
{
    public HuntCatchPhase(params PhaseBaseNode[] nodes)
        : base(nodes)
    {
    }

    protected override void CheckConditions(Action<Type> callback)
    {
        //callback?.Invoke(typeof(CatchSuccessPhase));

        //callback?.Invoke(typeof(CatchFailPhase));
    }
}
