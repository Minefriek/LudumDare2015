using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

    Rigidbody thisRB;
	// Use this for initialization
	void Start ()
    {
        thisRB = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider ObjectWhoseTriggersBeenEntered)
    {
        if(ObjectWhoseTriggersBeenEntered.tag == "Player")
        {
            Rigidbody playerRB = ObjectWhoseTriggersBeenEntered.GetComponent<Rigidbody>();

            float gravity = playerRB.mass;

            float islDenominator = (Mathf.Pow(Vector3.Distance(ObjectWhoseTriggersBeenEntered.gameObject.transform.position, this.transform.position), 2f)); // finds the denominator for the inverse square law formula

            Vector3 force = (ObjectWhoseTriggersBeenEntered.gameObject.transform.position - transform.position) * gravity;
            thisRB.AddForce((force / islDenominator) * Time.deltaTime);
            Debug.DrawRay(transform.position, force, Color.green);
        }
        else
        {

        }
    }
}
