using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonicStructures
{
    class StringTools
    {
        public static Pitch[] StringToPitches(string tuning)
        {
            List<Pitch> pitchesList = new List<Pitch>();
            string[] stringPitches = tuning.Split(' ');
            foreach(string p in stringPitches)
            {
                pitchesList.Add(StringToPitch(p));
            }
            //Pitch[] pitchesArray = ;
            return pitchesList.ToArray();
        }

        private static Pitch StringToPitch(string singlePitch)
        {
            return (singlePitch) switch
            {
                "C"  => new Pitch(Notes.C),
                "C#" => new Pitch(Notes.Csharp),                
                "Cs" => new Pitch(Notes.Csharp),
                "Db" => new Pitch(Notes.Csharp),

                "D"  => new Pitch(Notes.D),
                "D#" => new Pitch(Notes.Dsharp),
                "Ds" => new Pitch(Notes.Dsharp),
                "Eb" => new Pitch(Notes.Dsharp),

                "E"  => new Pitch(Notes.E),
                "E#" => new Pitch(Notes.F),
                "Es" => new Pitch(Notes.F),
                "Fb" => new Pitch(Notes.E),

                "F" =>  new Pitch(Notes.F),
                "F#" => new Pitch(Notes.Fsharp),
                "Fs" => new Pitch(Notes.Fsharp),
                "Gb" => new Pitch(Notes.Fsharp),

                "G" => new Pitch(Notes.G),
                "G#" => new Pitch(Notes.Gsharp),
                "Gs" => new Pitch(Notes.Gsharp),
                "Ab" => new Pitch(Notes.Gsharp),

                "A" => new Pitch(Notes.A),
                "A#" => new Pitch(Notes.Asharp),
                "As" => new Pitch(Notes.Asharp),
                "Bb" => new Pitch(Notes.Asharp),

                "B" => new Pitch(Notes.B),
                "B#" => new Pitch(Notes.C),
                "Bs" => new Pitch(Notes.C),
                "Cb" => new Pitch(Notes.B),
            };
        }
    }
}
