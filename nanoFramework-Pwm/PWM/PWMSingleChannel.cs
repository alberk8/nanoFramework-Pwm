

using System.Device.Pwm;
using System.Threading;

namespace nanoFramework_Pwm.PWM
{
    public class PWMSingleChannel
    {
        private readonly int _pin1;
        private PwmChannel _pwmChannel1;
        /// <summary>
        /// Single Channel
        /// </summary>
        /// <param name="pin1">GPIO Pin Number</param>
        public PWMSingleChannel(int pin1)
        {
            _pin1 = pin1;
        }

        public void Start(int frequency, double dutyCycle) 
        {
            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1, frequency, dutyCycle);
            _pwmChannel1.Start();
        }

        /// <summary>
        /// Single Frequency and Duty Cycle
        /// </summary>
        public void StartSimple()
        {
            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1);

            _pwmChannel1.Frequency = 5_000;
            _pwmChannel1.DutyCycle = 0.5;

            _pwmChannel1.Start();
        }


        /// <summary>
        /// Increase Frequency by 500Hz for 5 Iteration on the Fly
        /// </summary>
        public void StartIncreasingFrequency()
        {

            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1);

            _pwmChannel1.Frequency = 5_000;
            _pwmChannel1.DutyCycle = 0.5;

            _pwmChannel1.Start();

            for (int i = 1; i <= 5; i++)
            {
                Thread.Sleep(250);
                _pwmChannel1.Frequency += (i * 500);
            }
        }


        /// <summary>
        /// Increase Duty Cycle from 0 to 0.9 on the Fly
        /// </summary>
        public void StartIncreasingDutyCycle()
        {

            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1);

            _pwmChannel1.Frequency = 2_000;
            _pwmChannel1.DutyCycle = 0;

            _pwmChannel1.Start();

            for (int i = 1; i <= 9; i++)
            {
                Thread.Sleep(250);
                _pwmChannel1.DutyCycle = (i * 0.1);
            }
        }

        /// <summary>
        /// Start Stop Cycle
        /// </summary>
        public void StartStopCycle()
        {
            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1);
            _pwmChannel1.Frequency = 5_000;

            _pwmChannel1.Start();
            Thread.Sleep(100);
            _pwmChannel1.Stop();
            Thread.Sleep(100);
            _pwmChannel1.Frequency = 6_000;
            _pwmChannel1.Start();

        }

        public void StartSiren(int startFrequency, int endFrequency)
        {
            _pwmChannel1 = PwmChannel.CreateFromPin(_pin1, startFrequency, 0.2);

            for (int i = startFrequency; i < endFrequency; i++)
            {
                {
                    _pwmChannel1.Frequency = i;
                    Thread.Sleep(1);
                }
            }
            // move down
            for (int i = endFrequency; i > startFrequency; i-- )
            {
                {
                    _pwmChannel1.Frequency =  i;
                    Thread.Sleep(1);
                }
            }
            _pwmChannel1.Stop();
        }

        /// <summary>
        /// Stop PWM
        /// </summary>
        public void Stop()
        {
            _pwmChannel1.Stop();
        }
    }
}
