public class TempPhase_02 : PhaseBase
{
    public override void InitPhase()
    {
    }

    public override void StartPhase()
    {
        base.StartPhase();

        UnityEngine.Debug.Log("TempPhase_02");
    }

    protected override void StartListeningEvents()
    {
    }

    protected override void StopListeningEvents()
    {
    }
}
