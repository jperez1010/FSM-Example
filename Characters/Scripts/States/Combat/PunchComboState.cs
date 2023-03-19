using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchComboState : MeleeBaseState
{

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        attackIndex = 2;
        duration = 0.5f;
        animator.SetTrigger("Punch" + attackIndex);
        nextStateLight = new PunchFinisherState();
        Debug.Log("Player Attack " + attackIndex + " Fired!");
    }
}
