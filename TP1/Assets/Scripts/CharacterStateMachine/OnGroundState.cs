using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundState : CharacterState
{
    private  float m_getUpTimer = 2.0f;
    public override void OnEnter()
    {

    }

    public override void OnExit()
    {
        m_stateMachine.Animator.SetBool("CanGetUp", true);
        m_stateMachine.m_isOnFloor = false;
        m_stateMachine.m_isGettingUp = true;
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
        return m_stateMachine.m_isOnFloor;
    }

    public override bool CanExit()
    {
        return m_getUpTimer <= 0;
    }
}
