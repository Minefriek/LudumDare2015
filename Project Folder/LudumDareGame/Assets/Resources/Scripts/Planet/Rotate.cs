﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(transform.forward * (rotationSpeed * Time.deltaTime));
	
	}
}
