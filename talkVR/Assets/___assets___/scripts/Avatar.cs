using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Avatar : MonoBehaviour {

    public GameObject headCamera;
    public GameObject avatarTruthHead;
    public GameObject avatarHead;
    public GameObject avatarRightHand;
    public GameObject avatarLeftHand;

    public GameObject debugBlock1;
    public GameObject debugBlock2;
    public GameObject debugBlock3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Oculus位置取得
        Vector3 trackingPos = InputTracking.GetLocalPosition(XRNode.CenterEye);
        Vector3 trackingRightPos = InputTracking.GetLocalPosition(XRNode.RightHand);
        Vector3 trackingLeftPos = InputTracking.GetLocalPosition(XRNode.LeftHand);

        // Oculus角度取得
        Quaternion trackingRot = InputTracking.GetLocalRotation(XRNode.CenterEye);

        // 手の位置
        // Vector3 pos1 = OculusRightHand.transform.position - headCamera.transform.position;
        Vector3 pos1 = trackingRightPos - trackingPos;
        pos1.y += 1.4F;
        pos1.z += 0.2F;
        avatarRightHand.transform.position = pos1;

        // 手の位置
        // Vector3 pos2 = OculusLeftHand.transform.position - headCamera.transform.position;
        Vector3 pos2 = trackingLeftPos - trackingPos;
        pos2.y += 1.4F;
        pos2.z += 0.2F;
        avatarLeftHand.transform.position = pos2;

        // 顔の位置
        Vector3 basePos = avatarTruthHead.transform.position;
        Vector3 accuracyPos = new Vector3(0, -0.1F, 0.1F);
        headCamera.transform.position = basePos + accuracyPos;

        // 顔の角度
        avatarHead.transform.rotation = trackingRot;
    }
}
