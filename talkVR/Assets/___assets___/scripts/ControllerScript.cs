using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    public Animator charaAnimator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("Aボタンを押した");
            charaAnimator.CrossFade("smile1@unitychan", 0);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
            charaAnimator.CrossFade("default@unitychan", 0);
        }

    }
}
