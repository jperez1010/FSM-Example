using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        attackIndex = 3;
        duration = 0.8f;
        animator.SetTrigger("Punch" + attackIndex);
        nextStateLight = null;
        Debug.Log("Player Attack " + attackIndex + " Fired!");
    }
}
