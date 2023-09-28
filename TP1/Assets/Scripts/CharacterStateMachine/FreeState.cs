using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FreeState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("Enter state: FreeState\n");
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: FreeState\n");
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
        if (Input.GetKey(KeyCode.D))
        {
            m_stateMachine.Rigidbody.AddRelativeForce(new Vector3(1,0,0) * m_stateMachine.AccelerationValue, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.A))
        {
            m_stateMachine.Rigidbody.AddRelativeForce(new Vector3(-1, 0, 0) * m_stateMachine.AccelerationValue, ForceMode.Acceleration);
        }
        if (m_stateMachine.Rigidbody.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.Rigidbody.velocity = m_stateMachine.Rigidbody.velocity.normalized;
            m_stateMachine.Rigidbody.velocity *= m_stateMachine.MaxVelocity;
        }

        float forwardComponent = Vector3.Dot(m_stateMachine.Rigidbody.velocity, vectorOnFloor);
        float horizontalComponent = m_stateMachine.Rigidbody.velocity.x;
        m_stateMachine.UpdateAnimatorValues(new Vector2(horizontalComponent, forwardComponent));
        //TODO
        //Add movements in all directions
        //Have different max speeds on the sides and front/behind
        //When no input is being entered, make the character decelerate quickly
    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter()
    {
        return m_stateMachine.IsInContactWithFloor();    
    }

    public override bool CanExit()
    {
        return true;
    }
}
