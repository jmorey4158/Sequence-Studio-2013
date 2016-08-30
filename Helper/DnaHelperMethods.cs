//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SequenceStudio
{
    /// <summary>
    /// These static methods provides ways of manipulating DNA-oriented data. With the exception of two methods, which
    /// generate and return a DNA class instance, all methods require a DNA class instance.
    /// </summary>
    public static class DnaMethods
    {
        /// <summary>
        /// Counts all of the DNA codons in a DNA sequence.
        /// </summary>
        /// <param name="s">DNA class instance - the DNA sequence to operate upon.</param>
        /// <returns>Dictionary(String,Int32) - the list of the codond and number of instances in 
        /// the <paramref name="s"/>.</returns>
        /// <remarks>This methods instantiates a CodonMatrix and uses that to 
        /// match with the <paramref name="s"/>.</remarks>
        public static Dictionary<String,Int32> CodonCount(DNA d)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            Dictionary<string, string> cl = AminoAcids.GetCodonMatrix();
            int count = 0;
            String seq = d.Sequence;

            while (seq.Length % 3 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }

            foreach (KeyValuePair<string, string> kp in cl)
            {
                count = 0;
                for (int i = 0; i < seq.Length - 1; i += 3)
                {
                    if (seq.Substring(i, 3) == kp.Value)
                    {
                        count++;
                    }
                }
                list.Add(kp.Key, count);
            }
            return list;
        }

        public static Dictionary<String,Int32> CodonCount(String seq)
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            Dictionary<string, string> cl = AminoAcids.GetCodonMatrix();
            int count = 0;

            while (seq.Length % 3 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }

            foreach (KeyValuePair<string, string> kp in cl)
            {
                count = 0;
                for (int i = 0; i < seq.Length - 1; i += 3)
                {
                    if (seq.Substring(i, 3) == kp.Value)
                    {
                        count++;
                    }
                }
                list.Add(kp.Key, count);
            }
            return list;
        }



        /// <summary>
        /// Calculates the percentage of the DNA codons in a DNA sequence. 
        /// </summary>
        /// <param name="s">DNA class instance - the DNA strand to operate upon.</param>
        /// <returns>Dictionary(String,Int32) - the list of the codons and number of instances in 
        /// the <paramref name="s"/>.</returns>
        /// <remarks>This methods calls the CodonCount(Sequence s) method
        /// and uses the resutls of that method to calculate the percentages.<paramref name="s"/>.</remarks>
        public static Dictionary<String, Double> CodonPercentage(DNA d)
        {
            Dictionary<string, int> cc = CodonCount(d); //calls CodonCount method to get count of codons

            Dictionary<string, double> list = new Dictionary<string, double>();
            double p = d.Sequence.Length / 3;

            foreach (KeyValuePair<string, int> kc in cc)
            {
                list.Add(kc.Key, ((double)(kc.Value / p) * 100));
            }

            return list;
        }

        public static Dictionary<String, Double> CodonPercentage(String s)
        {
            Dictionary<string, int> cc = CodonCount(s); //calls CodonCount method to get count of codons

            Dictionary<string, double> list = new Dictionary<string, double>();
            double p = s.Length / 3;

            foreach (KeyValuePair<string, int> kc in cc)
            {
                list.Add(kc.Key, ((double)(kc.Value / p) * 100));
            }

            return list;
        }


        /// <summary>
        /// CodonMatrix - generates the CodonMatrix for the given DNA sequence and returns it as a string.
        /// </summary>
        /// <param name="d">DNA class instance - passing a DNA rather than string ensures validity</param>
        /// <returns>String - the CodonMatrix for the sequence</returns>
        /// <remarks><para>The Condon Matrix is the seqential representation of the coding residues of 
        /// the input <paramref name="d"/>. This method assumes that the iput DNA sequence is an 
        /// open reading frame (ORFMethods). If the input sequence is not an open reading frame then the 
        /// results might not be useful. The method will continue to the last codon on the sequence
        /// including STOP codons. All 'ATG' codons are translated as a Met residue rather than a 
        /// START codon.</para>
        /// <para>This method returns a String. To obtain the CodonMatrix class instance, 
        /// use AminoAcids.GetCodonMatrix().</para></remarks>
        public static String CodonMatrix(DNA d)
        {
            String dna = d.Sequence;
            while (dna.Length % 3 != 0)
            {
                dna = dna.Substring(0, dna.Length - 1);
            }
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> list = AminoAcids.GetCodonMatrix();

            for (int i = 0; i < dna.Length - 1; i += 3)
            {
                String s = dna.Substring(i, 3);
                foreach (KeyValuePair<string, string> kp in list)
                {
                    if (kp.Value == s)
                    {
                        sb.Append(kp.Key);
                    }
                }
            }
            return sb.ToString();
        }

        public static String CodonMatrix(String seq)
        {
            while (seq.Length % 3 != 0)
            {
                seq = seq.Substring(0, seq.Length - 1);
            }
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> list = AminoAcids.GetCodonMatrix();

            for (int i = 0; i < seq.Length - 1; i += 3)
            {
                String s = seq.Substring(i, 3);
                foreach (KeyValuePair<string, string> kp in list)
                {
                    if (kp.Value == s)
                    {
                        sb.Append(kp.Key);
                    }
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// CodonMatrix - generates the CodonMatrix for the given DNA sequence. Displayes the results as a 
        /// String with a separator <paramref name="sep"/> (for easier viewing).
        /// </summary>
        /// <param name="d">DNA class instance - passing a DNA rather than string ensures validity</param>
        /// <param name="sep">String - the character(s) to use to separate the codons in the matrix output</param> 
        /// <returns>String - the CodonMatrix for the sequence</returns>
        /// <remarks><para>The Condon Matrix is the seqential representation of the coding residues of 
        /// the input <paramref name="s"/>. This method assumes that the iput DNA sequence is an 
        /// open reading frame (ORFMethods). If the input sequence is not an open reading frame then the 
        /// results might not be useful. The method will continue to the last codon on the sequence
        /// including STOP codons. All 'ATG' codons are translated as a Met residue rather than a 
        /// START codon.</para>
        /// <para>This method returns a String. To obtain the CodonMatrix class instance, 
        /// use AminoAcids.GetCodonMatrix().</para></remarks>
        public static String CodonMatrix(DNA d, String sep)
        {
            String dna = d.Sequence;
            while (dna.Length % 3 != 0)
            {
                dna = dna.Substring(0, dna.Length - 1);
            }
            StringBuilder sb = new StringBuilder();

            Dictionary<string, string> list = AminoAcids.GetCodonMatrix();

            for (int i = 0; i < dna.Length - 1; i += 3)
            {
                String s = dna.Substring(i, 3);
                foreach (KeyValuePair<string, string> kp in list)
                {
                    if (kp.Value == s)
                    {
                        sb.Append(kp.Key + sep);
                    }
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Trascribes the input <paramref name="seq"/> DNA sequence into an RNA sequence.
        /// </summary>
        /// <param name="seq">Internal.DNA class instance - the DNA sequence to transcribe.</param>
        /// <returns>String - the RNA sequence.</returns>
        public static String Transcribe(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            String seq = d.Sequence;

            for (Int32 index = 0; index <= seq.Length - 1; index++)
            {
                if ((seq.Substring(index, 1)) == "T")
                {
                    sb.Append("U");
                }
                else
                {
                    sb.Append(seq.Substring(index, 1));
                }
            }
            return sb.ToString();
        }


        /// <summary>
        /// Translates the input <paramref name="seq"/> into a polypeptide strand and returns it as a String.
        /// </summary>
        /// <param name="d">Internal.DNA class instance - the DNA sequence to translate into poypeptide seuence.</param>
        /// <returns>String - the polypeptide sequence in Inital format.</returns>
        /// <remarks><para>This method processes the input sequence in groups of 3. 
        /// If the input sequence is not equally divisible by 3 then the remaining letters will be ignored.
        /// </para>
        /// <para>IMPORTANT - This method does not validate that the input string is a DNA sequence. If 
        /// another string is put in the results will be invalid.</para></remarks>
        public static String Translate(DNA d)
        {
            String seq = Transcribe(d);

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
        /// Translates a given DNA strand into the simple reading fram at all 3 locations.
        /// </summary>
        /// <param name="d">DNA class instance</param>
        /// <returns>String array of all three possible translation products.</returns>
        public static String[] TranslateAllReadingFrames(DNA d)
        {
            String[] frames = new String[3];
            String seq2 = d.Sequence.Substring(1,d.Sequence.Length);
            String seq3 = d.Sequence.Substring(2, d.Sequence.Length);

            DNA d2 = new DNA(Guid.NewGuid(), "", "", "", "", "", seq2);
            DNA d3 = new DNA(Guid.NewGuid(), "", "", "", "", "", seq3);

            frames[0] = Translate(d);
            frames[1] = Translate(d2);
            frames[2] = Translate(d3);

            return frames;
        }


        /// <summary>
        /// Calculates the residue statistics of the input DNA strand.
        /// </summary>
        /// <param name="d">Internal.DNA - the input DNA strand.</param>
        /// <returns>Dictionary(String,Int32) - the residue statistics of the input DNA strand.</returns>
        /// <remarks>The residue statistics is a Dictionary of the residues (A,C,T,G) and the number of times that
        /// residue appears in the sequence. 
        /// For example a sequence 100 residues long might have A = 20, C = 22, C = 28, G = 30.</remarks>
        public static Dictionary<String, Int32> Stats(DNA d)
        {
            Dictionary<String, Int32> units = new Dictionary<String, Int32>();
            Int32 count = 0;
            String[] s_DNA = new String[4] { "A", "T", "C", "G" };
            String seq = d.Sequence;

            foreach (String s in s_DNA)
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
        /// Calcualtes the molecular weight, in Daltons, of a specific DNA sequence.
        /// </summary>
        /// <param name="stats">Dictioanry(String,Int32) - the residue staticits of the DNA sequence.</param>
        /// <returns>Double - the molecualr weight, in Daltons, of the DNA sequence.</returns>
        public static Double MolWeight(DNA d)
        {
            Double molWeight = 0.0;
            Dictionary<String, Int32> stats = Stats(d);

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
                    case "T":
                        molWeight += (288.63 * (Double)(kp.Value));
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
        /// Calculates the complimentary for the input DNA strand.
        /// </summary>
        /// <param name="d">Internal.DNA class instance - the DNA strand.</param>
        /// <returns>String - the complimentary strand.</returns>
        public static String CompStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            String seq = d.Sequence;

            for (Int32 index = 0; index <= seq.Length - 1; index++)
            {
                switch (seq.Substring(index, 1))
                {
                    case "A":
                        sb.Append("T");
                        break;
                    case "C":
                        sb.Append("G");
                        break;
                    case "T":
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
        public static String ReverseCompStrand(DNA d)
        {
            StringBuilder sb = new StringBuilder();
            String seq = CompStrand(d);

            for (Int32 index = seq.Length -1; index >= 0; index--)
            {
                sb.Append(seq[index]);
            }            
            return sb.ToString();
        }


        /// <summary>
        /// Generates a 'doped' random sequence of the type given of the given length.
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <param name="pattern">String, type of sequence and units; use this to 'dope' the strand </param>
        /// <returns>String, the returned semi-random sequence</returns>
        /// <remarks><para>You can use this method to return any sequence type (e.g. DNA, RNA, or custom) by providing 
        /// the pattern to use for building the strand. If you use the pattern 'ACTG' the method will produce a 
        /// DNA strans with equal amounts of A, C, T, and G residues.</para> 
        /// <para>You can also 'dope' the strand by 
        /// providing a pattern that has more instances of a particular character in relation to the other characters. 
        /// For example the pattern 'AAACTGG'
        /// will produce a DNA sequence with 3 times as many A residues as T and C residues and twice as many
        /// G residues as T and C residues. However, the pattern 'ACTGACTG'will produce the smae result as if 
        /// you would have used 'ACTG'.</para>
        /// <para>NOTE - this method doesa not perform any character checking 
        /// and will return a sequence of any characters, the pattern determinig the outcome.</para>
        /// </remarks>
        public static String GenerateRandomDopedStrand(Int32 n, String pattern)
        {
            if (String.IsNullOrEmpty(pattern))
            {
                pattern = "ACTG"; // you can alter the ratios of nucleotides by altering the ratios in this string.
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
        /// Generates a random DNA sequence of the given length.
        /// </summary>
        /// <param name="n">Int32 number of units in sequence</param>
        /// <param name="pattern">String, type of sequence and units; use this to 'dope' the strand </param>
        /// <returns>String, the returned semi-random sequence</returns>
        public static String GenerateRandomStrand(Int32 n)
        {

            String pattern = "ACTG";
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
        /// THIS METHOD IS NOT COMPLETE! 
        /// 
        /// Finds all regions on the input DNA strand (<paramref name="d"/>) that do not code for 
        /// the input polypeptide, <paramref name="poly"/>.
        /// </summary>
        /// <param name="d">DNA class instance - the DNA strand to find introns (non-coding regions) on.</param>
        /// <param name="poly">PolyMethods class instance - the polypeptide to use as a template.</param>
        /// <param name="message">String - any message that the method will raise during execution.</param>
        /// <returns>Dictionary(Int32,Int32) - the list of introns as locus and length.</returns>
        /// <remarks>Possible messages: </remarks>
        public static Dictionary<Int32, Int32> Introns(DNA d, Poly poly, ref String message)
        {
            Dictionary<Int32, Int32> _introns = new Dictionary<int, int>();

            // TODO: PUT THE GUTS OF THE 'Intron' METHOD HERE
            // Need to split this into two seperate Methods: Find best match between DNA and Poly, if one exists and 
            // Find introns. The first function needs to have a threshold. 
            //
            // METHOD 1: Find the best match between the DNA and the Poly
            //  1. Translate DNA into the three reading frames x 2 directions (6 total)
            //  2. Run each through LongestContiguousMatchRegions(DNA.Sequence, Poly.Sequence)
            //  3. If best match > N GOTO next method
            //
            // METHOD 2: Find Introns
            //  1. Start at best alignment
            //  2. Translate next DNA codon
            //  3. Match to Poly
            //  4. While = (GOTO 2)
            //  4b. While != shift reading frame 1 and GOTO 2; record location
            //  5. When = record length
            //  6. While !EOF GOTO 2.


            return _introns;

        } //NOT COMPLETE


    }

    /// <summary>
    /// Instances of this class represent the 'introns' possible in the given DNA strands on the given Poly.
    /// </summary>
    /// <remarks>If no introns are found the Exception passed in will be populated and returned along with an
    /// empty Dictionary(Int32, Int32). </remarks>
    public class Intron : Dictionary<Int32, Int32>
        {
            private Dictionary<Int32, Int32> _introns;

            public Intron(DNA d, Poly p, ref SequenceException seq)
            {
                String m = "";
                _introns = DnaMethods.Introns(d, p, ref m); //This returns whatever the Intron method outputs.
            }


            public Dictionary<Int32, Int32> Introns
            {
                get { return _introns; }
            }

        }


    public class SequenceList : Dictionary<Int32, String>
        {

            protected readonly Dictionary<Int32, String> _list;


            public SequenceList(DNA d)
            {


            }

        } //NOT COMPLETE - not sure what I was thinking here.


    public class DNAStats
        {
            protected readonly Guid _id;
            protected readonly String _compStrand;
            protected readonly String _revCompStrand;
            protected readonly String _transcript;
            protected readonly String _gene;
            protected readonly Double _mol;
            protected readonly Dictionary<String, Int32> _units;

            public DNAStats(DNA d)
            {
                this._id = d.ID;
                this._gene = DnaMethods.Translate(d);
                this._compStrand = DnaMethods.CompStrand(d);
                this._revCompStrand = DnaMethods.ReverseCompStrand(d);
                this._units = DnaMethods.Stats(d);
                this._transcript = DnaMethods.Transcribe(d);
                this._mol = DnaMethods.MolWeight(d);
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

            public String Transcript
            {
                get { return _transcript; }
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
                sb.Append("RNA Trnascript: " + this.Transcript.ToString() + "\n");
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


}
