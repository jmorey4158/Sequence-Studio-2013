//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using SequenceStudio.Internal;
using System.Xml;
using SequenceStudio.Storage;



namespace SequenceStudio.Search
{
    public static class SearchMethods
    {
        /// <summary>
        /// Searches a list of FASTA sequences for an organsim entry that matches the input string.
        /// The method uses a path to an XML file of Classes and creates and in-memory list
        /// of FASTASequence obljects.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="inFile">full path to the XML file to search</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchOrganism(String term, String inFile, ref List<DNA> sl)
        {
            if (File.Exists(inFile))
            {
                try
                {
                    List<DNA> fc = StorageMethods.ListFromXML(inFile);
                    foreach (DNA fs in fc)
                    {
                        if (fs.Organism.Contains(term))
                        {
                            sl.Add(fs);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        } 

        /// <summary>
        /// Searches a list of FASTA sequences for a description entry that matches the input string.
        /// The method uses a path to an XML file of FASTASequence Classes and creates and in-memory list
        /// of FASTASequence obljects.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="inFile">full path to the XML file to search</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchDescription(String term, String inFile, ref List<DNA> sl)
        {
            if (File.Exists(inFile))
            {
                try
                {

                    List<DNA> fc = StorageMethods.ListFromXML(inFile);
                    foreach (DNA fs in fc)
                    {
                        if (fs.Description.Contains(term))
                        {
                            sl.Add(fs);
                        }

                    }

                }
                catch (Exception e)
                {
                    throw;
                }

            }



        } 

        /// <summary>
        /// Searches a list of FASTA sequences for an ascession number entry that matches the input string.
        /// The method uses a path to an XML file of FASTASequence Classes and creates and in-memory list
        /// of FASTASequence obljects.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="inFile">full path to the XML file to search</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchAscession(String term, String inFile, ref List<DNA> sl)
        {
            if (File.Exists(inFile))
            {
                try
                {

                    List<DNA> fc = StorageMethods.ListFromXML(inFile);
                    foreach (DNA fs in fc)
                    {
                        if (fs.Accession.Contains(term))
                        {
                            sl.Add(fs);
                        }

                    }

                }
                catch (Exception e)
                {
                    throw;
                }

            }



        } 

        /// <summary>
        /// Searches a list of FASTA sequences for a sequence entry that matches the input string.
        /// The method uses a path to an XML file of FASTASequence Classes and creates and in-memory list
        /// of FASTASequence obljects.
        /// </summary>
        /// <param name="term">a string to search for; must be a valid DNA sequence</param>
        /// <param name="inFile">full path to the XML file to search</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchSequence(String term, String inFile, ref List<DNA> sl)
        {
            if (File.Exists(inFile))
            {
                try
                {
                    term = term.ToUpper();
                    List<DNA> fc = StorageMethods.ListFromXML(inFile);
                    foreach (DNA fs in fc)
                    {
                        if (fs.Sequence.Contains(term))
                        {
                            sl.Add(fs);
                        }

                    }

                }
                catch (Exception e)
                {
                    throw;
                }

            }



        } 

        /// <summary>
        /// Searches a list of FASTA sequences for an enumeration entry that matches the input string.
        /// The method uses a path to an XML file of FASTASequence Classes and creates and in-memory list
        /// of FASTASequence obljects.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="inFile">full path to the XML file to search</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchEnumeration(String term, String inFile, ref List<DNA> sl)
        {
            if (File.Exists(inFile))
            {
                try
                {

                    List<DNA> fc = StorageMethods.ListFromXML(inFile);
                    foreach (DNA fs in fc)
                    {
                        if (fs.Enumeration.Contains(term))
                        {
                            sl.Add(fs);
                        }

                    }

                }
                catch (Exception e)
                {
                    throw;
                }

            }



        } 

        /// <summary>
        /// Searches a list of FASTASequence obljects for an organsim entry that matches the input string.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="dl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchOrganism(String term, ref List<DNA> fl)
        {
            List<DNA> temp = new List<DNA>();
            foreach (DNA fc in fl)
            {
                if (fc.Organism.Contains(term))
                {
                    temp.Add(fc);
                }
            }
            fl.Clear();
            fl = temp;
        } 

        /// <summary>
        /// Searches a list of FASTASequence obljects for an ascession number entry that matches the input string.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="fl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchAscession(String term, ref List<DNA> fl)
        {
            List<DNA> temp = new List<DNA>();
            foreach (DNA fc in fl)
            {
                if (fc.Accession.Contains(term))
                {
                    temp.Add(fc);
                }
            }
            fl.Clear();
            fl = temp;
        } 

        /// <summary>
        /// Searches a list of FASTASequence obljects for a description entry that matches the input string.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="fl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchDescription(String term, ref List<DNA> fl)
        {
            List<DNA> temp = new List<DNA>();
            foreach (DNA fc in fl)
            {
                if (fc.Description.Contains(term))
                {
                    temp.Add(fc);
                }
            }
            fl.Clear();
            fl = temp;
        } 

        /// <summary>
        /// Searches a list of FASTASequence obljects for a DNA sequence entry that matches the input string.
        /// </summary>
        /// <param name="term">a string to search for; muat be a valid DNA sequence</param>
        /// <param name="fl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchSequence(String term, ref List<DNA> fl)
        {
            term = term.ToUpper();
            List<DNA> temp = new List<DNA>();
            foreach (DNA fc in fl)
            {
                if (fc.Sequence.Contains(term))
                {
                    temp.Add(fc);
                }
            }
            fl.Clear();
            fl = temp;
        } 

        /// <summary>
        /// Searches a list of FASTASequence obljects for an enumeration entry that matches the input string.
        /// </summary>
        /// <param name="term">a string to search for</param>
        /// <param name="sl">List(FASTASequence) that is returned with matches, if any</param>
        public static void SearchEnumeration(String term, ref List<DNA> fl)
        {
            List<DNA> temp = new List<DNA>();
            foreach (DNA fc in fl)
            {
                if (fc.Enumeration.Contains(term))
                {
                    temp.Add(fc);
                }
            }
            fl.Clear();
            fl = temp;
        } 

    }

}
