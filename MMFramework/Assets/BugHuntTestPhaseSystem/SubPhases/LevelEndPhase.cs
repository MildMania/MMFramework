using System;

public class LevelEndPhase : PhaseConditionalNode
{
    public LevelEndPhase(params PhaseBaseNode[] nodes)
        : base(nodes)
    {
    }

    protected override void CheckConditions(Action<Type> callback)
    {
        //callback?.Invoke(typeof(LevelWinPhase));

        //callback?.Invoke(typeof(LevelFailPhase));
    }
}
