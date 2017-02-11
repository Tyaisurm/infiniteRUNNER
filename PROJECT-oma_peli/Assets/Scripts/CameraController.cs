using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject pelaaja;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - pelaaja.transform.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = pelaaja.transform.position + offset;
	
	}
}
