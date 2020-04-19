using System;

public class PhaseController
{
    #region Events
    public static Action<IPhase> OnPhaseActivated { get; set; }
    public static Action<IPhase> OnPhaseDeactivated { get; set; }
    #endregion

    public PhaseFlowController PhaseFlowController { get; private set; }

    private PhaseBase _currentPhase;

    public PhaseController()
    {
        PhaseFlowController = new PhaseFlowController();
    }

    public void InitPhases()
    {
        _currentPhase = null;

        PhaseFlowController.InitPhases();
    }

    public bool TryActivateNextLevelSubState()
    {
        DeactivateActivePhase();

        PhaseBase nextPhase = PhaseFlowController.GetNextPhase();

        if (nextPhase == null)
            return true;

        SetActivePhase(nextPhase);

        return false;
    }

    private void SetActivePhase(PhaseBase nextPhase)
    {
        _currentPhase = nextPhase;

        _currentPhase.StartPhase();

        OnPhaseActivated?.Invoke(_currentPhase);
    }

    private void DeactivateActivePhase()
    {
        if (_currentPhase == null)
            return;

        _currentPhase.StopPhase();

        OnPhaseDeactivated?.Invoke(_currentPhase);
    }
}