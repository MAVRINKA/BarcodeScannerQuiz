using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;
using System.Linq;
using System;

public class ArduinoReader : MonoBehaviour
{
    public delegate void CardPressedAction();
    public static event CardPressedAction OnCardPressed;

    // Initialization
    void Start()
    {
        //serialController = GameObject.Find("ArduinoReader").GetComponent<SerialController>();
        //textFileReader = GameObject.Find("ArduinoReader").GetComponent<TextFileReader>();

        //serialController.portName = textFileReader.comPort;
    }

    byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }

    // Executed each frame
    void Update()
    {
        //---------------------------------------------------------------------
        // Send data
        //---------------------------------------------------------------------

        // If you press one of these keys send it to the serial device. A
        // sample serial device that accepts this input is given in the README.
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Sending A");
            //serialController.SendSerialMessage("A");
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Sending Z");
           // serialController.SendSerialMessage("Z");
        }

        //---------------------------------------------------------------------
        // Receive data
        //---------------------------------------------------------------------

        //string message = serialController.ReadSerialMessage();


        //if (message == null)
        //    return;
        //else if (message != null)
        //{
        //    for(int i = 0; i < strings.Length; i++)
        //    {
        //        if (message == strings[i])
        //        {
        //            gameManager.OnClickCityButton(message);
        //            Debug.LogError("Есть совпадение");
        //            OnCardPressed();
        //        }

        //        else if(message != strings[i])
        //        {
        //            Debug.LogError("Нет совпадений");
        //        }
        //    }   
        //}

        //switch (message)
        //{
        //    case "0x53 0xB5 0xF9 0x15 0x50 0x00 0x01":
        //        Debug.Log("Первый ингридиент");
        //        objectManager.ActivateObject(0);
        //        //OnCardPressed();
        //        break;

        //    case "0x53 0xDC 0xEF 0x15 0x50 0x00 0x01":
        //        Debug.Log("Второй ингридиент");
        //        objectManager.ActivateObject(1);
        //        //OnCardPressed();
        //        break;

        //    case "0x53 0xB2 0xF6 0x15 0x50 0x00 0x01":
        //        Debug.Log("Третий ингридиент");
        //        objectManager.ActivateObject(2);
        //        //OnCardPressed();
        //        break;

        //    case "0x53 0x47 0xF3 0x15 0x50 0x00 0x01":
        //        Debug.Log("Четвертый ингридиент");
        //        objectManager.ActivateObject(3);
        //        //OnCardPressed();
        //        break;

        //    case "0x53 0x90 0xF6 0x15 0x50 0x00 0x01":
        //        Debug.Log("Пятый ингридиент");
        //        objectManager.ActivateObject(4);
        //        //OnCardPressed();
        //        break;
        //}


        //// Check if the message is plain data or a connect/disconnect event.
        //if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        //    Debug.Log("Connection established");
        //else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        //    Debug.Log("Connection attempt failed or disconnection detected");
        //else
        //    Debug.Log(message);

    }
}
