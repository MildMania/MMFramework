public class DefaultFlowController : PhaseFlowController
{
    protected override PhaseBaseNode CreateRootNode()
    {
        HuntPhase huntPhase = new HuntPhase();

        return new PhaseSerialComposition
        (
            new InitialPhase(), // Drone waits, main menu opens up, character enters to the scene and count down starts
            huntPhase, // Gameplay starts
            new HuntCatchPhase // Mini game
            (
                new PhaseSerialComposition // 1 of 2 mini game result
                (
                    new CatchSuccessPhase(), // Catch success, catch result pop up appears, game freezes, character dances etc
                    new LevelEndPhase // Checks whether game should finish or not
                    (
                        new LevelWinPhase(), // Game finish success, char makes another dance, dragon eats apple, level end success UI, success music plays
                        new LevelFailPhase(), // Game finish fail, char makes sad dance, dragon kills us, level end fail UI, fail music plays
                        new GotoHuntPhase(huntPhase) // game is not ready to finish (ie. not all bugs are catched, not all objecives are completed etc)
                    )
                ),
                new PhaseSerialComposition // other mini game result
                (
                    new CatchFailPhase(), // char fails to catch, or gets away from bug
                    new GotoHuntPhase(huntPhase) // returns to hunt phase
                )
            )
        );
    }
}
