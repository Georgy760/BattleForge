using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    public static PlayersManager playersManager;

    private void Awake()
    {
        if (playersManager == null)
        {
            playersManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
