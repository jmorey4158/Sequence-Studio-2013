using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SequenceStudio.Internal;



namespace SequenceStudio
{
    public class RNA : SequenceBase
    {
        public RNA(Guid id, String enm, String acc, String org, String loc, String desc, String seq)
        {
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
            if (ValidateSequence(seq, Regexes.s_regexRNA))
            {
                _seq = seq;
            }
        }

        /// <summary>
        /// Creates a duplicate instance with a different ID.
        /// </summary>
        /// <returns>RNA - ther cloned instance.</returns>
        public new RNA Copy()
        {
            String desc = "CLONED COPY of Sequence " + this.Accession + ". " + this.Description;
            return new RNA(Guid.NewGuid(), this.Enumeration, this.Accession, this.Organism,
               this.Locus, desc, this.Sequence);
        }

    }
}
