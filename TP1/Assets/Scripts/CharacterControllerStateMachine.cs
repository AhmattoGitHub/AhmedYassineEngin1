using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerStateMachine : MonoBehaviour
{
    public Camera Camera { get; private set; }

    [field:SerializeField]
    public Rigidbody Rigidbody { get; private set; }

    [field: SerializeField]
    public Animator Animator { get; private set; }

    [field:SerializeField]
    public float AccelerationValue { get; private set; }
    [field:SerializeField]
    public float MaxVelocity {  get; private set; }

    [SerializeField]
    private CharacterFloorTrigger m_floorTrigger;
    private CharacterState m_currentState;
    private List<CharacterState> m_possibleStates;
    [field:SerializeField]
    public float JumpIntensity { get; private set; }

    private void Awake()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new FreeState());
        m_possibleStates.Add(new JumpState());
        m_possibleStates.Add(new AttackingState());
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;

        foreach (CharacterState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();
    }

    // Update is called once per frame
    void Update()
    {
        m_currentState.OnUpdate();

        TryStateTransition();
    }

    private void FixedUpdate()
    {
        m_currentState.OnFixedUpdate();
    }

    private void TryStateTransition()
    {
        if (!m_currentState.CanExit())
        {
            return;
        }

        foreach (var state in m_possibleStates)
        {
            if (m_currentState == state)
            {
                continue;
            }

            if (state.CanEnter())
            {
                m_currentState.OnExit();
                m_currentState = state;
                m_currentState.OnEnter();
                return;
            }
        }
    }

    public bool IsInContactWithFloor()
    {
        return m_floorTrigger.IsOnFloor;
    }

    public void UpdateFreeStateAnimatorValues(Vector2 movementVecValue)
    {
        //Get current speed
        //Communicate with animator

        movementVecValue.Normalize();
        Animator.SetFloat("MoveX",movementVecValue.x);
        Animator.SetFloat("Move Y", movementVecValue.y);
    }
}
