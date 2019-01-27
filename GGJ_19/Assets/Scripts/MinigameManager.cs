using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public enum BumpType { Stone, Hole }

    public static MinigameManager instance;

    public Transform wincingTarget;
    [Space(5)]
    public float turnIntensity;
    public float turnSpeed;
    public float turnSpeedReductionRate;
    public float bumpDuration;
    public float bumpIntensity;
    public float offroadIntensityMultiplier;
    public Vector2 vibrationIntensity;
    public Vector2 vibrationSpeed;

    private Vector3 startPosition;
    private Vector3 turnComponent = Vector3.zero;
    private Vector3 bumpComponent = Vector3.zero;
    private Vector3 vibrationComponent = Vector3.zero;

    private bool offroad = false;


    void Awake()
    {
        instance = this;
        startPosition = wincingTarget.position;
        StartCoroutine(Vibration());
    }


    void Update()
    {
        turnComponent *= 1 - turnSpeedReductionRate * Time.deltaTime;
        wincingTarget.position = startPosition + turnComponent + bumpComponent + vibrationComponent;
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

    public void AddTurnAcceleration(float sign)
    {
        turnComponent = new Vector3(Mathf.Clamp(turnComponent.x + sign * turnSpeed * Time.deltaTime, -turnIntensity, turnIntensity), 0, 0);
    }
    // ---------------------------------------------------------------------------

    private IEnumerator Bump(BumpType bumpType)
    {
        float sign = (bumpType == BumpType.Stone ? 1 : -1);
        float time = 0;

        while (time < bumpDuration)
        {
            float angle = time / bumpDuration * Mathf.PI;
            bumpComponent = new Vector3(0, Mathf.Sin(angle) * bumpIntensity * sign, 0);
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }

    private IEnumerator Vibration()
    {
        float time = 0;
        while (true)
        {
            vibrationComponent = new Vector3(Mathf.Sin(time * vibrationSpeed.x) * vibrationIntensity.x, Mathf.Sin(time * vibrationSpeed.y) * vibrationIntensity.y, 0);
            if (offroad)
            {
                vibrationComponent *= offroadIntensityMultiplier;
            }
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
    }
}
