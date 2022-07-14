using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform takenFlag;
    [SerializeField] private Team team;
    //[SerializeField] private PlayerStats playerStats;
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Flag") && !takenFlag && !other.gameObject.GetComponent<Team>().CompareTeam(team.teamName))
        {
            var flag = other.transform;
            flag.SetParent(transform, true);
            takenFlag = flag;
            takenFlag.localPosition = Vector3.zero;
            //takenFlag.position = new Vector3(0,0, -0.5f);
            Debug.Log("TakenFlag pos: " + takenFlag.position);
        }

        if (other.gameObject.CompareTag("FlagPlacement") && takenFlag && other.gameObject.GetComponent<Team>().CompareTeam(team.teamName))
        {
            takenFlag.GetComponent<Flag>().ReturnFlag();
            takenFlag = null;
        }
    }
    
}
