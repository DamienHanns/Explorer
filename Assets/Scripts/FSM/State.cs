using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PlugableAI/State")]
public class State : ScriptableObject
{

    public AIAction[] actions;
    public Transition[] transitions;

    public Color stateIndicatorColour;

    public void ExecuteState(StateController controller)
    {
        PerformActions(controller);
        CheckTransitions(controller);
    }

    void PerformActions(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i] != null)
            {
                actions[i].Act(controller);
            }
            else
            {
                Debug.Log(controller.currentState.name + " Action: "  + i + " Initalized, but has no value assigned");
            }
        }
    }

    void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool bDecisionReturnsTrue = transitions[i].decision.Decide(controller);

            if (transitions[i] != null)
            {
                if (bDecisionReturnsTrue)
                {
                    controller.TransitionToState(transitions[i].trueState);
                }
                else
                {
                    controller.TransitionToState(transitions[i].falseState);
                }
            }
            else
            {
                Debug.Log(controller.currentState.name + " Transition: " + i + " Initalized, but has no value assigned");
            }
        }
    }
}