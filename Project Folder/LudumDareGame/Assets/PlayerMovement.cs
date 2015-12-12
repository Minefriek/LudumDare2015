using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    Rigidbody thisRB;
    Vector3 mousePosition;
	// Use this for initialization
	void Start ()
    {
        thisRB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.LookAt(new Vector3(mousePosition.x,mousePosition.y,0.0f));

        if (Input.GetButton("Jump"))
        {
            thisRB.AddForce(transform.forward * 100f);
        } 
	}
}
