using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace SmartLight.Services
{
    public class Global : System.Web.HttpApplication
    {
        private Timer timer;

        protected void Application_Start(object sender, EventArgs e)
        {
            SerialPort arduino = new SerialPort("COM3", 9600);
            arduino.Open();

            ArduinoControl.Arduino = arduino;

            TimerCallback tcb = new TimerCallback(this.TimerTask);

            timer = new Timer(tcb, null, 0, 6000);
        }

        private void TimerTask(Object stateInfo)
        {
            Debug.Print("TIMER SERVICE");
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            using(Entities.SmartLightEntities entities = new Entities.SmartLightEntities())
            {

                var lampsToTurnOn = entities.Lamps.Where(l => l.Timelock != null && l.CurrentState == Entities.Enumerations.LampState.Off
                    && l.Timelock.StartTime.Hours == currentTime.Hours && l.Timelock.StartTime.Minutes == currentTime.Minutes);

                foreach(var lamp in lampsToTurnOn)
                {
                    ArduinoControl.SwitchLamp(lamp.TurnOnCode);
                    lamp.CurrentState = Entities.Enumerations.LampState.On;
                }

                var lampsToTurnOff = entities.Lamps.Where(l => l.Timelock != null && l.CurrentState == Entities.Enumerations.LampState.On
                    && l.Timelock.EndTime.Hours == currentTime.Hours && l.Timelock.EndTime.Minutes == currentTime.Minutes);

                foreach(var lamp in lampsToTurnOff)
                {
                    ArduinoControl.SwitchLamp(lamp.TurnOffCode);
                    lamp.CurrentState = Entities.Enumerations.LampState.Off;
                }

                entities.SaveChanges();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            SerialPort arduino = ArduinoControl.Arduino;

            if (arduino != null)
            {
                arduino.Close();
            }
        }
    }
}