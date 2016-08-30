//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

using SequenceStudio.Internal;
using SequenceStudio.Parsers;

namespace SequenceStudio.Storage
{
    public class StorageMethods
    {
        /// <summary>
        /// Creates and saves to disk an XML file from a FASTA *.nt file on disk
        /// </summary>
        /// <param name="inFile">String, path to a valid FASTA *.nt file</param>
        /// <param name="outFile">String, valid path for output XML file</param>
        public static void XMLfromFASTA(String inFile, String outFile)
        {
            if (File.Exists(inFile))
            {
                String s = FASTAparser.ReadFASTAFile(inFile);
                Dictionary<int, string> err = new Dictionary<int, string>();
                try
                {
                    List<DNA> fclass = FASTAparser.ParseFASTASequence(s, ref err);
                    SequenceLINQtoXML(fclass, outFile);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        } //COMPLETE and TESTED

        /// <summary>
        /// Creates and saves to disk an XML file from a FASTA *.nt file on disk.
        /// This format is a simplified format to accomidate parsing errors.
        /// </summary>
        /// <param name="inFile">String, path to a valid FASTA *.nt file</param>
        /// <param name="outFile">String, valid path for output XML file</param>
        public static void XMLfromFASTASimple(String inFile, String outFile)
        {
            if (File.Exists(inFile))
            {
                String s = FASTAparser.ReadFASTAFile(inFile);
                List<DNA> fclass = FASTAparser.ParseFASTASequenceSimple(s);
                StorageMethods.SequenceLINQtoXML(fclass, outFile);
            }
        } //COMPLETE and TESTED

        /// <summary>
        /// PRocesses an entir folder with *.nt files into a set of .xml files
        /// and stores them in a child \outXML\ folder
        /// </summary>
        /// <param name="in_folder">String, path to a folder with valid *.nt files</param>
        /// <returns>Bolean, false = errors</returns>
        public static Boolean DoAllFilestoXML(String in_folder)
        {
            if (Directory.Exists(in_folder))
            {
                String out_folder = in_folder + "\\outXML";
                if (!Directory.Exists(out_folder)) { Directory.CreateDirectory(out_folder); }


                String[] files = Directory.GetFiles(in_folder);
                foreach (String s in files)
                {
                    if (s.EndsWith(".nt"))
                    {
                        String infn = s;
                        String outfn = s.Replace(".nt", ".xml").Replace(in_folder, out_folder); ;
                        XMLfromFASTA(infn, outfn);
                    }
                }
                return true;
            }

            return false;
        } //COMPLETE and TESTED

        /// <summary>
        /// Saves a List(FASTASequence) as an XML file
        /// </summary>
        /// <param name="seqList">List(FASTASequence)</param>
        /// <param name="outFile">String, valid path</param>
        public static void SequenceLINQtoXML(List<DNA> seqList, String outFile)
        {

            var xmlSeq = new XElement("FASTAsequenceSet", from s in seqList
                                                          select new XElement("FASTAsequence",
                                                              new XElement("ID", s.ID),
                                                              new XElement("Enumeration", s.Enumeration),
                                                              new XElement("Ascession", s.Accession),
                                                              new XElement("Organsim", s.Organism),
                                                              new XElement("Locus",s.Locus),
                                                              new XElement("Description", s.Description),
                                                              new XElement("Sequence", s.Sequence)));

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlSeq.ToString());

            XmlTextWriter writer = new XmlTextWriter(outFile, null);
            writer.Formatting = Formatting.None;
            xdoc.Save(writer);
            xdoc = null;
            writer.Close();
            xmlSeq = null;

        } //COMPLETE and TESTED

        /// <summary>
        /// Saves a DNASequence class insance as an XML file
        /// </summary>
        /// <param name="dna">DNASequence class instance</param>
        /// <param name="outFile">String, valid path</param>
        public static void DNASequenceLINQtoXML(DNA dna, DNAStats stats, String outFile)
        {

            var xmlSeq = new XElement("DNASequence",
                new XElement("ID", dna.ID),
                new XElement("Enumeration", dna.Enumeration),
                new XElement("Ascession", dna.Accession),
                new XElement("Organsim", dna.Organism),
                new XElement("Locus", dna.Locus),
                new XElement("Description", dna.Description),
                new XElement("Sequence", dna.Sequence));

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlSeq.ToString());

            XmlTextWriter writer = new XmlTextWriter(outFile, null);
            writer.Formatting = Formatting.None;
            xdoc.Save(writer);
            xdoc = null;
            writer.Close();
            xmlSeq = null;

        } //COMPLETE and TESTED

