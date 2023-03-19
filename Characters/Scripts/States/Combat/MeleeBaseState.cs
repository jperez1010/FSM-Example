using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
    public float duration;
    protected bool shouldComboLight;
    protected bool shouldComboHeavy;
    protected int attackIndex;

    protected Animator animator;
    protected MeleeBaseState nextStateLight;
    protected MeleeBaseState nextStateHeavy;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (!shouldComboLight && !shouldComboHeavy && (Input.GetButtonDown("Fire1")) && nextStateLight != null)
        {
            shouldComboLight = true;
        }
        if (!shouldComboLight && !shouldComboHeavy && (Input.GetButtonDown("Fire2")) && nextStateHeavy != null)
        {
            shouldComboHeavy = true;
        }

        if (fixedTime >= duration)
        {
            if (shouldComboLight && nextStateLight != null)
            {
                stateMachine.SetNextState(nextStateLight);
            }
            else if (shouldComboHeavy && nextStateLight != null)
            {
                stateMachine.SetNextState(nextStateHeavy);
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}