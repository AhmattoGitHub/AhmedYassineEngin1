using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : CharacterState
{
    CharacterFloorTrigger m_floorTrigger;
    public override void OnEnter()
    {
        m_stateMachine.Animator.SetBool("IsJumping", true);
    }

    public override void OnExit()
    {
        m_stateMachine.Animator.SetBool("IsJumping", false);
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter()
    {
        return !m_floorTrigger.IsOnFloor;
    }

    public override bool CanExit()
    {
        return m_floorTrigger.IsOnFloor;
    }
}
