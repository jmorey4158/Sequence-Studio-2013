using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{


    public class TestConstants
    {
        public const string _DnaStrand = "ACTGCTAGCTGCTAGCTAGCTGATCGATCGTGCTGCTGATGCTAGCTGACTGATGCATGCTGA";
        public const string _revCompStrand = "TCAGCATGCATCAGTCAGCTAGCATCAGCAGCACGATCGATCAGCTAGCTAGCAGCTAGCAGT";
        public const string _compStrand = "TGACGATCGACGATCGATCGACTAGCTAGCACGACGACTACGATCGACTGACTACGTACGACT";
        public const double _molWeight = 18200.28;
        public const string _codonMatrix = "T1A1S6C2L5A1N1D1R3S4C2C2C2L6T1N1D1A3C2";

        


        public const string _RnaStrand = "ACUGCUAGCUGCUAGCUAGCUGAUCGAUCGUGCUGCUGAUGCUAGCUGACUGAUGCAUGCUGA";

        public const string _PolyStrand = "TASC*LADRSCCUC*LTDACU";


    }


    public class TestDnaStats
    {
        private Dictionary<string, int> _stringInt;
        private Dictionary<string, double> _stringDouble;


        public IReadOnlyDictionary<string, int>  PopulateTestDnaStats()
        {
            _stringInt.Add("A", 11);
            _stringInt.Add("T", 18);
            _stringInt.Add("C", 15);
            _stringInt.Add("G", 18);

            return (IReadOnlyDictionary<string, int>)_stringInt;
        }



        public IReadOnlyDictionary<string, int> TestCodons()
        {
            _stringInt.Add("A1", 2);
            _stringInt.Add("A3", 1);
            _stringInt.Add("R3", 1);
            _stringInt.Add("N1", 2);
            _stringInt.Add("D1", 2);
            _stringInt.Add("C2", 5); 
            _stringInt.Add("L5", 1);
            _stringInt.Add("L6", 1);
            _stringInt.Add("S4", 1);
            _stringInt.Add("S6", 1);
            _stringInt.Add("T1", 2);

            return (IReadOnlyDictionary<string, int>)_stringInt;
        }


        public IReadOnlyDictionary<string, double> TestCodonMetrix()
        {
            _stringDouble.Add("A1", 9.52380952380952);
            _stringDouble.Add("A3", 4.76190476190476);
            _stringDouble.Add("R3", 4.76190476190476);
            _stringDouble.Add("N1", 9.52380952380952);
            _stringDouble.Add("D1", 9.52380952380952);
            _stringDouble.Add("C2", 23.8095238095238);
            _stringDouble.Add("L5", 4.76190476190476);
            _stringDouble.Add("L6", 4.76190476190476);
            _stringDouble.Add("S4", 4.76190476190476);
            _stringDouble.Add("S6", 4.76190476190476);
            _stringDouble.Add("T1", 9.52380952380952);

            return (IReadOnlyDictionary<string, double>)_stringDouble;
        }



    }

}
