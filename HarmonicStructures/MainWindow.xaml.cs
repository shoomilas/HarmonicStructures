using System;
using System.Collections.Generic;
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

using static HarmonicStructures.Pitches;
using static HarmonicStructures.Chords;
using static HarmonicStructures.Scales;
using static HarmonicStructures.Interval;

namespace HarmonicStructures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FretboardDisplay.Text = (new Fretboard(13, A, E, A, D, G, B, E)).PlotAsNotes(C, Major);
            FretboardDisplay2.Text = (new Fretboard(13, A, E, A, D, G, B, E)).Plot(C, Major);
        }

        //private void ButtonExit_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}
    }
}
