using UnityEngine;
using System.Collections;

public class MissileLauncherController : MonoBehaviour
{

    public GameObject attack;
    public float fireRate;
    public float range;

    GameObject launcherRight;
    GameObject launcherLeft;

    public float attackTimer;

    bool rightFired = false;
    // Use this for initialization
    void Start()
    {
        attackTimer = fireRate;

        launcherRight = this.transform.GetChild(1).gameObject;
        launcherLeft = this.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider ObjectEnteringTrigger)
    {
        if (ObjectEnteringTrigger.tag == "Player" && Vector3.Distance(this.transform.position, ObjectEnteringTrigger.gameObject.transform.position) <= range)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                if (rightFired == false)
                {
                    GameObject missile = (GameObject)Instantiate(attack, launcherRight.transform.position, Quaternion.identity);
                    attackTimer = fireRate;
                    rightFired = true;
                }
                else
                {
                    GameObject missile = (GameObject)Instantiate(attack, launcherLeft.transform.position, Quaternion.identity);
                    attackTimer = fireRate;
                    rightFired = false;
                }
            }
        }
        else
        if(ObjectEnteringTrigger.tag == "Player" && Vector3.Distance(this.transform.position, ObjectEnteringTrigger.gameObject.transform.position) > range)
        {
            attackTimer = fireRate;
        }
    }

    void OnTriggerExit(Collider ObjectExitingTrigger)
    {
        if (ObjectExitingTrigger.tag == "Player")
        {
            attackTimer = fireRate;
        }
    }
}
