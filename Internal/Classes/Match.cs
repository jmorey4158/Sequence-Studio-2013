//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used 
//without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any 
//Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio
{
    public class Match
    {
        protected Int32 _loc;
        protected Int32 _len;
        protected Guid _sourceID;
        protected Guid _matchID;
        protected Double _percent;

        #region Constructors

        public Match() { }

        public Match(Guid source, Guid match, Int32 loc, Int32 len, Double perc)
        {
            _sourceID = source;
            _matchID = match;
            _loc = loc;
            _len = len;
            _percent = perc;
        }

        #endregion

        #region Properties

        public Guid SourceStrand 
        {
            get { return _sourceID; }
        }

        public Guid MatchStrand 
        {
            get { return _matchID; }
        }

        public Int32 Location
        {
            get { return _loc; }
        }

        public Int32 Length
        {
            get { return _len; }
        }

        public Double Percentage
        {
            get { return _percent; }
        }

        #endregion
    } //NOT COMPLETE

}
