//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio.Internal;

namespace SequenceStudio
{
   public class RnaMethods
    {

        /// <summary>
        /// Translates the input into a polypeptide strand (String).
        /// </summary>
        /// <param name="r">RNA class instance - the DNA sequence to translate into poypeptide seuence.</param>
        /// <returns>String - the polypeptide sequence in Inital format.</returns>
        /// <remarks>This method does not validate that the input string is a DNA sequence. If 
        /// another string is put in the results will be invalid.</remarks>
        public static String Translate(RNA r)
        {
            String seq = r.Sequence;

            StringBuilder sb = new StringBuilder();
            for (Int32 index = 0; index <= seq.Length - 3; index += 3)
            {
                #region SWITCH
                switch (seq.Substring(index, 3))
                {

                    case "GCU":
                        sb.Append("A");
                        break;
                    case "GCC":
                        sb.Append("A");
                        break;
                    case "GCA":
                        sb.Append("A");
                        break;
                    case "GCG":
                        sb.Append("A");
                        break;


                    case "UGU":
                        sb.Append("C");
                        break;
                    case "UGC":
                        sb.Append("C");
                        break;


                    case "GAU":
                        sb.Append("D");
                        break;
                    case "GAC":
                        sb.Append("D");
                        break;


                    case "GAA":
                        sb.Append("E");
                        break;
                    case "GAG":
                        sb.Append("E");
                        break;


                    case "UUU":
                        sb.Append("F");
                        break;
                    case "UUC":
                        sb.Append("F");
                        break;


                    case "GGU":
                        sb.Append("G");
                        break;
                    case "GGC":
                        sb.Append("G");
                        break;
                    case "GGA":
                        sb.Append("G");
                        break;
                    case "GGG":
                        sb.Append("G");
                        break;


                    case "CAU":
                        sb.Append("H");
                        break;
                    case "CAC":
                        sb.Append("H");
                        break;


                    case "AUU":
                        sb.Append("I");
                        break;
                    case "AUC":
                        sb.Append("I");
                        break;
                    case "AUA":
                        sb.Append("I");
                        break;


                    case "AAA":
                        sb.Append("K");
                        break;
                    case "AAG":
                        sb.Append("K");
                        break;


                    case "UUA":
                        sb.Append("L");
                        break;
                    case "UUG":
                        sb.Append("L");
                        break;
                    case "CUU":
                        sb.Append("L");
                        break;
                    case "CUC":
                        sb.Append("L");
                        break;
                    case "CUA":
                        sb.Append("L");
                        break;
                    case "CUG":
                        sb.Append("L");
                        break;


                    case "AUG":
                        sb.Append("M");
                        break;


                    case "AAU":
                        sb.Append("N");
                        break;
                    case "AAC":
                        sb.Append("N");
                        break;


                    case "CCU":
                        sb.Append("P");
                        break;
                    case "CCC":
                        sb.Append("P");
                        break;
                    case "CCA":
                        sb.Append("P");
                        break;
                    case "CCG":
                        sb.Append("P");
                        break;


                    case "CAA":
                        sb.Append("Q");
                        break;
                    case "CAG":
                        sb.Append("Q");
                        break;


                    case "CGU":
                        sb.Append("R");
                        break;
                    case "CGC":
                        sb.Append("R");
                        break;
                    case "CGA":
                        sb.Append("R");
                        break;
                    case "CGG":
                        sb.Append("R");
                        break;
                    case "AGA":
                        sb.Append("R");
                        break;
                    case "AGG":
                        sb.Append("R");
                        break;


                    case "UCU":
                        sb.Append("S");
                        break;
                    case "UCC":
                        sb.Append("S");
                        break;
                    case "UCA":
                        sb.Append("S");
                        break;
                    case "UCG":
                        sb.Append("S");
                        break;
                    case "AGU":
                        sb.Append("S");
                        break;
                    case "AGC":
                        sb.Append("S");
                        break;


                    case "ACU":
                        sb.Append("T");
                        break;
                    case "ACC":
                        sb.Append("T");
                        break;
                    case "ACA":
                        sb.Append("T");
                        break;
                    case "ACG":
                        sb.Append("T");
                        break;


                    case "UGA":
                        sb.Append("U");
                        break;


                    case "GUU":
                        sb.Append("V");
                        break;
                    case "GUC":
                        sb.Append("V");
                        break;
                    case "GUA":
                        sb.Append("V");
                        break;
                    case "GUG":
                        sb.Append("V");
                        break;


                    case "UGG":
                        sb.Append("W");
                        break;


                    case "UAU":
                        sb.Append("Y");
                        break;
                    case "UAC":
                        sb.Append("Y");
                        break;


                    case "UAA":
                        sb.Append("*");
                        break;
                    case "UAG":
                        sb.Append("*");
                        break;

                    default:
                        sb.Append("_");
                        break;
                }
                #endregion
            }
            return sb.ToString();
        }



