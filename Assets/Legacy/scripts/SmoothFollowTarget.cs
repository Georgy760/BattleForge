using System;
using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    bool b;

    private void Awake(){
        if (target)
        {
            Debug.Log("Awake:" + target.name);
        } else Debug.Log("Awake:" + null);
    }

    private void Start()
    {
        if (target)
        {
            Debug.Log("Start:" + target.name);
        } else Debug.Log("Start:" + null);
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        else
        {
            if (!b)
            {
                offset = transform.position - target.transform.position;
                b = true;
            }

            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * 5);
            return;
        }
    }
}