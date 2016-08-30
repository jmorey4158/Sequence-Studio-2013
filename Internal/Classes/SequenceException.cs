//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file 
//may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property 
//in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio
{
    /// <summary>
    /// The base class for all Sequence.Exceptions
    /// </summary>
    public class SequenceException : Exception
    {
        private String _contextMessage;

        public SequenceException() { ;}

        public SequenceException(String m)
        {
            _contextMessage = m;
        }

        public String ContextMessage
        {
            get { return _contextMessage; }
            set { _contextMessage = value; }
        }
    }
                                                                                             
    public class SequenceParameterException : SequenceException
    {
        private String _paramName;
        private String _paramType;
        private String _paramMessage;

        public String ParameterName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }
        public String ParameterType
        {
            get { return _paramType; }
            set { _paramType = value; }
        }
        public String ParameterMessage
        {
            get { return _paramMessage; }
            set { _paramMessage = value; }
        }

    }

    public class SequenceValidationException : SequenceException
    {
        private String _paramName;
        private String _paramType;
        private String _paramMessage;

        public String ParameterName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }
        public String ParameterType
        {
            get { return _paramType; }
            set { _paramType = value; }
        }
        public String ParameterMessage
        {
            get { return _paramMessage; }
            set { _paramMessage = value; }
        }

    }



}
