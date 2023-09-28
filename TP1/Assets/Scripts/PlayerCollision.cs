using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CharacterControllerStateMachine m_characterControllerScript;
    private const float RECOIL_FORCE = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_characterControllerScript.m_isHit = true;
            Debug.Log("Player is hit!");
            m_characterControllerScript.Rigidbody.AddForce(Vector3.back * RECOIL_FORCE, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_characterControllerScript.m_isHit = false;
        }
    }
}
