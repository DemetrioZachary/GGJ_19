using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopetteForce : MonoBehaviour
{
    public float force;
    public float backMultiplier;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public void Launch()
    {
        rb.AddForce(new Vector3(force * backMultiplier, force, 0), ForceMode.Impulse);
    }
}