        /// <summary>
        /// Calculates the residue statistics of the input RNA strand.
        /// </summary>
        /// <param name="r">RNA - the input RNA strand.</param>
        /// <returns>Dictionary(String,Int32) - the residue statistics of the input RNA strand.</returns>
        public static Dictionary<String, Int32> Stats(RNA r)
        {
            Dictionary<String, Int32> units = new Dictionary<String, Int32>();
            Int32 count = 0;
            String[] s_RNA = new String[4] { "A", "U", "C", "G" };
            String seq = r.Sequence;

            foreach (String s in s_RNA)
            {
                for (Int32 index = 0; index < seq.Length - 1; ++index)
                {
                    if (seq.Substring(index, 1) == s)
                    {
                        count++;
                    }
                }
                units.Add(s, count);
                count = 0;
            }
            return units;
        }


        /// <summary>
        /// Calcualtes the molecular weight, in Daltons, of a specific RNA sequence.
        /// </summary>
        /// <param name="r">RNA calss instance the RNA sequence.</param>
        /// <returns>Double - the molecualr weight, in Daltons, of the RNA sequence.</returns>
        public static Double MolWeight(RNA r)
        {
            Double molWeight = 0.0;
            Dictionary<String, Int32> stats = Stats(r);

            foreach (KeyValuePair<String, Int32> kp in stats)
            {
                switch (kp.Key)
                {
                    case "A":
                        molWeight += (297.21 * (Double)(kp.Value));
                        break;
                    case "C":
                        molWeight += (273.19 * (Double)(kp.Value));
                        break;
                    case "U":
                        molWeight += (112.09 * (Double)(kp.Value));
                        break;
                    case "G":
                        molWeight += (313.21 * (Double)(kp.Value));
                        break;
                    default:
                        break;
                }
            }

            return molWeight;
        }


