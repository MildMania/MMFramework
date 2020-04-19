using System;

public abstract class PhaseBase : IPhase
{
    public abstract void InitPhase();

    public virtual void StartPhase()
    {
        StartListeningEvents();
    }

    public virtual void StopPhase()
    {
        StopListeningEvents();
    }

    protected abstract void StartListeningEvents();
    protected abstract void StopListeningEvents();
}
