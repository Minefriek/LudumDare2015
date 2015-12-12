using UnityEngine;
using System.Collections;

public class MissileLauncherController : MonoBehaviour
{

    public GameObject attack;
    public float fireRate;
    public float range;

    GameObject launcherRight;
    GameObject launcherLeft;

    public float rightAttackTimer;
    public float leftAttackTimer;
    // Use this for initialization
    void Start()
    {
        rightAttackTimer = fireRate;
        leftAttackTimer = fireRate * 2.0f;

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
            Debug.Log(ObjectEnteringTrigger.name);
            rightAttackTimer -= Time.deltaTime;
            leftAttackTimer -= Time.deltaTime;

            if (rightAttackTimer <= 0)
            {
                GameObject missile = (GameObject)Instantiate(attack, launcherRight.transform.position, Quaternion.identity);
                rightAttackTimer = fireRate;
            }

            if (leftAttackTimer <= 0)
            {
                GameObject missile = (GameObject)Instantiate(attack, launcherLeft.transform.position, Quaternion.identity);
                leftAttackTimer = fireRate * 2.0f;
            }
        }
        else
        if(ObjectEnteringTrigger.tag == "Player" && Vector3.Distance(this.transform.position, ObjectEnteringTrigger.gameObject.transform.position) > range)
        {
            rightAttackTimer = fireRate;
            leftAttackTimer = fireRate * 2.0f;
        }
    }

    void OnTriggerExit(Collider ObjectExitingTrigger)
    {
        if (ObjectExitingTrigger.tag == "Player")
        {
            rightAttackTimer = fireRate;
            leftAttackTimer = fireRate * 2.0f;
        }
    }
}
