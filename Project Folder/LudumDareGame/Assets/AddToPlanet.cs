using UnityEngine;
using System.Collections;

public class AddToPlanet : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.transform.parent = GameObject.Find("Planet").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
