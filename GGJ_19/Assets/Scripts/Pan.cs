using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pan : MonoBehaviour
{

    public float speed;
    public float minX, maxX, minY, maxY;
    public UnityEvent OnPush;

    public BoxCollider launchTrigger;

    private Animator anim;
    private bool canMove = true;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3((maxX + minX) / 2, (maxY + minY) / 2, 0), new Vector3(maxX - minX, maxY - minY, 0));
    }

    void Start()
    {
        anim = GetComponent<Animator>();
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
            foreach (Collider overlapping in Physics.OverlapBox(transform.position + launchTrigger.center, launchTrigger.size))
            {
                if (overlapping.CompareTag("Polpetta"))
                {
                    OnPush.Invoke();
                }
            }
            anim.SetTrigger("Up");
            canMove = false;
            StartCoroutine(Reset());
        }

        else if (Input.GetMouseButtonUp(0))
        {
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
