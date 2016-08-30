//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio;
using SequenceStudio.Internal;



[assembly: CLSCompliant(true)]
namespace SequenceStudio
{
    public static class ORFMethods
    {
        /// <summary>
        /// Returns the longest Open Reading Frame for the sequence, if there is one.
        /// To get actual sequence of ORFMethods pass results to GenerateORFs().
        /// </summary>
        /// <param name="d">FASTASequence containing the sequence</param>
        /// <returns>Dictionary(Int32, Int32) that is the longest ORFMethods locus and length.</returns>
        public static Dictionary<Int32, Int32> GetLongestORF(DNA d)
        {
            Dictionary<Int32, Int32> frames = new Dictionary<Int32, Int32>();
            String seq = d.Sequence;

            Int32 go = 0;
            Int32 stop = seq.Length - 3;

            //find first START codon on sequence
            while ((go + 3 < seq.Length) && (seq.Substring(go, 3) != "ATG"))
            {
                go++;
            }

            //find first START codon on sequence
            while ((stop >= go) && (seq.Substring(stop, 3) != "TAG"))
            {
                stop--;
            }

            if (stop - go > 6)
            {
                frames.Add(go, stop - go);
            }

            //This prevents the 'SEquence ahs not elements' error when dealing with a Null Dictionary<>
            if (frames.Count == 0)
            {
                frames.Add(0, 0);
            }
            return frames;

        }


        /// <summary>
        /// Finds all the non-overlapping ORFs in the sequence and returns a list of their loci and lengths.
        /// To get the actual sequnces of the ORFs pass the resutls to GenerateORFs().
        /// </summary>
        /// <param name="d">FASTASequence containing the sequence</param>
        /// <param name="minLen">Int32 - the minimum length of ORFMethods to return.</param>
        /// <returns>Dictionary(Int32, Int32) - list of the loci and lengths of the ORFs found.</returns>
        public static Dictionary<Int32, Int32> GetContiguousORFList(DNA d, Int32 minLen)
        {

            if (minLen > d.Sequence.Length) 
            {
                SequenceParameterException pe = new SequenceParameterException();
                pe.ContextMessage = "The minimum ORF length specified was longer than the sequence length.";
                throw pe;
            }
            
            Dictionary<Int32, Int32> frames = new Dictionary<Int32, Int32>();
            String seq = d.Sequence;
            Int32 endOfSequence = seq.Length;
            Int32 locus = 0;
            Int32 stopCodon = 0;

            minLen = (minLen < 0) ? 0 : minLen;

            while (locus <= endOfSequence)
            {
                //find START codon on sequence
                while ((locus + 6 <= endOfSequence) && (seq.Substring(locus, 3) != "ATG"))
                {
                    locus++;
                }

                stopCodon = locus + 3;

                //find STOP codon on sequence
                while ((stopCodon + 3 <= endOfSequence) && (seq.Substring(stopCodon, 3) != "TAG"))
                {
                    stopCodon ++;
                }

                if (stopCodon + 3 <= endOfSequence)
                {
                    stopCodon += 3;
                }
                else
                {
                    break;
                }


                if (stopCodon - locus >= minLen)
                {
                    frames.Add(locus, stopCodon - locus);

                }

                locus = stopCodon;

            }

            //This prevents the 'Sequence has not elements' error when dealing with a Null Dictionary<>
            if (frames.Count == 0)
            {
                frames.Add(0, 0);
            }

            return frames;

        }


