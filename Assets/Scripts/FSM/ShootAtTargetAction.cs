using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlugableAI/Actions/ShootAtTarget")]
public class ShootAtTargetAction : AIAction
{
    public override void Act(StateController controller)
    {
        ShootAtTarget(controller);
    }

    void ShootAtTarget(StateController controller)
    {
        //shoot at mainTarget in controller
    }

}
