﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    //This script makes the camera follow the player

    private GameObject player;
    private Player playerScript;
    [SerializeField]
    private float time = 1f;

	void Start ()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }	

	void FixedUpdate () {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z + 2f);
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (playerScript.livesGetter() > 0)
        {
            //Smoothly follow the player around
            transform.position = Vector3.Lerp(transform.position, newPos, time * Time.fixedDeltaTime);
        }
    }
}