        public static List<DNA> ListFromXML(String xmlPath)
        {

            if (File.Exists(xmlPath))
            {
                List<DNA> sl = new List<DNA>();
                XmlReader reader = XmlReader.Create(xmlPath);

                reader.ReadStartElement("DnaSequenceSet");
                while (!reader.EOF)
                {
                    try
                    {
                        reader.ReadStartElement("DnaSequence");
                    }
                    catch (XmlException xe)
                    {
                        if (xe.Message.Contains("'EndElement' is an invalid XmlNodeType"))
                        {
                            reader.Close();
                            return sl;
                        }
                        else
                        {
                            reader.Close();
                            throw;
                        }

                    }

                    #region Create XML


                    reader.ReadStartElement("ID");
                    String ID = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Enumeration");
                    String Enumeration = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Ascession");
                    String Ascession = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Organsim");
                    String Organism = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Locus");
                    String Locus = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Description");
                    String Description = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Sequence");
                    String Sequence = reader.ReadString();
                    reader.ReadEndElement();
                    #endregion

                    sl.Add(new DNA( Guid.NewGuid(), Enumeration, Ascession, Organism, Locus, Description, Sequence ));

                    reader.ReadEndElement();
                }
                reader.Close();
                return sl;
            }
            else
            {
                throw new Exception("The XML file was not found");
            }


        } 
        //COMPLETE AND TESTED; Performance testing revealed this method uses 78.9% of CPU

       
        
        // NOT PREFERED METHOD - Use StoreSequenceDataTable


        public static void StoreSequenceSQL(List<DNA> seqList, String dc)
        {
            if ((seqList.Count > 0) || (File.Exists(dc)))
            {
                try
                {
                    DataContext fastadb = new DataContext(dc);
                    Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();

                    foreach (DNA fc in seqList)
                    {
                        TableDefs.DNATable fa = new TableDefs.DNATable();

                        fa.ID = Guid.NewGuid();
                        fa.Enumeration = fc.Enumeration;
                        fa.Ascession = fc.Accession;
                        fa.Organism = fc.Organism;
                        fa.Locus = fc.Locus;
                        fa.Description = fc.Description;
                        fa.Sequence = fc.Sequence;

                        FastA.InsertOnSubmit(fa);
                        fastadb.SubmitChanges();
                    }
                            
                }
                catch (Exception e)
                {
                    throw;
                }
            }    
            else
            {
                throw new Exception("The database file does not exist.");
            }
        }//COMPLETE

