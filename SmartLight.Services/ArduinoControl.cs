using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Web;

namespace SmartLight.Services
{
    public class ArduinoControl
    {
        public static SerialPort Arduino { get; set; }

        public static void SwitchLamp(string lampCode)
        {
            Debug.Print(String.Format("Writing arduino {0}", lampCode));
            Arduino.Write(lampCode);
        }
    }

}