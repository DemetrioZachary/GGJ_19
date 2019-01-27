using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panDetection : MonoBehaviour
{
    public bool hasHit = true;
    public int succesCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Polpetta" && hasHit == false)
        {
            succesCount++;
            hasHit = true;

            if (succesCount == 3)
            {
                Debug.Log("KTM");
            }
        }
    }
}
