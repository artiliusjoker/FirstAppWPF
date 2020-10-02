using System;
using System.Windows;

using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace InspirationalQuotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Timer 
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private TimeSpan _timeCountDown = TimeSpan.FromSeconds(3);
        private bool isTimerOn = false;
        // Random imgs
        private Random _random = new Random();
        private readonly string[] imageNamesArray = { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg", "7.jpg", "8.jpg", "9.jpg", "10.jpg" };

        public MainWindow()
        {
            InitializeComponent();
            // Timer initializing
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(TimerTick);
            StartTimer();          
        }

        private void StartTimer()
        {          
            isTimerOn = true;
            _timer.IsEnabled = true;
            _timer.Start();            
        }

        private void StopTimer()
        {          
            isTimerOn = false;
            _timer.IsEnabled = false;
            _timer.Stop();
            timeCountDownDisplay.Text = "Timer is off";          
        }

        private void RefreshDisplayTimer()
        {
            _timeCountDown = TimeSpan.FromSeconds(3);
            timeCountDownDisplay.Text = _timeCountDown.ToString("c");
        }

        private void RandomizePicture()
        {
            string randomizedImageFile = imageNamesArray[_random.Next(imageNamesArray.Length)];
            string randomizedImageFileLocation = "resources/" + randomizedImageFile;
            BitmapImage bitmapImage = new BitmapImage(new Uri(randomizedImageFileLocation, UriKind.Relative));
            randomizedImg.Source = bitmapImage;
        }
    
        private void TimerTick(object sender, EventArgs e)
        {
            timeCountDownDisplay.Text = _timeCountDown.ToString("c");
            if (_timeCountDown == TimeSpan.Zero)
            {
                RefreshDisplayTimer();
                RandomizePicture();
                return;
            }
            _timeCountDown = _timeCountDown.Add(TimeSpan.FromSeconds(-1));                    
        }
       
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToggleTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isTimerOn)
            {
                StopTimer();
                return;
            }
            if (!isTimerOn)
            {
                StartTimer();
            }
           
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            RandomizePicture();
        }
    }
}
