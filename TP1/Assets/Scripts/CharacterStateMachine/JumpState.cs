using UnityEngine;
public class JumpState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("Enter state: JumpState\n");

        m_stateMachine.Rigidbody.AddForce(Vector3.up * m_stateMachine.JumpIntensity, ForceMode.Acceleration);
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: JumpState\n");
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {

    }

    public override bool CanEnter()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public override bool CanExit()
    {
        return true;
    }
}
