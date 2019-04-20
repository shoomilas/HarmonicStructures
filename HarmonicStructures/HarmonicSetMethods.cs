using System;
using System.Collections.Generic;
using System.Text;

namespace HarmonicStructures
{
    partial class HarmonicSet
    {
        //Just for testing purposes, before overriding ToString(). Example (printing Harmonic Minor Scale):
        //for (int i = 0; i < 12; i++) { new HarmonicSet((Notes) i, Scales.HarmonicMinor).Print(); }
        public void Print()
        {
            foreach (Pitch element in Components)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        } 

        public override string ToString()
        {
            string ReturnedValue = "";
            for (int i = 0; i < Components.Length; i++)
            {
                if (i == (Components.Length - 1))
                {
                    ReturnedValue += ($"{Components[i]}");
                }
                else
                {
                    ReturnedValue += ($"{Components[i]}, ");
                }
            }
            return ReturnedValue;
        }
    }
}
