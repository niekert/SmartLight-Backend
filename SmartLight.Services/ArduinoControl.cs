using System;
using System.Collections.Generic;
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
            Arduino.Write(lampCode);
        }
    }

}