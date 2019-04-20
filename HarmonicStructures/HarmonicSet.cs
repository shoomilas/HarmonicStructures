using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmonicStructures
{
    //HarmonicSet.cs                    main class file
    //HarmonicSetMethods.cs             methods
	partial class HarmonicSet
	{
		private bool IsRootless = false; //TODO: private Pitch root;
		public Pitch Root { get; set; } 
        public int[] Steps { get; set; } //TODO: private int[] steps;
        public int[] AllSteps { get; set; } //including Root's 0 at the start.
		private Pitch[] components;
		public Pitch[] Components { get => components; set => components = value; }

		public HarmonicSet(Pitch Root, params int[] steps)
		{
			this.Root = Root;
			this.Components = new Pitch[(1 + steps.Length)];
			this.Components[0] = Root;

			if (steps.Length > 0)
			{
				for (int i = 1; i <= steps.Length; i++)
				{
					Components[i] = new Pitch((Root.Note) + (steps[i - 1]));
				}
				this.Steps = steps;
				for (int i = 0; i < (steps.Length); i++)
				{
					this.Steps[i] = (int)(steps[i]);
				}
			}
			if (steps.Length == 0)
			{ 
				throw new ArgumentOutOfRangeException("Exception : HarmonicSet() : A single note is not a harmonic set.");
			} 
		}

		public HarmonicSet(Pitch Root, params Intervals[] steps)
		{
			this.Root = Root;
			this.Components = new Pitch[(1 + steps.Length)];
			this.Components[0] = this.Root;

			this.Steps = new int[steps.Length];
			if (steps.Length > 0) //Just a preventive measure
			{
				for (int i = 1; i <= steps.Length; i++) 
				{
					Components[i] = new Pitch((Root.Note) + ((int)steps[i - 1]));
				}
				for (int i = 0; i < (steps.Length); i++) 
				{
					this.Steps[i] = (int)(steps[i]);
				}
			}
			if (steps.Length == 0)
			{
				throw new ArgumentOutOfRangeException("Exception : HarmonicSet() : A single note is not a harmonic set.");
			}
		}

		public HarmonicSet(Notes Root, params int[] steps) //Very rare usage
		{
			this.Root = new Pitch(Root);
			this.Steps = steps;
			this.Components = new Pitch[(1 + steps.Length)];
			this.Components[0] = this.Root;

			if (steps.Length > 0)
			{
				for (int i = 1; i <= steps.Length; i++)
				{
					Components[i] = new Pitch((Root) + steps[i - 1]);
				}
			}
		}
	}
}