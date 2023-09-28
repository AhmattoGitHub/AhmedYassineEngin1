using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_objectToLookAt;
    [SerializeField]
    private float m_rotationSpeedX = 1.0f;
    [SerializeField]
    private float m_rotationSpeedY = 1.0f;
    [SerializeField]
    private Vector2 m_clampingXRotationValues = Vector2.zero;
    [SerializeField]
    private float m_maxCameraDistance = 10.0f;
    [SerializeField]
    private float m_minCameraDistance = 3.0f;

    private void Start()
    {

    }

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
        float currentAngleX = Input.GetAxis("Mouse X") * m_rotationSpeedX;
        transform.RotateAround(m_objectToLookAt.position, m_objectToLookAt.up, currentAngleX);

        m_objectToLookAt.transform.Rotate(m_objectToLookAt.up, transform.localEulerAngles.y);
    }

    private void UpdateVerticalMovements()
    {
        float currentAngleY = Input.GetAxis("Mouse Y") * m_rotationSpeedY;
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
            if (CalculateDistance(transform.position, m_objectToLookAt.position) < m_maxCameraDistance
                && CalculateDistance(transform.position, m_objectToLookAt.position) > m_minCameraDistance)
            {
                //TODO: Lerp plutôt que d'effectuer immédiatement la translation
                transform.Translate(Vector3.forward * Input.mouseScrollDelta.y, Space.Self);
            }
            else
            {
                ClampPosition();
            }
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

    private float CalculateDistance(Vector3 playerPosition, Vector3 cameraPosition)
    {
        float xDiff = cameraPosition.x - playerPosition.x;
        float yDiff = cameraPosition.y - playerPosition.y;
        float zDiff = cameraPosition.z - playerPosition.z;

        float distance = Mathf.Sqrt(Mathf.Pow(xDiff,2) + Mathf.Pow(yDiff,2) + Mathf.Pow(zDiff,2));

        return distance;
    }

    private void ClampPosition()
    {
        if (CalculateDistance(transform.position, m_objectToLookAt.position) >= m_maxCameraDistance)
        {
            transform.Translate(Vector3.forward);
        }
        else if(CalculateDistance(transform.position, m_objectToLookAt.position) <= m_minCameraDistance)
        {
            transform.Translate(Vector3.back);
        }
    }
}
