using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmartPhone : MonoBehaviour
{
    public Scrollbar scrollbar;

    public Button button;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    void Start()
    {
        InvokeRepeating("Scroll", 1, 1);
    }

    
    void Update()
    {
        //Scroll();
    }

    void Scroll()
    {
        //scrollbar.value += 0.01f;
    }

    public void Click(int i)
    {

        Color sprite;

        if(i == 0)
        {
            sprite = button.GetComponent<Image>().color;
        }
        else if(i == 1)
        {
            sprite = button1.GetComponent<Image>().color;
        }
        else if (i == 2)
        {
            sprite = button2.GetComponent<Image>().color;
        }
        else if (i == 3)
        {
            sprite = button3.GetComponent<Image>().color;
        }
        else if (i == 4)
        {
            sprite = button4.GetComponent<Image>().color;
        }

        sprite = new Color(255, 255, 255, 255);
    }
    
}
