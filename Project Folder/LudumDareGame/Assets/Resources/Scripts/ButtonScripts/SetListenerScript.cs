using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetListenerScript : MonoBehaviour {

    public string ManagerFunctionName;
    public GameObject manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("_MANAGER");
    }

    public void DoActionFromManager()
    {
        manager.SendMessage(ManagerFunctionName);
    }
}
