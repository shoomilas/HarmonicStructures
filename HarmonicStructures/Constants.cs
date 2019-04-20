using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonicStructures.Interval;

//NOTE: About the chords
// I'm not implementing extended chords like #11, 9, etc. right now. Essentially, it what Ted Greene wrote in 'Chord Chemistry': "On the guitar (...) SO IT'S JUST DUE TO TRADITION THAT THEY ARE STILL CALLED 9, 11, 13 AS OPPOSED TO 2, 4, 6" 

//NOTE: Possible ways to 'add' new chords/scales:
//public static readonly int[] Min7 = { 3, 7, 10 };  
//public static readonly int[] Min7 = { MajorThird, Fifth, MinorSeventh }; 
//public static readonly Intervals[] Min7 = { Intervals.MinorThird, Intervals.Fifth, Intervals.MinorSeventh };

namespace HarmonicStructures
{
	public enum Intervals
	{
		Root = 0,       //0 semitones
		MinorSecond,    //1 semitones
		MajorSecond,    //2 semitones
		MinorThird,     //3 
		MajorThird,     //4
		Fourth,         //5
		DiminishedFifth,//6
		Fifth,          //7
		AugmentedFifth, //8
		Sixth,          //9
		MinorSeventh,
		MajorSeventh,
		Octave,         //12
		MinorNinth,     //13
		MajorNinth,     //14
		MinorTenth,     
		MajorTenth,     //16
	}

	enum Notes // C, Csharp, D, ... : Contains the note names which are implemented in Pitch type.
	{
		C = 0,
		Csharp,
		D,
		Dsharp,
		E,
		F,
		Fsharp,
		G,
		Gsharp,
		A,
		Asharp,
		B
	}

    class Pitches
	{
		public static readonly Pitch C = new Pitch(Notes.C);
		public static readonly Pitch Csharp = new Pitch(Notes.Csharp);
		public static readonly Pitch D = new Pitch(Notes.D);
		public static readonly Pitch Dsharp = new Pitch(Notes.Dsharp);
		public static readonly Pitch E = new Pitch(Notes.E);
		public static readonly Pitch F = new Pitch(Notes.F);
		public static readonly Pitch Fsharp = new Pitch(Notes.Fsharp);
		public static readonly Pitch G = new Pitch(Notes.G);
		public static readonly Pitch Gsharp = new Pitch(Notes.Gsharp);
		public static readonly Pitch A = new Pitch(Notes.A);
		public static readonly Pitch Asharp = new Pitch(Notes.Asharp);
		public static readonly Pitch B = new Pitch(Notes.B);

		//public static implicit operator object? (Pitches v)
		//{
		//	throw new NotImplementedException();
		//}
	}

	public static class Interval
	{
		public const int Root = 0; //0 semitones
		public const int MinorSecond = 1;
		public const int MajorSecond = 2;
		public const int MinorThird = 3;
		public const int MajorThird = 4;
		public const int Fourth = 5;
		public const int AugmentedFourth = 5;
		public const int DiminishedFifth = 6;
		public const int Fifth = 7;
		public const int AugmentedFifth = 8;
		public const int MinorSixth = 8;
		public const int Sixth = 9;
		public const int MinorSeventh = 10;
		public const int MajorSeventh = 11;
		public const int Octave = 12;
		public const int MinorNinth = 13;
		public const int MajorNinth = 14;
		public const int AugmentedNinth = 15; //or Minor Tenth
		public const int MajorTenth = 16;
		public const int Eleventh = 17; //... check wiki for more
	}

	public static class Scales
	{
		//TODO: Change degree's names so that they're harmonically correct, e.g. lydian's #4 instead of b5. etc.

		//CHROMATIC:
		public static readonly int[] Chromatic = { MinorSecond, MajorSecond, MinorThird, MajorThird, Fourth, DiminishedFifth, Fifth, AugmentedFifth, Sixth, MinorSeventh, MajorSeventh };
		
		//Pentatonic
		public static readonly int[] MajorPentatonic = { MajorSecond, MajorThird, Fifth, Sixth };
		public static readonly int[] MinorPentatonic = { MinorThird, Fourth, Fifth, MinorSeventh };

		//Major Scale modes
		public static readonly int[] Major = { MajorSecond, MajorThird, Fourth, Fifth, Sixth, MajorSeventh };
		public static readonly int[] Major_2_Dorian = { MajorSecond, MinorThird, Fourth, Fifth, Sixth, MinorSeventh };
		public static readonly int[] Major_3_Phrygian = { MinorSecond, MinorThird, Fourth, Fifth, DiminishedFifth, MinorSeventh };
		public static readonly int[] Major_4_Lydian = { MajorSecond, MajorThird, DiminishedFifth, Fifth, Sixth, MajorSeventh };
		public static readonly int[] Major_5_Mixolydian = { MajorSecond, MajorThird, Fourth, Fifth, Sixth, MinorSeventh };
		public static readonly int[] Major_6_Aeolian = { MajorSecond, MinorThird, Fourth, Fifth, Sixth, MinorSeventh };
		public static readonly int[] Major_7_Locrian = { MinorSecond, MinorThird, Fourth, DiminishedFifth, AugmentedFifth, MinorSeventh };

		//TODO: Natural Melodic Minor's modes
		public static readonly int[] MelodicMinor = { MajorSecond, MinorThird, Fourth, Fifth, Sixth, MinorSeventh };

		//TODO: Harmonic Minor Modes
		public static readonly int[] HarmonicMinor = { MajorSecond, MinorThird, Fourth, Fifth, MinorSixth, MajorSeventh };
	}

	public static class Chords //TODO: When you'll be writing piano keyboard mapping - consider adding extended chords support.
	{
		//Template: public static readonly int[] NAME = { ... };
		public static readonly int[] Maj = { MajorThird, Fifth };
		public static readonly int[] Min = { MinorThird, Fifth };
		public static readonly int[] Dim = { MinorThird, DiminishedFifth };
		public static readonly int[] Aug = { MajorThird, AugmentedFifth };

		public static readonly int[] Maj7 = { MajorThird, Fifth, MajorSeventh};
		public static readonly int[] _7 = { MajorThird, Fifth, MinorSeventh };
		public static readonly int[] min7 = { MinorThird, Fifth, MinorSeventh };
		public static readonly int[] dim7 = { MinorThird, DiminishedFifth, Sixth };
		public static readonly int[] m7b5 = { MinorThird, DiminishedFifth, MinorSeventh };

		public static readonly int[] sus2 = { MajorSecond, Fifth };
		public static readonly int[] _7sus4 = { Fourth, Fifth, MinorSeventh};
	}
}

//enum Notes : int //Contains the note names which are implemented in Pitch type.
//{
//	C = 0,
//	C_D, //C#/Db, shorter notation meaning "something between C and D", "C#" notation won't be able to denote harmonic context
//	D,
//	D_E,
//	E,
//	F,
//	F_G,
//	G,
//	G_A,
//	A,
//	A_B,
//	B
//} // C, C_D, D, ...
