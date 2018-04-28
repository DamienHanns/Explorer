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
            Vector2 direction = (ObjectsInLookRadius[i].transform.position - controller.transform.position);
            float distanceToObject = Vector2.Distance(controller.transform.position, ObjectsInLookRadius[i].transform.position);
            
            if (Physics2D.Raycast(controller.transform.position, direction, distanceToObject, controller.obsticleMask))
            {
                controller.PrintToConsole("Target: " + ObjectsInLookRadius[i].transform.name + " BLOCKED by obsticle");      //TODO remove when look functinos completed
                return false;

            } else
            {
                controller.PrintToConsole("Target: " + ObjectsInLookRadius[i].transform.name + " has been dected");
                controller.mainTarget = ObjectsInLookRadius[i].transform;
                return true;
            }
        } 

        
        controller.PrintToConsole("NO targets found 2"); //TODO remove when look functinos completed
        return false;
    }
}
