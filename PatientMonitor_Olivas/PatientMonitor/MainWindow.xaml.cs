using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization.Charting.Compatible;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PatientMonitor
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<KeyValuePair<int, double>> dataPoints;
        private DispatcherTimer timer;
        private int index = 0;
        Patient patient;
        private ObservableCollection<Patient> patients; //Patient list
        private Patient currentPatient; //Selected patient
        
        public MainWindow()
        {
            InitializeComponent();

      
            DateTime? dateOfBirth = DateTime.Now;
            patient = new Patient(100, 1.0, 1, "Default Name", 30, DateTime.Now);
            
            dataPoints = new ObservableCollection<KeyValuePair<int, double>>();
            lineSeriesECG.ItemsSource = dataPoints; // Bind the series to the data points
            

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.025); // Set timer to tick every second
            timer.Tick += Timer_Tick;
            timer.Start();
            timer.Stop();
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Generate a new data point
            dataPoints.Add(new KeyValuePair<int, double>(index++, patient.NextSample(index)));

            // Optional: Remove old points to keep the chart clean
            if (dataPoints.Count > 200) // Maximum number of points
            {
                dataPoints.RemoveAt(0); // Remove the oldest point
            }
        }
        private void Slider_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider.IsEnabled) slider.ValueChanged += sliderECG_ValueChanged;
            else slider.ValueChanged -= sliderECG_ValueChanged;
        }
        private void sliderECG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (patient != null)
            {
                patient.ECGAmplitude = sliderECG.Value;
            }
        }
        private void buttonCreatePatient_Click(object sender, RoutedEventArgs e )
        {
            sliderECG.IsEnabled = true;
            string name = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }

            DateTime? selectedDate = datePicker.SelectedDate;

            double amplitude = sliderECG.Value;
            double frequency = 1.0;
            int harmonics = 1;

            if (double.TryParse(FrequencyTextBox.Text, out double freqValue))
            {
                frequency = freqValue;
            }
            if (HarmonicsComboBox.SelectedItem is ListBoxItem selectedItem)
            {
                harmonics = int.Parse(selectedItem.Content.ToString());
            }

            patient = new Patient(amplitude, frequency, harmonics, name, age, selectedDate);

            if (patients == null)
            {
                patients = new ObservableCollection<Patient>();
            }
            patients.Add(patient);

            ClearFields();
        }
        private void FrequencyTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FrequencyTextBox.Text, out double frequency))
            {
                if (patient != null)
                {
                    patient.ECGFrequency = frequency;
                }
            }
        }

        private void HarmonicsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HarmonicsComboBox.SelectedItem is ListBoxItem selectedItem)
            {
                int harmonics = int.Parse(selectedItem.Content.ToString());
                patient.ECGHarmonics = harmonics;
            }
        
        }

        private void textBoxAge_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out int result);
        }

        private void buttonParameter_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            buttonParameter.IsEnabled = true;
        }
        //private void buttonUpdatePatient_Click()
        //{ 
            //buttonUpdatePatient.IsEnabled = true;
        //}

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            buttonStop.IsEnabled = true;
        }

        private List<Point> GeneratePoints()
        {
            var points = new List<Point>();

            for (int i = 0; i < 80; i++)
            {

                double x = i;
                double y = Math.Sin(2 * Math.PI * (1 / 10) * i / 4);
                points.Add(new Point(x, y));
            }
            return points;
        }

        private void ClearFields()
        {
            NameTextBox.Text = string.Empty; 
            AgeTextBox.Text = string.Empty; 
            datePicker.SelectedDate = null; 
            sliderECG.Value = 5; 
            FrequencyTextBox.Text = string.Empty;
            HarmonicsComboBox.SelectedIndex = 1;
        }
    }
}
