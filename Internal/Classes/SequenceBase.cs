//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express 
//written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SequenceStudio.Internal;


namespace SequenceStudio
{
    /// <summary>
    /// Base Class for the DNA, Poly, and RNA classes
    /// </summary>
    /// <remarks>Typically, you would use an instance of one of the derived classes, DNA, RNA, or Poly.</remarks>
    public class SequenceBase
    {
       protected String _enm, _acc, _org, _loc, _desc, _seq;
       protected Guid _id;

       protected SequenceBase() { }

       public SequenceBase(Guid id, String enm, String acc, String org, String loc, String desc, String seq)
        {
            _seq = "ERROR";
            _enm = enm;
            _acc = acc;
            _org = org;
            _loc = loc;
            _desc = desc;
            if (id == null)
            {
                id = Guid.NewGuid();
            }
            else
            {
                _id = id;
            }
            if (ValidateSequence(seq, Regexes.s_regexDNA))
            {
                _seq = seq;
            }

        }

        #region Properties

        /// <summary>
        /// The Enumeration is derived from the NCBI enumeration property. It is used so that identitification
        /// of sequences with the NCBI databases can be made.
        /// </summary>
        public String Enumeration
        {
            get { return _enm; }
        }

        public String Accession
        {
            get { return _acc; }
        }

        public String Organism
        {
            get { return _org; }
        }

        public String Locus 
        {
            get { return _loc; }
        }

        public String Description
        {
            get { return _desc; }
        }

        public String Sequence
        {
            get { return _seq; }
        }

        public Int32 Length
        {
            get { return _seq.Length; }
        }

        public Guid ID 
        {
            get { return _id; }
        }

        #endregion

        /// <summary>
        /// Validateds that the input sequence is a valid Type of sequence.
        /// </summary>
        /// <param name="s">String - The input sequence string to validate.</param>
        /// <param name="p">String - the pattern to validate the sequence agaisnt.</param>
        /// <returns>Boolean - true if the validatio passed; false if not.</returns>
        /// <remarks>this meothed is overridden in child classes that use type-specific patterns.</remarks>
        protected static Boolean ValidateSequence(String s, String p)
        {
            if (!String.IsNullOrEmpty(s))
            {
                s = s.ToUpper();
                p = p.ToUpper();
                for (Int32 index = 0; index <= s.Length - 1; index++)
                {
                    if (!Regex.IsMatch(s.Substring(index, 1), p))
                    {
                        SequenceParameterException pe = new SequenceParameterException();
                        pe.ContextMessage = "The sequence could not be created because the given strand was not of a valid type.";
                        pe.ParameterName = "String seq";
                        pe.ParameterMessage = "The input sequence was not valid. The sequence cannot be null and must be a valid sequence.";
                        throw pe;
                    }
                }
                return true;
            }
            else
            {
                SequenceParameterException pe = new SequenceParameterException();
                pe.ContextMessage = "The sequence could not be created because the given strand was not of a vlaid type.";
                pe.ParameterName = "String seq";
                pe.ParameterMessage = "The input sequence was not valid. The sequence cannot be null and must be a valid sequence.";
                throw pe;
            }
        }

        /// <summary>
        /// Overrides .NET ToString() method to properly format the class to a String.
        /// </summary>
        /// <returns>String - a formateted String of the class Properties.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("ID: " + this.ID.ToString() + "\n");
                sb.Append("Enumeration: " + this.Enumeration.ToString() + "\n");
                sb.Append("Accession: " + this.Accession.ToString() + "\n");
                sb.Append("Organism: " + this.Organism.ToString() + "\n");
                sb.Append("Locus: " + this.Locus.ToString() + "\n");
                sb.Append("Description: " + this.Description.ToString() + "\n\n");
                sb.Append("Sequence: " + this.Sequence.ToString() + "\n\n");

            }
            catch (Exception e)
            {
                throw;
            }

            return sb.ToString();

        }


        #region Non-Inheritable Methods

            /// <summary>
            /// Creates a duplicate instance with a different ID.
            /// </summary>
            /// <returns>SequenceBase - the cloned instance.</returns>
            public SequenceBase Copy()
            {
                String desc = "CLONED COPY of Sequence " + this.Accession +". " + this.Description;
                return new SequenceBase(Guid.NewGuid(), this.Enumeration, this.Accession, this.Organism,
                   this.Locus, desc, this.Sequence);
            }

        #endregion

    }

}
