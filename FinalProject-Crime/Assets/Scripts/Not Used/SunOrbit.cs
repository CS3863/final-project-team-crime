using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOrbit : MonoBehaviour
{
    public float angle = 0.1f;
    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(Vector3.zero, Vector3.right, angle);
    }
}
