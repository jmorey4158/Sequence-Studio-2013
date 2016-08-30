//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without 
//express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Sql;

using SequenceStudio.Internal;

namespace SequenceStudio.Parsers
{
    public static class AAParsers
    {

        /// <summary>
        /// Creates a List(Polypeptide) from a string output from ReadFASTAFile()
        /// NOTE - calls CleansePoly(String inStr) to rid records of 'bad' parts that break parsing
        /// </summary>
        /// <param name="seq">String, the output of the ReadFASTAFile() method</param>
        /// <param name="errors">Dictionary(Int32, String) - a list of location (i.e. record no.) and the data that 
        ///  caused some parsiing error. This list can be examined and new 'bad parts' added to CleansePoly(String inStr)</param>
        /// <returns>List(FASTASequence)</returns>
        public static List<Poly> ParsePoly(String seq, ref Dictionary<Int32, String> errors)
        {
            seq = CleansePoly(seq); // use separate Method to clear out 'bad' parts of the records

            Char[] line = new char[] { '\n' }; //define separators
            Char[] sep = new char[] { '|' };
            Char[] metasp = new char[] { ' ' };

            // Breaks the entire string into sequence entries consisting of metadata and the sequence
            String[] seqArray = seq.Split(new char[] { '>' }); // create arrays for string splitting
            //errors.Add(seqArray.Length, "Total Sequence Count"); //count total Polys. Might be off of final tally becasue of '>'

            String[] meta = new String[6];
            String enm = "";
            String asc = "";
            String desc = "";
            String s = "";
            String loc = "";
            String org = "";
            Int32 first = 0;

            List<Poly> seqList = new List<Poly>();

            Int32 index = 0;

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
                        meta = divSeq[0].Split(sep, 6); // split the metadata string into the components
                        enm = meta[1];
                        asc = meta[3];
                        desc = meta[4].Trim();
                    }
                    catch (IndexOutOfRangeException i1)
                    {
                        errors.Add(index, divSeq[0]);
                    }

                    try
                    {
                        Poly fc = new Poly(Guid.NewGuid(),enm, asc, org, loc, desc, s); //need to re-create class each time to add new values
                        seqList.Add(fc); // add new class instance to list
                    }
                    catch (Exception e)
                    {
                        errors.Add(index, divSeq[0]);
                    }
                }
                seq = ""; //'seq' is a String that contains all of the data; zeroing makes sure that it is cleaned up
                return seqList;
            }
            else
            {
                throw new Exception("The file did not yield any sequence entries");
            }
        } //NOT TESTED

        public static String CleansePoly(String inStr)
        {
            String outStr = inStr;
            outStr = outStr.Replace("3->5", "3 to 5"); //the '3->5' was breaking the Split() later.
            outStr = outStr.Replace("3'->5'", "3 to 5"); //the '3->5' was breaking the Split() later.
            outStr = outStr.Replace("[", "("); //the '3->5' was breaking the Split() later.
            outStr = outStr.Replace("]", ")"); //the '3->5' was breaking the Split() later.

            return outStr;
        }


    }
}
