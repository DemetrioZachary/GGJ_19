using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Toothpaste : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;
    [Space(3)]
    public Transform brush;
    private ParticleSystem part;
    private List<ParticleCollisionEvent> collisionEvents;
    public Camera cam;

    private Collider2D[] colliders;
    private bool[] pasteOnCollider;
    private bool completed;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(new Vector3((maxX + minX) / 2, (maxY + minY) / 2, 0), new Vector3(maxX - minX, maxY - minY, 0));
    }

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        colliders = brush.GetComponentsInChildren<BoxCollider2D>();

        pasteOnCollider = new bool[colliders.Length];
        for (int i = 0; i < pasteOnCollider.Length; i++)
        {
            pasteOnCollider[i] = false;
        }
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + x * speed * Time.deltaTime, minX, maxX), Mathf.Clamp(transform.position.y + y * speed * Time.deltaTime, minY, maxY), 0);

        if (Input.GetMouseButtonDown(0))
        {
            var emission = part.emission;
            emission.enabled = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            var emission = part.emission;
            emission.enabled = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (completed) { return; }
        for(int i = 0; i < colliders.Length; i++)
        {
            if (other == colliders[i].gameObject)
            {
                pasteOnCollider[i] = true;
            }
        }
        CheckPasteCollisions();
    }

    private void CheckPasteCollisions()
    {
        bool checkCompletion = true;
        for(int i = 0; i < pasteOnCollider.Length; i++)
        {
            if (!pasteOnCollider[i]) { checkCompletion = false; }
        }
        completed = checkCompletion;
        // TODO send to GameManager
    }
}
