using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SequenceStudio.Internal;



namespace SequenceStudio
{
    public class DNA : SequenceBase
    {
        public DNA(Guid id, String enm, String acc, String org, String loc, String desc, String seq)
        {
            _enm = enm;
            _acc = acc;
            _org = org;
            _loc = loc;
            _desc = desc;
            seq = seq.ToUpper();
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

        /// <summary>
        /// Creates a duplicate instance with a different ID.
        /// </summary>
        /// <returns>DNA - the cloned instance.</returns>
        public new DNA Copy()
        {
            String desc = "CLONED COPY of Sequence " + this.Accession + ". " + this.Description;
            return new DNA(Guid.NewGuid(), this.Enumeration, this.Accession, this.Organism,
               this.Locus, desc, this.Sequence);
        }

    }

}
