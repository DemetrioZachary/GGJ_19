using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{

    public float camDistance;
    public float scrollSpeed;

    //local references
    private GameObject[] tiles;
    private Camera cam;
    private Transform endTile;
    private bool tileSpawned;

    void Start()
    {
        tiles = FindObjectOfType<TilesData>().tiles;
        cam = Camera.main;
        endTile = transform.GetChild(0);
    }

    
    void Update()
    {
        transform.Translate(- Vector3.forward * scrollSpeed * Time.deltaTime);

        if(transform.position.z <= cam.transform.position.z + camDistance && tileSpawned == false)
        {
            Instantiate(tiles[Random.Range(0,3)], new Vector3 (transform.position.x, transform.position.y, endTile.position.z + 5f), Quaternion.identity);
            tileSpawned = true;
        }
    }
}
