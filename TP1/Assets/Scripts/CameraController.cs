using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_objectToLookAt;
    [SerializeField]
    private float m_rotationSpeed = 1.0f;
    [SerializeField]
    private Vector2 m_clampingXRotationValues = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        UpdateHorizontalMovements();
        UpdateVerticalMovements();
        UpdateCameraScroll();
    }

    private void FixedUpdate()
    {
        MoveCameraInFrontOfObstructionFixedUpdate();
    }

    private void UpdateHorizontalMovements()
    {
        float currentAngleX = Input.GetAxis("Mouse X") * m_rotationSpeed;
        transform.RotateAround(m_objectToLookAt.position, m_objectToLookAt.up, currentAngleX);
    }

    private void UpdateVerticalMovements()
    {
        float currentAngleY = Input.GetAxis("Mouse Y") * m_rotationSpeed;
        float eulersAngleX = transform.rotation.eulerAngles.x;

        float comparisonAngle = eulersAngleX + currentAngleY;

        comparisonAngle = ClampAngle(comparisonAngle);

        if ((currentAngleY < 0 && comparisonAngle < m_clampingXRotationValues.x)
            || (currentAngleY > 0 && comparisonAngle > m_clampingXRotationValues.y))
        {
            return;
        }
        transform.RotateAround(m_objectToLookAt.position, transform.right, currentAngleY);
    }

    private void UpdateCameraScroll()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            //TODO: Faire une v�rification selon la distance la plus proche ou la plus �loign�e
            //Que je souhaite entre ma cam�ra et mon objet

            //TODO: Lerp plut�t que d'effectuer imm�diatement la translation
            transform.Translate(Vector3.forward * Input.mouseScrollDelta.y, Space.Self);
        }
    }

    private void MoveCameraInFrontOfObstructionFixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        RaycastHit hit;

        var vectorDiff = transform.position - m_objectToLookAt.position;
        var distance = vectorDiff.magnitude;
        if (Physics.Raycast(m_objectToLookAt.position, vectorDiff, out hit, distance, layerMask))
        {
            Debug.DrawRay(m_objectToLookAt.position, vectorDiff.normalized * hit.distance, Color.yellow);
            transform.SetPositionAndRotation(hit.point,transform.rotation);
        }
        else
        {
            Debug.DrawRay(m_objectToLookAt.position, vectorDiff, Color.white);
        }
    }
    private float ClampAngle(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }
}
