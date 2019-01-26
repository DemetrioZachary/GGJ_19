using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float horizontalSpeed;
    public float maxLeft;
    public float maxRight;

    private Transform mesh;
    private float xMove;

    private void Start()
    {
        mesh = transform.GetChild(0);
    }

    void Update()
    {
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxRight)
        {
            transform.position = new Vector3(maxRight, transform.position.y, transform.position.z);
        }


        Turn();
    }

    void Turn()
    {
        xMove = Input.GetAxis("Horizontal");

        transform.Translate(xMove * horizontalSpeed * Time.deltaTime, 0, 0);

        mesh.eulerAngles = new Vector3(0, 30 * xMove, 0);
    }
}
