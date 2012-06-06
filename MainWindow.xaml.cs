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
using Microsoft.Kinect;

namespace PlaySound
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        KinectSensor __kinect;

        bool closing = false;
        const int skeletonCount = 6;
        Skeleton[] allSkeletons = new Skeleton[skeletonCount];



        //setup kinect
        void SetupKinect()
        {
            //get first kinect sensor
            if (KinectSensor.KinectSensors.Count > 0)
            {
                __kinect = KinectSensor.KinectSensors[0];

                if (__kinect.Status == KinectStatus.Connected)
                {
                    //start the video stream only if the program in run from the
                    //Calibration Menu

                    __kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                    __kinect.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    __kinect.SkeletonStream.Enable();
                    // init the Depth Stream, with Near Mode Enabled
                    //KinectSensor.DepthStream.Enable( DepthImageFormat.Resolution640x480Fps30 );
                    //KinectSensor.DepthStream.Range = DepthRange.Near;

                    __kinect.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(_sensor_AllFramesReady);

                    __kinect.Start();
                }
            }
        }



        public MainWindow()
        {
            InitializeComponent();

            //System.Media.SoundPlayer
            //    aSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\Luke\Desktop\chords\G.wav");  
            ////Creates a sound player with the mentioned file. You can even load a stream in to this class
            //    aSoundPlayer.Play();  //Plays the sound in a new thread


            SetupKinect();

        }

        bool AE(int x, int y, int e)
        {
            return Math.Abs(x - y) < e;
        }

        // boolean meaning T or F value
        //
        //MAYBE to be played with
        void _sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

            Vector coolh = new Vector();
            // coolh = coordinates left hand
            // in vector i will save position of left hand


            short[] DataDepth;
            int HandDepth;

            byte[] RbgVideo;


            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            // the using above will detect a skeleton; the first one.
            {
                if (skeletonFrameData == null)
                {
                    return;
                }
                skeletonFrameData.CopySkeletonDataTo(allSkeletons);

                Skeleton first = (from s in allSkeletons
                                  where s.TrackingState == SkeletonTrackingState.Tracked
                                  select s).FirstOrDefault();

                if (first == null)
                {
                    return;
                }

                // the var = when i ask for the position of a joint the kinect will return a value btwn -1 and 1, for x and y
                // the fct does take those values and give the actual coordinates in comparison to the video stream.

                var pct = __kinect.MapSkeletonPointToColor

                (first.Joints[JointType.HandLeft].Position, ColorImageFormat.RgbResolution640x480Fps30

                );

                coolh.X = pct.X;
                coolh.Y = pct.Y;

                // the var = when i ask for the position of a joint the kinect will return a value btwn -1 and 1, for x and y
                // the fct does take those values and give the actual coordinates in comparison to the video stream.



            }
            // the using above will detect a skeleton; the first one.

            //next up we detect the depth of field, and then take the depth of the hand so we can only work with that, not with the whole img

            using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
            {
                if (depthFrame==null)
                {
                    return;
                }

               DataDepth = new short [depthFrame.PixelDataLength];
               depthFrame.CopyPixelDataTo(DataDepth);
            }
            //this above took a frame with depth

            HandDepth = DataDepth[(int)coolh.Y * 640 + (int)coolh.X] >> DepthImageFrame.PlayerIndexBitmaskWidth;


            //magic cast = transforms a variable on the spot (from int to double int for example.)


            using (ColorImageFrame colorFrame =e.OpenColorImageFrame())

            {
                if (colorFrame==null)
                {
                    return;
                    
                }

                    RbgVideo = new byte[colorFrame.PixelDataLength];
                    colorFrame.CopyPixelDataTo(RbgVideo);
                
            }

            int RedArea = 0;
                int YellowArea =0;
            //cati pixeli de culoarea aia s-au gasit
            //how many pixels of that color are found


                for (int i = -50; i < 51; i++)
                {
             

                    if (coolh.Y +i <0 || coolh.Y +i > 480)
                    {
                        continue;
                    }

                    int offset = ((int)(coolh.Y - 1) * 640);

                 for (int j = -50; j < 51; j++)
                    {
                        if (coolh.X+j <0||coolh.X+j>640)
                        {
                            continue;
                        }
                        const int redin = 0;
                        const int greenin = 0;
                        const int bluein = 0;
                   
                     //redin, greenin, bluein are indexes; offsets 
                        if (AE(DataDepth[offset + (int)coolh.X + j] >> DepthImageFrame.PlayerIndexBitmaskWidth, HandDepth, 50))
                        {
                            int coloroffset = (offset + (int)coolh.X * 4);

                                //*4 because every pixel is composed of 4 pixels: RGB and transparency

                            if (AE (RbgVideo[coloroffset+redin], 255, 20) && 
                                AE (RbgVideo[coloroffset+greenin], 0, 20) && 
                                    AE (RbgVideo[coloroffset+bluein], 0, 20))

                            {
                                RedArea++;
                            }
                        
                            //do that if above for each color that i want; this one is for red.

                        }

                    }


                }

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            __kinect.Stop();
        }





    }




}
