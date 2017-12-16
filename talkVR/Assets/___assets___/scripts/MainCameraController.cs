using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MainCameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 basePos = Vector3.zero;
        Vector3 trackingPos = InputTracking.GetLocalPosition(XRNode.CenterEye);
        transform.position = basePos - trackingPos;
    }
}
