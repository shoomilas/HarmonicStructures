using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonicStructures
{
    partial class Fretboard
    {
        public string Plot() //Default = Chromatic Scale with the last string's 0 fret being a root
        {
            Pitch Root = fretboard[(this.NumberOfStrings - 1), 0];
            HarmonicSet Set = new HarmonicSet(Root, Scales.Chromatic);
            Fretboard FretboardPlot = new Fretboard(this.NumberOfFrets, Tuning);

            //Sets Factor value for every Pitch in Fretboard.Plot.fretboard
            for (int current_string = 0; current_string < FretboardPlot.NumberOfStrings; current_string++)
            {
                for (int current_fret = 0; current_fret < FretboardPlot.fretboard.GetLength(1); current_fret++)
                {
                    if (FretboardPlot.fretboard[current_string, current_fret].Note == Root.Note)
                    {
                        FretboardPlot.fretboard[current_string, current_fret].Factor = 0;
                    }
                    else
                    {
                        for (int i = 1; i < Set.Components.Length; i++)
                        {
                            if (FretboardPlot.fretboard[current_string, current_fret].Note == Set.Components[i].Note)
                            {
                                FretboardPlot.fretboard[current_string, current_fret].Factor = Set.Steps[i - 1];
                            }
                        }
                    }
                }
            }

            string outcome = "";

            for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
            {
                outcome += $" {CurrentString + 1}:  {FretboardPlot.fretboard[CurrentString, 0].FactorToString()}  ||";
                for (int CurrentFret = 1; CurrentFret < FretboardPlot.fretboard.GetLength(1); CurrentFret++) //FretIteration
                {

                    if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == null)
                    {
                        outcome += "-------|";
                    }
                    else if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == Interval.Root)
                    {
                        outcome += $"-({FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()})--|";
                    }
                    else
                    {
                        outcome += $"- {FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()} --|";
                    }
                }
                outcome += "\n";
            }
            return outcome;
        }

        public string Plot(int[] Factors) //Creates a new fretboard[,] array filled witch Pitch type values and "writes" a Harmonic set into it.; Default Gsharp root so that it is positioned like in my tables done graphically
        {
            Pitch Root = Pitches.Gsharp;
            HarmonicSet Set = new HarmonicSet(Root, Factors);
            Fretboard FretboardPlot = new Fretboard(this.NumberOfFrets, Tuning);

            //Sets Factor value for every Pitch in Fretboard.Plot.fretboard
            for (int current_string = 0; current_string < FretboardPlot.NumberOfStrings; current_string++)
            {
                for (int current_fret = 0; current_fret < FretboardPlot.fretboard.GetLength(1); current_fret++)
                {
                    if (FretboardPlot.fretboard[current_string, current_fret].Note == Root.Note)
                    {
                        FretboardPlot.fretboard[current_string, current_fret].Factor = 0;
                    }
                    else
                    {
                        for (int i = 1; i < Set.Components.Length; i++)
                        {
                            if (FretboardPlot.fretboard[current_string, current_fret].Note == Set.Components[i].Note)
                            {
                                FretboardPlot.fretboard[current_string, current_fret].Factor = Set.Steps[i - 1];
                            }
                        }
                    }
                }
            }

            string outcome = "";         

            for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
            {
                outcome += $" {CurrentString + 1}:  {FretboardPlot.fretboard[CurrentString, 0].FactorToString()}  ||";
                for (int CurrentFret = 1; CurrentFret < FretboardPlot.fretboard.GetLength(1); CurrentFret++) //FretIteration
                {

                    if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == null)
                    {
                        outcome += "-------|";
                    }
                    else if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == Interval.Root)
                    {
                        outcome += $"-({FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()})--|";
                    }
                    else
                    {
                        outcome += $"- {FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()} --|";
                    }
                }
                outcome += "\n";
            }

            return outcome;
        }

        public string Plot(Pitch Root, int[] Factors) //This Method was made to "match" the fret-size of "PlotAsNotes"a
        {
            HarmonicSet Set = new HarmonicSet(Root, Factors);
            Fretboard FretboardPlot = new Fretboard(this.NumberOfFrets, Tuning);

            //Sets Factor value for every Pitch in Fretboard.Plot.fretboard
            for (int current_string = 0; current_string < FretboardPlot.NumberOfStrings; current_string++)
            {
                for (int current_fret = 0; current_fret < FretboardPlot.fretboard.GetLength(1); current_fret++)
                {
                    if (FretboardPlot.fretboard[current_string, current_fret].Note == Root.Note)
                    {
                        FretboardPlot.fretboard[current_string, current_fret].Factor = 0;
                    }
                    else
                    {
                        for (int i = 1; i < Set.Components.Length; i++)
                        {
                            if (FretboardPlot.fretboard[current_string, current_fret].Note == Set.Components[i].Note)
                            {
                                FretboardPlot.fretboard[current_string, current_fret].Factor = Set.Steps[i - 1];
                            }
                        }
                    }
                }
            }

            string outcome = "";

            //Responsible only for printing it out as factors: :D
            for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
            {
                outcome += $" {CurrentString + 1}:  {FretboardPlot.fretboard[CurrentString, 0].FactorToString()}  ||";
                for (int CurrentFret = 1; CurrentFret < FretboardPlot.fretboard.GetLength(1); CurrentFret++) //FretIteration
                {

                    if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == null)
                    {
                        outcome += "-------|";
                    }
                    else if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == Interval.Root)
                    {
                        outcome += $"-({FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()})--|";
                    }
                    else
                    {
                        outcome += $"- {FretboardPlot.fretboard[CurrentString, CurrentFret].FactorToString()} --|";
                    }
                }
                outcome += "\n";
            }

            return outcome;
        }

        public string PlotAsNotes(Pitch Root, int[] Factor)
        {
            HarmonicSet Set = new HarmonicSet(Root, Factor);
            Fretboard FretboardPlot = new Fretboard(this.NumberOfFrets, Tuning);

            //Sets Factor value for every Pitch in Fretboard.Plot.fretboard
            for (int current_string = 0; current_string < FretboardPlot.NumberOfStrings; current_string++)
            {
                for (int current_fret = 0; current_fret < FretboardPlot.fretboard.GetLength(1); current_fret++)
                {
                    if (FretboardPlot.fretboard[current_string, current_fret].Note == Root.Note)
                    {
                        FretboardPlot.fretboard[current_string, current_fret].Factor = 0;
                    }
                    else
                    {
                        for (int i = 1; i < Set.Components.Length; i++)
                        {
                            if (FretboardPlot.fretboard[current_string, current_fret].Note == Set.Components[i].Note)
                            {
                                FretboardPlot.fretboard[current_string, current_fret].Factor = Set.Steps[i - 1];
                            }
                        }
                    }
                }
            }

            string outcome = "";
            
            //Responsible for printing out as notes:
            for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
            {
                //Console.Write($" {CurrentString + 1}: {FretboardPlot.fretboard[CurrentString, 0].FactorToString()}||");
                if (FretboardPlot.fretboard[CurrentString, 0].Factor == null)
                {
                    //Console.Write($" {CurrentString + 1}: \t||");
                    outcome += $" {CurrentString + 1}:      ||";
                }
                else
                {
                    Pitch temp = FretboardPlot.fretboard[CurrentString, 0];
                    bool tempIsSharp = (temp.Note == Notes.Csharp || temp.Note == Notes.Dsharp || temp.Note == Notes.Fsharp || temp.Note == Notes.Gsharp || temp.Note == Notes.Asharp);
                    if (tempIsSharp)
                    {
                        outcome += $" {CurrentString + 1}: {FretboardPlot.fretboard[CurrentString, 0]}||";
                    }
                    else
                    {
                        outcome += $" {CurrentString + 1}:   {FretboardPlot.fretboard[CurrentString, 0]}  ||";
                    }
                }

                for (int CurrentFret = 1; CurrentFret < FretboardPlot.fretboard.GetLength(1); CurrentFret++) //FretIteration
                {

                    if (FretboardPlot.fretboard[CurrentString, CurrentFret].Factor == null)
                    {
                        outcome += "-------|";
                    }
                    else
                    {
                        Pitch temp = FretboardPlot.fretboard[CurrentString, CurrentFret];
                        bool tempIsSharp = (temp.Note == Notes.Csharp || temp.Note == Notes.Dsharp || temp.Note == Notes.Fsharp || temp.Note == Notes.Gsharp || temp.Note == Notes.Asharp);
                        if (tempIsSharp)
                        {
                            outcome += $"-{FretboardPlot.fretboard[CurrentString, CurrentFret]}-|";
                        }
                        else
                        {
                            outcome += $"---{FretboardPlot.fretboard[CurrentString, CurrentFret]}---|";
                        }
                    }
                }
                outcome += "\n";
            }

            return outcome;
        }

        public string ShowFretboardMap()
        {
            string outcome = "";

            for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
            {

                {
                    Pitch temp = fretboard[CurrentString, 0];
                    bool tempIsSharp = (temp.Note == Notes.Csharp || temp.Note == Notes.Dsharp || temp.Note == Notes.Fsharp || temp.Note == Notes.Gsharp || temp.Note == Notes.Asharp);
                    if (tempIsSharp)
                    {
                        outcome += $" {CurrentString + 1}: {fretboard[CurrentString, 0]} ||";
                    }
                    else
                    {
                        outcome += $" {CurrentString + 1}:   {fretboard[CurrentString, 0]}   ||";
                    }
                }  //Writes the note on the 0 fret.
                for (int CurrentFret = 1; CurrentFret < fretboard.GetLength(1); CurrentFret++) //FretIteration
                {
                    {
                        Pitch temp = fretboard[CurrentString, CurrentFret];
                        bool tempIsSharp = (temp.Note == Notes.Csharp || temp.Note == Notes.Dsharp || temp.Note == Notes.Fsharp || temp.Note == Notes.Gsharp || temp.Note == Notes.Asharp);
                        if (tempIsSharp)
                        {
                            outcome += $"-{fretboard[CurrentString, CurrentFret]}-|";
                        }
                        else
                        {
                            outcome += $"---{fretboard[CurrentString, CurrentFret]}---|";
                        }
                    }
                    //outcome += $"{fretboard[CurrentString, CurrentFret]} \t");
                }
                outcome += "\n";
            }

            return outcome;
        }
    }
}
