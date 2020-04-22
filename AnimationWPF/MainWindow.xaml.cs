using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnimationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool isFinished = false;
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isFinished)
            {
                isFinished = true;
                DoubleAnimation anim = new DoubleAnimation();
                anim.Completed += (o, s) =>
                {
                    isFinished = false;
                };
                // To --- 360  From --- 0 Duration ---- 0:0:1.800
                anim.Duration = new Duration(TimeSpan.FromSeconds(2));
                anim.From = 0;
                anim.To = 360;
                anim.AutoReverse = true;

                RotateTransform transform = new RotateTransform();

                button.RenderTransform = transform;
                transform.BeginAnimation(RotateTransform.AngleProperty, anim);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation();
            anim.From = 1;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(1);
            anim.RepeatBehavior = new RepeatBehavior(2);
            anim.AutoReverse = true;
            button.BeginAnimation(Button.OpacityProperty, anim);
        }
    }
}
