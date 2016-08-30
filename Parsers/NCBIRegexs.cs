//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;

namespace SequenceStudio.Parsers
{
    public class NCBIRegexs
    {

        public static String fs_Local
        {
            get { return "lcl|"; }
        }

        public static String fs_GenInfoSeqid
        {
            get { return "bbs|"; }
        }

        public static String fs_GenInfoMoltype
        {
            get { return "bbm|"; }
        }

        public static String fs_GenInfoImport
        {
            get { return "gim|"; }
        }

        public static String fs_GenBank
        {
            get { return "gb|"; }
        }

        public static String fs_EMBL
        {
            get { return "emb|"; }
        }

        public static String fs_PIR
        {
            get { return "pir|"; }
        }

        public static String fs_SwissProt
        {
            get { return "sp"; }
        }

        public static String fs_Patent
        {
            get { return "pat|"; }
        }

        public static String fs_PrePatent
        {
            get { return "pgp|"; }
        }

        public static String fs_RefSq
        {
            get { return "ref|"; }
        }

        public static String fs_GenDBRef
        {
            get { return "gnl|"; }
        }

        public static String fs_GenInfoIntegrated
        {
            get { return "gi|"; }
        }

        public static String fs_DDBJ
        {
            get { return "dbg|"; }
        }

        public static String fs_PRF
        {
            get { return "prf|"; }
        }

        public static String fs_PDB
        {
            get { return "pdb|"; }
        }

        public static String fs_3rdGenBank
        {
            get { return "tpg|"; }
        }

        public static String fs_3rdEMBL
        {
            get { return "tpe|"; }
        }

        public static String fs_3rdDDBJ
        {
            get { return "tpd|"; }
        }

        public static String fs_TrEMBL
        {
            get { return "tr|"; }
        }

        public static String fs_GenomePipeline
        {
            get { return "gpp|"; }
        }

        public static String fs_NamedAnotationTrack
        {
            get { return "nat|"; }
        }



        public static String fs_Accession
        {
            get { return "|"; }
        }

        public static String fs_Locus
        {
            get { return "}"; }
        }







    }

}
