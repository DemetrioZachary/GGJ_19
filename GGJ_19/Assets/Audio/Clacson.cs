using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clacson : MonoBehaviour
{
    AudioSource clacson;
    void Start()
    {
        clacson = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clacson.Play();
        }
    }
}
