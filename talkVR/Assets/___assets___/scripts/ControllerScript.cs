using System.Collections;
using System.Collections.Generic;
using UnityChan;
using UnityEngine;

static class FaceAnimations
{
    public const string DEFAULT = "default@unitychan";
    public const string SMILE = "smile1@unitychan";
    public const string ANGRY = "angry1@unitychan";
}

public class ControllerScript : MonoBehaviour {

    private FaceUpdate faceUpdate;
    private string nowFace = FaceAnimations.DEFAULT;

    

    // Use this for initialization
    void Start () {
        faceUpdate = GetComponent<FaceUpdate>();
    }
	
	// Update is called once per frame
	void Update () {

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log("Aボタンを押した");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Debug.Log("Bボタンを押した");
        }

        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if( (primaryAxis.y > 0.0f) && !nowFace.Equals(FaceAnimations.SMILE) )
        {
            nowFace = FaceAnimations.SMILE;
            faceUpdate.OnCallChangeFace(nowFace);
        }
        else if( (primaryAxis.y < 0.0f) && !nowFace.Equals(FaceAnimations.ANGRY) )
        {
            nowFace = FaceAnimations.ANGRY;
            faceUpdate.OnCallChangeFace(nowFace);
        }
        else if( (primaryAxis.y == 0.0f) && !nowFace.Equals(FaceAnimations.DEFAULT) )
        {
            nowFace = FaceAnimations.DEFAULT;
            faceUpdate.OnCallChangeFace(nowFace);
        }
    }
}
