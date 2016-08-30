//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Collections.Generic;


using SequenceStudio.Internal;

namespace SequenceStudio.Parsers
{
    public static class GetSequenceFromDB
    {
        public static void ByOrganism(String dc, String search, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where fa.Organism.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                DataContext fastadb = new DataContext(dc);
                Table<TableDefs.DNATable> dnaT = fastadb.GetTable<TableDefs.DNATable>();

                var results =
                    from fa in dnaT
                    where fa.Organism.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }

        } //COMPLETE

        public static void ByAccession(String dc, String search, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where fa.Accession.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                DataContext fastadb = new DataContext(dc);
                Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();

                var results =
                    from fa in FastA
                    where fa.Ascession.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }

        } //COMPLETE

        public static void BySequence(String dc, String search, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where fa.Sequence.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                try
                {
                    DataContext fastadb = new DataContext(dc);
                    fastadb.CommandTimeout = 20;
                    Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();
                    var results =
                        from fa in FastA
                        where fa.Sequence.Contains(search)
                        select fa;

                    foreach (var fa in results)
                    {
                        fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                        if (!all)
                        {
                            if (fl.Count >= limit)
                            {
                                return;//TODO: the code goes into limbo here, it is trying some framework disposal methods and is going tharn. 
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }


            }

        } //COMPLETE

        public static void ByEnumeration(String dc, String search, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where fa.Enumeration.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                DataContext fastadb = new DataContext(dc);
                Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();

                var results =
                    from fa in FastA
                    where fa.Enumeration.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }

        } //COMPLETE

        public static void ByDescription(String dc, String search, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where fa.Description.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                DataContext fastadb = new DataContext(dc);
                Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();

                var results =
                    from fa in FastA
                    where fa.Description.Contains(search)
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }

        } //COMPLETE

        public static void BySequenceLengthRange(String dc, Int32 lower, Int32 upper, Int32 limit, ref List<DNA> fl)
        {
            Boolean all = false;
            if (lower < 0) { lower = 0; }
            if (limit < 0) { return; }
            if (limit == 0) { all = true; }

            if (fl.Count > 0)
            {
                List<DNA> fr = new List<DNA>(fl);
                fl.Clear();

                var results =
                    from fa in fr
                    where ((fa.Sequence.Length >= lower) && (fa.Sequence.Length <= upper))
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Accession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }
            else
            {
                DataContext fastadb = new DataContext(dc);
                Table<TableDefs.DNATable> FastA = fastadb.GetTable<TableDefs.DNATable>();

                var results =
                    from fa in FastA
                    where ((fa.Sequence.Length >= lower) && (fa.Sequence.Length <= upper))
                    select fa;

                foreach (var fa in results)
                {
                    fl.Add(new DNA(fa.ID, fa.Enumeration, fa.Ascession, fa.Organism, fa.Locus, fa.Description, fa.Sequence));
                    if (!all) { if (fl.Count >= limit) { return; } }
                }
            }


        } //COMPLETE
    }


    public class CreateDatabase
    {
        /// <summary>
        /// Returns a SQLCommand String that can be used to create a customized Table.
        /// Two variants:
        ///  (String tblName, List(String) items) - pass in a list of the Constants.ct_X Strings to create a cusomt DB
        ///  (String tblName, String items) - pass in a pre-designed Constants.db_X String.
        /// </summary>
        /// <param name="tblName">String = name of the Table. If a Table with the name already exits the method fails silently.</param>
        /// <param name="items">
        ///  Two variants:
        ///  (String tblName, List(String) items) - pass in a list of the Constants.ct_X Strings to create a cusomt DB
        ///  (String tblName, String items) - pass in a pre-designed Constants.db_X String
        /// </param>
        /// <returns>String - to be used as a SQLCOmmand(String)</returns>
        public static String TableCommand(String tblName, List<String> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE dbo." + tblName + " (");

            foreach (String s in items)
            {
                sb.Append(s + ", ");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");

            return sb.ToString();
        }
        public static String TableCommand(String tblName, String items)
        {
            return ("CREATE TABLE dbo." + tblName + items);
        }


        /// <summary>
        /// Creates a customized Table in the DB specified in sconn, with the schema specified by schema
        /// </summary>
        /// <param name="sconn">String - connection string used in SQLConnection(String)</param>
        /// <param name="schema">String - used in SQLCommand(String) to CREATE TABLE....</param>
        /// <returns>Ture if Table is created; false otherwise</returns>
        public static Boolean CreateCustomTable(String sconn, String schema)
        {
            SqlConnection conn = new SqlConnection(sconn);
            SqlCommand cmd = new SqlCommand(schema, conn);
            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("There is already an object"))
                {
                    return false;
                }
            }
            conn.Close();
            return true;
        }


        #region OBSOLETE
        public static Boolean CreatePolyTable(String name, SqlConnection conn)
        {
            String sql = "CREATE TABLE dbo." + name
                + "(ID uniqueidentifier PRIMARY KEY NOT NULL,"
                + "Enumeration nvarchar(1000) NULL,"
                + "Ascession nvarchar(1000) NULL,"
                + "Description nvarchar(1000) NULL,"
                + "Sequence nvarchar(MAX) NULL)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("There is already an object"))
                {
                    return false;
                }
            }

            conn.Close();

            return true;
        }
        public static Boolean CreatePolyTable(String name, String sconn)
        {
            String sql = "CREATE TABLE dbo." + name
                + "(ID uniqueidentifier PRIMARY KEY NOT NULL,"
                + "Enumeration nvarchar(1000) NULL,"
                + "Ascession nvarchar(1000) NULL,"
                + "Description nvarchar(1000) NULL,"
                + "Sequence nvarchar(MAX) NULL)";

            SqlConnection conn = new SqlConnection(sconn);
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("There is already an object"))
                {
                    return false;
                }
            }

            conn.Close();

            return true;
        }

        public static Boolean CreateDNATable(String name, SqlConnection conn)
        {
            String sql = "CREATE TABLE dbo." + name
                + "(ID uniqueidentifier PRIMARY KEY NOT NULL,"
                + "DBType nvarchar(1000) NULL,"
                + "Enumeration nvarchar(1000) NULL,"
                + "Ascession nvarchar(1000) NULL,"
                + "Organism nvarchar(1000) NULL,"
                + "Description nvarchar(1000) NULL,"
                + "Sequence nvarchar(MAX) NULL)";

            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("There is already an object"))
                {
                    return false;
                }
            }

            conn.Close();

            return true;
        }
        public static Boolean CreateDNATable(String name, String sconn)
        {
            String sql = "CREATE TABLE dbo." + name
                + "(ID uniqueidentifier PRIMARY KEY NOT NULL,"
                + "DBType nvarchar(1000) NULL,"
                + "Enumeration nvarchar(1000) NULL,"
                + "Ascession nvarchar(1000) NULL,"
                + "Organism nvarchar(1000) NULL,"
                + "Description nvarchar(1000) NULL,"
                + "Sequence nvarchar(MAX) NULL)";

            SqlConnection conn = new SqlConnection(sconn);
            SqlCommand cmd = new SqlCommand(sql, conn);

            conn.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (!ex.Message.Contains("There is already an object"))
                {
                    return false;
                }
            }

            conn.Close();

            return true;
        }

        #endregion
    }

}
