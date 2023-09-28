using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackingState : CharacterState
{
    private float m_attackTimer = 0.1f;
    public override bool CanEnter()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override bool CanExit()
    {
        return m_attackTimer <= 0f;
    }

    public override void OnEnter()
    {
        Debug.Log("Enter state: Attacking");
        m_stateMachine.Animator.SetBool("IsAttacking", true);
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: Attacking");
        m_attackTimer = 1f;
        m_stateMachine.Animator.SetBool("IsAttacking", false);
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        m_attackTimer -= Time.deltaTime;
    }
}
