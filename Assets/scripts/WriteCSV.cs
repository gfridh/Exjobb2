using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class WriteCSV : MonoBehaviour {

    string[] output;
    int length;
    string delimiter = ",", filePath;
    StringBuilder sb;
    StreamWriter outStream;

    void Start()
    {

        output = new string[] {"hej" , "hej"} ;
    }

    void Update()
    {
        //output = new string[triggers.Count][];

        //for (int i = 0; i < output.Length; i++)
        //  output[i] = triggers[i];s
        if (Input.GetKeyDown("space"))
            
        {
            print("createFile");
            sb = new StringBuilder();
            sb.AppendLine(string.Join(delimiter, output));
            filePath = "Assets/UserData/" + 1.ToString() + ".csv";
            outStream = File.CreateText(filePath);
            outStream.WriteLine(sb);
            outStream.Close();
        }


    }

}