        /// <summary>
        /// Returns Dictionary(Int32, String) the actiual ORFMethods sequences when given a list of
        /// the locus and length, and the sequence that has the ORFs.
        /// </summary>
        /// <param name="list">Dictionary(Int32, Int32) - the list of locus / length pairs</param>
        /// <param name="d">DNA class instance -  seq.Sequence is the DNA sequence on which the ORFs are found.</param>
        /// <returns>Dictionary(Int32, String) - list of all ORFs on the DNA strand specified by the input list.</returns> 
        /// <remarks>This method assumes that there ar no overlapping ORFs, that is there are no ORFs with the same 
        /// starting point, or locus. If you need to generate the ORF sequences for ORFs with the same locus, use 
        /// public static List(KeyValuePair(Int32, String)) GenerateORFs(List(KeyValuePair(Int32, Int32)) list, DNA seq.</remarks>
        public static Dictionary<Int32, String> GenerateNonOverlappingORFs(Dictionary<Int32, Int32> list, DNA d)
        {
            Dictionary<Int32, String> refs = new Dictionary<Int32, String>();
            String s = d.Sequence;

            foreach (KeyValuePair<Int32, Int32> kp in list)
            {
                //make sure that the segment does not produce OutOfRange eexception
                if (kp.Key + kp.Value <= s.Length)
                {
                    refs.Add(kp.Key, s.Substring(kp.Key, kp.Value));
                }
            }

            return refs;
        }


        /// <summary>
        /// Finds the first START codon on the input DNA strand, <paramref name="d"/>.
        /// </summary>
        /// <param name="d">DNA class instance - The DNA strand.</param>
        /// <returns>Int32 - the locus of the first START codon.</returns>
        public static Int32 FirstStart(DNA d)
        {
            Int32 loc = 0;
            String s = d.Sequence;
            Boolean found = false;

            if (!String.IsNullOrEmpty(s))
            {
                for (Int32 start = 0; start <= s.Length - 3; start++)
                {
                    if ((s.Substring(start, 3) == "ATG"))
                    {
                        found = true;
                        loc =  start;
                    }
                }
            }
            loc = (found) ? loc : -1;

            return loc;
        }


        /// <summary>
        /// Finds all Open Reading Frames in the sequence of at least min length and returns a list of the locus and length.
        /// To get the actual ORFMethods sequences, pass this.return to GenerateORFs().
        /// </summary>
        /// <param name="d">DNA class instance(s)</param>
        /// <param name="min">Int32 - the minimum length for the ORFs; if min is greater than sequence length
        /// the method returns a null.</param>
        /// <returns>Dictionary(Int32, Int32) which is the list of locud and length of the valid ORFs.</returns>
        public static List<KeyValuePair<Int32, Int32>> GetORFList(DNA d, Int32 min)
        {
            List<KeyValuePair<Int32, Int32>> frames = new List<KeyValuePair<int, int>>();
            String seq = d.Sequence;
            List<Int32> _starts = new List<Int32>();
            List<Int32> _stops = new List<Int32>();
            Int32 end = seq.Length - 3;
            Int32 lastStop = min + 6;
            Int32 lastStart = end - min - 3;


            if (min < 0) { min = 0; }
            if (min > seq.Length) { return frames; }



            //build list of all START codons where the ORFMethods would be longer than min
            for (Int32 start = 0; start <= lastStart; start++)
            {
                if ((seq.Substring(start, 3) == "ATG"))
                {
                    _starts.Add(start);
                }
            }

            //build list of all STOP codons where the ORFMethods would be longer than min
            for (Int32 stop = end; stop >= lastStop; stop--)
            {
                if ((seq.Substring(stop, 3) == "TAG"))
                {
                    _stops.Add(stop);
                }
            }
            //Add all locus,length pairs where length >= min
            foreach (Int32 _start in _starts)
            {
                foreach (Int32 _stop in _stops)
                {
                    if (_stop - _start >= min)
                    {
                        frames.Add(new KeyValuePair<int, int>(_start, _stop - _start));
                    }
                }
            }

            //This prevents the 'SEquence ahs not elements' error when dealing with a Null Dictionary<>
            if (frames.Count == 0)
            {
                frames.Add(new KeyValuePair<int, int>(0, 0));
            }

            return frames;
        }


