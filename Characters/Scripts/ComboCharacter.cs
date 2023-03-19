using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine meleeStateMachine;

    [SerializeField] public Collider hitbox;

    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && meleeStateMachine.currentState.GetType() == typeof(IdleState))
        {
            meleeStateMachine.SetNextState(new MeleeEntryState());
        }
    }
}
