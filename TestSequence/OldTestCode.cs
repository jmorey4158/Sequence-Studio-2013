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
    class OldTestCode
    {

        #region PARSE

        public static void TestGetORFList()
        {
            String s = "ATGCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCTAGctgatcgatgatgatcgatctagctcgtagctgatgatgacacacacacacatgacgacatcatcgagctag";
            DNA fa = new DNA(Guid.NewGuid(), "001", "1234", "Test", "Test", "Test sequence", s);

            List<KeyValuePair<Int32, Int32>> results = ORFMethods.GetORFList(fa, 0);

            Console.WriteLine(fa.Sequence);

            foreach (KeyValuePair<int, int> kp in results)
            {
                Console.WriteLine("locus: {0}\tlength: {1}", kp.Key, kp.Value);
            }

        }

        public static void DoPopulateDNASQL(String tableName, String path)
        {
            String fasta = "";
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<DNA> fs = new List<DNA>();

            //get Fasta String
            fasta = BaseParser.ReadFASTAFile(path);

            Console.WriteLine("ReadFASTAFile(path) Done.");

            //Get List<DNA>
            Dictionary<int, string> err = new Dictionary<int, string>();
            fs = FASTAparser.ParseFASTASequence(fasta, ref err);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Errors: {0}", err.Count - 1);
            Console.WriteLine("Good Parses: {0}", fs.Count);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("ParseFASTASequence(fasta) Done.");

            //foreach (DNA fa in fs)
            //{
            //    Console.WriteLine("Enum: {0}\tDesc: {1}\tSeq: {2}", fa.Enumeration, fa.Description, fa.Sequence);
            //}

            //Populate DB table with content
            CreateDatabase.CreateDNATable(tableName, dc);
            Console.WriteLine("CreateDNATable Done.");

            Console.WriteLine("STARTING StoreSequenceSQL.");
            StorageMethods.StoreSequenceSQL(fs, dc);
            Console.WriteLine("CreateDNATable Done.");
            Console.WriteLine("StoreSequenceSQL Done.");
        }

        public static void TestParseSequences(String path)
        {
            String fasta = "";
            List<DNA> fs = new List<DNA>();

            //get Fasta String
            fasta = FASTAparser.ReadFASTAFile(path);

            Console.WriteLine("ReadFASTAFile(path) Done.");

            //Get List<DNA>
            Dictionary<int, string> err = new Dictionary<int, string>();
            fs = FASTAparser.ParseFASTASequence(fasta, ref err);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Errors: {0}", err.Count - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good Parses: {0}", fs.Count);

        }

        public static void TestParsePoly(String path, String dc)
        {
            String polys = "";
            List<Poly> pl = new List<Poly>();
            Dictionary<Int32, String> err = new Dictionary<int, string>();

            //get Fasta String
            polys = BaseParser.ReadFASTAFile(path);

            Console.WriteLine("ReadFASTAFile(path) Done.");

            //Get List<DNA>
            pl = SequenceStudio.Parsers.AAParsers.ParsePoly(polys, ref err);

            Console.WriteLine("Errors: {0}", err.Count);
            Console.WriteLine("Sucesses: {0}", pl.Count);


            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Storing Errors in Database");
            StorageMethods.StoreErrors(err, dc, "PolyParseErrors");

        }


        public static void TestArray()
        {
            Int32[,] array = new Int32[3, 2] { { 15, 1 }, { 20, 2 }, { 1, 3 } };

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }



        }

        public static void TestKeyValuePair()
        {
            List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();

            for (Double i = 0; i < 100; i++)
            {
                list.Add(new KeyValuePair<double, double>(10, i * i));
            }


            foreach (KeyValuePair<double, double> kp in list)
            {
                Console.WriteLine("Key: {0}\t Value: {1}", kp.Key, kp.Value);
            }

        }

        public static void TestCreatePolyTable(String name, String conn)
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            Boolean table = new Boolean();
            table = CreateDatabase.CreatePolyTable(name, sqlconn);
        }

        public static void TestCreateDNATable(String name, String conn)
        {
            SqlConnection sqlconn = new SqlConnection(conn);
            Boolean table = new Boolean();
            table = CreateDatabase.CreateDNATable(name, sqlconn);
        }

        public static void TestPopulateDNASQL(String tableName, String path)
        {
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<DNA> fs = new List<DNA>();
            DNA fa = new DNA(Guid.NewGuid(), "enum", "asc", "org", "loc", "desc", "ACGATCGATGCTAGCTGCTGATCGTGCGTA");
            for (Int32 i = 0; i < 10; i++)
            {
                fs.Add(fa);
            }

            CreateDatabase.CreateDNATable(tableName, dc);
            StorageMethods.StoreSequenceSQL(fs, dc);
        }

        public static void TestFastaDataTable(String tableName, String tblSchema)
        {
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<DNA> fs = new List<DNA>();
            DNA fa = new DNA(Guid.NewGuid(), "enum", "asc", "org", "loc", "desc", "ACGATCGATGCTAGCTGCTGATCGTGCGTA");
            for (Int32 i = 0; i < 10; i++)
            {
                fs.Add(fa);
            }

            CreateDatabase.CreateDNATable(tableName, dc);
            Console.WriteLine("Table: {0} created.", tableName);

            Console.WriteLine("Beginning StoreSequenceDataTable Method....");
            StorageMethods.StoreSequenceDataTable(fs, dc, tableName);
        }

        public static void TestPolyDataTable(String tableName)
        {
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<Poly> poly = new List<Poly>();
            Poly p = new Poly(Guid.NewGuid(), "enum", "asc", "org", "loc", "desc", "MCATYMFNITVIITHPTPTLRTRGPGFVRNRDLYIYKY");
            for (Int32 i = 0; i < 10; i++)
            {
                poly.Add(p);
            }

            CreateDatabase.CreatePolyTable(tableName, dc);
            Console.WriteLine("Table: {0} created.", tableName);

            Console.WriteLine("Beginning StoreSequenceDataTable Method....");
            StorageMethods.StoreSequenceDataTable(poly, dc, tableName);
        }

        public static String TestTableSchema(String tbleName)
        {
            List<String> schema = new List<string>();
            schema.Add(Constants.ct_ID);
            //schema.Add(Constants.ct_DbType);
            schema.Add(Constants.ct_Enum);
            schema.Add(Constants.ct_Asc);
            //schema.Add(Constants.ct_Org);
            schema.Add(Constants.ct_Desc);
            schema.Add(Constants.ct_Seq);

            String s = CreateDatabase.TableCommand(tbleName, schema);
            return s;
        }

        public static void TestStoreCustomTable(String tblName)
        {
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<DNA> fs = new List<DNA>();
            DNA fa = new DNA(Guid.NewGuid(), "enum", "asc", "org", "loc", "desc", "ACGATCGATGCTAGCTGCTGATCGTGCGTA");
            // List<Poly> fs = new List<Poly>();
            //Polypeptide fa = new Polypeptide("enum", "asc", "desc", "MCATYMFNITVIITHPTPTLRTRGPGFVRNRDLYIYKY");
            for (Int32 i = 0; i < 10; i++)
            {
                fs.Add(fa);
            }

            String schema = TestTableSchema(tblName);

            CreateDatabase.CreateCustomTable(dc, schema);
            Console.WriteLine("Table: {0} created.", tblName);

            Console.WriteLine("Beginning StoreSequenceDataTable Method....");
            StorageMethods.StoreSequenceDataTable(fs, dc, tblName);

        }

        public static void DoPopulatePolyDB(String tblName, String path)
        {
            String poly = "";
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<Poly> lp = new List<Poly>();

            //get Fasta String
            poly = BaseParser.ReadFASTAFile(path);
            Console.WriteLine("ReadFASTAFile(path) Done.");

            //Get List<DNA>
            Dictionary<int, string> err = new Dictionary<int, string>();
            lp = AAParsers.ParsePoly(poly, ref err);

            //Show Errors and Goods
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Errors: {0}", err.Count - 1);
            Console.WriteLine("Good Parses: {0}", lp.Count);
            Console.ForegroundColor = ConsoleColor.Green;

            //foreach (DNA fa in fs)
            //{
            //    Console.WriteLine("Enum: {0}\tDesc: {1}\tSeq: {2}", fa.Enumeration, fa.Description, fa.Sequence);
            //}

            //Create Polypeptide table for good parses
            CreateDatabase.CreateCustomTable(dc, CreateDatabase.TableCommand(tblName, Constants.db_Poly));
            Console.WriteLine("CreateCustomTable {0} Done.", tblName);

            //Populate Polypeptide table
            Console.WriteLine("STARTING StoreSequenceSQL.");
            StorageMethods.StoreSequenceDataTable(lp, dc, tblName);
            Console.WriteLine("StoreSequenceSQL Done.");

            // Create and populate Errors table
            Console.WriteLine("Storing Errors in Database.");
            StorageMethods.StoreErrors(err, dc, tblName + "ParseErrors");

        }

        public static void TestSpeed(int limit)
        {
            if (limit < 10)
            {
                limit = 10;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Speed Test: Parallel ForAll");
            RunForAllParallel(limit);

            //Console.WriteLine("Speed Test: Parallel");
            //RunParallel(limit);


            //Console.WriteLine("Speed Test: Singular");
            //RunSingular(limit);
        }
        public static void RunParallel(int limit)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var source = Enumerable.Range(1, limit).AsParallel();
            var evenNums = from num in source
                           where Compute(num) % 2 == 0
                           select num;
            foreach (var ev in evenNums)
            {
                Console.WriteLine("{0} on Thread {1}", ev,
                    Thread.CurrentThread.GetHashCode());
            }
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time: {0} seconds", sw.Elapsed.Seconds);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void RunSingular(int limit)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var source = Enumerable.Range(1, limit);
            var evenNums = from num in source
                           where Compute(num) % 2 == 0
                           select num;
            foreach (var ev in evenNums)
            {
                Console.WriteLine("{0} on Thread {1}", ev,
                    Thread.CurrentThread.GetHashCode());
            }
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time: {0} seconds", sw.Elapsed.Seconds);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static void RunForAllParallel(int limit)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var source = Enumerable.Range(1, limit).AsParallel().AsOrdered();
            var evenNums = from num in source
                           where Compute(num) % 2 == 0
                           select num;
            evenNums.ForAll(ev => Console.WriteLine(string.Format(
                              "{0} on Thread {1}", ev,
                              Thread.CurrentThread.GetHashCode())));
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time: {0} seconds", sw.Elapsed.Seconds);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static int Compute(int num)
        {
            Console.WriteLine("Computing {0} on Thread {1}", num,
                Thread.CurrentThread.GetHashCode());
            Thread.Sleep(1000);
            return num;
        }

        #endregion


        #region CodonMatrix

        public static void GetAminoList()
        {
            List<AminoAcids.AminoAcidBase> list = new List<AminoAcids.AminoAcidBase>();
            list = AminoAcids.GetAminoAcidList();

            foreach (AminoAcids.AminoAcidBase a in list)
            {
                Console.Write("LongName: {0}\t ShortName: {1}\tMole: {2}\n\tCodons: ",
                    a.LongName, a.ShortName, a.MolecularWeight);
                foreach (String s in a.Codons)
                {
                    Console.Write("{0},", s);
                    Console.WriteLine();
                }
            }
        }

        public static void CreateCMTable()
        {
            Dictionary<string, string> list = AminoAcids.GetCodonMatrix();

            foreach (KeyValuePair<string, string> kp in list)
            {
                Console.WriteLine("{0}:{1}", kp.Key, kp.Value);
            }

        }

        public static void CreateCMTableTuple()
        {
            List<Tuple<string, string>> list = AminoAcids.GetCodonMatixTuple();

            foreach (Tuple<string, string> kp in list)
            {
                Console.WriteLine("{0}:{1}", kp.Item1, kp.Item2);
            }

        }

        public static void TestGetCMforDNA()
        {
            String dna = "GTGCTACTAGTCGGAGTCGTGTGCTACTACTAGTCGTAGTCGTGGATAGTCGTGATATTATTAAGTCGTGCTAGTCAGTCGTGGTGTACTAGTCGTGAATACTAGTCGTGAATATTGCTGTGTGCTACTAGTCGTGGTGCTACACAGCTAGC";
            //Console.WriteLine(dna);
            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", dna);
            Console.WriteLine(DnaMethods.CodonMatrix(d));
        }

        public static void TestStats()
        {

            DNA d = new DNA(Guid.NewGuid(), "enm", "asc", "org", "loc", "desc", "ATGGATCGTAGCATGCTAGTCGATCGATGCTAGCTGATCGATGCTAGCCTAGCTAGCCTAGCTGATCGTAGCTGGATCGTAGCTGATGCTAGCTGATAGCCTAGCTGATCGTAGCTGGATCGTAGCTGCTAGCTGATCGTAGCTGAAGCCTAGCTGATCGTAGCTGTGCTAGCTGAATGCTAGCTGATCGATCTAGCTGATCGTAGCTGATGCTAGCTGAGCTGATGCATGATCGATGCTGACTGATCGTAGCTGATCGTAGCTGATCGTAGCTGATCGATGCTAGCTGACTGATCG");
            Console.WriteLine(d.Sequence);

            DNAStats st = new DNAStats(d);

            Console.WriteLine("Gene: {0}\n\nMOL: {1}\n\nCS: {2}\n\nR: {3}\n\nCM: {4}", st.Gene,
                st.MolWeight, st.CompStrand, st.Transcript, DnaMethods.CodonMatrix(d));
        }

        public static void TestCodonStats()
        {
            DNA d = new DNA(Guid.NewGuid(), "enm", "asc", "org", "loc", "desc", "ATGGATCGTAGCATGCTAGTCGATCGATGCTAGCTGATCGATGCTAGCCTAGCTAGCCTAGCTGATCGTAGCTGGATCGTAGCTGATGCTAGCTGATAGCCTAGCTGATCGTAGCTGGATCGTAGCTGCTAGCTGATCGTAGCTGAAGCCTAGCTGATCGTAGCTGTGCTAGCTGAATGCTAGCTGATCGATCTAGCTGATCGTAGCTGATGCTAGCTGAGCTGATGCATGATCGATGCTGACTGATCGTAGCTGATCGTAGCTGATCGTAGCTGATCGATGCTAGCTGACTGATCG");
            String cm = DnaMethods.CodonMatrix(d);
            Dictionary<string, int> cstats = DnaMethods.CodonCount(d);

            Console.WriteLine(cm + "\n");
            foreach (KeyValuePair<string, int> kp in cstats)
            {
                Console.WriteLine("{0} : {1}", kp.Key, kp.Value);
            }
        }

        public static void RandomSignal(String p, Int64 l)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            int r = 0;

            if (!String.IsNullOrEmpty(p))
            {
                for (Int64 i = 0; i <= l; i++)
                {
                    r = rnd.Next(0, p.Length);
                    Console.Write(p.Substring(r, 1));
                }
            }
        }

        public static void TestCodonMatrix()
        {
            Dictionary<string, string> cm = AminoAcids.GetCodonMatrix();

            foreach (KeyValuePair<string, string> kp in cm)
            {
                Console.WriteLine("{0}:{1}", kp.Key, kp.Value);
            }

            Console.WriteLine(cm.Count);
        }

        public static void RandomDNAtoCM(int len)
        {
            DNA pt = new DNA(Guid.NewGuid(), "", "", "", "", "", "ACTGACTG");

            DNA s = ORFMethods.GenerateRandomORF(len);
            //Console.WriteLine(s);

            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", s.Sequence);
            String tr = DnaMethods.Translate(d);
            String cm = DnaMethods.CodonMatrix(d);

            Dictionary<string, int> cstats = DnaMethods.CodonCount(d);
            Console.WriteLine(s);
            foreach (KeyValuePair<string, int> kp in cstats)
            {
                Console.WriteLine("{0}:{1}", kp.Key, kp.Value);
            }
            Console.WriteLine("\n");
        }

        public static void TestCodonPerc(int len, String p)
        {
            DNA pt = new DNA(Guid.NewGuid(), "", "", "", "", "", p);
            DNA s = ORFMethods.GenerateRandomORF(len);

            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", s.Sequence);
            Dictionary<string, int> cc = DnaMethods.CodonCount(d);
            foreach (KeyValuePair<string, int> kp in cc)
            {
                Console.WriteLine("{0}:{1}", kp.Key, kp.Value);
            }
            Console.WriteLine("\n");

            Dictionary<string, double> cp = DnaMethods.CodonPercentage(d);
            foreach (KeyValuePair<string, double> kp in cp)
            {
                Console.WriteLine("{0}:{1}", kp.Key, kp.Value);
            }
            Console.WriteLine("\n");

        }



        #endregion


        #region Search.Match

        public static void TestMatchSet(String s, String p, Double t)
        {
            Dictionary<Int32, Double> l = Find.MatchSet(s, p, t);

            foreach (KeyValuePair<int, double> kp in l)
            {
                Console.Write("K: {0}\tV: {1}\n", kp.Key, kp.Value);
            }

        }


        public static void TestMatchSequence(String s, String p, Double t)
        {
            Dictionary<Int32, Int32> l = Find.MatchSequences(s, p, t);

            foreach (KeyValuePair<int, int> kp in l)
            {
                Console.Write("K: {0}\tV: {1}\n", kp.Key, kp.Value);
            }

        }


        public static void TestFindEncryptionBlockDB()
        {
            String dc = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2011';Integrated Security=True";
            List<DNA> fs = new List<DNA>();


            SequenceStudio.Parsers.GetSequenceFromDB.ByOrganism(dc, "homo", 10, ref fs);

            foreach (DNA d in fs)
            {
                Console.WriteLine("ENU: {0}\tAC: {1}\tORG: {2}\n", d.Enumeration, d.Accession, d.Organism);
            }



            List<Tuple<int, int>> tlist = (Find.EncryptionBlock(fs[0]));

            foreach (Tuple<int, int> t in tlist)
            {
                Console.WriteLine("START: {0}\tSTOP: {1}\nSEQ: {2}", t.Item1, t.Item2, fs[0].Sequence.Substring(t.Item1, t.Item2 - t.Item1));
            }

        }


        public static void TestSequenceFromDB(String s, Int32 l)
        {
            List<DNA> fa = new List<DNA>();

            Console.WriteLine("START");

            GetSequenceFromDB.BySequence(Constants.ConnString, s, l, ref fa);

            foreach (DNA fs in fa)
            {
                Console.WriteLine("Organism: {0}\tDescription: {1}\tSeq Len: {2}",
                    fs.Organism, fs.Description, fs.Sequence.Length);
            }
        }


        public static void TestMakeDNA()
        {
            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "test", "ACATCGACTGCTGCTGCTCTCGTCGTGCTGCTGCA");
            Console.WriteLine(d.ToString());
        }


        public static void TestDNAStats()
        {
            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "test", "ACATCGACTGCTGCTGCTCTCGTCGTGCTGCTGCA");
            Console.WriteLine(d.ToString());

            DNAStats stats = new DNAStats(d);
            Console.WriteLine(stats.ToString());
        }


        public static void TestPolyStatsAndMol()
        {

            Poly p = new Poly(Guid.NewGuid(), "", "", "", "", "test", MakeTestPoly());
            Console.WriteLine(p.ToString());

            PolyStats stats = new PolyStats(p);
            Console.WriteLine(stats.Print());
        }


        public static void TestAminoList()
        {
            List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
            foreach (AminoAcids.AminoAcidBase b in aa)
            {
                Console.WriteLine(b.ToString() + "\n\n");
            }
        }


        public static void TestCopySequence()
        {
            DNA d1 = MakeTestDNA();
            DNA d2 = d1.Copy();

            Console.WriteLine("DNA 1\n" + d1.ToString());
            Console.WriteLine("DNA 2\n" + d2.ToString());
        }


        public static void TestRna()
        {
            RNA r = MakeTestRna();
            Console.WriteLine(r.ToString());

            RNAStats stats = new RNAStats(r);
            Console.WriteLine(stats.ToString());

            Console.WriteLine("Test Copy()\n\n");

            RNA r2 = r.Copy();
            Console.WriteLine(r2.ToString());
            RNAStats stats2 = new RNAStats(r2);
            Console.WriteLine(stats2.ToString());


        }


        public static void TestMatchPattern()
        {
            DNA d1 = MakeMyDNA("atcgatgatcgtcgatgcaatgctactgcatcgctactgctgtcaagctactactgaagctagtgatgctatcggctcgatgca");
            DNA d2 = MakeMyDNA("atcgatatacgtcgtgctggctactgcatagtcacgtgatgcatcacgtctacgatgtgaccgtagctgatgcacgatcatctt");

            String[] ret = FormatMethods.FormatNonMatchPattern(d1, d2);

            Console.WriteLine("FormatNonMatchPattern Results");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ret[0]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ret[1]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ret[2]);



            String[] ret2 = FormatMethods.FormatMatchPattern(d1, d2);
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ret2[0]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ret2[1]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(ret2[2]);

            Console.ForegroundColor = ConsoleColor.Green;
        }


        public static void TestMatchCount()
        {
            DNA d1 = MakeMyDNA("atcgatatacgtcgtgctggctactgcatagtcacgtgatgatcgatatacgtcgtgctggctactgcatagtcacgtgatgatcgatatacgtcgtgctggctactgcatatcgatatacgtcgtgctggctactgcat");
            DNA d2 = MakeMyDNA("atcgatatacgtcgtgctggctactgcatagtcacgtgatg");

            Dictionary<Int32, Int32> ret = Search.MatchCount(d1, d2, 00.0);

            foreach (KeyValuePair<int, int> kp in ret)
            {
                Console.WriteLine("L: {0}\tI: {1}", kp.Key, kp.Value);
            }
        }

        public static void TestLongestContiguousMatchRegions()
        {
            DNA s = MakeMyDNA("aaaaaaaaaactcgtgtagcgtgctcgtgaaaaaaaaaaaaaaaaaactcgtgtagcgtgctcgtgaaaaaaaaaaaactcgtgtagcgtgctcgtgaaaaaaaa");
            DNA p = MakeMyDNA("ctcgtgtagcgtgctcgtg");

            Dictionary<Int32, Int32> matches = Search.ContiguousMatchRegions(s, p, 50.0);
            foreach (KeyValuePair<int, int> kp in matches)
            {
                Console.WriteLine("LOCUS: {0}\tLENGTH: {1}", kp.Key, kp.Value);
            }


        }

        public static void TestMatchInterval()
        {
            DNA s = MakeMyDNA("t");
            DNA p = MakeMyDNA("aaa");
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(11);
            list.Add(15);
            list.Add(21);

            Dictionary<Int32, Double> matches = Search.MatchInterval(s, p, list, 50.0);
            foreach (KeyValuePair<int, double> kp in matches)
            {
                Console.WriteLine("LOCUS: {0}\tPER: {1}", kp.Key, kp.Value);
            }


        }

        public static void TestRepeats()
        {
            DNA s = MakeMyDNA("atgctagatcgatcgtacatgctagctgatcgatgctacgatgcatgctactactatcgatgctgac");

            List<Tuple<int, int>> matches = Search.Repeats(s, 30);
            foreach (Tuple<int, int> kp in matches)
            {
                Console.WriteLine("LOCUS: {0}\tLENGTH: {1}", kp.Item1, kp.Item2);
            }


        }


        #endregion


        #region ORFs

        public static void TestFindEncryptionBlock()
        {
            String start = UnitPatterns.tripleStart;
            String stop = UnitPatterns.tripleStop;
            String inner = "ACTGACTGTG";
            String s = start + inner + stop;

            DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", s);

            List<Tuple<int, int>> list = Find.EncryptionBlock(d);

            foreach (Tuple<int, int> t in list)
            {
                Console.WriteLine("START: {0}\tSTOP: {1}", t.Item1, t.Item2);
            }
        }

        public static void TestGetLongestORF()
        {
            DNA yes = MakeMyDNA("tgcgtgctctcgtgatgtcgtcgctgtcgtcggccagccctagctgtgctagctagtagctgactgactgatcggccctagctgactagacgatcggccctagctgatcgatagtacgtcggccctagcgccctagctagcgtgctgactga");
            DNA no = MakeMyDNA("cgtgctctcgtgtgtcgtcgctgtcgtcggccagccctagctgtgctagctagtagctgactgactgatcggccctagctgactagacgatcggccctagctgatcgatagtacgtcggccctagcgccctagctagcgtgctgactga");

            Dictionary<Int32, Int32> orf = ORFMethods.GetLongestORF(no);

            Console.WriteLine("SEQUENCE>LENGTH: {0}\tLOCUS: {1}\tLENGTH: {2}", no.Sequence.Length, orf.Keys.First(), orf.Values.First());
        }

        public static void TestGetContiguousORFList()
        {
            DNA yes = MakeMyDNA("atgtttttttttttagatgtagatggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggtagatgtagatgtagatgtagatgtagatgtagatgtagatgtagatgtag");
            DNA no = MakeMyDNA("gcccgtcgtcgtcgtcgctgtcgtcgtgtaggcccgtcgtcgtcgtcgctgtcgtcgtgtaggcccgtcgtcgtcgtcgctgtcgtcgtgtagtcgctgtcgtcggccgcgcgtag");

            Dictionary<Int32, Int32> orf = ORFMethods.GetContiguousORFList(no, 5);
            foreach (KeyValuePair<int, int> kp in orf)
            {
                Console.WriteLine("SEQUENCE_LENGTH: {0}\tLOCUS: {1}\tLENGTH: {2}", no.Sequence.Length, kp.Key, kp.Value);
            }

            Dictionary<Int32, String> list = ORFMethods.GenerateNonOverlappingORFs(orf, no);
            foreach (KeyValuePair<int, string> kp in list)
            {
                Console.WriteLine("LOCUS: {0}\tSTRAND: {1}", kp.Key, kp.Value);
            }
        }

        #endregion


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


    }

}