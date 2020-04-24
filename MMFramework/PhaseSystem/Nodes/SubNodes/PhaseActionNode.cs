public abstract class PhaseActionNode : PhaseBaseNode
{
    protected sealed override void TraverseNode()
    {
        ProcessFlow();
    }

    protected abstract void ProcessFlow();
}


//Serialed(main, hunt, minigame, minigame_cond(succcess, lose(hunt as ref))), end_cond(win, lose), finish)

//Serialed(main, hunt, minigame_cond(succcess, lose)), end_cond(win, lose), finish)