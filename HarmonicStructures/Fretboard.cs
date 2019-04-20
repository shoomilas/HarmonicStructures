using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicStructures
{
    //Fretboard.cs                    main class file; props and constructors
    //FretboardMethods.cs             methods (Plot(), etc.)
    partial class Fretboard
	{
		private Pitch[] Tuning;
		private int NumberOfStrings { get; set; }
		private int NumberOfFrets { get; set; } = 12; //default value for Number of Frets
		private Pitch[,] fretboard;

		public Fretboard(params Pitch[] Tuning) //Constructor that will assign notes to frets on a guitar, dynamically (accordingly to guitar's number of strings and tuning).
		{
			this.Tuning = Tuning; // Might be useful
			this.NumberOfStrings = Tuning.Length;
			fretboard = new Pitch[NumberOfStrings, NumberOfFrets + 1]; // +1 so that it doesn't count from 0.

			{
				int string_index = 0;
				for (int i = NumberOfStrings - 1; i >= 0; i--)
				{
					this.fretboard[string_index, 0] = Tuning[i];
					string_index++;
				}

			} //Assigned the notes from Tuning to the fretboard[,] array's 0-frets.

			{
				for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
				{
					for (int CurrentFret = 1; CurrentFret < fretboard.GetLength(1); CurrentFret++) //FretIteration
					{
						fretboard[CurrentString, CurrentFret].Note = (fretboard[CurrentString, CurrentFret - 1].Note + 1);
					}
				}
			} //Using the Tuning[] table, assigned the next notes for the whole fretboard[,] array.
		}

		public Fretboard(int NumberOfFrets, params Pitch[] Tuning)
		{
			this.NumberOfFrets = NumberOfFrets;
			this.Tuning = Tuning; //For later usage
			this.NumberOfStrings = Tuning.Length;
			fretboard = new Pitch[NumberOfStrings, NumberOfFrets + 1]; //+1 so it's "human readable" number of frets, not starting from 0.

			{
				int string_index = 0;
				for (int i = NumberOfStrings - 1; i >= 0; i--)
				{
					this.fretboard[string_index, 0] = Tuning[i];
					string_index++;
				}

			} //Assigned the notes from tuning to the fretboard[,] array.

			{
				for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
				{
					for (int CurrentFret = 1; CurrentFret < fretboard.GetLength(1); CurrentFret++) //FretIteration
					{
						fretboard[CurrentString, CurrentFret].Note = (fretboard[CurrentString, CurrentFret - 1].Note + 1);
					}
				}
			} //Using the Tuning[] table, assigned the next notes for the whole fretboard[,] array.

		}

		public Fretboard(params Notes[] Tuning)
		{
			this.NumberOfFrets = NumberOfFrets;
			for (int i = 0; i < Tuning.Length; i++)
			{
				this.Tuning[i].Note = Tuning[i];
			}
			this.NumberOfStrings = Tuning.Length;
			fretboard = new Pitch[NumberOfStrings, NumberOfFrets]; 

			{
				int string_index = 0;
				for (int i = NumberOfStrings - 1; i >= 0; i--)
				{
					this.fretboard[string_index, 0] = this.Tuning[i];
					string_index++;
				}

			} //Assigns the notes from tuning to the fretboard[,] array.

			{
				for (int CurrentString = 0; CurrentString < NumberOfStrings; CurrentString++) //StringIteration
				{
					for (int CurrentFret = 1; CurrentFret < fretboard.GetLength(1); CurrentFret++) //FretIteration
					{
						fretboard[CurrentString, CurrentFret].Note = (fretboard[CurrentString, CurrentFret - 1].Note + 1);
					}
				}
			} //Using the Tuning[] table, assigns the next notes for the whole fretboard[,] array.

		}
	}
}