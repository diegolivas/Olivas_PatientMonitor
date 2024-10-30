using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitor
{
    class Patient
    {
        

        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        ECG ecg;

        public double ECGAmplitude { get => ecg.Amplitude; set => ecg.Amplitude = value; }
        public double ECGFrequency { get => ecg.Frequency; set => ecg.Frequency = value; }
        public int ECGHarmonics { get => ecg.Harmonics; set => ecg.Harmonics = value; }

        public Patient(double amplitude, double frequency, int harmonics, string name, int age, DateTime? dateOfBirth) 
        {
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;
            ecg = new ECG(amplitude, frequency, harmonics);
        }
        
        public double NextSample(double timeIndex) 
        {
            return ecg.NextSample(timeIndex);
        }
    }
}
