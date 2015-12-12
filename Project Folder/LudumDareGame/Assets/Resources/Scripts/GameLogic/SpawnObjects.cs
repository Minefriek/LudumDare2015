using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public GameObject[] neutral;
    public GameObject[] enemy;

    GameObject planet;
    float sphereSize = 10;
    float limits;
    bool spawned;

    void OnLevelWasLoaded(int LevelID)
    {
        if (LevelID == 1)
        {
            planet = GameObject.Find("Planet");
            limits = sphereSize - 1;
        }
    }
	
	// Update is called once per frame
	void Update () 
    {

    }

}
