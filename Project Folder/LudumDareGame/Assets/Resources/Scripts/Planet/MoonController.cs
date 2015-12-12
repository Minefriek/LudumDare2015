using UnityEngine;
using System.Collections;

public class MoonController : MonoBehaviour {

    Rigidbody thisRB;
    Vector3 oppositeDirection;

    // Use this for initialization
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody>();

        float tempScale = Random.Range(0.1f, 0.5f);
        this.transform.localScale = new Vector3(tempScale, tempScale, tempScale);

        thisRB.mass = (thisRB.mass * 3) * tempScale;


    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerStay(Collider ObjectWhoseTriggersBeenEntered)
    {
        if (ObjectWhoseTriggersBeenEntered.tag == "Player")
        {
            Rigidbody playerRB = ObjectWhoseTriggersBeenEntered.GetComponent<Rigidbody>();

            float gravity = playerRB.mass;

            float islDenominator = (Mathf.Pow(Vector3.Distance(ObjectWhoseTriggersBeenEntered.gameObject.transform.position, this.transform.position), 2f)); // finds the denominator for the inverse square law formula

            Vector3 force = (ObjectWhoseTriggersBeenEntered.gameObject.transform.position - transform.position) * gravity;
            thisRB.AddForce((force / islDenominator) * Time.deltaTime);
        }
        else
        if (thisRB.velocity.magnitude > 0.5f)
        {
            thisRB.AddForce((oppositeDirection.normalized * (thisRB.mass * 100f)) * Time.deltaTime);
        }
    }
}
