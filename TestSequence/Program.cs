//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.IO;

using SequenceStudio;
using SequenceStudio.Storage;
using SequenceStudio.Parsers;
using SequenceStudio.Internal;

namespace TestSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureConsole();

            String d = DnaMethods.GenerateRandomStrand(1000);
            DNA dna = new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);
            DNAStats s = new DNAStats(dna);
            Console.Write(s);
            Console.WriteLine();

            StringBuilder sa = new StringBuilder();
            StringBuilder sb = new StringBuilder();

            List<Int32> ints = SequenceStudio.Math.FibonacciSeries(1000);
            StringBuilder si = new StringBuilder();
            foreach (Int32 i in ints)
            {
                si.Append(i + ",");
            }

            SequenceStudio.Math.NumericalPattern(dna.Sequence, ints, ref sb);
            SequenceStudio.Math.PrimePattern(dna.Sequence, 1000, ref sa);

            Console.Write(si);
            Console.WriteLine();
            Console.Write(sb);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(sa);

            
            
            WrapUp();
        }





        #region Helpers

        public static RNA MakeTestRna()
        {
            return new RNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description",
                    "ACUGCUAGCUGCUAGCUAGCUGAUCGAUCGUGCUGCUGAUGCUAGCUGACUGAUGCAUGCUGA");
        }

        public static String MakeTestPoly()
        {
            List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
            StringBuilder sb = new StringBuilder();

            foreach (AminoAcids.AminoAcidBase b in aa)
            {
                sb.Append(b.Initial.ToString());
            }
            return sb.ToString();

        }

        public static DNA MakeMyDNA(String s)
        {
            return new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description",
                s);
        }

        public static RNA MakeMyRNA(String s)
        {
            return new RNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description",
                s);
        }

        public static DNA MakeTestDNA()
        {
            return new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description",
                "ACTGCTAGCTGCTAGCTAGCTGATCGATCGTGCTGCTGATGCTAGCTGACTGATGCATGCTGA");
        }

        public static DNA MakeTestDNA2()
        {
            return new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description",
                "GCTGCTGTCGGCTAGCTAGCTGATCGCTGTGTGCGCCGCTGATGCTACACACCAGCTGACTGATGCATGCTGA");
        }

        #endregion

        #region ConfigureConsole
            public static void ConfigureConsole()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BufferHeight = 1500;
                Console.BufferWidth = 150;
                Console.WindowHeight = 70;
                Console.WindowWidth = 150;
            }
        #endregion

        #region WrapUp
        public static void WrapUp()
        {
            Console.WriteLine("==================================== \nPress any key to end program.");
            Console.ReadKey();
        }
        #endregion

    }
}
