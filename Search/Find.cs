//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SequenceStudio;
using SequenceStudio.Internal;

namespace SequenceStudio
{
    /// <summary>
    /// The Find Class contains static Methods for finding mathces or non-matches between two strings or 
    /// within a single string.
    /// </summary>
    /// <remarks>The Find class and its methods are pat of an internal set of functionality. You may call
    /// these methods but they are typically called from helper methods that also perform validation
    /// and other pre-requisite checks before calling these methods.
    /// <para>These methods are intended for use with DNA, RNA, and ploypeptide sequences, but can be used with
    /// any string. However, using with strings might produce non-sense result sets.</para>
    /// </remarks>
    public class Find
    {


        /// <summary>
        /// Finds all places where there is at least a <paramref name="threshold"/> percentage match
        /// of a shorter String <paramref name="sequence2"/> within a longer String <paramref name="sequence1"/>.
        /// </summary>
        /// <param name="sequence1">String - the sequence to be matched against.</param>
        /// <param name="sequence2">String - the pattern to match agasint the sequence.
        /// <para>NOTE - If the <paramref name="sequence2"/> is longer than the
        /// <paramref name="sequence1"/> it is being matched against a 
        /// SequenceParameterException will be raised.</para></param>
        /// <param name="threshold">Double - any match below this percentage is not counted.</param>
        /// <returns>Dictionary(Int32, Double) - the list of matches found 
        /// that are greater than, or equal to, the <paramref name="threshold"/>. 
        /// The Int32 indicates where on the <paramref name="sequence1"/> the match is found 
        /// and 'Double' indicates the percentage of match between 
        /// <paramref name="sequence2"/> and <paramref name="sequence1"/> at that location.</returns>
        /// <exception cref="SequenceParameterException">The shortString is longer than the longString.</exception>
        /// <remarks>This method is intended to be used by helper methods in Sequence Studio 2011, where the input
        /// Strings are automatically validated to make sure that DNA, RNA, and Polypeptide sequences are being
        /// used as inputs. However, you can call this method directly using any String as inputs. 
        /// If the input strings are not of the same type the results not reprsent true matches.</remarks>
        public static Dictionary<Int32, Double> MatchSet(String sequence1, String sequence2, Double threshold)
        {

            Int32 shortLen = 0;
            Int32 longLen = 0;
            Int32 limit = 0;
            Int32 overlap = 0;
            Char padding = Convert.ToChar("_");
            Dictionary<Int32, Double> matches = new Dictionary<Int32, Double>();
            Dictionary<Int32, Double> temp = new Dictionary<Int32, Double>();
            String entendedSequence = "";
            Int32 patternLength = 0;
            Int32 thisMatchRegion = 0;
            Int32 lastRegionLocation = 0;
            Boolean IsMatch = false;

            //calculate threshold
            if (threshold < Constants.MatchesMin) { threshold = Constants.MatchesMin; }
            if (threshold > 100) { threshold = 100; }



            //BRANCH on shortest strand
            if (sequence1.Length >= sequence2.Length)
            {
                shortLen = sequence2.Length;
                longLen = sequence1.Length;

                patternLength = shortLen;
                lastRegionLocation = longLen - patternLength;

                limit = (Int32)(shortLen * (threshold / 100));
                overlap = shortLen - limit;

                entendedSequence = entendedSequence.PadLeft(sequence1.Length + overlap, padding);
                entendedSequence = entendedSequence.PadRight(overlap + sequence1.Length + overlap, padding);

                // This loop keeps matching the pattern and sequence until no match is found. thisMatchRegion 
                // is the length of the match region.
                // The loop will continue incremnementing thisMatchRegion until the sequence has been searched
                for (Int32 regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
                {
                    IsMatch = false;
                    thisMatchRegion = 0;

                    for (Int32 patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                    {
                        if (sequence2[patternLocation] == sequence1[regionLocation + patternLocation])
                        {
                            thisMatchRegion++;
                            IsMatch = true;
                        }
                    }
                    if ((IsMatch) && (thisMatchRegion >= limit))
                    {
                        Double product = ((double)thisMatchRegion / (double)longLen) * 100.0;
                        temp.Add(regionLocation + 1, product);
                    }
                }
            }
            else
            {
                longLen = sequence2.Length;
                shortLen = sequence1.Length;

                patternLength = shortLen;
                lastRegionLocation = longLen - patternLength;

                limit = (Int32)(shortLen * (threshold / 100));
                overlap = shortLen - limit;

                entendedSequence = entendedSequence.PadLeft(sequence2.Length + overlap, padding);
                entendedSequence = entendedSequence.PadRight(overlap + sequence2.Length + overlap, padding);

                // This loop keeps matching the pattern and sequence until no match is found. thisMatchRegion 
                // is the length of the match region.
                // The loop will continue incremnementing thisMatchRegion until the sequence has been searched
                for (Int32 regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
                {
                    IsMatch = false;
                    thisMatchRegion = 0;

                    for (Int32 patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                    {
                        if (sequence1[patternLocation] == sequence2[regionLocation + patternLocation])
                        {
                            thisMatchRegion++;
                            IsMatch = true;
                        }
                    }
                    if ((IsMatch) && (thisMatchRegion >= limit))
                    {
                        Double product = ((double)thisMatchRegion / (double)longLen) * 100.0;
                        temp.Add(regionLocation, product);
                    }
                }

            }



            // Sort the matches in length order and select the top matches
            if (temp.Count > 0)
            {
                Sort.ValuesDescending(ref temp);

                foreach (KeyValuePair<Int32, Double> kp in temp)
                {
                    matches.Add(kp.Key, kp.Value);
                }

            }

            return matches;
        }

        /// <summary>
        /// Finds all locations along <paramref name="string1"/> where <paramref name="string2"/> 
        /// does not match <paramref name="string1"/>.</summary>
        /// <param name="string1">String - the sequence to be matched.</param>
        /// <param name="string2">String - the sequence to match agasint the sequence.</param>
        /// <returns>List(Int32)- the list of mismatches found.</returns>
        /// <exception cref="SequenceParameterException">One or both input Strings is empty or Null.</exception>
        /// <remarks>This method returns a list of the locations where any character-character missmatches
        /// are found between the two strings. The matching algorythm aligns the two strings starting at
        /// position[0] and performs a match between each string at position[n]. 
        /// <para>The method does not attempt to fins the maximum matching alignment for the strings.
        /// The two input strings can be different sizes. 
        /// The matching algorythm stops at the end of the shortest string.</para></remarks>
        public static List<Int32> NonMatchPattern(String string1, String string2)
        {
            List<Int32> mismatches = new List<Int32>();
            if ((String.IsNullOrEmpty(string1)) || (String.IsNullOrEmpty(string2)))
            {
                SequenceParameterException e = new SequenceParameterException();
                e.ContextMessage = "One or both input Strings is empty or Null.";
                throw e;
            }
            
            Int32 sequenceLength = string1.Length;
            Int32 patternLength = string2.Length;
            Int32 matchlen = (string1.Length >= string2.Length) ? string2.Length : string1.Length;


            for (Int32 matchLocation = 0; matchLocation <= matchlen - 1; matchLocation++)
            {
                if (string1.Substring(matchLocation, 1) != string2.Substring(matchLocation, 1))
                {
                    mismatches.Add(matchLocation + 1);
                }
            }
            return mismatches;
        }

        /// <summary>
        /// Finds all locations along <paramref name="string1"/> where <paramref name="string2"/> 
        /// matched <paramref name="string1"/>.</summary>
        /// <param name="string1">String - the sequence to be matched.</param>
        /// <param name="string2">String - the sequence to match agasint the sequence.</param>
        /// <returns>List(Int32)- the list of match locations found.</returns>
        /// <exception cref="SequenceParameterException">One or both input Strings is empty or Null.</exception>
        /// <remarks>This method returns a list of the locations where any character-character matches
        /// are found between the two strings. The matching algorythm aligns the two strings starting at
        /// position[0] and performs a match between each string at position[n]. 
        /// <para>The method does not attempt to find the maximum matching alignment for the strings.
        /// The two input strings can be different sizes. 
        /// The matching algorythm stops at the end of the shortest string.</para></remarks>
        public static List<Int32> MatchPattern(String string1, String string2)
        {
            List<Int32> matches = new List<Int32>();
            if ((String.IsNullOrEmpty(string1)) || (String.IsNullOrEmpty(string2)))
            {
                SequenceParameterException e = new SequenceParameterException();
                e.ContextMessage = "One or both input Strings is empty or Null.";
                throw e;
            }
            
            Int32 sequenceLength = string1.Length;
            Int32 patternLength = string2.Length;
            Int32 matchlen = (string1.Length >= string2.Length) ? string2.Length : string1.Length;

            for (Int32 matchLocation = 0; matchLocation <= matchlen - 1; matchLocation++)
            {
                if (string1.Substring(matchLocation, 1) == string2.Substring(matchLocation, 1))
                {
                    matches.Add(matchLocation + 1);
                }
            }
            return matches;
        }
       

        /// <summary>
        /// Finds the longest contiguous region of non-matches between two Strings.
        /// The method returns only 1 entry, unless there is more than one region with the same characterisitcs.
        /// </summary>
        /// <dependencies>
        /// This Method calls the following Methods:
        /// ValidateSequence();
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="seq1">String - the sequence to be matched against</param>
        /// <param name="seq2">String - the pattern to match agasint the sequence.</param>
        /// <returns>Dictionary(Int32,Int32)- The list of the start and length of the match region.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousMisMatchRegions(String seq1, String seq2)
        {
            #region Set Variables
            Dictionary<Int32, Int32> mismatches = new Dictionary<Int32, Int32>();
            Dictionary<Int32, Int32> temp = new Dictionary<Int32, Int32>();

            Int32 reaLen = (seq1.Length >= seq2.Length)  ? seq2.Length - 1 : seq1.Length - 1;

            Int32 matchLoc = 0;
            Int32 thisLoc = 0;
            Int32 mismatchLen = 0;
            Boolean isNewMismatch = true;
            #endregion

            #region Find Mismatches

            for (thisLoc = 0; thisLoc <= reaLen; thisLoc++)
                {
                    if (seq2[thisLoc] != seq1[thisLoc])
                    {
                        mismatchLen++;
                        if (isNewMismatch)
                        {
                            matchLoc = thisLoc;
                            isNewMismatch = false;
                        }
                    }
                    else
                    {
                        if (mismatchLen > 0)
                        {
                            temp.Add(matchLoc + 1, thisLoc - matchLoc);
                            isNewMismatch = true;
                            mismatchLen = 0;
                        }
                    }
                }
            //This covers what happens is the last char doesn't match
                if (mismatchLen > 0)
                {
                    temp.Add(matchLoc + 1, thisLoc - matchLoc);
                }

            #endregion

            #region Sort Results
                if (temp.Count > 0)
                {
                    Sort.ValuesDescending(ref temp);
                    Int32 high = temp.First().Value;

                    foreach (KeyValuePair<Int32, Int32> kp in temp)
                    {
                        if (kp.Value == high)
                        {
                            mismatches.Add(kp.Key, kp.Value);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //returns if no mismatches found
                else
                {
                    mismatches.Add(-1, -1);
                }
             #endregion

             return mismatches;
        }


        /// <summary>
        /// This method takes two Strings and finds the longest contiguous match region between them.
        /// This match usually signifies an area of overlap if these sequences are sequential in a 
        /// longer sequence. 
        /// </summary>
        /// <dependencies>
        /// This Method called the following Methods:
        /// LongestContiguousMatchRegion();
        /// </dependencies>
        /// <param name="sequence1">String - the first sequence to be matched.</param>
        /// <param name="sequence2">String - the second sequence to be matched.</param>
        /// <param name="threshold">Double - the percentage of similarity required to qualify as a "match".</param>
        /// <returns>Dictionary(Int32 locus, Int32 length)- this is a list of the match(es) that qualify.
        /// Typically there will be only one match.</returns>
        public static Dictionary<Int32, Int32> MatchSequences(String sequence1, String sequence2,
            Double threshold)
        {

            Int32 shortLen = 0;
            Int32 longLen = 0;
            Int32 limit = 0;
            Int32 overlap = 0;
            Char padding = Convert.ToChar("_");
            Dictionary<Int32, Int32> matches = new Dictionary<Int32, Int32>();
            Dictionary<Int32, Int32> temp = new Dictionary<Int32, Int32>();
            String entendedSequence = "";
            Int32 patternLength = 0;
            Int32 thisMatchRegion = 0;
            Int32 lastRegionLocation = 0;
            Boolean IsMatch = false;

            //calculate threshold
            threshold = (threshold < Constants.MatchesMin) ? Constants.MatchesMin : threshold;
            threshold = (threshold > 100) ? 100 : threshold;



            //BRANCH on shortest strand
            if (sequence1.Length >= sequence2.Length)
            {
                shortLen = sequence2.Length;
                longLen = sequence1.Length;

                patternLength = shortLen;
                lastRegionLocation = longLen - patternLength;

                limit = (Int32)(shortLen * (threshold / 100));
                overlap = shortLen - limit;

                entendedSequence = entendedSequence.PadLeft(sequence1.Length + overlap, padding);
                entendedSequence = entendedSequence.PadRight(overlap + sequence1.Length + overlap, padding);

                // This loop keeps matching the pattern and sequence until no match is found. thisMatchRegion 
                // is the length of the match region.
                // The loop will continue incremnementing thisMatchRegion until the sequence has been searched
                for (Int32 regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
                {
                    IsMatch = false;
                    thisMatchRegion = 0;

                    for (Int32 patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                    {
                        if (sequence2[patternLocation] == sequence1[regionLocation + patternLocation])
                        {
                            thisMatchRegion++;
                            IsMatch = true;
                        }
                    }
                    if ((IsMatch) && (thisMatchRegion >= limit))
                    {
                        temp.Add(regionLocation + 1, thisMatchRegion);
                    }
                }
            }
            else
            {
                longLen = sequence2.Length;
                shortLen = sequence1.Length;

                patternLength = shortLen;
                lastRegionLocation = longLen - patternLength;

                limit = (Int32)(shortLen * (threshold / 100));
                overlap = shortLen - limit;

                entendedSequence = entendedSequence.PadLeft(sequence2.Length + overlap, padding);
                entendedSequence = entendedSequence.PadRight(overlap + sequence2.Length + overlap, padding);

                // This loop keeps matching the pattern and sequence until no match is found. thisMatchRegion 
                // is the length of the match region.
                // The loop will continue incremnementing thisMatchRegion until the sequence has been searched
                for (Int32 regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
                {
                    IsMatch = false;
                    thisMatchRegion = 0;

                    for (Int32 patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                    {
                        if (sequence1[patternLocation] == sequence2[regionLocation + patternLocation])
                        {
                            thisMatchRegion++;
                            IsMatch = true;
                        }
                    }
                    if ((IsMatch) && (thisMatchRegion >= limit))
                    {
                        temp.Add(regionLocation, thisMatchRegion);
                    }
                }

            }



            // Sort the matches in length order and select the top matches
            if (temp.Count > 0)
            {
                Sort.ValuesDescending(ref temp);

                foreach (KeyValuePair<Int32, Int32> kp in temp)
                {
                        matches.Add(kp.Key, kp.Value);
                }

            }

            return matches;

        }//TODO: Test for performance



        /// <summary>
        /// Finds the best match by percentage of all matches between two Strings.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// ValuesDescending(Int32,Double);
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="pattern">String - the pattern to match agasint the sequence.</param>
        /// <returns>Dictionary(Int32, Double)- the list of matches found that are >= the threshold.</returns>
        public static Dictionary<Int32, Double> BestMatchesPercentage(String sequence, String pattern)
        {
            Double threshold = 10; //This is a seed value to make sure we get matches at 10%
            //match or better. This could be any value. The method only takes the top value(s).
            Dictionary<Int32, Double> matches = new Dictionary<Int32, Double>();
            Dictionary<Int32, Double> tempMatches = MatchSet(sequence, pattern, threshold); // this is the rate-limiting step
            if (tempMatches.Count > 0)
            {
                Sort.ValuesDescending(ref tempMatches);
                Double highVal = tempMatches.First().Value;

                //This routine finds and Appends() any other matches where the kp.Value = highVal
                foreach (KeyValuePair<Int32, Double> keyPairMatches in tempMatches)
                {
                    if (keyPairMatches.Value == highVal)
                    {
                        matches.Add(keyPairMatches.Key, keyPairMatches.Value);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return matches;
        }

        /// <summary>
        /// Finds the longest contiguous match regions between two Strings. Usually returns only 1 match, unless
        /// there is more than one match with the same characterisitcs.
        /// </summary>
        /// <dependencies>
        /// ValidateSequence();
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="pattern">String - the pattern to match agasint the sequence. 
        /// NOTE - the pattern and the sequence must be the same sequecne type (e.g. DNA-DNA, RNA-RNA,
        /// Polypeptide-Polypeptide. IF they are not the matches will be non-sense.</param>
        /// <returns>Dictionary(Int32 loc, Double percentage)- populated and passed back
        /// to the caller.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousMatchRegions(String seq1, String seq2)
        {

            #region Set Variables
            Dictionary<Int32, Int32> matches = new Dictionary<Int32, Int32>();
            Dictionary<Int32, Int32> temp = new Dictionary<Int32, Int32>();

            Int32 reaLen = (seq1.Length >= seq2.Length) ? seq2.Length - 1 : seq1.Length - 1;

            Int32 matchLen = 0;
            Int32 matchLoc = 0;
            Int32 thisLoc = 0;;
            Boolean isNewMatch = true;
            #endregion

            #region Find Matches

            for (thisLoc = 0; thisLoc <= reaLen; thisLoc++)
            {
                if (seq2[thisLoc] == seq1[thisLoc])
                {
                    matchLen++;
                    if (isNewMatch)
                    {
                        matchLoc = thisLoc;
                        isNewMatch = false;
                    }
                }
                else
                {
                    if (matchLen > 0)
                    {
                        temp.Add(matchLoc + 1, thisLoc - matchLoc);
                        isNewMatch = true;
                        matchLen = 0;
                    }
                }
            }
            //This covers what happens is the last char matches
            if (matchLen > 0)
            {
                temp.Add(matchLoc + 1, thisLoc - matchLoc);
            }

            #endregion

            #region Sort Results
            if (temp.Count > 0)
            {
                Sort.ValuesDescending(ref temp);
                Int32 high = temp.First().Value;

                foreach (KeyValuePair<Int32, Int32> kp in temp)
                {
                    if (kp.Value == high)
                    {
                        matches.Add(kp.Key, kp.Value);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //returns if no matches found
            else
            {
                matches.Add(-1, -1);
            }
            #endregion

            return matches;
        }

        /// <summary>
        /// Finds all contiguous match regions between two Stirng. Two Strings are 
        /// passed in: (1) sequence and (2) pattern. This method returns all matches over the 'threashold'.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// ValidateSequence();
        /// BestMatchesPercentage();
        /// ValuesDescending();
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="pattern">String - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">Double - the percentage at or above which a match is recorded.</param>
        /// <returns name="matches">Dictionary(Int32 loc, Double percentage)- The list of matches.</returns>
        public static Dictionary<Int32, Int32> ContiguousMatchRegions(String sequence, String pattern, Double threshold)
        {

            threshold = (threshold < Constants.MatchesMin) ? Constants.MatchesMin : threshold;
            threshold = (threshold > 100) ? 100 : threshold;

            Dictionary<Int32, Int32> matches = new Dictionary<Int32, Int32>();
            Int32 patternLength = pattern.Length;
            Int32 cutoff = (Int32)(patternLength * (threshold / 100));
            Int32 thisMatchRegion = 0;
            Int32 lastRegionLocation = sequence.Length - patternLength;
            Boolean IsMatch = false;

            for (Int32 regionLocation = 0; regionLocation <= lastRegionLocation; regionLocation++)
            {
                IsMatch = false;
                for (Int32 patternLocation = 0; patternLocation <= patternLength - 1; patternLocation++)
                {
                    if (pattern[patternLocation] == sequence[regionLocation + patternLocation])
                    {
                        thisMatchRegion++;
                        IsMatch = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if ((IsMatch) && (thisMatchRegion >= cutoff))
                {
                    matches.Add(regionLocation + 1, thisMatchRegion);
                    thisMatchRegion = 0;
                }
            }
            Sort.ValuesDescending(ref matches);
            return matches;
        }

        /// <summary>
        /// Finds all self-matches by percentage on a given String. The String is 'folded' back over itself and 
        /// matches are searched for between the String and its Reverse String.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="threshold">The percentage to stop matching at.</param>
        /// <returns>Dictionary(Int32, Double)- the list of matches found that are >= the threshold.</returns>
        public static Dictionary<Int32, Int32> SelfMatchRegion(String sequence, Double threshold)
        {
            //Calculate the number of residues in half of the sequence
            Int32 halfSequence = (System.Math.Abs(sequence.Length / 2));

            //Ensure that threshold is withing 1-100%
            threshold = (threshold < Constants.MatchesMin) ? Constants.MatchesMin : threshold;
            threshold = (threshold > 100) ? 100 : threshold;

            // Create a sequence that is the same if the sequence folds over on itself.
            StringBuilder sb = new StringBuilder();
            for (Int32 matchLocation = sequence.Length - 1;
                matchLocation >= halfSequence; matchLocation--)
            {
                sb.Append(sequence.Substring(matchLocation, 1));
            }
            String pattern = sb.ToString();

            Dictionary<Int32, Int32> matches = ContiguousMatchRegions(sequence, pattern, threshold);
            return matches;
        }
        //TODO: This method does not find self-matches; it must get the comp strand of the pattern first

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
        /// <param name="sequence">String - the sequence to be matched against itself.</param>
        /// <returns>ref Dictionary(Int32, Int32)- the list of starting point and length ofmatches found.</returns>
        public static Dictionary<Int32, Int32> LongestContiguousSelfMatch(String sequence)
        {
            Int32 halfSequence = (System.Math.Abs(sequence.Length / 2));

            StringBuilder sb = new StringBuilder();
            for (Int32 matchLocation = sequence.Length - 1; matchLocation >= halfSequence; matchLocation--)
            {
                sb.Append(sequence.Substring(matchLocation, 1));
            }

            String pattern = sb.ToString();

            Dictionary<Int32, Int32> matches = LongestContiguousMatchRegions(sequence, pattern);
            return matches;
        }
        //TODO: This method does not find self-matches; it must get the comp strand of the pattern first


        /// <summary>
        /// Finds all matches by percentage at a given interval between two Strings. 
        /// If the match of 'threashold' percent is at a given interval then it is recorded.
        /// </summary>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="pattern">String - the pattern to match agasint the sequence.</param>
        /// <param name="threshold">The percentage at which a match is recorded.</param>
        /// <param name="interval">List(Int32) a list of intervals between this match and the next one.</param>
        /// <returns>Dictionary(Int32, Int32)- the list of matches found that are => the threshold.</returns>
        public static Dictionary<Int32, Double> MatchInterval(String sequence, String pattern
            , List<Int32> interval, Double threshold)
        {

            Dictionary<Int32, Double> matches = new Dictionary<Int32, Double>();
            Int32 sLen = sequence.Length;
            Int32 pLen = pattern.Length;
            Int32 seqTotalLength = sLen - 1;
            Int32 patTotalLength = pLen - 1;
            Int32 matchCount;
            Double product;

            //Ensure that threshold is withing 1-100%
            threshold = (threshold < Constants.MatchesMin) ? Constants.MatchesMin : threshold;
            threshold = (threshold > 100) ? 100 : threshold;

            foreach (Int32 interv in interval)
            {
                if ((interv + pLen) <= sLen)
                {
                    matchCount = 0;
                    for (Int32 p = 0; p <= patTotalLength; p++)
                    {
                        if ((pattern.Substring(p, 1) == (sequence.Substring((interv + p), 1))))
                        {
                            matchCount++;
                        }
                    }
                    product = ((Double)matchCount / (Double)pLen) * 100;
                    if (product >= threshold)
                    {
                        matches.Add(interv, product);
                    }
                }
            }
            //adds error entry if no matches
            if (matches.Count == 0)
            {
                matches.Add(-1,0);
            }
            return matches;
        }


        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search with.</param>
        /// <returns>Dictionary(Int32, Int32) - the set of matches that 
        /// meets the criteria. The list entries are the location where the match starts and the length of the match.</returns>
        /// <overloads>
        /// Repeats(String sequence, UInt16 length,ref Dictionary(Int32, Int32) repeats)
        /// Repeats(String sequence, Double threshold, UInt16 length,ref Dictionary(Int32, Int32) repeats)
        /// </overloads>
        public static List<Tuple<int, int>> Repeats(String sequence, Int32 length)
        {
            List<Tuple<int, int>> repeats = new List<Tuple<int, int>>();

            Int32 thisLocus = 0;
            Int32 endOfSeq = sequence.Length - 1;
            String pattern = "";

            //grab the first 'length' of the strand ad use that as the pattern
            for (thisLocus = 0; thisLocus + length <= endOfSeq; thisLocus++)
            {
                pattern = sequence.Substring(thisLocus, length);
                Dictionary<Int32, Int32> matches = ContiguousMatchRegions(sequence, pattern, 100);
                if (matches.Count > 0)
                {
                    foreach (KeyValuePair<int, int> kp in matches)
                    {
                        repeats.Add(Tuple.Create<int, int>(kp.Key, kp.Value));
                    }
                }

            }
            if (repeats.Count == 0)
            {
                repeats.Add(Tuple.Create<int, int>(-1, -1));
            }
            return repeats;
        }

        /// <summary>
        /// Finds all places on the strand where the sequence of 'length' units long repeats on the strand.
        /// </summary>
        /// <dependencies>
        /// This Method also calls the following Methods:
        /// MatchSet();
        /// </dependencies>
        /// <param name="sequence">String - the sequence to be matched against</param>
        /// <param name="length">UInt32 - the length of pattern to search on.</param>
        /// <param name="threshold">Double - the percentage match threshold to record matches.</param> 
        /// <returns>Dictionary(Int32, Int32) - the set of matches that meets the criteria. 
        /// The list entries are the location where the match starts and the length of the match.</returns>
        /// <overloads>
        /// Repeats(String sequence, UInt32 length,ref Dictionary(Int32, Int32) repeats)
        /// Repeats(String sequence, Double threshold, UInt16 length,ref Dictionary(Int32, Int32) repeats)
        /// </overloads>
        public static List<Tuple<int, int>> Repeats(String sequence, Int32 length, Double threshold)
        {
            List<Tuple<int, int>> repeats = new List<Tuple<int, int>>();
            String selfStrand = sequence;

            //Ensure that threshold is withing 1-100%
            threshold = (threshold < Constants.MatchesMin) ? Constants.MatchesMin : threshold;
            threshold = (threshold > 100) ? 100 : threshold;


            Int32 thisLocus = 0;
            Int32 endOfSeq = sequence.Length - 1;
            String pattern = "";

            //grab the first 'length' of the strand ad use that as the pattern
            for (thisLocus = 0; thisLocus + length <= endOfSeq; thisLocus++)
            {
                pattern = sequence.Substring(thisLocus, length);
                Dictionary<Int32, Int32> matches = ContiguousMatchRegions(sequence, pattern, 100);
                if (matches.Count > 0)
                {
                    foreach (KeyValuePair<int, int> kp in matches)
                    {
                        repeats.Add(Tuple.Create<int, int>(kp.Key, kp.Value));
                    }
                }

            }
            if (repeats.Count == 0)
            {
                repeats.Add(Tuple.Create<int, int>(-1, -1));
            }
            return repeats;
        }


        /// <summary>
        /// Returns the actual sequence matches for the given locations and length match set.</summary>
        /// <param name="sequence">String - the sequence to be matched against.</param>
        /// <param name="matches">Dictionary(int,int) - the loci and length of the matches.</param>
        /// <returns>String[] - the set of string representing the actual matches on 
        /// <paramref name="sequence"/> as provided in the location and length in 
        /// <paramref name="matches"/></returns>
        /// <remarks>This method is intended to be used to generate the actual match sequences
        /// for a List(int,int) generated using <paramref name="sequence"/>. MatchGrids produced 
        /// using another string may represent non-sense.</remarks>
        public static Dictionary<int, string> MatchGrid(Dictionary<int, int> matches, String sequence)
        {
            Dictionary<int, string> mGrid = new Dictionary<int, string>();

            foreach (KeyValuePair<int, int> kp in matches)
            {
                try
                {
                    mGrid.Add(kp.Key,sequence.Substring(kp.Key, kp.Value));
                }
                catch (IndexOutOfRangeException ie)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw;
                }

            }

            return mGrid;
        }

        /// <summary>
        /// Finds any Encryption Blocks in the given DNA seuence.
        /// </summary>
        /// <param name="d">DNA Class instance.</param>
        /// <returns>List(Tuple(int,int)) - the list of all Encryption Blocks, starting at N and of length L.
        /// NOTE - Becasue the entries can have repeated Key vlaues, a Tuple was used instead of Dictionary().</returns>
        public static List<Tuple<int,int>> EncryptionBlock(DNA d)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            String s = d.Sequence;
            int start = -1;
            int stop = -1;

            for (int i = 0; i <= s.Length - 9; i++)
            {

                if (s.Substring(i, 9) == UnitPatterns.tripleStart)
                {
                    start = i + 1;
                    i += 9;
                }
                if (s.Substring(i, 9) == UnitPatterns.tripleStop)
                {
                    if (start != -1)
                    {
                        stop = i + 1;
                    }
                }
                if ((start != -1) && (stop != -1))
                {
                    list.Add(Tuple.Create<int,int>(start, stop));
                    start = -1;
                    stop = -1;
                }

            }

            return list;
        }// TODO: NOT COMPLETE


        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="list">List(int) - list of all places on the <paramref name="strand"/> where the 
        /// <paramref name="pattern"/> matches it.</param>
        /// <param name="strand">String - the sequence being matched to.</param>
        /// <param name="pattern">String - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        public static String[] FormatMatchPattern(List<int> list, String strand, String pattern)
        {
            String[] ret = new String[3];
            ret[0] = strand;
            ret[2] = pattern;
            Int32 minLen = (strand.Length >= pattern.Length)? pattern.Length : strand.Length;
            Int32 inner = 0;
            StringBuilder sb = new StringBuilder();

            for (int index = 1; index <= minLen; index++)
            {
                if (inner <= list.Count - 1)
                {
                    if (list[inner] == index)
                    {
                        sb.Append("|");
                        inner++;
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }
                else
                {
                    sb.Append(" ");
                }
            }

            ret[1] = sb.ToString();

            return ret;
        }

        /// <summary>
        /// Returns a String[] of [0] = first sequence, [2] = MatchGrid string, [3] = second sequence. The MatchGrid
        /// string shows "_" for non-matches and "|" for matches.
        /// </summary>
        /// <param name="list">List(int) - list of all places on the <paramref name="strand"/> where the 
        /// <paramref name="pattern"/> does NOT match it.</param>
        /// <param name="strand">String - the sequence being matched to.</param>
        /// <param name="pattern">String - the sequence being matched.</param>
        /// <returns>String[3] - [0] = first sequence, [2] = MatchGrid string, [3] = second sequence.</returns>
        public static String[] FormatNonMatchPattern(List<int> list, String strand, String pattern)
        {
            String[] ret = new String[3];
            ret[0] = strand;
            ret[2] = pattern;
            Int32 minLen = (strand.Length >= pattern.Length)? pattern.Length : strand.Length;
            Int32 inner = 0;
            StringBuilder sb = new StringBuilder();

            for (int index = 1; index <= minLen; index++ )
            {
                if (inner <= list.Count - 1)
                {
                    if (list[inner] == index)
                    {
                        sb.Append(" ");
                        inner++;
                    }
                    else
                    {
                        sb.Append("X");
                    }
                }
                else
                {
                    sb.Append("X");
                }
            }
            ret[1] = sb.ToString();

            return ret;
        }

    } //END Find Class

}
