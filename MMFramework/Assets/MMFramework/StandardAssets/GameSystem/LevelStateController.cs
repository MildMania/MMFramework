using System;

public enum ELevelState
{
    None = 0,
    PreStart,
    PostStart,
    PreEnd,
    PostEnd
}

public class LevelStateController
{
    public static Action<ELevelState> OnLevelStateChanged { get; set; }

    public ELevelState CurLevelState { get; private set; } = ELevelState.None;

    public void SetLevelState(ELevelState levelState)
    {
        CurLevelState = levelState;

        OnLevelStateChanged?.Invoke(CurLevelState);
    }
}
