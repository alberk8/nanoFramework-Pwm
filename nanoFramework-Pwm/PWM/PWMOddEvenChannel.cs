using System;
using System.Device.Pwm;

namespace nanoFramework_Pwm.PWM
{
    public class PWMOddEvenChannel
    {
        private readonly int _pin1;
        private readonly int _pin2;
        private PwmChannel _pwmChannel1;
        private PwmChannel _pwmChannel2;

        /// <summary>
        /// Even Channel number, eg PWM1 and PWM2
        /// This allows for setting Same Frequency and different duty cycle for each channel
        /// On ESP32 Odd and Even channel pair only support same Frequency but can have different duty cycle
        /// </summary>
        /// <param name="pin1">First GPIO Pin Number</param>
        /// <param name="pin2">Second GPIO Pin Number</param>
        public PWMOddEvenChannel(int pin1, int pin2)
        {
            _pin1 = pin1;
            _pin2 = pin2;
        }

        /// <summary>
        /// Start PWM
        /// </summary>
        public void Start()
        {
             _pwmChannel1 = PwmChannel.CreateFromPin(_pin1);

            _pwmChannel1.Frequency = 5_000;
            _pwmChannel1.DutyCycle = 0.2;

            _pwmChannel1.Start();

            Console.WriteLine("\n Second PWM\n");

            _pwmChannel2 = PwmChannel.CreateFromPin(_pin2);

            _pwmChannel2.Frequency = 5_000;
            _pwmChannel2.DutyCycle = 0.6;

            _pwmChannel2.Start();
        }

        /// <summary>
        /// Stop PWM
        /// </summary>
        public void Stop()
        {
            _pwmChannel1.Stop();
            _pwmChannel2.Stop();
        }
    }
}
