﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    public bool timerStarted = false;
    public float time = 0;
    public List<float> times;

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
                timerStarted = true;
            }
            else
            {
                timerStarted = false;
                times.Add(time);

                foreach (float item in times) { print(item); }
                time = 0;
            }

        }

        if (timerStarted)
        {
            time += Time.deltaTime;
        }
    }
}