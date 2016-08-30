//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio.Internal
{
    public class Enums
    {
        public enum AminoAcids
        {
            Alanine, Cysteine, AsparticAcid, GlutamicAcid,
            Phenylalanine, Glycine, Histidine, Isoleucine,
            Lysine, Leucine, Methionine, Asparagine, Proline,
            Glutamine, Arginine, Serine, Threonine,
            Valine, Tryptophan, Tyrosine
        }

        public enum SequenceType
        {
            DNA, RNA, AminoAcid, DNAConsensus, RNAConsensus,
            PolypeptideConsensus, ReverseTranscript, SourceStrand,
            SourceConsensus, DirtySequence
        }
    }//NOT USED YET
}
