public class SampleCatchSuccessPhaseActionNode : PhaseActionNode
{
    public SampleCatchSuccessPhaseActionNode(int id)
        : base(id)
    {
    }

    protected override void ProcessFlow()
    {
        throw new System.NotImplementedException();
    }
}
