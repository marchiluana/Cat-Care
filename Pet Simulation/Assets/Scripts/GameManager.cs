using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameManager : MonoBehaviour
{
    public GameObject hungerText;
    public GameObject hapinessText;

    public GameObject cat;
    public GameObject carePanel;

    public GameObject displayTime;
    // public GameObject displayDate;
    void Start()
    {

    }
    void Update()
    {
        DateTime now = DateTime.Now;
        displayTime.GetComponent<Text>().text = "" + now.Hour + ":" + now.Minute + ":" + now.Second;

        hungerText.GetComponent<Text>().text = cat.GetComponent<Cat>().hunger.ToString();
        hapinessText.GetComponent<Text>().text = cat.GetComponent<Cat>().happiness.ToString();
    }

    public void buttonBehavior(int i)
    {
        switch (i)
        {
            case (0):
                carePanel.SetActive(!carePanel.activeInHierarchy);
                break;

            case (1):
                cat.GetComponent<Cat>().saveStatus();
                Application.Quit();
                break;
        }
    }
}