        /// <summary>
        /// Returns Dictionary(Int32, String) the actiual ORF DNA sequences when given a list of
        /// the locus and length, and the sequence that has the ORFs.
        /// </summary>
        /// <param name="list">Dictionary(Int32, Int32) - the list of locus / length pairs</param>
        /// <param name="seq">FASTASequnce struct -  seq.Sequence is the DNA sequence on which the ORFs are found.</param>
        /// <returns>List(KeyValuePair(Int32, String)) - list of all ORFs on the DNA strand specified by the input list.</returns> 
        public static List<KeyValuePair<Int32, String>> GenerateORFs(List<KeyValuePair<Int32, Int32>> list, DNA seq)
        {
            List<KeyValuePair<Int32, String>> refs = new List<KeyValuePair<int, string>>();
            String s = seq.Sequence;

            foreach (KeyValuePair<Int32, Int32> kp in list)
            {
                if (kp.Key + kp.Value <= s.Length)
                {
                    refs.Add(new KeyValuePair<int, string>(kp.Key, s.Substring(kp.Key, kp.Value)));
                }
            }

            return refs;
        }


        /// <summary>
        /// Generates a random DNA class instance ORF of the given length.
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <returns>String, the returned random sequence</returns>
        public static DNA GenerateRandomORF(Int32 n)
        {
            String p = "ACTGACTGACTGACTGACTGACTGACTG";

            StringBuilder sb = new StringBuilder();
            StringBuilder ss = new StringBuilder();
            //add START CODON
            sb.Append("ATG");
            Random rnd = new Random();
            Int32 r = 0;

            for (Int32 len = 0; len <= n - 3; len += 3)
            {
                for (int i = 1; i <= 3; i++)
                {
                    r = rnd.Next(0, p.Length);
                    ss.Append(p.Substring(r, 1));
                }

                if ((ss.ToString() == "TAA") || (ss.ToString() == "TAG"))
                {
                    ss.Clear();
                }
                else
                {
                    sb.Append(ss.ToString());
                    ss.Clear();
                }
            }
            return new DNA(Guid.NewGuid() ,"","","","","Random ORF", sb.ToString());
        }


        /// <summary>
        /// Generates a random DNA class instance ORF of the given length that is 'doped' with certain codon ratios
        /// provided by the template.
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <param name="template">DNA instance - the sequence that provides the template for 'doping' the 
        /// generated ORF. The generated ORF will contain the specific codons in proportion to the number
        /// of the codons present in 'template'.</param>
        /// <returns>String, the returned random sequence</returns>
        public static DNA GenerateDopedRandomORF(Int32 n, DNA template)
        {
            String p = template.Sequence;

            StringBuilder sb = new StringBuilder();
            StringBuilder ss = new StringBuilder();
            //add START CODON
            sb.Append("ATG");
            Random rnd = new Random();
            Int32 r = 0;

            for (Int32 len = 0; len <= n - 3; len += 3)
            {
                for (int i = 1; i <= 3; i++)
                {
                    r = rnd.Next(0, p.Length);
                    ss.Append(p.Substring(r, 1));
                }

                if ((ss.ToString() == "TAA") || (ss.ToString() == "TAG"))
                {
                    ss.Clear();
                }
                else
                {
                    sb.Append(ss.ToString());
                    ss.Clear();
                }
            }
            return new DNA(Guid.NewGuid(), "", "", "", "", "Random ORF", sb.ToString());
        } 


    }


    public class OpenReadingFrames : Dictionary<Int32, String>
    {

        private readonly List<KeyValuePair<Int32, String>> _orfs;
        private readonly List<KeyValuePair<Int32, Int32>> _list;

        public OpenReadingFrames(DNA dna, Int32 minLen)
        {
            if (minLen < 1) { minLen = 1; }


            _list = ORFMethods.GetORFList(dna, minLen);

            _orfs = ORFMethods.GenerateORFs(_list, dna);
        }

        public Int32 OrfCount
        {
            get { return _orfs.Count; }
        }

        public List<KeyValuePair<Int32, String>> ORFList
        {
            get { return _orfs; }
        }

    }

}
