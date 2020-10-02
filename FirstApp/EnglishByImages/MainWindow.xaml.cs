using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EnglishByImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Random
        private readonly Random _random = new Random();
        // Dictionary <Meaning, Picture location>
        private readonly List<MyDictionary> myDictionary = new List<MyDictionary>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeDictionary();
        }

        public void InitializeDictionary()
        {        
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Apple",
                PictureLocation = "apple.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Pomelo",
                PictureLocation = "pomelo.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Mangosteen",
                PictureLocation = "mangosteen.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Pitaya",
                PictureLocation = "pitaya.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Peach",
                PictureLocation = "peach.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Orange",
                PictureLocation = "orange.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Breadfruit",
                PictureLocation = "breadfruit.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Durian",
                PictureLocation = "durian.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Jackfruit",
                PictureLocation = "jackfruit.jpg"
            });
            myDictionary.Add(new MyDictionary()
            {
                Meaning = "Mango",
                PictureLocation = "mango.jpg"
            });
        }

        private MyDictionary RandomizeWord()
        {
            MyDictionary randomizedWord = myDictionary[_random.Next(myDictionary.Count)];           
            return randomizedWord;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            MyDictionary randomizedWord = RandomizeWord();
            string randomizedImageFileLocation = "resources/" + randomizedWord.PictureLocation;
            BitmapImage bitmapImage = new BitmapImage(new Uri(randomizedImageFileLocation, UriKind.Relative));
            randomizedImg.Source = bitmapImage;
            meaningText.Text = randomizedWord.Meaning;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
