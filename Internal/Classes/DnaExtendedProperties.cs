using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio.Internal.Classes
{

    public class DnaExtendedProperties
    {
        private Guid _id;
        private String _compStrand;
        private String _transcript;
        private String _gene;
        private Double _mol;
        private Dictionary<String, Int32> _units;

        public DnaExtendedProperties() { }

        #region Properties

        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }


        public String Gene
        {
            get { return _gene; }
            set { _gene = value; }
        }

        public Dictionary<String, Int32> Stats
        {
            get { return _units; }
            set { _units = value; }
        }

        public String CompStrand
        {
            get { return _compStrand; }
            set { _compStrand = value; }
        }

        public String Transcript
        {
            get { return _transcript; }
            set { _transcript = value; }
        }

        public Double MolWeight
        {
            get { return _mol; }
            set { _mol = value; }
        }

        #endregion

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Anti-Strand: " + this.CompStrand.ToString() + "\n");
            sb.Append("RNA Trnascript: " + this.Transcript.ToString() + "\n");
            sb.Append("Molecular Weight (Daltons): " + this.MolWeight.ToString() + "\n");
            sb.Append("Residue Composition:\n");
            foreach (KeyValuePair<string, int> kp in Stats)
            {
                sb.Append("\t" + kp.Key + ": " + kp.Value + "\n");
            }
            sb.Append("Gene: " + this.Gene.ToString() + "\n\n");
            return sb.ToString();
        }

    }
}
