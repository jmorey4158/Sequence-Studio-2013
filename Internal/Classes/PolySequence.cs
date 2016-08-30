using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio.Internal;



namespace SequenceStudio
{
    public class Poly : SequenceBase
    {
        public Poly(Guid id, String enm, String acc, String org, String loc, String desc, String seq)
        {
            _enm = enm;
            _acc = acc;
            _org = org;
            _loc = loc;
            _desc = desc;
            if (ValidateSequence(seq, Regexes.s_regexAAshort))
            {
                _seq = seq;
            }
        }

        /// <summary>
        /// Creates a duplicate instance with a different ID.
        /// </summary>
        /// <returns>Poly - ther cloned instance.</returns>
        public new Poly Copy()
        {
            String desc = "CLONED COPY of Sequence " + this.Accession + ". " + this.Description;
            return new Poly(Guid.NewGuid(), this.Enumeration, this.Accession, this.Organism,
               this.Locus, desc, this.Sequence);
        }

    }
}
