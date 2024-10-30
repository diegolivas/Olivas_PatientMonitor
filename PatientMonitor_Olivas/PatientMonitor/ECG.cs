using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PatientMonitor
{
    class ECG
    {
        public double amplitude = 0.0;
        public double frequency = 0;
        public int harmonics = 1;

        public double Amplitude { get => amplitude; set => amplitude = value; }
        public double Frequency { get => frequency; set => frequency = value; }
        public int Harmonics { get => harmonics; set => harmonics = Math.Max(1, value); }

        public ECG(double amplitude, double frequency, int harmonics =1 )
        {
            this.amplitude = amplitude;
            this.frequency = frequency;
            this.harmonics = harmonics;
        }

        public double NextSample(double timeIndex)
        {
            const double HzToBeatsPerMin = 60.0;
            double sample = 0;

            for (int i = 1; i <= Harmonics; i++)
            {
                sample += Math.Cos(2 * Math.PI * (frequency / HzToBeatsPerMin) * timeIndex * i);
            }

            sample *= Amplitude / Harmonics;

            return sample;
        }
    }
}

