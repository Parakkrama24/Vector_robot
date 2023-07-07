using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SensorData : MonoBehaviour
{
    SerialPort sp;
    private string receivedString;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            sp = new SerialPort("COM5", 9600);
            sp.Open();
            sp.ReadTimeout = 1000;
            Debug.Log("Serial port opened successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open serial port: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                receivedString = sp.ReadLine();
                string[] data = receivedString.Split(':');
                Debug.Log(data[1]);
            }
            catch (System.Exception e)
            {
                // print("Error reading from serial port: " + e.Message);
            }
        }
        else
        {
            print("Serial port is not open.");
        }
    }
}