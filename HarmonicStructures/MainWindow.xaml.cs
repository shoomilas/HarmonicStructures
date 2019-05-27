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
        public List<string> ChordsList { get; set; }
        public List<string> ScalesList { get; set; }
        public List<string> RootsList { get; set; }
        private Pitch[] CurrentTuning { get; set; }
        public bool ScaleOrChord;
        private int numberOfStringsToPrint;
        public int[] CurrentSet;
        private Pitch CurrentRoot { get; set; }
        private bool ShouldNotExecute;

        public MainWindow()
        {         
            InitializeComponent();
           
            DataContext = this;
            ChordsList = new List<string>(ChordsDictionary.Keys);
            ScalesList = new List<string>(ScalesDictionary.Keys);
            RootsList = new List<string>(RootsDictionary.Keys);

            numberOfStringsToPrint = 14;
            ScaleOrChord = true;
            CurrentSet = GetScale("Major (1) Ionian");
            CurrentRoot = GetPitch("C");
            CurrentTuning = new[] { E, A, D, G, B, E };
            ShouldNotExecute = false;

            ChordSelection.SelectedIndex = -1;
            RootSelection.SelectedIndex = 0;
            ScaleSelection.SelectedValue = "Major (1) Ionian";

            //TODO: Use delegates to make these more concise
            FretboardDisplay.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).PlotAsNotes(CurrentRoot, CurrentSet);
            FretboardDisplay2.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).Plot(CurrentRoot, CurrentSet); //FretboardDisplay2.Text = (new Fretboard(13, A, E, A, D, G, B, E)).Plot(C, Major);
        }

        private void ChordSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShouldNotExecute) return;

            ScaleOrChord = true;
            ShouldNotExecute = true;
            ScaleSelection.SelectedIndex = -1;
            ShouldNotExecute = false;

            CurrentSet = GetChord(ChordSelection.SelectedItem.ToString());
            FretboardDisplay.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).PlotAsNotes(CurrentRoot, CurrentSet);
            FretboardDisplay2.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).Plot(CurrentRoot, CurrentSet);
        }

        private void ScaleSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShouldNotExecute) return;

            ScaleOrChord = false;

            ShouldNotExecute = true;
            ChordSelection.SelectedIndex = -1;
            ShouldNotExecute = false;

            CurrentSet = GetScale(ScaleSelection.SelectedItem.ToString());
            FretboardDisplay.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).PlotAsNotes(CurrentRoot, CurrentSet);
            FretboardDisplay2.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).Plot(CurrentRoot, CurrentSet);

        }

        private void RootSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRoot = GetPitch(
                RootSelection.SelectedItem.ToString()
            );
           
            FretboardDisplay.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).PlotAsNotes(CurrentRoot, CurrentSet);
            FretboardDisplay2.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).Plot(CurrentRoot, CurrentSet);
        }

        private void TuningSelection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (StringTools.StringToPitchesValidator(TuningSelection.Text))
                {
                    CurrentTuning = StringTools.StringToPitches(TuningSelection.Text);
                    FretboardDisplay.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).PlotAsNotes(CurrentRoot, CurrentSet);
                    FretboardDisplay2.Text = (new Fretboard(numberOfStringsToPrint, CurrentTuning)).Plot(CurrentRoot, CurrentSet);
                }
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
