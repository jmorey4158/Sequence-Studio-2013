using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SequenceStudio.Internal.Classes
{
    public class TSeq
    {
        private string _seq;
        private string _seqType;
        private string _seqAccession;
        private string _seqOrganism;
        private string _seqDescription;
        private string _seqLen;
        public string _seqGi;
        public string _seqTaxId;

        public TSeq() { }

        #region Poperties

        public String TSeq_seqtype
        {
            get { return _seqType; }
            set { _seqType = value; }
        }

        public String TSeq_accver
        {
            get { return _seqAccession; }
            set { _seqAccession = value; }
        }

        public String TSeq_orgname
        {
            get { return _seqOrganism; }
            set { _seqOrganism = value; }
        }

        public String TSeq_defline
        {
            get { return _seqDescription; }
            set { _seqDescription = value; }
        }

        public String TSeq_sequence
        {
            get { return _seq; }
            set { _seq = value; }
        }

        public String TSeq_length
        {
            get { return _seqLen; }
            set { _seqLen = value; }
        }

        public String TSeq_gi
        {
            get { return _seqGi; }
            set { _seqGi = value; }
        }

        public String TSeq_taxid
        {
            get { return _seqTaxId; }
            set { _seqTaxId = value; }
        }


        #endregion


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type: " +  this.TSeq_seqtype + "\n");
            sb.Append("Accession: " +  this.TSeq_accver + "\n");
            sb.Append("GI: " + this.TSeq_gi + "\n");
            sb.Append("Organism: " +  this.TSeq_orgname + "\n");
            sb.Append("Taxon ID: " +  this.TSeq_taxid + "\n");
            sb.Append("Description: " +  this.TSeq_defline + "\n");
            sb.Append("Length: " +  this.TSeq_length.ToString() + "\n");
            sb.Append("Sequence: " +  this.TSeq_sequence + "\n");
            return sb.ToString();
        }

    }



    public class TSeqList
    {
        public TSeqList() {}

        private Dictionary<String, TSeq> _seqList;


        public Boolean AddItem(TSeq ts)
        {
            if (!_seqList.Keys.Contains(ts.TSeq_accver))
            {
                _seqList.Add(ts.TSeq_accver, ts);
                return true;
            }

            else
            {
                return false;
            }
        }


        public Boolean RemoveItem(TSeq ts)
        {
            if (!_seqList.Keys.Contains(ts.TSeq_accver))
            {
                _seqList.Remove(ts.TSeq_accver);
                return true;
            }

            else
            {
                return false;
            }
        }


    }
}
