using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeState : CharacterState
{
    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnFixedUpdate() 
    {
        var vectorOnFloor = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        vectorOnFloor.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            m_stateMachine.Rigidbody.AddForce(vectorOnFloor * m_stateMachine.AccelerationValue, ForceMode.Acceleration);

        }
        if (Input.GetKey(KeyCode.S))
        {
            m_stateMachine.Rigidbody.AddForce(-vectorOnFloor * m_stateMachine.AccelerationValue, ForceMode.Acceleration);

        }
        if (m_stateMachine.Rigidbody.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.Rigidbody.velocity = m_stateMachine.Rigidbody.velocity.normalized;
            m_stateMachine.Rigidbody.velocity *= m_stateMachine.MaxVelocity;
        }
        Debug.Log(m_stateMachine.Rigidbody.velocity.magnitude);

        //TODO
        //Add movements in all directions
        //Have different max speeds on the sides and front/behind
        //When no input is being entered, make the character decelerate quickly
    }

    public override void OnUpdate()
    {

    }
}
