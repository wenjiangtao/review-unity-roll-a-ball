﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{

    public Transform player;
    
    private Vector3 _offset;

	void Start() 
    {
	    _offset = transform.position - player.transform.position;
	}
	
	void LateUpdate() 
    {
	    transform.position = player.transform.position + _offset;
	}
}
