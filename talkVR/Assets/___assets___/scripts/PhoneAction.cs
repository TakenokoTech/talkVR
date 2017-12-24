using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneAction : MonoBehaviour {

	public GameObject head;
	public HoldingScript holdingScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if( (holdingScript.GetHoldingObj() != null) && (0 <= Array.IndexOf(holdingScript.GetHoldingObj(), "phone")))
		{
			Debug.Log(holdingScript.GetHoldingObj()[0]);
			transform.LookAt(head.transform.position);
		}
	}
}
