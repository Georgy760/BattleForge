using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Joystick joystick;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            
            player.position = new Vector3(joystick.Horizontal/10 + transform.position.x, player.transform.position.y,
                joystick.Vertical/10 + transform.position.z);
            transform.LookAt(new Vector3(player.position.x, 0, player.position.z));
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        
    }

    private void FixedUpdate()
    {
        
    }
    
}
