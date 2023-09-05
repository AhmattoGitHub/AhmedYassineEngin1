using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : IState
{
    protected CharacterControllerStateMachine m_stateMachine;

    public void OnStart(CharacterControllerStateMachine stateMachine)
    {
        m_stateMachine = stateMachine;
    }
    public virtual void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
