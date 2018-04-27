using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlugableAI/Action/LookAction")]
public class LookAction : AIAction {

    public override void Act(StateController controller)
    {
        Look(controller);
    }

    void Look(StateController controller)
    {
        controller.PrintToConsole("Looking for targets");
        //Look from targets
    }   
}
