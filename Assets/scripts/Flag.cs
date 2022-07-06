using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Team), typeof(Collider))]
public class Flag : MonoBehaviour
{
    [SerializeField] private Transform FlagBase;
    private void Start()
    {
        
    }

    public void ReturnFlag()
    {
        transform.SetParent(FlagBase, true);
        transform.localPosition = Vector3.zero;
    }
}
