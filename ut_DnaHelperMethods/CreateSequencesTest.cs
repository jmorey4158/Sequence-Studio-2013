using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;
using System.Collections.Generic;
using System.Text;

namespace ut_DnaHelperMethods
{
    [TestClass]
    public class CreateSequencesTest
    {
        [TestMethod]
        public void TestNewDnaSequence()
        {
            String d = "ACTAGCATGCTAGCTCGATGCTGCTAGCTGCTGACTAGCTGATCGATGCTG";
            DNA dna = new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);

            //Check to make sure that the correct class instance was created
            Assert.IsInstanceOfType(dna, typeof(DNA), "The DNA sequence class instance was not created properly.");
            Assert.IsNotInstanceOfType(dna, typeof(RNA), "The DNA sequence class instance was created as an RNA class instance.");
            Assert.IsNotInstanceOfType(dna, typeof(Poly), "The DNA sequence class instance was created as a Poly class instance.");

            //Check to make sure that the Poperties were reated correctly
            Assert.AreEqual(dna.Sequence, d, "Sequence porperty was not populated correctly.");
            Assert.AreEqual(dna.Accession, "Accession", "Accession property was not populated correctly.");
            Assert.AreEqual(dna.Description, "Description", "Description property was not populated correctly.");
            Assert.AreEqual(dna.Enumeration, "Enumeration", "Enumeration property was not populated correctly.");
            Assert.AreEqual(dna.Organism, "Organism", "Organism property was not populated correctly.");
            Assert.AreEqual(dna.Locus, "Locus", "Locus property was not populated correctly.");
            Assert.AreEqual(dna.Length, d.Length, "Length property was not populated correctly.");
        }


        [TestMethod]
        public void TestNewRnaSequence()
        {
            String d = "ACUAGCAUGCUAGCUCGAUGCUGCUAGCUGCUGACUAGCUGAUCGAUGCUG";
            RNA rna = new RNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);

            //Check to make sure that the correct class instance was created
            Assert.IsInstanceOfType(rna, typeof(RNA), "The RNA sequence class instance was not created properly.");
            Assert.IsNotInstanceOfType(rna, typeof(DNA), "The RNA sequence class instance was created as a DNA class instance.");
            Assert.IsNotInstanceOfType(rna, typeof(Poly), "The RNA sequence class instance was created as a Poly class instance.");

            //Check to make sure that the Poperties were reated correctly
            Assert.AreEqual(rna.Sequence, d, "Sequence porperty was not populated correctly.");
            Assert.AreEqual(rna.Accession, "Accession", "Accession property was not populated correctly.");
            Assert.AreEqual(rna.Description, "Description", "Description property was not populated correctly.");
            Assert.AreEqual(rna.Enumeration, "Enumeration", "Enumeration property was not populated correctly.");
            Assert.AreEqual(rna.Organism, "Organism", "Organism property was not populated correctly.");
            Assert.AreEqual(rna.Locus, "Locus", "Locus property was not populated correctly.");
            Assert.AreEqual(rna.Length, d.Length, "Length property was not populated correctly.");
        }


        [TestMethod]
        public void TestNewPolySequence()
        {
            List<AminoAcids.AminoAcidBase> aa = AminoAcids.GetAminoAcidList();
            StringBuilder sb = new StringBuilder();

            foreach (AminoAcids.AminoAcidBase b in aa)
            {
                sb.Append(b.Initial.ToString());
            }

            String d = sb.ToString();
            Poly poly = new Poly(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);

            //Check to make sure that the correct class instance was created
            Assert.IsInstanceOfType(poly, typeof(Poly), "The Poly sequence class instance was not created properly.");
            Assert.IsNotInstanceOfType(poly, typeof(DNA), "The Poly sequence class instance was created as a DNA class instance.");
            Assert.IsNotInstanceOfType(poly, typeof(RNA), "The Poly sequence class instance was created as an RNA class instance.");

            //Check to make sure that the Poperties were reated correctly
            Assert.AreEqual(poly.Sequence, d, "Sequence porperty was not populated correctly.");
            Assert.AreEqual(poly.Accession, "Accession", "Accession property was not populated correctly.");
            Assert.AreEqual(poly.Description, "Description", "Description property was not populated correctly.");
            Assert.AreEqual(poly.Enumeration, "Enumeration", "Enumeration property was not populated correctly.");
            Assert.AreEqual(poly.Organism, "Organism", "Organism property was not populated correctly.");
            Assert.AreEqual(poly.Locus, "Locus", "Locus property was not populated correctly.");
            Assert.AreEqual(poly.Length, d.Length, "Length property was not populated correctly.");
        }



        [TestMethod]
        [ExpectedException(typeof(SequenceParameterException))]
        public void TestFailDnaSequence()
        {
            String d = "1234567890ABCDEFGHIJKLMNOPQRSTUYWXYZ";
            DNA dna = new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);
        }


        [TestMethod]
        [ExpectedException(typeof(SequenceParameterException))]
        public void TestFailRnaSequence()
        {
            String d = "1234567890ABCDEFGHIJKLMNOPQRSTUYWXYZ";
            DNA dna = new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);
        }


        [TestMethod]
        [ExpectedException(typeof(SequenceParameterException))]
        public void TestFailPolySequence()
        {
            String d = "1234567890ABCDEFGHIJKLMNOPQRSTUYWXYZ";
            DNA dna = new DNA(Guid.NewGuid(), "Enumeration", "Accession", "Organism", "Locus", "Description", d);
        }

    }
}
