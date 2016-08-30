//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express 
//written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio.Internal
{
    public class UnitPatterns
    {
        public static String[] s_DNA = new String[4] { "A", "T", "C", "G" };

        public static String[] s_RNA = new String[4] { "A", "U", "C", "G" };

        public static String[] s_Polypeptide = new String[20] { "A", "R", "N", "D", 
                                                                    "C", "E", "Q", "G",
                                                                    "H", "I", "L", "K",
                                                                    "M", "F", "P", "S",
                                                                    "T", "W", "Y", "V"};


        public static String p_DNA = "ACTG";

        public static String p_RNA = "AUCG";

        public static String p_Polypeptide = "ARNDCEQGHILKMFPSTWYV";

        public static String tripleStop = "TAGTAATGA";

        public static String tripleStart = "AGTAATGAT";

        public static String tripleStart2 = "GCTATTACT";
    }//NOT USED YET
}
