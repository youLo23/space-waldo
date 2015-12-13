using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    private float tileSizeZ;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        Debug.Log("transform.lossyScale.z : " + transform.lossyScale.z);
        startPosition = transform.position;
        tileSizeZ = transform.lossyScale.y;
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