        /// <summary>
        /// Calculates the anti-strand for the input RNA strand.
        /// </summary>
        /// <param name="r">RNA class instance - the RNA strand.</param>
        /// <returns>String - the anti-strand.</returns>
        public static String CompStrand(RNA r)
        {
            StringBuilder sb = new StringBuilder();
            String seq = r.Sequence;

            for (Int32 index = 0; index <= seq.Length - 1; index++)
            {
                switch (seq.Substring(index, 1))
                {
                    case "A":
                        sb.Append("U");
                        break;
                    case "C":
                        sb.Append("G");
                        break;
                    case "U":
                        sb.Append("A");
                        break;
                    case "G":
                        sb.Append("C");
                        break;
                    case "N":
                        sb.Append("N");
                        break;
                    default:
                        break;
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Calculates the complimentary for the input DNA strand and then orients it in the same 
        /// orientation as the input strand.
        /// </summary>
        /// <param name="d">Internal.DNA class instance - the DNA strand.</param>
        /// <returns>String - the complimentary strand.</returns>
        public static String ReverseCompStrand(RNA r)
        {
            StringBuilder sb = new StringBuilder();
            String seq = CompStrand(r);

            for (Int32 index = seq.Length - 1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }
            return sb.ToString();
        }



        /// <summary>
        /// Generates a 'doped' random sequence of the type given of the given length
        /// NOTE - this method will return a sequence of any type, the pattern determinig the outcome
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <param name="pattern">String, type of sequence and units; use this to 'dope' the strand </param>
        /// <returns>String, the returned semi-random sequence</returns>
        public static String GenerateRandomDopedStrand(Int32 n, String pattern)
        {
            if (String.IsNullOrEmpty(pattern))
            {
                pattern = "ACUG"; // you can alter the ratios of nucleotides by altering the ratios in this string.
            }
            String s;
            StringBuilder seq = new StringBuilder();

            Random rnd = new Random();
            Int32 r;

            // I could not figure out a way to do something like StringBuilder.CLear()
            // so I made up this way.
            seq.Remove(0, seq.Length);
            for (int i = 1; i <= n; i++)
            {
                r = rnd.Next(0, pattern.Length);
                seq.Append(pattern.Substring(r, 1));
                //After debugging, I decided to break this out into 2 statements...
                // ... in the confusion of "seq.Append(code.Substring(rnd.Next(0, code.Length),1))"
                //... I forgot to add the second param to ToString(int, int) and generated really long strings.
                // Breaking it into two statements makes things a little more clear.
            }
            s = seq.ToString().ToUpper();
            return s;
        }


        /// <summary>
        /// Generates a random sequence of the type given of the given length
        /// NOTE - this method will return a sequence of any type, the pattern determinig the outcome
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <returns>String, the returned semi-random sequence</returns>
        public static String GenerateRandomStrand(Int32 n)
        {

            String pattern = "ACUG";
            String s;
            StringBuilder seq = new StringBuilder();
            Random rnd = new Random();
            Int32 r;

            seq.Clear();

            for (int i = 1; i <= n; i++)
            {
                r = rnd.Next(0, pattern.Length);
                seq.Append(pattern.Substring(r, 1));
            }
            s = seq.ToString().ToUpper();
            return s;
        }




        /// <summary>
        /// Trascribes the input <paramref name="seq"/> DNA sequence into an RNA sequence.
        /// </summary>
        /// <param name="seq">Internal.RNA class instance - the RNA sequence to transcribe.</param>
        /// <returns>String - the RNA sequence.</returns>
        public static DNA ReverseTranscribe(RNA r)
        {
            StringBuilder sb = new StringBuilder();
            String seq = r.Sequence;

            for (Int32 index = 0; index <= seq.Length - 1; index++)
            {
                if ((seq.Substring(index, 1)) == "U")
                {
                    sb.Append("T");
                }
                else
                {
                    sb.Append(seq.Substring(index, 1));
                }
            }
            return new DNA(Guid.NewGuid(), "", "", "", "", "", (sb.ToString()));
        }

    }


    public class RNAStats
    {
        protected readonly String _gene;
        protected readonly String _compStrand;
        protected readonly Double _mol;
        protected readonly Dictionary<String, Int32> _units;

        public RNAStats(RNA r)
        {
            this._compStrand = RnaMethods.CompStrand(r);
            this._units = RnaMethods.Stats(r);
            this._gene = RnaMethods.Translate(r);
            this._mol = RnaMethods.MolWeight(r);
        }

        #region Properties

        public String Gene
        {
            get { return _gene; }
        }

        public Dictionary<String, Int32> Stats
        {
            get { return _units; }
        }

        public String CompStrand
        {
            get { return _compStrand; }
        }

        public Double MolWeight
        {
            get { return _mol; }
        }

        #endregion

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Anti-Strand: " + this.CompStrand.ToString() + "\n");
            sb.Append("Molecular Weight (Daltons): " + this.MolWeight.ToString() + "\n");
            sb.Append("Residue Composition:\n");
            foreach (KeyValuePair<string, int> kp in Stats)
            {
                sb.Append("\t" + kp.Key + ": " + kp.Value + "\n");
            }
            sb.Append("Gene: " + this.Gene.ToString() + "\n\n");
            return sb.ToString();
        }

    }


    public class RNAProps
    {
        private Guid _id;
        private String _comp;
        private String _translate;
        private Double _mw;
        private Dictionary<String, Int32> _stats;


        protected RNAProps() { }

        public RNAProps(RNA r)
        {
            _id = r.ID;
            _comp = RnaMethods.CompStrand(r);
            _translate = RnaMethods.Translate(r);
            _mw = RnaMethods.MolWeight(r);
            _stats = RnaMethods.Stats(r);
        }


        #region Properties

        public Guid ID
        {
            get { return _id; }
        }


        public String Compliment
        {
            get { return _comp; }
        }


        public String Tranlation
        {
            get { return _translate; }
        }


        public Double MolWeight
        {
            get { return _mw; }
        }

        public Dictionary<String, Int32> Stats
        {
            get { return _stats; }
        }

        #endregion

    }

}
