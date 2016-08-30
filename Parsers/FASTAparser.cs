//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SequenceStudio.Internal;
using System.IO;

namespace SequenceStudio.Parsers
{

    public class BaseParser
    {
        /// <summary>
        /// Reads a downloaded FASTA (****.nt) file into memory and renders it as a string
        /// </summary>
        /// <param name="path">String, valid path to a *.nt file</param>
        /// <returns>String, the entire file as a valid string</returns>
        /// <remarks>Typically, the results of this method are passed to the ParseSequence method.</remarks>
        public static String ReadFASTAFile(String path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                if (File.Exists(@"C:\Users\jmorey\Documents\yeast.nt"))
                {

                    try
                    {
                        String seq = (String)File.ReadAllText(path);
                        return seq;
                    }
                    catch (UnauthorizedAccessException ue)
                    {
                        throw;
                    }
                    catch (IOException ioe)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                else
                {
                    Exception e = new Exception("The file was not found.");
                    throw e;
                }
            }
            else
            {
                Exception e = new Exception("The file path was empty.");
                throw e;
            }
        } //COMPLETE and TESTED

        /// <summary>
        /// Creates a List(SequenceBase) from a string output from ReadFASTAFile()
        /// </summary>
        /// <param name="seq">String, the output of the ReadFASTAFile() method</param>
        /// <returns>List(SequenceBase)</returns>
        public static List<SequenceBase> ParseSequence(String seq, ref Dictionary<Int32, String> errors)
        {
            Char[] line = new char[] { '\n' }; //define separators
            Char[] sep = new char[] { '|' };
            Char[] metasp = new char[] { ' ' };

            // Breaks the entire string into sequence entries consisting of metadata and the sequence
            String[] seqArray = seq.Split(new char[] { '>' }); // create arrays for string splitting
            String[] meta = new String[5];
            String[] org_array = new String[2];

            List<SequenceBase> seqList = new List<SequenceBase>();
            Int32 index = 0;
            Int32 first = 0;
            String s = "";
            String enm = "";
            String asc = "";
            String desc = "";
            String loc = "";
            String org = "";

            if (seqArray.Length > 1)
            {

                for (index = 1; index <= seqArray.Length - 1; index++)
                {
                    String[] divSeq = { "", "" };
                    divSeq[0] = ""; //blank the array for each cycle
                    divSeq[1] = "";

                    first = seqArray[index].IndexOf(line[0]); //find the first instance of the null char

                    try
                    {
                        divSeq = seqArray[index].Split(line, 2);//split the string into the metadata and the sequence
                        s = divSeq[1].Replace(line[0].ToString(), String.Empty); // parse the sequence and store it in the class

                        divSeq[0] = divSeq[0].Replace(">", String.Empty); //remove the initial '>' 
                        meta = divSeq[0].Split(sep, 5); // split the metadata string into the components
                        enm = meta[1];
                        asc = meta[3];
                        meta[4] = meta[4].Trim();
                        org_array = meta[4].Split(metasp, 3); // split the organsim string into components

                        org = org_array[0] + " " + org_array[1];
                        desc = org_array[2];
                    }
                    catch (IndexOutOfRangeException i1)
                    {
                        errors.Add(index, divSeq[0]);
                    }

                    try
                    {
                        DNA fc = new DNA(Guid.NewGuid(), enm, asc, org, loc, desc, s); //need to re-create class each time to add new values
                        seqList.Add(fc); //a add new class instance to list
                    }
                    catch (Exception e)
                    {
                        errors.Add(index, divSeq[0]);
                    }
                }

                seq = ""; //zero out memory
                return seqList;
            }
            else
            {
                throw new Exception("The file did not yield any sequence entries");
            }

        } //COMPLETE and TESTED

    }

    public class FASTAparser
    {
        /// <summary>
        /// Reads a downloaded FASTA (****.nt) file into memory and renders it as a string
        /// </summary>
        /// <param name="path">String, valid path to a *.nt file</param>
        /// <returns>String, the entire file as a valid string</returns>
        /// <remarks>Typically, the results of this method are passed to the ParseFASTASequence method.</remarks>
        public static String ReadFASTAFile(String path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {

                    try
                    {
                        String seq = (String)File.ReadAllText(path);
                        return seq;
                    }
                    catch (UnauthorizedAccessException ue)
                    {
                        throw;
                    }
                    catch (IOException ioe)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
                else
                {
                    Exception e = new Exception("The file was not found.");
                    throw e;
                }
            }
            else
            {
                Exception e = new Exception("The file path was empty.");
                throw e;
            }
        } //COMPLETE and TESTED


