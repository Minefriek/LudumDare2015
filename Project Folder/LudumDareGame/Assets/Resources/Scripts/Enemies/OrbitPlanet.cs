using UnityEngine;
using System.Collections;

public class OrbitPlanet : MonoBehaviour {

    GameObject planet;
	// Use this for initialization
	void Start ()
    {
        planet = GameObject.Find("Planet");
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.RotateAround(planet.transform.position, transform.forward, 1 * Time.deltaTime);
	
	}
}
