﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HoldingScript : MonoBehaviour {

    public ColliderScript colliderToLeftHand;
    public ColliderScript colliderToRightHand;

    public GameObject debugBlock1;
    public GameObject debugBlock2;

    private Transform haveItemInLeftHand = null;
    private Transform haveItemInRightHand = null;

    private string holdingRightHandStr = null;
    private string holdingLeftHandStr = null;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 人差し指・中指トリガー
        float rTrigger1 = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        float rTrigger2 = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        if (haveItemInRightHand != null && rTrigger1 < 0.8)
        {
            Debug.Log("右手Release " + haveItemInRightHand);
            HandScript.Release(ref haveItemInRightHand, ref colliderToRightHand);
            holdingRightHandStr = null;
        }
        else if ((colliderToRightHand.GetColliderObj() != null) && rTrigger1 >= 0.8)
        {
            Debug.Log("右手Hold " + haveItemInRightHand);
            HandScript.Hold(ref haveItemInRightHand, ref colliderToRightHand, ref debugBlock1);
            holdingRightHandStr = haveItemInRightHand.name;
        }

        // 人差し指・中指トリガー
        float lTrigger1 = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float lTrigger2 = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger);
        if (haveItemInLeftHand != null && lTrigger1 < 0.8)
        {
            Debug.Log("左手Release " + haveItemInLeftHand);
            HandScript.Release(ref haveItemInLeftHand, ref colliderToLeftHand);
            holdingLeftHandStr = null;
        }
        else if ((colliderToLeftHand.GetColliderObj() != null) && lTrigger1 >= 0.8)
        {
            Debug.Log("左手Hold " + haveItemInLeftHand);
            HandScript.Hold(ref haveItemInLeftHand, ref colliderToLeftHand, ref debugBlock1);
            holdingLeftHandStr  = haveItemInLeftHand.name;
        }
    }

    public string[] GetHoldingObj() {
        string[] r = {holdingRightHandStr, holdingLeftHandStr};
        return r;
    }
}

public class HandScript {

    public static void Hold(ref Transform haveItem, ref ColliderScript obj, ref GameObject debugObj1)
    {
        
        haveItem = obj.GetColliderObj().transform;
        Vector3 vec = obj.GetPosition();
        obj.GetColliderObj().transform.position = vec;
        debugObj1.transform.position = vec;
        Rigidbody rb = haveItem.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public static void Release(ref Transform haveItem, ref ColliderScript obj)
    {
        Rigidbody rb = haveItem.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        haveItem = null;
    }
} 
