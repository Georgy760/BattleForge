using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LookAtCam : MonoBehaviour
{  
    [Inject]
    public Transform cam;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
