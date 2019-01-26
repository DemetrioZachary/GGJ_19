using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public enum BumpType { Stone, Hole}

    public static MinigameManager instance;

    public Transform wincingTarget;
    [Space(5)]
    public float maxTurnIntensity;
    public float bumpDuration;
    public float bumpIntensity;
    public float offroadIntensityMultiplier;
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
        startPosition = wincingTarget.position;
    }


    void Update()
    {
        Vibration();
        wincingTarget.position = startPosition + turnComponent + bumpComponent + offroadComponent + vibrationComponent;
    }

    // Methods for car
    // ----------------------------------------------------------------------------
    public void DoBump(BumpType bumpType)
    {
        StartCoroutine(Bump(bumpType));
    }

    public void EnableOffroad(bool enabled)
    {
        offroad = enabled;
    }

    public void AddTurnAcceleration(float value01)
    {
        turnComponent = new Vector3(value01 * maxTurnIntensity, 0, 0);
    }
    // ---------------------------------------------------------------------------

    private IEnumerator Bump(BumpType bumpType)
    {
        float sign = (bumpType == BumpType.Stone ? 1 : -1);
        float time = 0;

        while (time < bumpDuration)
        {
            float angle = time / bumpDuration * Mathf.PI * sign;
            bumpComponent = new Vector3(0, Mathf.Sin(angle) * bumpIntensity, 0);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }

    private void Vibration()
    {
        float time = Time.time;
        vibrationComponent = new Vector3(Mathf.Sin(time * vibrationSpeed.x) * vibrationIntensity.x, Mathf.Sin(time * vibrationSpeed.y) * vibrationIntensity.y, Mathf.Sin(time * vibrationSpeed.z) * vibrationIntensity.z);
        if (offroad)
        {
            vibrationComponent *= offroadIntensityMultiplier;
        }
    }
}
