using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingHand : MonoBehaviour
{

    private Animator anim;
    private bool canMove = true;


    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }


    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        Vector3 mousePos;

        mousePos = Input.mousePosition ;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (canMove == true)
        {
            // transform.position = new Vector3(Mathf.Clamp(transform.position.x + x * speed * Time.deltaTime, minX, maxX), Mathf.Clamp(transform.position.y + y * speed * Time.deltaTime, minY, maxY), 0);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0) * 1.1f; ;

        }


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(mousePos.y);

            if(mousePos.y >= 4)
            {
                anim.SetInteger("Tap", 1);

            }
            else
            {
                anim.SetInteger("Tap", 2);
            }

            canMove = false;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetInteger("Tap", 0);
            canMove = true;
        }

        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        }
    }
}
