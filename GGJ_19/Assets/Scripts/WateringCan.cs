using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;
    [Space(5)]
    public float wateringTime;
    public GameObject[] pots;

    private ParticleSystem part;
    private float[] timers;
    private bool completed = false;
    private Animator animator;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3((maxX + minX) / 2, (maxY + minY) / 2, 0), new Vector3(maxX - minX, maxY - minY, 0));
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        part = GetComponent<ParticleSystem>();
        timers = new float[pots.Length];
        for(int i = 0; i < timers.Length; i++)
        {
            timers[i] = wateringTime;
        }
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + x * speed * Time.deltaTime, minX, maxX), Mathf.Clamp(transform.position.y + y * speed * Time.deltaTime, minY, maxY), 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Versa", true);
            //var emission = part.emission;
            //emission.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Versa", false);
            //var emission = part.emission;
            //emission.enabled = false;
        }

        if (Input.GetMouseButton(0))
        {
            Watering();
        }
    }

    private void Watering()
    {
        if (completed) { return; }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit && hit.collider.CompareTag("Pot"))
        {
            for(int i=0; i < pots.Length; i++)
            {
                if (pots[i] == hit.collider.gameObject)
                {
                    timers[i] -= Time.deltaTime;
                    if (timers[i] <= 0)
                    {
                        // SPAWN FOGLIOLINA
                    }
                }
            }
        }

        bool checkCompletion = true;
        for(int i = 0; i < timers.Length; i++)
        {
            if (timers[i] > 0) { checkCompletion = false; }
        }
        completed = checkCompletion;
        if (completed)
        {
            FindObjectOfType<GameManager>().ChangeMinigame();
        }
    }
}
