//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio.Internal;

namespace SequenceStudio
{
    /// <summary>
    /// This class provides 8 methods that format a String[] that indicates the matches, or non-matches, between the 
    /// following: DNA-DNA, RNA-RNA, Poly-Poly, or DNA-RNA
    /// </summary>
    public static class FormatMethods
    {


        #region FormatMatchPattern

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="list">List(int) - list of all places on the <paramref name="strand"/> where the 
        /// <paramref name="pattern"/> matches it.</param>
        /// <param name="strand">DNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">DNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatMatchPattern(DNA strand, DNA pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="strand">RNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">RNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatMatchPattern(RNA strand, RNA pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="strand">Poly class instance - the sequence being matched to.</param>
        /// <param name="pattern">Poly class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatMatchPattern(Poly strand, Poly pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="strand">DNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">RNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatMatchPattern(DNA strand, RNA pattern)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession, pattern.Organism,
                pattern.Locus, pattern.Description, s);
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatMatchPattern(list, strand.Sequence, d.Sequence);
        }

        #endregion


        #region FormatNonMatchPattern

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "X" for non-matches and " " for matches.
        /// </summary>
        /// <param name="list">List(int) - list of all places on the <paramref name="strand"/> where the 
        /// <paramref name="pattern"/> does NOT match it.</param>
        /// <param name="strand">DNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">DNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatNonMatchPattern(DNA strand, DNA pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatNonMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "X" for non-matches and " " for matches.
        /// </summary>
        /// <param name="strand">RNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">RNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method. if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatNonMatchPattern(RNA strand, RNA pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatNonMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "X" for non-matches and " " for matches.
        /// </summary>
        /// <param name="strand">Poly class instance - the sequence being matched to.</param>
        /// <param name="pattern">Poly class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method. if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatNonMatchPattern(Poly strand, Poly pattern)
        {
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatNonMatchPattern(list, strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "X" for non-matches and " " for matches.
        /// </summary>
        /// <param name="strand">DNA class instance - the sequence being matched to.</param>
        /// <param name="pattern">RNA class instance - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        /// <remarks>The List(int) list must be the result of the MatchPattern() method . if it is not
        /// the resulting MatchGrid string may be innaccurrate.</remarks>
        public static String[] FormatNonMatchPattern(DNA strand, RNA pattern)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession, pattern.Organism,
                pattern.Locus, pattern.Description, s);
            List<int> list = Search.MatchPattern(strand, pattern);
            return Find.FormatNonMatchPattern(list, strand.Sequence, d.Sequence);
        }

        #endregion

    }
}
