using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public Joint end; 
    public GameObject target;
    private Vector3 offset;

    void Start()
    {
        offset = end.transform.position - target.transform.position;
    }

    void FixedUpdate()
    {
        end.transform.position = new Vector3(end.transform.position.x, target.transform.position.y + offset.y, end.transform.position.z);
    }
}