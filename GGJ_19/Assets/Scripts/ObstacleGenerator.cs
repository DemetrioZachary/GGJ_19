using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float xMin;
    public float zMin;
    public float xMax;
    public float zMax;

    public float minObsDist;

    private List<Transform> obstaclesPos;
    private GameObject[] obstacles;
    private GameObject obs;

    void Start()
    {
        obstacles = FindObjectOfType<TilesData>().obstacles;

        obstaclesPos = new List<Transform>();

        for (int i = 0; i < Random.Range(0, 3); i++)
        {
            obs = Instantiate(obstacles[Random.Range(0, 2)], new Vector3(Random.Range(xMin, xMax), transform.position.y + 0.1f, Random.Range(zMin, zMax)), Quaternion.Euler(90, 0, 0));
            obs.transform.parent = this.transform;
            obstaclesPos.Add(obs.transform);

            //SetObsPosition();
        }


    }

    void SetObsPosition()
    {

        obs.transform.position = new Vector3(Random.Range(-xMin, xMax), transform.position.y + 0.1f, Random.Range(-zMin, zMax));

        for (int n = 1; n < obstaclesPos.Count; n++)
        {
            if (Vector3.Distance(obs.transform.position, obstaclesPos[n].transform.position) < minObsDist)
            {
                SetObsPosition();
            }
        }

    }

}
