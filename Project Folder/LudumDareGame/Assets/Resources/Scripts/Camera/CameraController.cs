using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float speed;
    public float cameraZoom;
    public GameObject target;
    PlayerController pcScript;

	// Use this for initialization
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        pcScript = target.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, target.transform.position.y, cameraZoom), speed * Time.deltaTime);
        SetCameraZoom();
    }


    void SetCameraZoom()
    {
        cameraZoom = (-1 * (pcScript.transform.localScale.x / 0.2f));
    }

}
