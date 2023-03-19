using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateMachineType stateMachineType;
    private State mainState;
    public State currentState { get; private set; }
    private State nextState;


    void Update()
    {
        if (nextState != null)
        {
            SetState(nextState);
        }

        if (currentState != null)
        {
            currentState.OnUpdate();
        }

    }
    public void FixedUpdate()
    {
        if (currentState != null)
            currentState.OnFixedUpdate();
    }
    public void LateUpdate()
    {
        if (currentState != null)
            currentState.OnLateUpdate();
    }


    private void SetState(State _newState)
    {
        nextState = null;
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = _newState;
        currentState.OnEnter(this);
    }
    public void SetNextState(State _newState)
    {
        if (_newState != null)
        {
            nextState = _newState;
        }
    }
    public void SetNextStateToMain()
    {
        nextState = mainState;
    }

    
    private void Awake()
    {
        SetNextStateToMain();
    }
    private void OnValidate()
    {
        if (mainState == null)
        {
            if (stateMachineType == StateMachineType.PLAYER)
            {
                mainState = new IdleState();
            }
        }
    }
}

public enum StateMachineType { PLAYER };