using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettinUpState : CharacterState
{
    public override void OnEnter()
    {
        m_stateMachine.m_isGettingUp = false;
    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter()
    {
        return m_stateMachine.m_isGettingUp;
    }

    public override bool CanExit()
    {
        return !m_stateMachine.m_isGettingUp;
    }
}
