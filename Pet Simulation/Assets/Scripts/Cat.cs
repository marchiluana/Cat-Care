using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cat : MonoBehaviour
{
    [SerializeField]
    private int _hunger;
    [SerializeField]
    private int _happiness;

    private bool _serverTime;
    private int _clickCount;

    void Start()
    {
        // PlayerPrefs.SetString("then", "15/12/2021 00:00:00");
        updateStatus();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject.tag == "Gato")
                {
                    _clickCount++;
                    if (_clickCount >= 3)
                    {
                        _clickCount = 0;
                        updateHappiness(1);
                    }
                }
            }
        }
    }

    void updateStatus()
    {
        if (!PlayerPrefs.HasKey("_hunger"))
        {
            _hunger = 100;
            PlayerPrefs.SetInt("_hunger", _hunger);
        }
        else
        {
            _hunger = PlayerPrefs.GetInt("_hunger");
        }

        if (!PlayerPrefs.HasKey("_happiness"))
        {
            _happiness = 100;
            PlayerPrefs.SetInt("_happiness", _happiness);
        }
        else
        {
            _happiness = PlayerPrefs.GetInt("_happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", getStringTime());

        Debug.Log(getTimeSpan().ToString());
        TimeSpan ts = getTimeSpan();

        _hunger -= (int)(ts.TotalHours * 2);
        if (_hunger < 0)
            _hunger = 0;

        _happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        if (_happiness < 0)
            _happiness = 0;

        if (_serverTime)
            updateServer();
        else
            InvokeRepeating("updateDevice", 0f, 60f);
    }

    void updateServer()
    {

    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (_serverTime)
            return new TimeSpan();

        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Day + "/" + now.Month + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }
    public int hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }

    public int happiness
    {
        get { return _happiness; }
        set { _happiness = value; }
    }

    public void updateHappiness(int i)
    {
        happiness += i;
        if (happiness > 100)
            happiness = 100;
    }

    public void updateHunger(int i)
    {
        hunger += i;
        if (hunger > 100)
            hunger = 100;
    }

    public void saveStatus()
    {
        if (!_serverTime)
            updateDevice();
        PlayerPrefs.SetInt("_hunger", _hunger);
        PlayerPrefs.SetInt("_happiness", _happiness);
    }
}