        /// <summary>
        /// Updates the SQL DB with the new rows
        /// </summary>
        /// <param name="seqList"></param>
        /// <param name="dc">List(Type) - the list of the sequence items. Can be any of: FASTASequence, Polypeptide</param>
        /// <param name="tblName">The name of the existing DB table</param>
        public static void StoreSequenceDataTable(List<DNA> seqList, String dc, String tblName)
        {
            if ((seqList.Count > 0) || (File.Exists(dc)))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dc))
                    {
                        String tsql = "SELECT TOP (1) * FROM dbo." + tblName;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(tsql, conn);
                        SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                        DataTable dt = new DataTable();


                        da.Fill(dt);
                        if (dt.Rows.Count > 0) 
                        { 
                            dt.Rows.RemoveAt(0);
                        }

                        foreach (DNA fc in seqList)
                        {
                            DataRow fa = dt.NewRow();
                            try
                            {
                                fa["ID"] = Guid.NewGuid();
                                fa["Enumeration"] = fc.Enumeration;
                                fa["Ascession"] = fc.Accession;
                                fa["Organism"] = fc.Organism;
                                fa["Locus"] = fc.Locus;
                                fa["Description"] = fc.Description;
                                fa["Sequence"] = fc.Sequence;
                            }
                            catch (ArgumentException e) { }
                                dt.Rows.Add(fa);
                        }
                        da.Update(dt);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }    
            else
            {
                throw new Exception("The database file does not exist.");
            }
        }//COMPLETE
        public static void StoreSequenceDataTable(List<Poly> seqList, String dc, String tblName)
        {
            if ((seqList.Count > 0) || (File.Exists(dc)))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dc))
                    {
                        String tsql = "SELECT TOP (1) * FROM dbo." + tblName;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(tsql, conn);
                        SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        if (dt.Rows.Count > 0) 
                        { 
                            dt.Rows.RemoveAt(0);
                        }
                            
                        foreach (Poly fc in seqList)
                        {
                            DataRow fa = dt.NewRow();
                            try
                            {
                                fa["ID"] = Guid.NewGuid();
                                fa["Enumeration"] = fc.Enumeration;
                                fa["Ascession"] = fc.Accession;
                                fa["Organsim"] = fc.Organism;
                                fa["Locus"] = fc.Locus;
                                fa["Description"] = fc.Description;
                                fa["Sequence"] = fc.Sequence;
                            }
                            catch (ArgumentException e) { }
                            dt.Rows.Add(fa);
                        }
                        da.Update(dt);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }    
            else
            {
                throw new Exception("The database file does not exist.");
            }
        }//COMPLETE


        public static void StoreErrors(Dictionary<Int32, String> errors, String dc, String tblName)
        {
            if ((errors.Count > 0) || (File.Exists(dc)))
            {
                try
                {
                    CreateDatabase.CreateCustomTable(dc, CreateDatabase.TableCommand(tblName, Constants.db_Errors));

                    using (SqlConnection conn = new SqlConnection(dc))
                    {
                        String tsql = "SELECT TOP (1) * FROM dbo." + tblName;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(tsql, conn);
                        SqlCommandBuilder sqlcb = new SqlCommandBuilder(da);
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            dt.Rows.RemoveAt(0);
                        }

                        foreach (KeyValuePair<Int32,String> kp in errors)
                        {
                            DataRow fa = dt.NewRow();
                            try
                            {
                                fa["ID"] = Guid.NewGuid();
                                fa["Record"] = kp.Key;
                                fa["Data"] = kp.Value;
                            }
                            catch (ArgumentException e) { }
                            dt.Rows.Add(fa);
                        }
                        da.Update(dt);
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("The database file does not exist.");
            }
        }//COMPLETE



        #region NOT COMPLETE

        public static List<DNA> RetrieveFromXMLStream(String xmlPath)
        {

            if (File.Exists(xmlPath))
            {
                List<DNA> sl = new List<DNA>();
                XmlReader reader = XmlReader.Create(xmlPath);

                reader.ReadStartElement("FASTAsequenceSet");
                while (!reader.EOF)
                {
                    try
                    {
                        reader.ReadStartElement("FASTAsequence");
                    }
                    catch (XmlException xe)
                    {
                        if (xe.Message.Contains("'EndElement' is an invalid XmlNodeType"))
                        {
                            reader.Close();
                            return sl;
                        }
                        else
                        {
                            reader.Close();
                            throw;
                        }

                    }

                    #region CreateXML

                    reader.ReadStartElement("Enumeration");
                    String Enumeration = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Ascession");
                    String Ascession = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Organsim");
                    String Organism = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Locus");
                    String Locus = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Description");
                    String Description = reader.ReadString();
                    reader.ReadEndElement();

                    reader.ReadStartElement("Sequence");
                    String Sequence = reader.ReadString();
                    reader.ReadEndElement();
                    #endregion

                    sl.Add(new DNA( Guid.NewGuid(), Enumeration, Ascession, Organism, Locus, Description, Sequence ));

                    reader.ReadEndElement();
                }
                reader.Close();
                return sl;
            }
            else
            {
                throw new Exception("The XML file was not found");
            }


        } //NOT COMPLETE



        public static void StoreSequenceDB(String meta, String seq)
        {
            try
            {
                DataContext fastadb = new DataContext(@"Data Source=C:\Users\jmorey\Documents\Sequences.sdf");
                Table<DNA> FastA = fastadb.GetTable<DNA>();

                for (int i = 0; i < 10; i++)
                {
                    fastadb.ExecuteCommand("INSERT INTO FASTA_sequences (Metadata,Sequence) VALUES(N'" + meta + "', N'" + seq + "')");
                }

            }
            catch (Exception e)
            {
                throw;
            }

        }//NOT COMPLETE
        
        #endregion

    }

}
