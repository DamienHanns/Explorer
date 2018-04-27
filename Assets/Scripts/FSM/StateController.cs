using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public LayerMask targetMask;
    public LayerMask obsticleMask;

    public State currentState;
    public State remainInState;
    [SerializeField] Transform stateIndicatorHolder;

    public float detectionRadius;

    bool bIsAIActive = true;

    public void SetupAI(bool bActivateAI)
    {
        bIsAIActive = bActivateAI;
        
    }

    private void Update()
    {
        if (!bIsAIActive) { return; }

        currentState.ExecuteState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && stateIndicatorHolder != null)
        {
            Gizmos.color = currentState.stateIndicatorColour;
            Gizmos.DrawSphere(stateIndicatorHolder.position, 0.1f);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }

    public void TransitionToState(State state)
    {

    }

    public void PrintToConsole(string stringToPrint)
    {
        print(stringToPrint);
    }
    public void DrawRay(Vector2 direction)
    {
        Debug.DrawRay(transform.position, direction, Color.red);
    }
}
