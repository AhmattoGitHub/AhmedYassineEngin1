using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : CharacterState
{
    private float m_hitTimer = 0.5f;
    public override void OnEnter()
    {
        Debug.Log("Enter state: HitState\n");
        m_stateMachine.Animator.SetBool("IsHit", true);
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: HitState\n");
        m_stateMachine.Animator.SetBool("IsHit", false);
        m_stateMachine.m_isOnFloor = true;
        m_hitTimer = 0.5f;
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        m_hitTimer -= Time.deltaTime;
    }

    public override bool CanEnter()
    {
        return m_stateMachine.m_isHit;
    }

    public override bool CanExit()
    {
        return m_hitTimer <= 0;
    }
}