        /// <summary>
        /// Creates a List(DNA) from a string output from ReadFASTAFile()
        /// </summary>
        /// <param name="seq">String, the uotput of the ReadFASTAFile() method</param>
        /// <returns>List(DNA)</returns>
        public static List<DNA> ParseFASTASequence(String seq, ref Dictionary<Int32, String> errors)
        {
            Char[] line = new char[] { '\n' }; //define separators
            Char[] sep = new char[] { '|' };
            Char[] metasp = new char[] { ' ' };

            // Breaks the entire string into sequence entries consisting of metadata and the sequence
            String[] seqArray = seq.Split(new char[] { '>' }); // create arrays for string splitting
            errors.Add(seqArray.Length, "Total DNA Sequences");
            String[] meta = new String[5];
            String[] org_array = new String[2];

            List<DNA> seqList = new List<DNA>();
            Int32 index = 0;
            Int32 first = 0;
            String s = "";
            String enm = "";
            String asc = "";
            String desc = "";
            String org = "";
            String loc = "";

            if (seqArray.Length > 1)
            {
                for (index = 1; index <= seqArray.Length - 1; index++)
                {
                    String[] divSeq = { "", "" };
                    divSeq[0] = ""; //blank the array for each cycle
                    divSeq[1] = "";

                    first = seqArray[index].IndexOf(line[0]); //find the first instance of the null char

                    try
                    {
                        divSeq = seqArray[index].Split(line, 2);//split the string into the metadata and the sequence
                        s = divSeq[1].Replace(line[0].ToString(), String.Empty); // parse the sequence and store it in the class

                        divSeq[0] = divSeq[0].Replace(">", String.Empty); //remove the initial '>' 
                        meta = divSeq[0].Split(sep, 5); // split the metadata string into the components
                        enm = meta[1];
                        asc = meta[3];

                        meta[4] = meta[4].Trim();
                        org_array = meta[4].Split(metasp, 3); // split the organsim string into components

                        org = org_array[0] + " " + org_array[1];
                        desc = org_array[2];
                    }

                    // TODO: NOTE - this method might generate errors if the input string contains segments 
                    // that generate IndexOutOfRangeException. If this is true we must create another 
                    // method that cleases the string like we do for Poly.
                    catch (IndexOutOfRangeException i1)
                    {
                        errors.Add(index, divSeq[0]);
                    }

                    try
                    {
                        DNA fc = new DNA(Guid.NewGuid(), enm, asc, org, loc, desc, s); 
                        //need to re-create class each time to add new values
                        seqList.Add(fc); //a add new class instance to list
                    }
                    catch (Exception e)
                    {
                        errors.Add(index, divSeq[0]);
                    }
                }

                seq = ""; //zero out memory
                return seqList;
            }
            else
            {
                throw new Exception("The file did not yield any sequence entries");
            }

        } //COMPLETE and TESTED

        /// <summary>
        /// Creates a List(DNA) from a string output from ReadFASTAFile().
        /// This class instances are simplified as a fall-back for parsing errors.
        /// </summary>
        /// <param name="seq">String, the output of the ReadFASTAFile() method</param>
        /// <returns>List(DNA)</returns>
        public static List<DNA> ParseFASTASequenceSimple(String seq)
        {
            Char[] line = new char[] { '\n' }; //define separators
            Char[] sep = new char[] { '|' };
            Char[] metasp = new char[] { ' ' };

            // Breaks the entire string into sequence entries consisting of metadata and the sequence
            String[] seqArray = seq.Split(new char[] { '>' }); // create arrays for string splitting
            String[] divSeq = { "", "" };
            String[] meta = new String[5];
            String[] org_array = new String[2];

            List<DNA> seqList = new List<DNA>();
            Int32 index = 0;

            if (seqArray.Length > 1)
            {

                //FASTAsequence[] seqTable = new DNA[seqArray.Length];

                try
                {
                    for (index = 1; index <= seqArray.Length - 1; index++)
                    {
                        divSeq[0] = ""; //blank the array for each cycle
                        divSeq[1] = "";

                        Int32 first = seqArray[index].IndexOf(line[0]); //find the first instance of the null char
                        divSeq = seqArray[index].Split(line, 2);//split the string into the metadata and the sequence
                        String s = divSeq[1].Replace(line[0].ToString(), String.Empty); // parse the sequence and store it in the class
                        DNA fc = new DNA( Guid.NewGuid(), "", "", "", "", divSeq[0], s ); //create the struct providing only the seq and desc.

                        seqList.Add(fc); //a add new class instance to list
                    }
                }
                catch (IndexOutOfRangeException i)
                {
                    Exception e = new Exception("IndexOutOfRangeException\nMethod: ParseFASTASequenceSimple\nThe index is:  " + index.ToString() + "\n" + divSeq[0]);
                    throw;
                }


                divSeq = null; //zero out memory
                seq = ""; //zero out memory
                return seqList;
            }
            else
            {
                throw new Exception("The file did not yield any sequence entries");
            }

        } //COMPLETE and TESTED

    }

}
