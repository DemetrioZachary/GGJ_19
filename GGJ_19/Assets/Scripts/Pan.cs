using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{

    public float speed;
    public float minX, maxX, minY, maxY;

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

        if (canMove == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + x * speed * Time.deltaTime, minX, maxX), Mathf.Clamp(transform.position.y + y * speed * Time.deltaTime, minY, maxY), 0);

        }


        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Up", true);
            canMove = false;
            StartCoroutine(Reset());
        }

        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Up", false);
            canMove = true;
        }

        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(0).GetComponent<panDetection>().hasHit = false;
    }

}
