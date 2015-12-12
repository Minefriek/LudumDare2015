using UnityEngine;
using System.Collections;

public class MissileBehaviour : MonoBehaviour {

    public float speed;
    public float rotationSpeed;
    public float lifeSpan;

    GameObject target;
    Rigidbody thisRB;
    Vector3 direction;
    float distance;
    public float lifeTimer;
	// Use this for initialization
	void Start ()
    {
        lifeTimer = lifeSpan;
        target = GameObject.FindWithTag("Player");
        thisRB = this.GetComponent<Rigidbody>();
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        lifeTimer -= Time.deltaTime;

        
        if(target != null)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        distance = Vector3.Distance(this.transform.position, target.transform.position);
        direction = (target.transform.position - this.transform.position) / distance;

        Quaternion tempRotation = Quaternion.LookRotation(target.transform.position - transform.position); ;
        
        transform.rotation = Quaternion.Lerp(this.transform.rotation, tempRotation, Time.deltaTime * rotationSpeed);

        if (thisRB.velocity.magnitude < 200)
        {
            thisRB.AddForce(this.transform.forward * (speed * Time.deltaTime));
        } 
    }
}
