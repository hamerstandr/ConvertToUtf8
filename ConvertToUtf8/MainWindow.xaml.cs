using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace ConvertToUtf8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    { string str = "";
        public MainWindow()
        {
            InitializeComponent();
            if (App.Arg != "")
            {
                try
                {
                    var arabic = Encoding.GetEncoding(1256);
                    StreamReader reader = new StreamReader(App.Arg, arabic);
                    str = reader.ReadToEnd();
                    reader.Close();
                    TextBox1.Text = str;
                }
                catch { }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try {/* File.Delete(App.Arg); File.CreateText(App.Arg, true, Encoding.UTF8);*/ } catch { }
            try {
                Stream s =File.Create(App.Arg);
                StreamWriter writer =  new StreamWriter(s, Encoding.UTF8);
                writer.Write(str);
                writer.Close();
                TextMasege.Text = "Saved.";
                TextMasege.Foreground = Brushes.DarkGreen;
            } catch { }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            try
            {
                var arabic = Encoding.GetEncoding(1256);
                StreamReader reader = new StreamReader(dialog.FileName, arabic);
                str = reader.ReadToEnd();
                reader.Close();
                TextBox1.Text = str;
            }
            catch { }
        }
    }
}
