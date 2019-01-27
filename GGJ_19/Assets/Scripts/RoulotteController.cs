using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulotteController : MonoBehaviour
{
    public Transform car;

    private MinigameManager MGM;


    void Update()
    {
        transform.LookAt(car);

        transform.position = Vector3.Lerp(transform.position, new Vector3(car.position.x, transform.position.y, transform.position.z), 2f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {

            if (MGM == null)
            {
                MGM = FindObjectOfType<MinigameManager>();
            }

            MGM.DoBump(MinigameManager.BumpType.Stone);
        }
        else if (other.tag == "Hole")
        {
            if (MGM == null)
            {
                MGM = FindObjectOfType<MinigameManager>();
            }

            MGM.DoBump(MinigameManager.BumpType.Hole);
        }

        if (other.tag == "Offroad")
        {
            if (MGM == null)
            {
                MGM = FindObjectOfType<MinigameManager>();
            }

            MGM.EnableOffroad(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Offroad")
        {
            if (MGM == null)
            {
                MGM = FindObjectOfType<MinigameManager>();
            }

            MGM.EnableOffroad(false);
        }
    }
}
