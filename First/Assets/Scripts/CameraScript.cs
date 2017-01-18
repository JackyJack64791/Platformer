using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Vector2 _velocity;

    public float smoothTimeX;
    public float minCameraPosition;
    public float maxCameraPosition;

    public bool bounds;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref _velocity.x, smoothTimeX);

        var delta = Screen.currentResolution.width / 400;

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(posX + delta, minCameraPosition, maxCameraPosition), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(posX + delta, transform.position.y, transform.position.z);
        }

    }
}
