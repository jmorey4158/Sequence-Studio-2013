//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2012 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without 
//express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio.Internal;

namespace SequenceStudio
{
    public static class PolyMethods
    {



        /// <summary>
        /// Calculates the residue statistics of the input Polypeptide.
        /// </summary>
        /// <param name="p">Poly class instance - the input Polypeptide.</param>
        /// <returns>Dictionary(String,Int32) - the residue statistics of the input polypeptide.</returns>
        public static Dictionary<String, Int32> Stats(Poly p)
        {
            List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
            String[] s_AA = new String[20];
            Int32 i = 0;
            foreach (AminoAcids.AminoAcidBase b in aa)
            {
                s_AA[i] = b.Initial.ToString();
                i++;
            }

            Dictionary<String, Int32> units = new Dictionary<String, Int32>();
            String seq = p.Sequence;
            Int32 count = 0;

            foreach (String s in s_AA)
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
        /// Calcualtes the molecular weight, in Daltons, of a specific polypeptide using the residue statistics.
        /// </summary>
        /// <param name="p">Poly instance, the polypeptide.</param>
        /// <returns>Double - the molecualr weight, in Daltons, of the polypeptide.</returns>
        public static Double MolWeight(Poly p)
        {
            List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
            Dictionary<String, Int32> stats = Stats(p);
            Double mol = 0;

            Double[] mols = new double[stats.Count];
            Int32 molsIndex = 0;
            foreach (KeyValuePair<string, int> kp in stats)
            {
                mols[molsIndex] = kp.Value;
                molsIndex++;
            }

            double[] vals = new double[aa.Count];
            Int32 valsIndex = 0;
            foreach (AminoAcids.AminoAcidBase b in aa)
            {
                vals[valsIndex] = b.MolecularWeight;
            }

            for (int loc = 0; loc <= vals.Length-1; loc++)
            {
                mol += (vals[loc] * mols[loc]);
            }
            return mol;
        }


        /// <summary>
        /// Generates a random DNA sequence of the given length.
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <returns>String, the returned semi-random sequence</returns>
        public static String GenerateRandomStrand(Int32 n)
        {

            String pattern = "ACDEFGHIKLMNPQRSTVWY";
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
                pattern = "ACDEFGHIKLMNPQRSTVWY"; // you can alter the ratios of polypeptides by altering the ratios in this string.
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
        /// Generates a consensus DNA source sequence for the input polypeptide
        /// </summary>
        /// <param name="poly">String, a valid polypeptide strand</param>
        /// <returns>String, the consensus source sequence</returns>
        public static String ConsensusSourceSequence(Poly poly)
        {
            String polypeptide = poly.Sequence;
            Int32 len = polypeptide.Length;
            StringBuilder sb = new StringBuilder();

            for (int index = 0; index <= len - 1; index++)
            {
                #region Switch
                switch (polypeptide.Substring(index, 1))
                {
                    case "A": //Alanine
                        sb.Append("GCN");
                        break;

                    case "C": //Cysteine
                        sb.Append("UG[T|C]");
                        break;

                    case "D": //Aspartic Acid
                        sb.Append("GA[T|C]");
                        break;

                    case "E": //Glutamic Acid
                        sb.Append("GA[A|G]");
                        break;

                    case "F": //Phenylalanine
                        sb.Append("TT[T|C]");
                        break;

                    case "G": //Glycine
                        sb.Append("GGN");
                        break;

                    case "H": //Histidine
                        sb.Append("CA[T|C]");
                        break;

                    case "I": //Isoleucine
                        sb.Append("AT[T|C|A]");
                        break;

                    case "K": //Lysine
                        sb.Append("AA[A|G]");
                        break;

                    case "L": //Leucine
                        sb.Append("CTN|[TT[A|G]]");
                        break;

                    case "M": //Methionine
                        sb.Append("ATG");
                        break;

                    case "N": //Asparagine
                        sb.Append("AA[T|C]");
                        break;

                    case "P": //Proline
                        sb.Append("CCN");
                        break;

                    case "Q": //Glutamine
                        sb.Append("CA[A|G]");
                        break;

                    case "R": //Arginine
                        sb.Append("CGN|[AG[A|G]]");
                        break;

                    case "S": //Serine
                        sb.Append("TCN|[AG[T|C]]");
                        break;

                    case "T": //Threonine
                        sb.Append("ACN");
                        break;

                    case "V": //Valine
                        sb.Append("GTN");
                        break;

                    case "W": //Tryptophan
                        sb.Append("TGG");
                        break;

                    case "Y": //Tyrosine
                        sb.Append("TA[T|C]");
                        break;

                    case "X": //STOP
                        sb.Append("TA[A|G]|[TGA]");
                        break;

                    case "+": //START
                        sb.Append("ATG");
                        break;

                    default:
                        break;
                }
                #endregion

                sb.Append(" + ");
            }
            return sb.ToString();
        }


    }


    public class PolyStats
    {

        protected readonly Double _mol;
        protected readonly Dictionary<String, Int32> _units;

        public PolyStats(Poly p)
        {

            this._units = PolyMethods.Stats(p);
            this._mol = PolyMethods.MolWeight(p);
        }

        #region Properties

        public Dictionary<String, Int32> Stats
        {
            get { return _units; }
        }

        public Double MolWeight
        {
            get { return _mol; }
        }

        #endregion

        public String Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Molecular Weight (Daltons): " + this.MolWeight.ToString() + "\n");
            sb.Append("Residue Composition:\n");
            foreach (KeyValuePair<string, int> kp in Stats)
            {
                sb.Append("\t" + kp.Key + ": " + kp.Value + "\n");
            }
            return sb.ToString();
        }

    }


    public class PolyProps
    {
        private Guid _id;
        private String _consensus;
        private Double _mw;
        private Dictionary<String, Int32> _stats;


        protected PolyProps() { }

        public PolyProps(Poly p)
        {
            _id = p.ID;
            _consensus = PolyMethods.ConsensusSourceSequence(p);
            _mw = PolyMethods.MolWeight(p);
            _stats = PolyMethods.Stats(p);
        }


        #region Properties

        public Guid ID
        {
            get { return _id; }
        }


        public String ConsensusSource
        {
            get { return _consensus; }
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
