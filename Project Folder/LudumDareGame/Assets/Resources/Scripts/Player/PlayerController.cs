using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float playerMass;

    public float brakingPower;

    Rigidbody thisRB;
    Vector3 mousePosition;
    Vector3 oppositeDirection;
    Vector3 newScale;
    TrailRenderer thisTR;
    
    // Use this for initialization
    void Start()
    {
        thisRB = this.GetComponent<Rigidbody>();
        playerMass = thisRB.mass;
        newScale = this.transform.localScale;
        thisTR = this.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        SetScale();
    }

    void MovePlayer()
    {
        mousePosition = GetWorldPositionOnPlane(1f);
        oppositeDirection = -thisRB.velocity;

        this.transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, 0.0f));

        if (Input.GetButton("Jump"))
        {
            if (thisRB.velocity.magnitude < 50f)
            {
                thisRB.AddForce(transform.forward * (thisRB.mass*5.0f));
            }
        }
        else
        if (thisRB.velocity.magnitude > 0.5f)
        {
            thisRB.AddForce((oppositeDirection.normalized * (thisRB.mass * 100f)) * Time.deltaTime);
        }
    }

    void SetMass()
    {
        thisRB.mass = playerMass;
    }

    void GetNewScale(float objectMass)
    {
        newScale += new Vector3(objectMass/150, objectMass / 150, objectMass / 150);
    }

    void SetScale()
    {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, newScale, 5f*Time.deltaTime);
    }

    public Vector3 GetWorldPositionOnPlane(float z)
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(raycast, out distance);
        return raycast.GetPoint(distance);
    }

    void SetTrailRendererScale()
    {
        thisTR.startWidth = this.transform.localScale.x / 3;
        thisTR.endWidth = this.transform.localScale.x / 120;
    }

    void OnCollisionEnter(Collision ObjectCollidingWith)
    {
        if(ObjectCollidingWith.gameObject.tag == "Absorbable")
        {
            if(ObjectCollidingWith.gameObject.GetComponent<Rigidbody>())
            {
                if (ObjectCollidingWith.gameObject.GetComponent<Rigidbody>().mass < playerMass)
                {
                    playerMass += (ObjectCollidingWith.gameObject.GetComponent<Rigidbody>().mass/1.5f);
                    SetMass();
                    GetNewScale(ObjectCollidingWith.gameObject.GetComponent<Rigidbody>().mass);
                    SetTrailRendererScale();
                    Destroy(ObjectCollidingWith.gameObject);
                }
            }
        }
    }

    public void ReduceScale(float objectMass)
    {
        newScale -= new Vector3(objectMass/150, objectMass/150, objectMass/150);
        thisRB.mass = playerMass;
    }
}

