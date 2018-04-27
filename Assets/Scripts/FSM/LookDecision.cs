using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlugableAI/Decisions/Look")]
public class LookDecision : Decision {

    public override bool Decide(StateController controller)
    {
       return ObjectOfInterestDected(controller);
    }

    bool ObjectOfInterestDected(StateController controller)
    {
        RaycastHit2D[] ObjectsInLookRadius = Physics2D.CircleCastAll(controller.transform.position, controller.detectionRadius, Vector2.zero, 0.0f, controller.targetMask);

        for (int i = 0; i < ObjectsInLookRadius.Length; i++)
        {
            Vector3 direction = ObjectsInLookRadius[i].transform.position - controller.transform.position;

            RaycastHit2D hit = Physics2D.Raycast(controller.transform.position, direction, float.MaxValue, controller.obsticleMask);

            if (hit)
            {
                controller.PrintToConsole("NO targets found");      //TODO remove when look functinos completed
                direction = ObjectsInLookRadius[i].transform.position - new Vector3 (hit.point.x, hit.point.y, 0.0f) ;
                controller.DrawRay(direction);
                return false;

            } else
            {
                controller.DrawRay(direction); //TODO remove when look functinos completed
                controller.PrintToConsole("Target: " + ObjectsInLookRadius[i].transform.name + " has been dected");
                return true;
            }
            
        }

        controller.PrintToConsole("NO targets found 2"); //TODO remove when look functinos completed
        return false;
    }
}
