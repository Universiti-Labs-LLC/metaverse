using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePie : MonoBehaviour {

public float speed;
    // Use this for initialization
    private void Start()
    {
        speed = 3.5f;
    }

    private void OnMouseDrag() {
		float rotX=Input.GetAxis("Mouse X")*speed*Mathf.Deg2Rad;
		transform.RotateAround(Vector3.up,-rotX);
	}

}
