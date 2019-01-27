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

        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            obs = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(Random.Range(xMin, xMax), transform.position.y + 0.1f, Random.Range(zMin, zMax)), Quaternion.identity);
            obs.transform.parent = this.transform;

            for (int n = 0; n < obstaclesPos.Count; n++)
            {
                if (Vector3.Distance(obs.transform.position, obstaclesPos[n].transform.position) < minObsDist)
                {
                    obs.transform.position = new Vector3(obs.transform.position.x, obs.transform.position.y, obs.transform.position.z + 1);
                }
            }

            obstaclesPos.Add(obs.transform);
        }


    }

   // void AdjustPos()
    //{
    //    obs.transform.position = new Vector3(Random.Range(xMin, xMax), transform.position.y + 0.1f, Random.Range(zMin, zMax));

    //    for (int n = 0; n < obstaclesPos.Count; n++)
    //    {
    //        if (Vector3.Distance(obs.transform.position, obstaclesPos[n].transform.position) < minObsDist)
    //        {
    //            AdjustPos();
    //        }

    //    }
    //}
}
