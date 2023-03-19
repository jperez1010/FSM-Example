using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
    State previousState;
    State currentState;
    public int punchTime = 100;
    public int punch2Time = 100;
    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        previousState = currentState;
        if (previousState == State.Idle || previousState == State.Walking)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (previousState == State.Punch)
                {
                    GetComponent<PlayerAttack>().Punch();
                }
                else if (currentState != State.Punch2)
                {
                    currentState = State.Punch;
                    counter = punchTime;
                }
            }
            else if (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized != Vector3.zero)
            {
                currentState = State.Walking;
            }
            else
            {
                currentState = State.Idle;
            }
        }

        if (currentState == State.Punch || currentState == State.Punch2) {
            counter -= 1;
            if (counter <= 0)
            {
                currentState = State.Idle;
            }
        }
        PerformAction();
    }

    void PerformAction() {
        switch (currentState)
        {
            case State.Walking:
                GetComponent<PlayerMovement>().MovePlayer();
                break;
            case State.Punch:
                if (counter == punchTime - 1)
                {
                    GetComponent<PlayerAttack>().Punch();
                }
                break;
            case State.Punch2:
                if (counter >= punchTime + punch2Time - 1)
                {
                    GetComponent<PlayerAttack>().Punch2();
                }
                break;
            default:
                break;
        }
    }
}