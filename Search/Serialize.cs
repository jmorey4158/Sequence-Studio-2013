//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace SequenceStudio
{
    public class Serialize
    {
        //public static void SerializeToFile(DNASequence dna, FileInfo file)
        //{

        //}//NOT COMPLETED
        //public static void DeserializeFromFile(Guid SeqID, FileInfo file)
        //{

        //}//NOT COMPLETED

        //public static void SerializeToSoap()
        //{

        //}//NOT COMPLETE
        //public static void DeserializeFromSoap()
        //{

        //}//NOT COMPLETE

        /// <summary>
        /// Serializes a set of matches (locus, percentage) to an in-memory XMLDocument class instance
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Double) locus, percentage match</param>
        /// <returns>XmlDocument class instance</returns>
        public static XmlDocument SerializeToXML(Dictionary<Int32, Double> matches)
        {
            StringBuilder sb = new StringBuilder();
            XmlDocument xdoc = new XmlDocument();
            sb.Append("<matchSet>");
            foreach (KeyValuePair<Int32, Double> kp in matches)
            {
                sb.Append("<match><locus>" + kp.Key.ToString() + "</locus>" +
                    "<percentage>" + kp.Value.ToString() + "</percentage></match>");
            }
            sb.Append("</matchSet>");
            xdoc.LoadXml(sb.ToString());
            return xdoc;
        }

        /// <summary>
        /// Serializes a set of matches (locus, length) to an in-memory XMLDocument class instance
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Int32) locus, percentage match</param>
        /// <returns>XmlDocument class instance</returns>
        public static XmlDocument SerializeToXML(Dictionary<Int32, Int32> matches)
        {
            StringBuilder sb = new StringBuilder();
            XmlDocument xdoc = new XmlDocument();
            sb.Append("<matchSet>");
            foreach (KeyValuePair<Int32, Int32> kp in matches)
            {
                sb.Append("<match><locus>" + kp.Key.ToString() + "</locus>" +
                    "<length>" + kp.Value.ToString() + "</length></match>");
            }
            sb.Append("</matchSet>");
            xdoc.LoadXml(sb.ToString());
            return xdoc;
        }


    } //WORKING BUT NOT COMPLETE

}
