   M S B A M L   `   `   `  ����I  EPatientMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:PatientMonitorPatientMonitor  5   	       PatientMonitor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:PatientMonitor     5   	   p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289bOtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit  5   	     � Title$  
MainWindow��5	   	   $	��688��6   $	��800��6)   .��5      � .+�5   
   >  8System.Windows.Controls.DataVisualization.Charting.Chart     Title$ Real-time ECG��6   $	��800��6.   $	��362��6:   $	��Top=�6G      Series. 5      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  -   5          Name$ lineSeriesECG��5   !   ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ ECG Channel1��5   )   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 5   )   �� *Key+   DependentValueBinding 5   )   �� *Value+�  �System.Windows.Controls.DataVisualization.Charting.LineAreaBaseSeries`1[[System.Windows.Controls.DataVisualization.Charting.LineDataPoint, DotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b]]   IndependentAxis 5      C  =System.Windows.Controls.DataVisualization.Charting.LinearAxis  5      =  7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ X=�6)   D  >System.Windows.Controls.DataVisualization.Charting.DisplayAxis	   Title$
	 Time��69   
   DependentRangeAxis
 5        5      $ Y=�6)   $	 Value��69   5      5      �� 5   
   -   5         ��Name$ ECGgroupBox��5      $	��ECG��6(   $	��380��65   $	��230��6A   $��Bottom=�6N   $��Right=�6i   $��	0,0,10,80q�6�   $��16(�6�   .��5      �� -   5         ��Name$ 	sliderECG��5       � Minimum$ 0Q�6(    � Maximum$ 10Q�64    � Value$ 5Q�6A   $��9,40,9,0q�6K   $��20��6]   $	��350��6i   $	��Top=�6�   5      �� 5   
   -   5        $ CreatePatientGroupBox��5      $��Input Patient��62   $	��380��6I   $	��230��6U   $��Bottom=�6b   $
��Left=�6}   $��	14,0,0,80q�6�   $��16(�6�   .��5       �� -   5         ��Name$ buttonCreatePatient��5       $��Create Patient��62   $	��120��6K   $��	0,100,0,0q�6W   $��30��6j   5"      �� 5$   
   -   5        $ UpdatePatientGroupBox��5$      $��Input Patient��62   $	��380��6I   $	��230��6U   $��Bottom=�6b   $
��Left=�6}   $��	14,0,0,80q�6�   $��16(�6�   .��5&      �� -   5        $ buttonUpdatePatient��5&      $��Update Patient��62   $	��120��6K   $��124,0,124,0q�6W   $��30��6l   $��Bottom=�6x   5(      �� 5*   
   -   5        $ DatePatientGroupBox��5*      $��Input Patient��60   $	��380��6G   $	��230��6S   $��Bottom=�6`   $
��Left=�6{   $��	14,0,0,80q�6�   $��16(�6�   .��5+      �� .+�5,      (	  "System.Windows.Controls.DatePicker	  -	   5         	 Name$ 
datePicker��5,      $��	0,100,0,0q�6W   $	��150��6j    	  SelectedDate 61   �� *SelectedDate+6j   5-      5.      �� 50   
   $��Patient Name:��6   $
��Left=�6(   $	��Top=�6C   $��16(�6[   $��
15,380,0,0q�6i   �� 51   
   -
   5         ��Name$ NameTextBox��51      $
��Left=�6'   $��
20,405,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $��0��6j   $	��Top=�6s   $	��350��6�   $��16(�6�   �� 53   
   $��Patient Age:��6   $
��Left=�6'   $	��Top=�6B   $��16(�6Z   $��
15,430,0,0q�6h   �� 54   
   -   5        $ 
AgeTextBox��54      $
��Left=�6&   $��
20,455,0,0q�6A   $
 Wrap=�6U   $��0��6i   $	��Top=�6r   $	��150��6�   $��16(�6�   6�   �� 56   
   $;��50 mV        2.5 mV       5 mV         7.5 mV    10 mV��6   $
��Left=�6P   $	��Top=�6k   $��16(�6�   $��426.5,398,0,0q�6�   $	��350��6�   �� 58   
   $!��ECG Frequency (cycles/min):��6   $
��Left=�66   $	��Top=�6Q   $��497,450,0,0q�6i   $��16(�6~   �� 59   
   -   5        $ FrequencyTextBox��59      $
��Left=�6-   $��527,480,0,0q�6H   $
 Wrap=�6]   $��0��6q   $	��Top=�6z   $	��150��6�   $��16(�6�   6�   �� 5;   
   $��
Harmonics:��6   $
��Left=�6%   $	��Top=�6@   $��550,495,0,0q�6X   $��16(�6m   �� 5<   
   -   5         ��Name$ HarmonicsComboBox��5<      $
��Left=�6.   $��574,526,0,125q�6I   $��40��6`   .@�5=      �� $��1��6   �� 5>      $��2��6   �� 5?      $��3��6   5@      �� 5B   
   -   5        $ buttonParameter��5B      $��Start Simulation��6*   $
��Left=�6E   $��480,610,0,0q�6`   $	��Top=�6u   $��16(�6�   6�   �� 5C   
   -   5        $ 
buttonStop��5C      $
��Stop��6%   $
��Left=�64   $��630,610,0,0q�6O   $	��Top=�6d   $��16(�6|   6�   5D      5E      