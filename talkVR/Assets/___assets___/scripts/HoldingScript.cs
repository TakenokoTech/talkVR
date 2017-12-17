using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HoldingScript : MonoBehaviour {

    public Transform haveItemInLeftHand;
    public Transform haveItemInRightHand;
    public ColliderScript colliderToLeftHand;
    public ColliderScript colliderToRightHand;

    private GameObject holdPosition;

    // Use this for initialization
    void Start ()
    {
        //holdPosition = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 人差し指・中指トリガー
        float rTrigger1 = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        float rTrigger2 = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        if (haveItemInRightHand != null && rTrigger1 < 80)
        {
            Debug.Log("右手Release");
            HandScript.Release(haveItemInRightHand, colliderToRightHand);
        }
        else if ((haveItemInRightHand == null) && (colliderToRightHand.GetColliderObj() != null) && rTrigger1 >= 80)
        {
            Debug.Log("右手Hold");
            HandScript.Hold(haveItemInRightHand, colliderToRightHand);
        }

        // 人差し指・中指トリガー
        float lTrigger1 = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
        float lTrigger2 = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger);
        if (haveItemInLeftHand != null && lTrigger1 < 80)
        {
            Debug.Log("左手Release");
            HandScript.Release(haveItemInLeftHand, colliderToLeftHand);
        }
        else if ((haveItemInRightHand == null) && (colliderToLeftHand.GetColliderObj() != null) && lTrigger1 >= 80)
        {
            Debug.Log("左手Hold");
            HandScript.Hold(haveItemInLeftHand, colliderToLeftHand);
        }

        Debug.Log(colliderToRightHand.GetColliderObj() + ", " + colliderToLeftHand.GetColliderObj());
    }
}

public class HandScript {

    public static void Hold(Transform haveItem, ColliderScript obj)
    {
        Rigidbody rb = obj.GetColliderObj().GetComponent<Rigidbody>();
        haveItem = obj.GetColliderObj().transform;
        obj.GetColliderObj().transform.position = obj.transform.position;
        // haveItem.transform.parent = obj.transform;
        // rb.isKinematic = true;
        rb.useGravity = false;
    }

    public static void Release(Transform haveItem, ColliderScript obj)
    {
        Rigidbody rb = haveItem.GetComponent<Rigidbody>();
        // haveItem.parent = null;
        // rb.velocity = OVRInput.GetLocalControllerVelocity(whichController);
        // rb.isKinematic = false;
        rb.useGravity = true;
        haveItem = null;
    }
} 
