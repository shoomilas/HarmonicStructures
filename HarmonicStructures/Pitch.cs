using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonicStructures.Interval;

namespace HarmonicStructures
{
	struct Pitch //TODO: implement Pitches that broader than just 11 notes, think, for example, a musical staff or 88 piano keys vs just 11.
	{
		private Notes note;
		public Notes Note
		{
			get { return note; }
			set //This property is responsible for making the Notes enum's cyclic behaviour.
			{
				if (value < 0)
				{
					note = (Notes)((12 + (int)value) % 12);
				}
				else
				{
					note = (Notes)((int)value % 12); 
				}
			}
		}

        //private int octave; //later on
        //private float bend; //later on, for 

		private int? factor; //Interval From Root / Step, e.g.: MajorThird for 'E' in CMaj7
		public int? Factor 
		{
			get { return factor; }
			set { factor = value; }
		}

		public Pitch(int i) : this()
		{
			Note = (Notes)i;
		}

		public Pitch(Notes i) : this()
		{
			Note = i;
		}

		public static Pitch operator +(Pitch Note1, int Note2)
		{
			return new Pitch( Note1.Note + Note2 );
		}

		public static Pitch operator -(Pitch SubNote1, int SubNote2) //TODO: !!! PITCH SUBTRACTING OVERLOAD 
		{
			//WORKS:
			//Console.WriteLine($"TEST: Odejmowanie Pitch - Int: {D - 2}");
			//Console.WriteLine($"TEST: Odejmowanie Pitch - Int: C - 3: {C - 3}");
			//Pitch PitchTestNegativeValues1 = new Pitch(-1);
			//Console.WriteLine($"TEST: Ujemne wartości w konstruktorze klasy Pitch: {PitchTestNegativeValues1}");
			//Pitch PitchTestNegativeValues2 = new Pitch(-3);
			//Console.WriteLine($"TEST: Ujemne wartości w konstruktorze klasy Pitch: {PitchTestNegativeValues2}");

			//DOESN'T WORK, MAKE IT WORK
			//Pitch PitchTestNegativeValues4 = new Pitch(D - 3);
			//Console.WriteLine($"TEST: Ujemne wartości w konstruktorze klasy Pitch: {PitchTestNegativeValues4}");

			//DOESN'T WORK (WHY?):
			//Pitch PitchTestNegativeValues3 = new Pitch(D.Note - 3); //Result is a -1 instead of B
			//Console.WriteLine($"TEST: Ujemne wartości w konstruktorze klasy Pitch: {PitchTestNegativeValues3}");
			//fretboard[CurrentString, CurrentFret] = (fretboard[CurrentString, CurrentFret - 1] + 1); // Works at first, but after going through B it goes 12, 13, 14, ...

			return new Pitch((int)(SubNote1.Note - SubNote2)); //TRY:  return new Pitch( ((int) SubNote1.Note) - ( (int) SubNote2)) );
		}

		public string FactorToString()
		{
			{
				string ReturnedValue;
				switch (Factor) //TODO: !!!! ONCE YOU GET TO MAKING GUI, GET THE NAMES BACK TO NORMAL (NO SPACES AND ASTERISKS).
				{
					case Root:
						ReturnedValue = "R*";
						break;
					case MinorSecond:
						ReturnedValue = "b2";
						break;
					case MajorSecond:
						ReturnedValue = "2 ";
						break;
					case MinorThird:
						ReturnedValue = "b3";
						break;
					case MajorThird:
						ReturnedValue = "3 ";
						break;
					case Fourth:
						ReturnedValue = "4 ";
						break;
					//case AugmentedFourth:
					//	ReturnedValue = "#4";
					//	break;
					case DiminishedFifth:
						ReturnedValue = "b5";
						break;
					case Fifth:
						ReturnedValue = "5 ";
						break;
					case AugmentedFifth:
						ReturnedValue = "#5";
						break;
					//case MinorSixth:
					//	ReturnedValue = "b6";
					//	break;
					case Sixth:
						ReturnedValue = "6 ";
						break;
					case MinorSeventh:
						ReturnedValue = "b7";
						break;
					case MajorSeventh:
						ReturnedValue = "7 ";
						break;
					case null:
						ReturnedValue = "  ";
						break;
					default:
						ReturnedValue = "? ";
						break;
				}
				return ReturnedValue;
			}
		}

		public override string ToString()
		{
			//return ($"{Note}");//<- This would return the 'name' of the Notes enum (e.g. "C", "Dsharp", etc.) - used in the default case below.
			{
				string ReturnedValue;
				switch (Note)
				{
					case Notes.Csharp:
						ReturnedValue = "C#/Db";
						break;
					case Notes.Dsharp:
						ReturnedValue = "D#/Eb";
						break;
					case Notes.Fsharp:
						ReturnedValue = "F#/Gb";
						break;
					case Notes.Gsharp:
						ReturnedValue = "G#/Ab";
						break;
					case Notes.Asharp:
						ReturnedValue = "A#/Bb";
						break;
					default:
						ReturnedValue = ($"{Note}");
						break;
				}
				return ReturnedValue;
			}
		}
	}


}