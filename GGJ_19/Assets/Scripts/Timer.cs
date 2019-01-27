using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float delay;

    void Start()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {

        yield return new WaitForSeconds(delay);
        FindObjectOfType<GameManager>().ChangeMinigame();

    }

}
