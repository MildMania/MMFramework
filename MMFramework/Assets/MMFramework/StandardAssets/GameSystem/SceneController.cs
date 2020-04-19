using System;
using UnityEngine;

public abstract class SceneController : MonoBehaviour
{
    public Action OnSceneResetRequest { get; set; }

    private static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<SceneController>();

            return _instance;
        }
    }

    public PhaseController PhaseController { get; private set; }

    protected LevelStateController _levelStateController;

    protected virtual void Awake()
    {
        _levelStateController = new LevelStateController();

        PhaseController = new PhaseController();

        StartListeningEvents();
    }

    protected virtual void Start()
    {
        PhaseController.InitPhases();
    }

    protected virtual void OnDestroy()
    {
        StopListeningEvents();
    }

    protected virtual void StartListeningEvents()
    {
    }

    protected virtual void StopListeningEvents()
    {
    }

    public virtual void StartLevel()
    {
        _levelStateController.SetLevelState(ELevelState.PreStart);

        _levelStateController.SetLevelState(ELevelState.PostStart);

        TryActivateNextSubState();
    }

    public virtual void FinishLevel()
    {
        _levelStateController.SetLevelState(ELevelState.PreEnd);

        _levelStateController.SetLevelState(ELevelState.PostEnd);
    }

    public bool TryActivateNextSubState()
    {
        bool arePhasesFinished = PhaseController.TryActivateNextLevelSubState();

        if (arePhasesFinished)
            FinishLevel();

        return arePhasesFinished;
    }

    public virtual void ResetScene()
    {
        Start();

        OnSceneResetRequest?.Invoke();
    }
}
