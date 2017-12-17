using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{

    public Vector3 acc;
    private List<GameObject> colList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("holdable") && !colList.Contains(other.gameObject))
        {
            colList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("holdable") && colList.Contains(other.gameObject))
        {
            colList.Remove(other.gameObject);
        }
    }

    public GameObject GetColliderObj()
    {
        if (colList.Count > 0)
        {
            return colList[0];
        }
        else
        {
            return null;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position + acc;
    }
}
