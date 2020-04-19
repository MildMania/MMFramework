using System.Collections.Generic;
using UnityEngine;

public class DefaultSceneScript : SceneController
{
    protected override void Start()
    {
        base.Start();

        PhaseController.PhaseFlowController.AppendPhase(new List<PhaseBase>() { new TempPhase_01(), new TempPhase_02() });

        StartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            TryActivateNextSubState();
    }
}
