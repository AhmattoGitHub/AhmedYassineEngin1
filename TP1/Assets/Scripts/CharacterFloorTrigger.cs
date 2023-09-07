using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFloorTrigger : MonoBehaviour
{
    public bool IsOnFloor { get; private set; }

    private void Awake()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(!IsOnFloor)
        {
            Debug.Log("Started touching floor");
        }
        IsOnFloor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Started leaving floor");
        IsOnFloor = false;
    }
}
