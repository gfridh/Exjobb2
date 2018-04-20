﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataLogger : MonoBehaviour
{
    public bool timerStarted = false;
    public float time = 0;
    public int zoomIn = 0;
    public int zoomOut = 0;
    public float actions = 0;
    public List<string> times;
    public List<string> actionsList;
    public List<string> zoomInList;
    public List<string> zoomOutList;

    string[] output;
    int length;
    string delimiter = ",", filePath;
    StringBuilder sb;
    StreamWriter outStream;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            print("createFile");
            sb = new StringBuilder();
            for (int i = 0; i < actionsList.Count; i++)
            {

            }
            sb.AppendLine(string.Join(delimiter, times.ToArray()));
            sb.AppendLine(string.Join(delimiter, actionsList.ToArray()));
            sb.AppendLine(string.Join(delimiter, zoomInList.ToArray()));
            sb.AppendLine(string.Join(delimiter, zoomOutList.ToArray()));

            filePath = "Assets/UserData/" + 1.ToString() + ".csv";
            outStream = File.CreateText(filePath);
            outStream.WriteLine(sb);
            outStream.Close();
        }

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
                times.Add(time.ToString());
                actionsList.Add(actions.ToString());
                zoomInList.Add(zoomIn.ToString());
                zoomOutList.Add(zoomOut.ToString());
              }

        }

        if (timerStarted)
        {
            time += Time.deltaTime;
        }
    }
}
