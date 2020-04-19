public class TempPhase_01 : PhaseBase
{
    public override void InitPhase()
    {
    }

    public override void StartPhase()
    {
        base.StartPhase();

        UnityEngine.Debug.Log("TempPhase_01");
    }

    protected override void StartListeningEvents()
    {
    }

    protected override void StopListeningEvents()
    {
    }
}
