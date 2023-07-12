using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class SensorData : MonoBehaviour
{
    SerialPort sp;
    private string receivedString;
    public  double distance;
    [SerializeField] private int maxTrigger = 10;
    //private bool isClicked = false;

    public ITriger trigger;
    public Uimaneger _uimaneger;
    private string portNumbre = "6";
    // Start is called before the first frame update
    void Start()
    {
        if(_uimaneger.inputValue != null) {
            _uimaneger.inputValue = portNumbre;
        }
        try
        {
            Debug.Log(portNumbre);
            sp = new SerialPort("COM"+ portNumbre.ToString(), 9600);
            sp.Open();
            sp.ReadTimeout = 10;
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
                distance = double.Parse(data[1]);
                //distance = 11f;
                Debug.Log(distance);
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

    private bool hasExecuted = false;





}