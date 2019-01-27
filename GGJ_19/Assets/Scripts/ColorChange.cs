using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    private int currentColor = 0;

    private Light mlight;

    void Start()
    {
        mlight = GetComponent<Light>();
        mlight.color = colors[0];
    }

    public void ChangeColor()
    {
        if (++currentColor >= colors.Length) { currentColor = 0; }
        mlight.color = colors[currentColor];
    }
}
