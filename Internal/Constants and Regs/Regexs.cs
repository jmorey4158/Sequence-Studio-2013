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

namespace SequenceStudio.Internal
{
    /// <summary>
    /// These Strings are used in Parse() and Validate() methods. 
    /// The function as Regex tempaltes
    /// for the specific Sequence types and allow the code to determine 
    /// the validity of the sequence.
    /// They are also used as constants in various methods, such as Translate().
    /// </summary>
    public static class Regexes
    {
        public static String s_regexDNA
        {
            get { return "A|C|T|G"; }
        }

        public static String s_regexRNA
        {
            get { return "A|C|U|G"; }
        }

        public static String s_regexAAshort
        {
            get { return "A|C|D|E|F|G|H|I|K|L|M|N|P|Q|R|S|T|V|W|Y"; }
        }

        public static String s_regexAAlong
        {
            get
            {
                return "Ala|Cys|Asp|Glu|Phe|Gly|His|Ile|Lys|Leu|" +
                    "Met|Asn|Pro|Gln|Arg|Ser|Thr|Val|Trp|Tyr";
            }
        }

        public static String s_regexStopCodon
        {
            get { return "TAG|TAA|TGA"; }
        }

        public static String s_startCodon
        {
            get { return "ATG"; }
        }

        public static String s_stopCodon
        {
            get { return "TAG"; }
        }
    }
}
