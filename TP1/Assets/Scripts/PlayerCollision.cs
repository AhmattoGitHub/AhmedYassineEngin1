using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public CharacterControllerStateMachine m_characterControllerScript;
    private float m_recoilForce = 5f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_characterControllerScript.m_isHit = true;
            Debug.Log("Player is hit!");
            m_characterControllerScript.Rigidbody.AddForce(Vector3.back * m_recoilForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_characterControllerScript.m_isHit = false;
            Debug.Log("Player is hit!");
            m_characterControllerScript.Rigidbody.AddForce(Vector3.back * m_recoilForce, ForceMode.Impulse);
        }
    }
}
