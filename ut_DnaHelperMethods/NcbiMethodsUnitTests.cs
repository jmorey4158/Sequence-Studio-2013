using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;
using SequenceStudio.Internal;
using SequenceStudio.Internal.Classes;
using System.Xml;


namespace UnitTests
{
    [TestClass]
    public class NcbiMethodsUnitTests
    {
        [TestMethod]
        public void GetSequenceBaseFromNcbi_ValidRequest_ReturnSequenceBaseObject()
        {
            string uri = "http://eutils.ncbi.nlm.nih.gov/entrez/eutils/efetch.fcgi?db=nucleotide&id=5&rettype=fasta&retmode=xml";
            

            var seq = GetSequences.GetSequenceBaseFromNcbi(uri);
            var rna = seq.ConvertToRNA();

            Assert.IsInstanceOfType(seq, typeof(SequenceBase));
            Assert.IsInstanceOfType(rna, typeof(RNA));
        }


        [TestMethod]
        public void GetSequenceIDs_ValidRequest_ReturnResponseObject()
        {
            var xdoc = GetSequences.GetIDsFromNCBI("http://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?db=nucleotide&term=biomol+trna[prop]");

            Assert.IsInstanceOfType(xdoc, typeof(XmlDocument));

        }
    }
}
