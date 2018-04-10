﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    public bool timerStarted = false;
    public float time = 0;
    public int zoomIn = 0;
    public int zoomOut = 0;
    public float actions = 0;
    public List<float> times;
    public List<float> actionsList;
    public List<int> zoomInList;
    public List<int> zoomOutList;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (timerStarted == false)
            {
                time = 0;
                actions = 0;
                zoomIn = 0;
                zoomOut = 0;
                timerStarted = true;
            }
            else
            {
                timerStarted = false;
                times.Add(time);
                actionsList.Add(actions);
                zoomInList.Add(zoomIn);
                zoomOutList.Add(zoomOut);

                foreach (float item in times) { print(item); }
              }

        }

        if (timerStarted)
        {
            time += Time.deltaTime;
        }
    }
}
