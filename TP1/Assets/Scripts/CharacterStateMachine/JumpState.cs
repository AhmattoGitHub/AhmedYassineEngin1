using UnityEngine;
public class JumpState : CharacterState
{
    private const float STATE_EXIT_TIMER = 0.2f;
    private float m_currentStateTimer = 0f;
    public override void OnEnter()
    {
        Debug.Log("Enter state: JumpState\n");

        m_stateMachine.Rigidbody.AddForce(Vector3.up * m_stateMachine.JumpIntensity, ForceMode.Acceleration);
        m_currentStateTimer = STATE_EXIT_TIMER;

        m_stateMachine.Animator.SetBool("IsJumping", true);
    }

    public override void OnExit()
    {
        Debug.Log("Exit state: JumpState\n");
        m_stateMachine.Animator.SetBool("IsJumping", false);
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        m_currentStateTimer -= Time.deltaTime;
    }

    public override bool CanEnter()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public override bool CanExit()
    {
        return m_currentStateTimer <= 0f;
    }
}
