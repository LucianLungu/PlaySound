using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlaySound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //System.Media.SoundPlayer
            //    aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\G.wav");  
            ////Creates a sound player with the mentioned file. You can even load a stream in to this class
            //    aSoundPlayer.Play();  //Plays the sound in a new thread

       

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\G.wav");
            //Creates a sound player with the mentioned file. You can even load a stream in to this class
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Am.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Dm.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\C.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\D.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Bm.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\A.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\E.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Em.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\F.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Fm.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Gm.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\Cm.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
                aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\B.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
               aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\A5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\B5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\C5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\D5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\E5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\F5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer
             aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\PowerChords\G5arp.wav");
            aSoundPlayer.Play();  //Plays the sound in a new thread
        }





    }




}
