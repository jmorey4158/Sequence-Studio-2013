//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio.Internal;
using SequenceStudio;

namespace SequenceStudio
{
    public static class Search
    {

        #region MatchPercentage

        /// <summary>
        /// Finds all instances of the <paramref name="pattern"/> found to at least the <paramref name="threshold"/> 
        /// percentage match on the <paramref name="strand"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to search for the pattern</param>
        /// <param name="pattern">DNA class instance - the pattern to search for</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Double) - the list of all matches.</returns>
        public static Dictionary<Int32, Double> MatchPercentage(DNA strand, DNA pattern, Double threshold)
        {
            return Find.MatchSet(strand.Sequence, pattern.Sequence, threshold);

        }

        /// <summary>
        /// Finds all instances of the <paramref name="pattern"/> found to at least the <paramref name="threshold"/> 
        /// percentage match on the <paramref name="strand"/>.
        /// </summary>
        /// <param name="strand">RNA class instance - the strand to search for the pattern</param>
        /// <param name="pattern">RNA class instance - the pattern to search for</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Double) - the list of all matches.</returns>
        public static Dictionary<Int32, Double> MatchPercentage(RNA strand, RNA pattern, Double threshold)
        {
            return Find.MatchSet(strand.Sequence, pattern.Sequence, threshold);

        }

        /// <summary>
        /// Finds all instances of the <paramref name="pattern"/> found to at least the <paramref name="threshold"/> 
        /// percentage match on the <paramref name="strand"/>.
        /// </summary>
        /// <param name="strand">Poly class instance - the strand to search for the pattern</param>
        /// <param name="pattern">Poly class instance - the pattern to search for</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Double) - the list of all matches, the locus of the start of the match and 
        /// the percentage of the match.</returns>
        public static Dictionary<Int32, Double> MatchPercentage(Poly strand, Poly pattern, Double threshold)
        {
            return Find.MatchSet(strand.Sequence, pattern.Sequence, threshold);

        }

        #endregion


        #region MatchCount

        /// <summary>
        /// Matches two DNA sequences and finds all segents that match to at least <paramref name="threshold"/>
        /// percentage.
        /// </summary>
        /// <param name="strand">DNA class instance.</param>
        /// <param name="pattern">DNA class instance.</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Int32) - the list of all matches, the locus of the match and the length
        /// of the match segment.</returns>
        public static Dictionary<Int32, Int32> MatchCount(DNA strand, DNA pattern, Double threshold)
        {
            return Find.MatchSequences(strand.Sequence, pattern.Sequence, threshold);
        }

        /// <summary>
        /// Matches two RNA sequences and finds all segents that match to at least <paramref name="threshold"/>
        /// percentage.
        /// </summary>
        /// <param name="strand">RNA class instance.</param>
        /// <param name="pattern">RNA class instance.</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Int32) - the list of all matches, the locus of the match and the length
        /// of the match segment.</returns>
        public static Dictionary<Int32, Int32> MatchCount(RNA strand, RNA pattern, Double threshold)
        {
            return Find.MatchSequences(strand.Sequence, pattern.Sequence, threshold);
        }

        /// <summary>
        /// Matches two Poly sequences and finds all segents that match to at least <paramref name="threshold"/>
        /// percentage.
        /// </summary>
        /// <param name="strand">Poly class instance.</param>
        /// <param name="pattern">Poly class instance.</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Int32) - the list of all matches, the locus of the match and the length
        /// of the match segment.</returns>
        public static Dictionary<Int32, Int32> MatchCount(Poly strand, Poly pattern, Double threshold)
        {
            return Find.MatchSequences(strand.Sequence, pattern.Sequence, threshold);
        }

