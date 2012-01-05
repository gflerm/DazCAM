using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;

namespace SimpleServo02
{
    public class Servo
    {
        PWM servo;

        public Servo(Cpu.Pin pin)
        {
            servo = new PWM(pin);
            servo.SetDutyCycle(dutyCycle: 0);
        }

        private uint _angle = 0;

        public uint Angle
        {
            get
            {
                return _angle;
            }

            set
            {
                const uint degreeMin = 0;
                const uint degreeMax = 180;
                const uint durationMin = 500;  // 480  
                const uint durationMax = 2300;  // 2450  
                _angle = value;
                if (_angle < degreeMin) _angle = degreeMin;
                if (_angle > degreeMax) _angle = degreeMax;
                uint dur = (_angle - degreeMin) * (durationMax - durationMin) / (degreeMax - degreeMin) + durationMin;
                servo.SetPulse(period: 20000, duration: dur);
            }
        }
    }
}