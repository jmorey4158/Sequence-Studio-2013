//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file 
//may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property 
//in any Revealed Designs, LLC product.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace SequenceStudio
{
    /// <summary>
    /// This Class holds all the classes that define the amino acids and makes their info 
    /// available to all Sequence Studio methods.
    /// </summary>
    public class AminoAcids
    {
        public class AminoAcidBase
        {
            protected String s_lname;
            protected String s_sname;
            protected String s_init;
            protected Double d_molw;
            protected String[] sa_codon;

            protected AminoAcidBase()
            {
                s_lname = "AminoAcidBase";
                s_sname = "*";
                s_init = "*";
                d_molw = 0;
                sa_codon = new String[] { "" };
            }

            public String LongName
            {
                get { return s_lname; }
            }

            public String ShortName
            {
                get { return s_sname; }
            }

            public String Initial
            {
                get { return s_init; }
            }

            public Double MolecularWeight
            {
                get { return d_molw; }
            }

            public String[] Codons
            {
                get { return sa_codon; }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Long Name: " + this.LongName.ToString() + "\n");
                sb.Append("Short Name: " + this.ShortName.ToString() + "\n");
                sb.Append("Initial: " + this.Initial.ToString() + "\n");
                sb.Append("Molecular Weight: " + this.MolecularWeight.ToString() + "\n");
                sb.Append("Codons: ");
                foreach (String s in Codons)
                {
                    sb.Append(s + " ");
                }
                return sb.ToString();
            }

        }

        #region Amino Acids

        public class Alanine : AminoAcidBase
        {
            public Alanine()
            {
                s_lname = "Alanine";
                s_sname = "Ala";
                s_init = "A";
                d_molw = 89.09404;
                sa_codon = new String[] { "GCU", "GCC", "GCA", "GCG" };
            }
        }

        public class Asparagine : AminoAcidBase
        {
            public Asparagine()
            {
                s_lname = "Asparagine";
                s_sname = "Asn";
                s_init = "N";
                d_molw = 132.11904;
                sa_codon = new String[] { "GAU", "GAC" };
            }
        }

        public class Cysteine : AminoAcidBase
        {
            public Cysteine()
            {
                s_lname = "Cysteine";
                s_sname = "Cys";
                s_init = "C";
                d_molw = 121.15404;
                sa_codon = new String[] { "UGU", "UGC" };
            }
        }

        public class AsparticAcid : AminoAcidBase
        {
            public AsparticAcid()
            {
                s_lname = "AsparticAcid";
                s_sname = "Asp";
                s_init = "D";
                d_molw = 133.10384;
                sa_codon = new String[] { "GAU", "GAC" };
            }
        }

        public class GlutamicAcid : AminoAcidBase
        {
            public GlutamicAcid()
            {
                s_lname = "GlutamicAcid";
                s_sname = "Glu";
                s_init = "E";
                d_molw = 147.13074;
                sa_codon = new String[] { "GAA", "GAG" };
            }
        }

        public class Phenylalanine : AminoAcidBase
        {
            public Phenylalanine()
            {
                s_lname = "Phenylalanine";
                s_sname = "Phe";
                s_init = "F";
                d_molw = 165.19184;
                sa_codon = new String[] { "UUU", "UUC" };
            }
        }

        public class Glycine : AminoAcidBase
        {
            public Glycine()
            {
                s_lname = "Glycine";
                s_sname = "Gly";
                s_init = "G";
                d_molw = 75.06714;
                sa_codon = new String[] { "GGU", "GGC", "GGA", "GGG" };
            }
        }

        public class Histidine : AminoAcidBase
        {
            public Histidine()
            {
                s_lname = "Histidine";
                s_sname = "His";
                s_init = "H";
                d_molw = 155.15634;
                sa_codon = new String[] { "CAU", "CAC" };
            }
        }

        public class Isoleucine : AminoAcidBase
        {
            public Isoleucine()
            {
                s_lname = "Isoleucine";
                s_sname = "Ile";
                s_init = "I";
                d_molw = 131.17464;
                sa_codon = new String[] { "AUU", "AUC", "AUA" };
            }
        }

        public class Lysine : AminoAcidBase
        {
            public Lysine()
            {
                s_lname = "Lysine";
                s_sname = "Lys";
                s_init = "K";
                d_molw = 146.18934;
                sa_codon = new String[] { "AAA", "AAG" };
            }
        }

        public class Leucine : AminoAcidBase
        {
            public Leucine()
            {
                s_lname = "Leucine";
                s_sname = "Leu";
                s_init = "L";
                d_molw = 131.17464;
                sa_codon = new String[] { "UUA", "UUG", "CUU", "CUC", "CUA", "CUG" };
            }
        }

        public class Methionine : AminoAcidBase
        {
            public Methionine()
            {
                s_lname = "Methionine";
                s_sname = "Met";
                s_init = "M";
                d_molw = 149.20784;
                sa_codon = new String[] { "AUG" };
            }
        }

        public class Proline : AminoAcidBase
        {
            public Proline()
            {
                s_lname = "Proline";
                s_sname = "Pro";
                s_init = "P";
                d_molw = 132.11904;
                sa_codon = new String[] { "CCU", "CCC", "CCA", "CCG" };
            }
        }

        public class Glutamine : AminoAcidBase
        {
            public Glutamine()
            {
                s_lname = "Glutamine";
                s_sname = "Gln";
                s_init = "Q";
                d_molw = 146.14594;
                sa_codon = new String[] { "GAA", "GAG" };
            }
        }

        public class Arginine : AminoAcidBase
        {
            public Arginine()
            {
                s_lname = "Arginine";
                s_sname = "Arg";
                s_init = "R";
                d_molw = 174.20274;
                sa_codon = new String[] { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" };
            }
        }

        public class Serine : AminoAcidBase
        {
            public Serine()
            {
                s_lname = "Serine";
                s_sname = "Ser";
                s_init = "S";
                d_molw = 105.09344;
                sa_codon = new String[] { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" };
            }
        }

        public class Threonine : AminoAcidBase
        {
            public Threonine()
            {
                s_lname = "Threonine";
                s_sname = "Thr";
                s_init = "T";
                d_molw = 119.12034;
                sa_codon = new String[] { "ACU", "ACC", "ACA", "ACG" };
            }
        }

        public class Valine : AminoAcidBase
        {
            public Valine()
            {
                s_lname = "Valine";
                s_sname = "Val";
                s_init = "V";
                d_molw = 117.14784;
                sa_codon = new String[] { "GUU", "GUC", "GUA", "GUG" };
            }
        }

        public class Tryptophan : AminoAcidBase
        {
            public Tryptophan()
            {
                s_lname = "Tryptophan";
                s_sname = "Trp";
                s_init = "W";
                d_molw = 204.22844;
                sa_codon = new String[] { "UGG" };
            }
        }

        public class Tyrosine : AminoAcidBase
        {
            public Tyrosine()
            {
                s_lname = "Tyrosine";
                s_sname = "Tyr";
                s_init = "Y";
                d_molw = 181.19124;
                sa_codon = new String[] { "UAU", "UAC" };
            }
        }

        public class Stop : AminoAcidBase
        {
            public Stop()
            {
                s_lname = "Stop";
                s_sname = "Stop";
                s_init = "^";
                d_molw = 0;
                sa_codon = new String[] { "UAA", "UAG" };
            }
        }

        #endregion



        /// <summary>
        /// Creates a set of Amino ACid class instances for use in other methods and classes
        /// </summary>
        public static void InitAminoAcids()
        {
            AminoAcids.Alanine ala = new AminoAcids.Alanine();
            AminoAcids.Arginine arg = new AminoAcids.Arginine();
            AminoAcids.Asparagine asn = new AminoAcids.Asparagine();
            AminoAcids.AsparticAcid asp = new AminoAcids.AsparticAcid();
            AminoAcids.Cysteine cys = new AminoAcids.Cysteine();

            AminoAcids.GlutamicAcid glu = new AminoAcids.GlutamicAcid();
            AminoAcids.Glutamine gln = new AminoAcids.Glutamine();
            AminoAcids.Glycine gly = new AminoAcids.Glycine();
            AminoAcids.Histidine his = new AminoAcids.Histidine();
            AminoAcids.Isoleucine ile = new AminoAcids.Isoleucine();

            AminoAcids.Leucine leu = new AminoAcids.Leucine();
            AminoAcids.Lysine lys = new AminoAcids.Lysine();
            AminoAcids.Methionine met = new AminoAcids.Methionine();
            AminoAcids.Phenylalanine phe = new AminoAcids.Phenylalanine();
            AminoAcids.Proline pro = new AminoAcids.Proline();

            AminoAcids.Serine ser = new AminoAcids.Serine();
            AminoAcids.Threonine thr = new AminoAcids.Threonine();
            AminoAcids.Tryptophan trp = new AminoAcids.Tryptophan();
            AminoAcids.Tyrosine tyr = new AminoAcids.Tyrosine();
            AminoAcids.Valine val = new AminoAcids.Valine();
        }


        /// <summary>
        /// Returns a List(AminoAcidBase) of all the Amino Acid classes instances
        /// </summary>
        public static List<AminoAcidBase> GetAminoAcidList()
        {
            List<AminoAcidBase> aminoList = new List<AminoAcidBase>();

            aminoList.Add(new AminoAcids.Alanine());
            aminoList.Add(new AminoAcids.Arginine());
            aminoList.Add(new AminoAcids.Asparagine());
            aminoList.Add(new AminoAcids.AsparticAcid());
            aminoList.Add(new AminoAcids.Cysteine());
            aminoList.Add(new AminoAcids.GlutamicAcid());
            aminoList.Add(new AminoAcids.Glutamine());
            aminoList.Add(new AminoAcids.Glycine());
            aminoList.Add(new AminoAcids.Histidine());
            aminoList.Add(new AminoAcids.Isoleucine());

            aminoList.Add(new AminoAcids.Leucine());
            aminoList.Add(new AminoAcids.Lysine());
            aminoList.Add(new AminoAcids.Methionine());
            aminoList.Add(new AminoAcids.Phenylalanine());
            aminoList.Add(new AminoAcids.Proline());

            aminoList.Add(new AminoAcids.Serine());
            aminoList.Add(new AminoAcids.Threonine());
            aminoList.Add(new AminoAcids.Tryptophan());
            aminoList.Add(new AminoAcids.Tyrosine());
            aminoList.Add(new AminoAcids.Valine());

            return aminoList;
        }


        /// <summary>
        /// Returns the CodonMatrix, a
        /// list (of Tuple(string,string)) of all the codons for all amino acids
        /// </summary>
        /// <returns>List(Typle(string,string)) - the CodonMatrix</returns>
        public static List<Tuple<string, string>> GetCodonMatixTuple()
        {
            List<AminoAcidBase> la = GetAminoAcidList();
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            int i = 1;

            foreach (AminoAcidBase b in la)
            {
                string a = b.Initial;
                i = 1;
                foreach (string c in b.Codons)
                {
                    list.Add(Tuple.Create<string, string>(a + i.ToString(), c.Replace("U","T")));
                    i++;
                }
            }
            return list;
        }


        /// <summary>
        /// Returns the CodonMatrix, a
        /// Dictionary(string,string) of all the codons for all amino acids
        /// </summary>
        /// <returns>Dictionary(string,string) - the CodonMatrix</returns>
        public static Dictionary<string, string> GetCodonMatrix()
        {
            int i = 1;
            List<AminoAcidBase> la = GetAminoAcidList();
            Dictionary<string, string> list = new Dictionary<string, string>();

            foreach (AminoAcidBase b in la)
            {
                string a = b.Initial;
                i = 1;
                foreach (string c in b.Codons)
                {
                    list.Add(a + i.ToString(), c.Replace("U", "T"));
                    i++;
                }
            }
            return list;
        }

    }


}
