using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettinUpState : CharacterState
{
    private float m_getUpTimer = 1f;
    public override void OnEnter()
    {

    }

    public override void OnExit()
    {
        m_stateMachine.m_isGettingUp = false;
        m_stateMachine.Animator.SetBool("CanGetUp", false);
        m_getUpTimer = 1f;
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        m_getUpTimer -= Time.deltaTime;
    }

    public override bool CanEnter()
    {
        return m_stateMachine.m_isGettingUp;
    }

    public override bool CanExit()
    {
        return m_getUpTimer <= 0f;
    }
}
