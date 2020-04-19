using System.Collections.Generic;

public class PhaseFlowController
{
    private List<PhaseBase> _phaseFlow = new List<PhaseBase>();

    private int _curIndex;

    public void InitPhases()
    {
        _curIndex = 0;

        _phaseFlow.Clear();
    }

    public void AppendPhase(PhaseBase phase)
    {
        phase.InitPhase();

        _phaseFlow.Add(phase);
    }

    public void AppendPhase(List<PhaseBase> phaseColl)
    {
        for(int i = 0; i < phaseColl.Count; i++)
        {
            phaseColl[i].InitPhase();

            _phaseFlow.Add(phaseColl[i]);
        }
    }

    public PhaseBase GetNextPhase()
    {
        if (_curIndex == _phaseFlow.Count)
            return null;

        return _phaseFlow[_curIndex++];
    }
}
