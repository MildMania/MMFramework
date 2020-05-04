public class SampleDefaultFlowManager : PhaseFlowManager
{
    protected override PhaseFlowController CreatePhase()
    {
        return new SampleDefaultFlowController();
    }
}
