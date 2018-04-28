using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlugableAI/Decisions/IsTargetActive")]
public class IsTargetActiveDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool bIsTargetActive;

        if (controller.mainTarget == null) { bIsTargetActive = false; }
        else { bIsTargetActive = controller.mainTarget.gameObject.activeSelf; }

        return bIsTargetActive;
    }
}
