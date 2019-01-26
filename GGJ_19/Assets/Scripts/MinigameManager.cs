using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public Transform wincing;
    [Space(5)]
    public float maxTurnIntensity;
    public float bumpDuration;
    public float bumpIntensity;
    public float offroadIntensity;
    public float offroadSpeed;
    public Vector3 vibrationIntensity;
    public Vector3 vibrationSpeed;

    private Vector3 startPosition;
    private Vector3 turnComponent;
    private Vector3 bumpComponent;
    private Vector3 offroadComponent;
    private Vector3 vibrationComponent;

    private bool offroad = false;


    void Awake()
    {
        instance = this;
        startPosition = wincing.position;
    }


    void Update()
    {
        Vibration();
        wincing.position = startPosition + turnComponent + bumpComponent + offroadComponent + vibrationComponent;
    }

    public void DoBump()
    {
        StartCoroutine(Bump());
    }

    public void EnableOffroad(bool enabled)
    {
        if (enabled)
        {
            offroad = true;
            StartCoroutine(Offroad());
        }
        else
        {
            offroad = false;
        }
    }

    public void AddTurningEffect(float value01)
    {
        turnComponent = new Vector3(value01 * maxTurnIntensity, 0, 0);
    }

    private IEnumerator Bump()
    {
        float time = 0;

        while (time < bumpDuration)
        {
            float angle = time / bumpDuration * Mathf.PI;
            bumpComponent = new Vector3(0, Mathf.Sin(angle) * bumpIntensity, 0);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }

    private IEnumerator Offroad()
    {
        float time = 0;
        while (offroad)
        {
            offroadComponent = new Vector3(0, Mathf.Sin(time * offroadSpeed) * offroadIntensity, 0);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            if (time * offroadSpeed >= 2 * Mathf.PI) { time = 0; }
        }
    }

    private void Vibration()
    {
        float time = Time.time;
        vibrationComponent = new Vector3(Mathf.Sin(time * vibrationSpeed.x) * vibrationIntensity.x, Mathf.Sin(time * vibrationSpeed.y) * vibrationIntensity.y, Mathf.Sin(time * vibrationSpeed.z) * vibrationIntensity.z);
    }
}