        /// <summary>
        /// Matches DNA and RNA sequences and finds all segments that match to at least <paramref name="threshold"/>
        /// percentage.
        /// </summary>
        /// <param name="strand">DNA class instance.</param>
        /// <param name="pattern">RNA class instance.</param>
        /// <param name="threshold">Double - the minimum percentage match that will be accpeted.</param>
        /// <returns>Dictionary(Int32, Int32) - the list of all matches, the locus of the match and the length
        /// of the match segment.</returns>
        public static Dictionary<Int32, Int32> MatchCount(DNA strand, RNA pattern, Double threshold)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d  = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession,pattern.Organism,
                pattern.Locus, pattern.Description, s );
            return Find.MatchSequences(strand.Sequence, d.Sequence, threshold);
        }


       
        #endregion


        #region MatchGrid

        /// <summary>
        /// Returns the actual sequence matches for the given sequences.</summary>
        /// <param name="strand">DNA class instance - the sequence to be matched against.</param>
        /// <param name="pattern">DNA class instance - the sequence to be matched against.</param>
        /// <param name="threshold">Double - the percentage of match threshold.</param>
        /// <returns>String[] - the set of string representing the actual matches on 
        /// <paramref name="strand"/> when matches with <paramref name="pattern"/>.</returns>
        public static Dictionary<Int32,String> MatchGrid(DNA strand, DNA pattern, Double threshold)
        {
            Dictionary<int,int> matches = MatchCount(strand, pattern, threshold);
            return Find.MatchGrid(matches, strand.Sequence);
        }

        /// <summary>
        /// Returns the actual sequence matches for the given sequences.</summary>
        /// <param name="strand">RNA class instance - the sequence to be matched against.</param>
        /// <param name="pattern">RNA class instance - the sequence to be matched against.</param>
        /// <param name="threshold">Double - the percentage of match threshold.</param>
        /// <returns>String[] - the set of string representing the actual matches on 
        /// <paramref name="strand"/> when matches with <paramref name="pattern"/>.</returns>
        public static Dictionary<Int32, String> MatchGrid(RNA strand, RNA pattern, Double threshold)
        {
            Dictionary<int,int> matches = MatchCount(strand, pattern, threshold);
            return Find.MatchGrid(matches, strand.Sequence);
        }

        /// <summary>
        /// Returns the actual sequence matches for the given sequences.</summary>
        /// <param name="strand">Poly class instance - the sequence to be matched against.</param>
        /// <param name="pattern">Poly class instance - the sequence to be matched against.</param>
        /// <param name="threshold">Double - the percentage of match threshold.</param>
        /// <returns>String[] - the set of string representing the actual matches on 
        /// <paramref name="strand"/> when matches with <paramref name="pattern"/>.</returns>
        public static Dictionary<Int32, String> MatchGrid(Poly strand, Poly pattern, Double threshold)
        {
            Dictionary<int,int> matches = MatchCount(strand, pattern, threshold);
            return Find.MatchGrid(matches, strand.Sequence);
        }

        /// <summary>
        /// Returns the actual sequence matches for the given sequences.</summary>
        /// <param name="strand">DNA class instance - the sequence to be matched against.</param>
        /// <param name="pattern">RNA class instance - the sequence to be matched against.</param>
        /// <param name="threshold">Double - the percentage of match threshold.</param>
        /// <returns>String[] - the set of string representing the actual matches on 
        /// <paramref name="strand"/> when matches with <paramref name="pattern"/>.</returns>
        /// <remarks>THe methods transcribes the RNA strand into a DNA strand and reports 
        /// the results in reference to the DNA strand.</remarks>
        public static Dictionary<Int32, String> MatchGrid(DNA strand, RNA pattern, Double threshold)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession, pattern.Organism,
                pattern.Locus, pattern.Description, s);

            Dictionary<int, int> matches = MatchCount(strand, d, threshold);

            return Find.MatchGrid(matches, strand.Sequence);
        }


        #endregion


        #region NonMatchPattern

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that do not match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">DNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> NonMatchPattern(DNA strand, DNA pattern)
        {
            return Find.NonMatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that do not match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">RNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> NonMatchPattern(RNA strand, RNA pattern)
        {
            return Find.NonMatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that do not match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">Poly class instance - the strand to perform the match on.</param>
        /// <param name="pattern">Poly class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> NonMatchPattern(Poly strand, Poly pattern)
        {
            return Find.NonMatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that do not match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> NonMatchPattern(DNA strand, RNA pattern)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession, pattern.Organism,
                pattern.Locus, pattern.Description, s);
            return Find.NonMatchPattern(strand.Sequence, d.Sequence);
        }

        #endregion


        #region MatchPattern

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">DNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> MatchPattern(DNA strand, DNA pattern)
        {
            return Find.MatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">RNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> MatchPattern(RNA strand, RNA pattern)
        {
            return Find.MatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">Poly class instance - the strand to perform the match on.</param>
        /// <param name="pattern">Poly class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> MatchPattern(Poly strand, Poly pattern)
        {
            return Find.MatchPattern(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds all places on the <paramref name="strand"/> that match the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to perform the match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>List(Int32) - the list of all loci on the <paramref name="strand"/> 
        /// that does not match the <paramref name="pattern"/>.</returns>
        /// <remarks>this method does not perform aligment.</remarks>
        public static List<Int32> MatchPattern(DNA strand, RNA pattern)
        {
            String s = pattern.Sequence.ToUpper().Replace("U", "T");
            DNA d = new DNA(pattern.ID, pattern.Enumeration, pattern.Accession, pattern.Organism,
                pattern.Locus, pattern.Description, s);
            return Find.NonMatchPattern(strand.Sequence, d.Sequence);
        }

        #endregion


        #region LongestContiguousMatchRegions

        /// <summary>
        /// Finds the longest region along the <paramref name="strand"/> that matches the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to match on.</param>
        /// <param name="pattern">DNA class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousMatchRegions(DNA strand, DNA pattern)
        {
            return Find.LongestContiguousMatchRegions(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds the longest region along the <paramref name="strand"/> that matches the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">RNA class instance - the strand to match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousMatchRegions(RNA strand, RNA pattern)
        {
            return Find.LongestContiguousMatchRegions(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds the longest region along the <paramref name="strand"/> that matches the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">Poly class instance - the strand to match on.</param>
        /// <param name="pattern">Poly class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousMatchRegions(Poly strand, Poly pattern)
        {
            return Find.LongestContiguousMatchRegions(strand.Sequence, pattern.Sequence);
        }

        #endregion


        #region LongestContiguousNonMatchRegions

        /// <summary>
        /// Finds the region of non-matches on the <paramref name="strand"/> with the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">DNA class instance - the strand to match on.</param>
        /// <param name="pattern">DNA class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest non-match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousNonMatchRegions(DNA strand, DNA pattern)
        {
            return Find.LongestContiguousMisMatchRegions(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds the region of non-matches on the <paramref name="strand"/> with the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">RNA class instance - the strand to match on.</param>
        /// <param name="pattern">RNA class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest non-match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousNonMatchRegions(RNA strand, RNA pattern)
        {
            return Find.LongestContiguousMisMatchRegions(strand.Sequence, pattern.Sequence);
        }

        /// <summary>
        /// Finds the region of non-matches on the <paramref name="strand"/> with the <paramref name="pattern"/>.
        /// </summary>
        /// <param name="strand">Poly class instance - the strand to match on.</param>
        /// <param name="pattern">Poly class instance - the pattern to match.</param>
        /// <returns>Dictionary(Int32, Int32) - the locus and length of the longest non-match region. If thre are 
        /// multiple match regions witht he same length, they will all be returned.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousNonMatchRegions(Poly strand, Poly pattern)
        {
            return Find.LongestContiguousMisMatchRegions(strand.Sequence, pattern.Sequence);
        }

        #endregion


        #region ContiguousMatchRegions

        /// <summary>
        /// Finds the longest contiguous match regions between two sequences. Two Strings are 
        /// passed in: (1) sequence and (2) pattern. This method returns all matches over the 'threashold'.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="strand">DNA class instance - the sequence to be matched against</param>
        /// <param name="pattern">DNA class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">Double - the percentage at or above which a match is recorded.</param>
        /// <returns name="matches">Dictionary(Int32 loc, Double percentage)- The list of matches.</returns>
        public static Dictionary<Int32, Int32> ContiguousMatchRegions(DNA strand, DNA pattern, Double threshold)
        {
            return Find.ContiguousMatchRegions(strand.Sequence, pattern.Sequence, threshold);
        }

        /// <summary>
        /// Finds the longest contiguous match regions between two sequences. Two Strings are 
        /// passed in: (1) sequence and (2) pattern. This method returns all matches over the 'threashold'.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="strand">RNA class instance - the sequence to be matched against</param>
        /// <param name="pattern">RNA class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">Double - the percentage at or above which a match is recorded.</param>
        /// <returns name="matches">Dictionary(Int32 loc, Double percentage)- The list of matches.</returns>
        public static Dictionary<Int32, Int32> ContiguousMatchRegions(RNA strand, RNA pattern, Double threshold)
        {
            return Find.ContiguousMatchRegions(strand.Sequence, pattern.Sequence, threshold);
        }

        /// <summary>
        /// Finds the longest contiguous match regions between two sequences. Two Strings are 
        /// passed in: (1) sequence and (2) pattern. This method returns all matches over the 'threashold'.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="strand">Poly class instance - the sequence to be matched against</param>
        /// <param name="pattern">Poly class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">Double - the percentage at or above which a match is recorded.</param>
        /// <returns name="matches">Dictionary(Int32 loc, Double percentage)- The list of matches.</returns>
        public static Dictionary<Int32, Int32> ContiguousMatchRegions(Poly strand, Poly pattern, Double threshold)
        {
            return Find.ContiguousMatchRegions(strand.Sequence, pattern.Sequence, threshold);
        }

        #endregion


        #region SelfMatchRegion

        /// <summary>
        /// Finds all self-matches by percentage on a given sequence. 
        /// The sequence is 'folded' back over itself and 
        /// matches are searched for between the sequence and its Reverse sequence.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">DNA class instance - the sequence to be matched against</param>
        /// <param name="threshold">The percentage to stop matching at.</param>
        /// <returns>Dictionary(Int32, Double)- the list of matches found that are >= the threshold.</returns>
        public static Dictionary<Int32, Int32> SelfMatchSet(DNA strand, Double threshold)
        {
            return Find.SelfMatchRegion(strand.Sequence, threshold);
        }

        /// <summary>
        /// Finds all self-matches by percentage on a given sequence. 
        /// The sequence is 'folded' back over itself and 
        /// matches are searched for between the sequence and its Reverse sequence.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">RNA class instance - the sequence to be matched against</param>
        /// <param name="threshold">The percentage to stop matching at.</param>
        /// <returns>Dictionary(Int32, Double)- the list of matches found that are >= the threshold.</returns>
        public static Dictionary<Int32, Int32> SelfMatchSet(RNA strand, Double threshold)
        {
            return Find.SelfMatchRegion(strand.Sequence, threshold);
        }

        /// <summary>
        /// Finds all self-matches by percentage on a given sequence. 
        /// The sequence is 'folded' back over itself and 
        /// matches are searched for between the sequence and its Reverse sequence.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">Poly class instance - the sequence to be matched against</param>
        /// <param name="threshold">The percentage to stop matching at.</param>
        /// <returns>Dictionary(Int32, Double)- the list of matches found that are >= the threshold.</returns>
        public static Dictionary<Int32, Int32> SelfMatchSet(Poly strand, Double threshold)
        {
            return Find.SelfMatchRegion(strand.Sequence, threshold);
        }

        #endregion 
        //TODO: Fix internal method to get comp strand for match.


        #region LongestContiguousSelfMatch

        /// <summary>
        /// Finds anywhere along the sequence's own length that it can match to itself 
        /// and determines the longest contiguous area of this match.
        /// </summary>
        /// <remarks>This function builds a backwards strand equal to half the strand length and then runs 
        /// LongestContiguousMatchRegions(sequence, pattern) with the sequence and the backwards strand.</remarks>
        /// <dependencies>
        /// This Methods also calls the following Methods:
        /// LongestContiguousMatchRegion();
        /// </dependencies>
        /// <param name="strand">DNA class instance - the sequence to be matched against itself.</param>
        /// <returns>ref Dictionary(Int32, Int32)- the list of starting point and length ofmatches found.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousSelfMatch(DNA strand)
        {
            return Find.LongestContiguousSelfMatch(strand.Sequence);
        }

        /// <summary>
        /// Finds anywhere along the sequence's own length that it can match to itself 
        /// and determines the longest contiguous area of this match.
        /// </summary>
        /// <remarks>This function builds a backwards strand equal to half the strand length and then runs 
        /// LongestContiguousMatchRegions(sequence, pattern) with the sequence and the backwards strand.</remarks>
        /// <dependencies>
        /// This Methods also calls the following Methods:
        /// LongestContiguousMatchRegion();
        /// </dependencies>
        /// <param name="strand">RNA class instance - the sequence to be matched against itself.</param>
        /// <returns>ref Dictionary(Int32, Int32)- the list of starting point and length ofmatches found.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousSelfMatch(RNA strand)
        {
            return Find.LongestContiguousSelfMatch(strand.Sequence);
        }

        /// <summary>
        /// Finds anywhere along the sequence's own length that it can match to itself 
        /// and determines the longest contiguous area of this match.
        /// </summary>
        /// <remarks>This function builds a backwards strand equal to half the strand length and then runs 
        /// LongestContiguousMatchRegions(sequence, pattern) with the sequence and the backwards strand.</remarks>
        /// <dependencies>
        /// This Methods also calls the following Methods:
        /// LongestContiguousMatchRegion();
        /// </dependencies>
        /// <param name="strand">Poly class instance - the sequence to be matched against itself.</param>
        /// <returns>ref Dictionary(Int32, Int32)- the list of starting point and length ofmatches found.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousSelfMatch(Poly strand)
        {
            return Find.LongestContiguousSelfMatch(strand.Sequence);
        }

        #endregion


        #region MatchInterval

        /// <summary>
        /// Finds all matches by percentage at a given interval between two Strings. 
        /// If the match of 'threashold' percent is at a given interval then it is recorded.
        /// </summary>
        /// <param name="strand">DNA class instance - the sequence to be matched against</param>
        /// <param name="pattern">DNA class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">The percentage at which a match is recorded.</param>
        /// <param name="interval">List(Int32) a list of intervals between this match and the next one.</param>
        /// <returns>Dictionary(Int32, Int32)- the list of matches found that are => the threshold.</returns>
        public static Dictionary<Int32, Double> MatchInterval(DNA strand, DNA pattern
            , List<Int32> interval, Double threshold)
        {
            return Find.MatchInterval(strand.Sequence, pattern.Sequence, interval, threshold);
        }

        /// <summary>
        /// Finds all matches by percentage at a given interval between two Strings. 
        /// If the match of 'threashold' percent is at a given interval then it is recorded.
        /// </summary>
        /// <param name="strand">RNA class instance - the sequence to be matched against</param>
        /// <param name="pattern">RNA class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">The percentage at which a match is recorded.</param>
        /// <param name="interval">List(Int32) a list of intervals between this match and the next one.</param>
        /// <returns>Dictionary(Int32, Int32)- the list of matches found that are => the threshold.</returns>
        public static Dictionary<Int32, Double> MatchInterval(RNA strand, RNA pattern
            , List<Int32> interval, Double threshold)
        {
            return Find.MatchInterval(strand.Sequence, pattern.Sequence, interval, threshold);
        }

        /// <summary>
        /// Finds all matches by percentage at a given interval between two Strings. 
        /// If the match of 'threashold' percent is at a given interval then it is recorded.
        /// </summary>
        /// <param name="strand">Poly class instance - the sequence to be matched against</param>
        /// <param name="pattern">Poly class instance - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">The percentage at which a match is recorded.</param>
        /// <param name="interval">List(Int32) a list of intervals between this match and the next one.</param>
        /// <returns>Dictionary(Int32, Int32)- the list of matches found that are => the threshold.</returns>
        public static Dictionary<Int32, Double> MatchInterval(Poly strand, Poly pattern
            , List<Int32> interval, Double threshold)
        {
            return Find.MatchInterval(strand.Sequence, pattern.Sequence, interval, threshold);
        }

        #endregion


        #region Repeats

        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">DNA class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <returns>Dictionary(Int32, Int32) - the set of matches that 
        /// meets the criteria. The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(DNA strand, Int32 length)
        {
            return Find.Repeats(strand.Sequence, length);
        }

        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">DNA class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <param name="threshold">Double - the percentage match threshold to record matches.</param> 
        /// <returns>Dictionary(Int32, Int32) - the set of matches that meets the criteria. 
        /// The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(DNA strand, Int32 length, Double threshold)
        {
            return Find.Repeats(strand.Sequence, length, threshold);
        }

        
        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">RNA class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <returns>Dictionary(Int32, Int32) - the set of matches that 
        /// meets the criteria. The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(RNA strand, Int32 length)
        {
            return Find.Repeats(strand.Sequence, length);
        }

        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">RNA class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <param name="threshold">Double - the percentage match threshold to record matches.</param> 
        /// <returns>Dictionary(Int32, Int32) - the set of matches that meets the criteria. 
        /// The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(RNA strand, Int32 length, Double threshold)
        {
            return Find.Repeats(strand.Sequence, length, threshold);
        }


        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">Poly class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <returns>Dictionary(Int32, Int32) - the set of matches that 
        /// meets the criteria. The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(Poly strand, Int32 length)
        {
            return Find.Repeats(strand.Sequence, length);
        }

        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="strand">Poly class instance - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <param name="threshold">Double - the percentage match threshold to record matches.</param> 
        /// <returns>Dictionary(Int32, Int32) - the set of matches that meets the criteria. 
        /// The list entries are the location where the match starts and the length of the match.</returns>
        public static List<Tuple<int, int>> Repeats(Poly strand, Int32 length, Double threshold)
        {
            return Find.Repeats(strand.Sequence, length, threshold);
        }

        #endregion 
        ///TODO: NOT TESTED





    }
}
