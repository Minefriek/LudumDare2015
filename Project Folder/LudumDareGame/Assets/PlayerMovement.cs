using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    Rigidbody thisRB;
    Vector3 mousePosition;
	// Use this for initialization
	void Start ()
    {
        thisRB = this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        this.transform.LookAt(new Vector3(mousePosition.x,mousePosition.y,0.0f));

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Hi!");
            thisRB.AddForce(transform.forward * 100f);
        } 
	}
}
