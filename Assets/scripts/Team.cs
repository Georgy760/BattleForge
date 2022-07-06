using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Team : MonoBehaviour
{
    public string teamName;
    public enum teamColor
    {
        Red,
        Blue
    }

    public bool CompareTeam(string teamName)
    {
        if (this.teamName == teamName) 
            return true;
        return false;
    }
}
