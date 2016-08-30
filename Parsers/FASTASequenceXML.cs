//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Xml;
using System.Xml.Serialization;

namespace SequenceStudio.Parsers
{
    public class FASTASequenceXML
    {
        [XmlElement]
        public String Enumeration;

        [XmlElement]
        public String Ascession;

        [XmlElement]
        public String Organism;

        [XmlElement]
        public string Locus;

        [XmlElement]
        public String Description;

        [XmlElement]
        public String Sequence;

    }

}
