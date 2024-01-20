using nanoFramework.Hardware.Esp32;
using nanoFramework_Pwm.PWM;
using System.Diagnostics;
using System.Threading;

namespace nanoFramework_Pwm
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");
            Thread.Sleep(1_000);

            int pin1 = 2;
            int pin2 = 22;

          
            #region Single Channel
            //// Single Channel 
            
             Configuration.SetPinFunction(pin1, DeviceFunction.PWM1);

             var pwmSingleChannel = new PWMSingleChannel(pin1);

            ////Start with Freqency and Duty Cycle
            //pwmSingleChannel.Start(6_000, 0.8);

            //// Simple Single Frequency
             pwmSingleChannel.StartSimple();

            //// Start Stop Cycle
            // pwmSingleChannel.StartStopCycle();

            //// Increasing Frequency
            // pwmSingleChannel.StartIncreasingFrequency();

            //// Increasing Duty Cycle
            // pwmSingleChannel.StartIncreasingDutyCycle();

            //// Start Siren
            // pwmSingleChannel.StartSiren(600,900);
            #endregion


            #region Dual Channel Odd Even Pair
            //// Dual Channel
            //// Odd and Even Channel Pair
            
            // Configuration.SetPinFunction(pin1, DeviceFunction.PWM1);
            // Configuration.SetPinFunction(pin2, DeviceFunction.PWM2);
            // var oddEvenChannel = new PWMOddEvenChannel(pin1, pin2);
            // oddEvenChannel.Start();
            #endregion


            #region Dual Channel Odd Only
            //// Dual Channel
    
            // Configuration.SetPinFunction(pin1, DeviceFunction.PWM1);
            // Configuration.SetPinFunction(pin2, DeviceFunction.PWM3);
            // var oddOnlyChannel = new PWMOddOnlyChannel(pin1, pin2);
            // oddOnlyChannel.Start();
            #endregion

            Debug.WriteLine("Done");

            Thread.Sleep(Timeout.Infinite);


        }
    }
}
