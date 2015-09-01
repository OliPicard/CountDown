using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace CountDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            main();
        }
        private string date;
        public DateTime endTime;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        private void  main()
        {
            hours.MaxLength = 2;
            minutes.MaxLength = 2;
            seconds.MaxLength = 2;
            button1.IsEnabled = false;
            button1.Opacity = 0;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int hour, minute, second;
            bool result;
            
            
            result = Int32.TryParse(minutes.Text, out minute); // checking numbers
            if (result)
            {
                minute = Int32.Parse(minutes.Text); //ok we are good to go.
            }
            else
            {
                MessageBox.Show("This number is invaild."); //error handling
                minutes.Text = "00";
            }
            result = Int32.TryParse(hours.Text, out hour);
            if (result)
            {
                hour = Int32.Parse(hours.Text);
            }
            else
            {
                MessageBox.Show("This number is invaild.");
                hours.Text = "00";
            }
            result = Int32.TryParse(seconds.Text, out second);
            if (result)
            {
                second = Int32.Parse(seconds.Text);
            }
            else
            {
                MessageBox.Show("This number is invaild.");
                seconds.Text = "00";
            }
            date = picker.ToString(); //getting the date
            if (date == "")
            {
                MessageBox.Show("Select a date"); 
            }
            else if (hour <= 0 && minute <= 0) //if numbers are null, let's prompt the user.
            {
                MessageBox.Show("Enter a vaild number.");
            }
            else
            {
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                button1.Opacity = 100;
                button1.IsEnabled = true;
                hours.IsEnabled = false;
                minutes.IsEnabled = false;
                seconds.IsEnabled = false;
                picker.IsEnabled = false;
                picker.Opacity = 0;
                seconds.Opacity = 0;
                minutes.Opacity = 0;
                hours.Opacity = 0;
                label1.Opacity = 0;
                label1_Copy.Opacity = 0;
                button.Opacity = 0;
                date = Regex.Replace(date, @"00:00:00$", "");
                string resulty = date + hour + ":" + minute + ":" + second;
                endTime = DateTime.Parse(resulty);
                TimeSpan ts = endTime.Subtract(DateTime.Now);
                dispatcherTimer.Start();
                label.Content = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");

            }

        }
 
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            string t = label.Content.ToString();
            label.Content = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
            if (t == "0 Days 0 Hours 0 Minutes 0 Seconds")
            {
                MessageBox.Show("Time's Up!");
                dispatcherTimer.Stop();
                hours.Text = "00";
                minutes.Text = "00";
                seconds.Text = "00";
                label.Content = "";
                hours.IsEnabled = true;
                minutes.IsEnabled = true;
                picker.IsEnabled = true;
                seconds.IsEnabled = true;
                button.IsEnabled = true;
                button1.Opacity = 100;
                picker.Opacity = 100;
                seconds.Opacity = 100;
                minutes.Opacity = 100;
                hours.Opacity = 100;
                label1.Opacity = 100;
                label1_Copy.Opacity = 100;
                button.Opacity = 100;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            hours.Text = "00";
            minutes.Text = "00";
            seconds.Text = "00";
            label.Content = "";
            hours.IsEnabled = true;
            minutes.IsEnabled = true;
            picker.IsEnabled = true;
            button.IsEnabled = true;
            button1.IsEnabled = false;
            seconds.IsEnabled = true;
            picker.Opacity = 100;
            seconds.Opacity = 100;
            minutes.Opacity = 100;
            hours.Opacity = 100;
            label1.Opacity = 100;
            label1_Copy.Opacity = 100;
            button.Opacity = 100;
            button1.Opacity = 0;
            dispatcherTimer.Stop();

        }
    }
}
