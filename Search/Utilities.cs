//This file is part of Sequence Studio 2011, an application by Revealed Design, LLC. 
//Copyright© 2011 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SequenceStudio.Internal;

namespace SequenceStudio
{
    public class Utilities
    {
        /// <summary>
        /// This method is a utility used by otehr methods. It validates that the params passed
        /// to it are valid sequences, patterns, and/or regexes (Unit pattersn for DNA, RNA, etc.)
        /// </summary>
        /// <param name="sequence">String, sequence to be validated</param>
        /// <param name="regex">String, a regex phrase to test the input sequence</param>
        /// <returns>Boolean, true = valid; false = not valid</returns>
        public static Boolean ValidateSequence(String sequence, String regex)
        {
            sequence = sequence.ToUpper();
            if (sequence != "")
            {
                for (Int32 index = 0; index <= sequence.Length - 1; index++)
                {
                    if (!Regex.IsMatch(sequence.Substring(index, 1), regex))
                    {
                        //Console.WriteLine("Regex did not match: {0}\t{1}", index, sequence.Substring(index, 1));
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        
        //public static void ValidateSequence(ref String sequence, ref String pattern, String regex,
        //    ref Boolean isValid)
        //{
        //    sequence = sequence.ToUpper();
        //    pattern = pattern.ToUpper();
        //    isValid = true;
        //    if ((sequence != "") && (pattern != ""))
        //    {
        //        if (pattern.Length < sequence.Length)
        //        {
        //            for (Int32 index = 0; index <= sequence.Length - 1; index++)
        //            {
        //                if (!Regex.IsMatch(sequence.Substring(index, 1), regex))
        //                {
        //                    isValid = false;
        //                    return;
        //                }
        //            }

        //            for (Int32 index2 = 0; index2 <= pattern.Length - 1; index2++)
        //            {
        //                if (!Regex.IsMatch(pattern.Substring(index2, 1), regex))
        //                {
        //                    isValid = false;
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            isValid = false;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        isValid = false;
        //        return;
        //    }
        //} //NOT COMPLETE

        //public static void ValidateSequence(ref String sequence1, String regex, ref Double threshold,
        //    ref Boolean isValid, ref String sequence2)
        //{
        //    sequence1 = sequence1.ToUpper();
        //    sequence2 = sequence2.ToUpper();
        //    isValid = true;
        //    if ((sequence1 != "") && (sequence2 != ""))
        //    {
        //        for (Int32 index = 0; index <= sequence1.Length - 1; index++)
        //        {
        //            if (!Regex.IsMatch(sequence1.Substring(index, 1), regex))
        //            {
        //                isValid = false;
        //                return;
        //            }
        //        }

        //        for (Int32 index2 = 0; index2 <= sequence2.Length - 1; index2++)
        //        {
        //            if (!Regex.IsMatch(sequence2.Substring(index2, 1), regex))
        //            {
        //                isValid = false;
        //                return;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        isValid = false;
        //        return;
        //    }
        //} //NOT COMPLETE

        //public static void ValidateSequence(ref String sequence, ref String pattern,
        //    ref Double threshold, String regex, ref Boolean isValid)
        //{
        //    sequence = sequence.ToUpper();
        //    pattern = pattern.ToUpper();
        //    threshold = System.Math.Abs(threshold);
        //    if (threshold > 100)
        //    {
        //        threshold = 100;
        //    }

        //    isValid = true;

        //    if ((sequence != "") && (pattern != ""))
        //    {
        //        if (pattern.Length < sequence.Length)
        //        {
        //            for (Int32 index = 0; index <= sequence.Length - 1; index++)
        //            {
        //                if (!Regex.IsMatch(sequence.Substring(index, 1), regex))
        //                {
        //                    isValid = false;
        //                    return;
        //                }
        //            }

        //            for (Int32 index2 = 0; index2 <= pattern.Length - 1; index2++)
        //            {
        //                if (!Regex.IsMatch(pattern.Substring(index2, 1), regex))
        //                {
        //                    isValid = false;
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            isValid = false;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        isValid = false;
        //        return;
        //    }
        //} //NOT COMPLETE


    }//End CLass - Utilities

}
