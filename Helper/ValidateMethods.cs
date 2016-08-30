using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SequenceStudio.Internal;

namespace SequenceStudio.Validate
{
    public static class ValidateMethods
    {

        public static bool IsValidDna (String strand)
        {
            Regex reg = new Regex(Regexes.s_regexDNA);

            if (reg.IsMatch(strand.ToUpper()))
            {
                return true;
            }

            return false;
        }


        public static bool IsValidRna (String strand)
        {
            Regex  reg = new Regex(Regexes.s_regexRNA);

            if (reg.IsMatch(strand.ToUpper()))
            {
                return true;
            }

            return false;
        }


        public static bool IsValidPolypeptide (String strand)
        {
            Regex reg = new Regex(Regexes.s_regexAAshort);

            if (reg.IsMatch(strand.ToUpper()))
            {
                return true;
            }

            return false;
        }


        public static bool IsValidPolypeptideLong (String strand)
        {
            Regex reg = new Regex(Regexes.s_regexAAlong);

            if (reg.IsMatch(strand.ToUpper()))
            {
                return true;
            }

            return false;
        }


        public static bool IsValidSequence (String strand)
        {
            Regex regA = new Regex(Regexes.s_regexAAlong);
            Regex regR = new Regex(Regexes.s_regexRNA);
            Regex regD = new Regex(Regexes.s_regexDNA);

            if (  (regA.IsMatch(strand.ToUpper())) || (regR.IsMatch(strand.ToUpper())) || (regD.IsMatch(strand.ToUpper())) )
            {
                return true;
            }
            return false;
        }


        public static bool IsValidSequenceObject (Object obj)
        {
            if (obj.GetType() == typeof(DNA))
            {
                return true;
            }
            else if (obj.GetType() == typeof(RNA))
            {
                return true;
            }
            else if (obj.GetType() == typeof(Poly))
            {
                return true;
            }

            return false;
        }

        public static bool AreSameType(Object obj1, Object obj2)
        {
            if (obj1.GetType() == obj2.GetType())
            {
                return true;
            }
            else 
            {
                return false;
            }
        }


        public static bool IsValidThreshould (Double threshold)
        {

            if ((threshold > 0) && (threshold <= 100))
            {
                return true;
            }

            return false;
        }


        public static bool IsValidStrandType (String strandType)
        {
            Regex reg = new Regex("[DNA|RNA|POLYPEPTIDE");

            if (reg.IsMatch(strandType.ToUpper()))
            {
                return true;
            }
            return false;
        }


    }
}
