using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCompetenceCast : InputEventController
{
    public override void ReleaseControl()
    {
        inputControllerManager.ControllerReleaseMaster(this);
    }

    public override void TakeControl()
    {
        inputControllerManager.NewControllerIsMaster(this);
    }
}
