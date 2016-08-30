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
    public class Constants
    {
        public const String ConnString = "Data Source=jmorey-sql;Initial Catalog='Sequence Studio 2014';Integrated Security=True";

        public const Int32 MatchesMin = 20;
        public const Int32 MatchesMax = 100;

        public const String FastaSchema = "[ID],[DBType],[Enumeration],[Ascession]," +
            "[Organism],[Description],[Sequence]";
        public const String PolySchema = "[ID],[Enumeration],[Ascession],[Description],[Sequence]";                    


        public const String conn = "";

        //These Strings are used to build SQLCommand for creating a DB. Add one or more of these 
        // to create the command
        public const String ct_ID = "ID uniqueidentifier PRIMARY KEY NOT NULL";
        public const String ct_DbType = "DBType nvarchar(1000) NULL";
        public const String ct_Enum = "Enumeration nvarchar(1000) NULL";
        public const String ct_Asc = "Ascession nvarchar(1000) NULL";
        public const String ct_Desc = "Description nvarchar(1000) NULL";
        public const String ct_Org = "Organism nvarchar(1000) NULL";
        public const String ct_Seq = "Sequence nvarchar(MAX) NULL";

        public const String ct_Rec = "Record int NULL";
        public const String ct_Err = "Data nvarchar(MAX) NULL";

        // These are pre-built Strings used to build SQLCommand for creating a DB.
        public const String db_Fasta = " (" + ct_ID + ", " + ct_DbType + ", " + ct_Enum + 
            ", " + ct_Asc 
            + ", " + ct_Org + ", " + ct_Desc + ", " + ct_Seq + ")";

        public const String db_Poly = " (" + ct_ID + ", " + ct_Enum + ", " + ct_Asc + ", " + 
            ct_Desc + ", " + ct_Seq + ")";

        public const String db_Errors = " (" + ct_ID + ", " +  ct_Rec + ", " +  ct_Err + ")";
    }
}
