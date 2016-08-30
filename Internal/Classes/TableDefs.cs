//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without 
//express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Data.Linq.Mapping;

namespace SequenceStudio.Internal
{
    public class TableDefs
    {
        [Table(Name = "SequenceBase")]
        public class SequenceBaseTable
        {
            protected Guid _id;
            protected String _enum;
            protected String _acc;
            protected String _desc;
            protected string _org;
            protected string _loc;
            protected String _seq;

            [Column(CanBeNull = false, DbType = "uniqueidentifier", IsPrimaryKey = true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Enumeration
            {
                get { return _enum; }
                set { _enum = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Accession
            {
                get { return _acc; }
                set { _acc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Description
            {
                get { return _desc; }
                set { _desc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Organism
            {
                get { return _org; }
                set { _org = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Locus
            {
                get { return _loc; }
                set { _loc  = value; }
            }

            [Column(CanBeNull = true, DbType = "varchar(MAX)")]
            public String Sequence
            {
                get { return _seq; }
                set { _seq = value; }

            }

        }

        [Table(Name = "DNA")]
        public class DNATable
        {
            protected Guid _id;
            protected String _enum;
            protected String _acc;
            protected String _desc;
            protected string _org;
            protected string _loc;
            protected String _seq;

            [Column(CanBeNull = false, DbType = "uniqueidentifier", IsPrimaryKey = true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Enumeration
            {
                get { return _enum; }
                set { _enum = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Ascession
            {
                get { return _acc; }
                set { _acc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Description
            {
                get { return _desc; }
                set { _desc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Organism
            {
                get { return _org; }
                set { _org = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Locus
            {
                get { return _loc; }
                set { _loc = value; }
            }

            [Column(CanBeNull = true, DbType = "varchar(MAX)")]
            public String Sequence
            {
                get { return _seq; }
                set { _seq = value; }

            }

        }



        [Table(Name = "RNA")]
        public class RNATable
        {
            protected Guid _id;
            protected String _enum;
            protected String _acc;
            protected String _desc;
            protected string _org;
            protected string _loc;
            protected String _seq;

            [Column(CanBeNull = false, DbType = "uniqueidentifier", IsPrimaryKey = true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Enumeration
            {
                get { return _enum; }
                set { _enum = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Ascession
            {
                get { return _acc; }
                set { _acc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Description
            {
                get { return _desc; }
                set { _desc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Organism
            {
                get { return _org; }
                set { _org = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Locus
            {
                get { return _loc; }
                set { _loc = value; }
            }

            [Column(CanBeNull = true, DbType = "varchar(MAX)")]
            public String Sequence
            {
                get { return _seq; }
                set { _seq = value; }

            }

        }



        [Table(Name = "Poly")]
        public class PolyTable
        {
            protected Guid _id;
            protected String _enum;
            protected String _acc;
            protected String _desc;
            protected string _org;
            protected string _loc;
            protected String _seq;

            [Column(CanBeNull = false, DbType = "uniqueidentifier", IsPrimaryKey = true)]
            public Guid ID
            {
                get { return _id; }
                set { _id = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Enumeration
            {
                get { return _enum; }
                set { _enum = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Ascession
            {
                get { return _acc; }
                set { _acc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Description
            {
                get { return _desc; }
                set { _desc = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Organism
            {
                get { return _org; }
                set { _org = value; }
            }

            [Column(CanBeNull = true, DbType = "nvarchar(1000)")]
            public String Locus
            {
                get { return _loc; }
                set { _loc = value; }
            }

            [Column(CanBeNull = true, DbType = "varchar(MAX)")]
            public String Sequence
            {
                get { return _seq; }
                set { _seq = value; }

            }

        }



    }
}
