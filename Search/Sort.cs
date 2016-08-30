//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;

namespace SequenceStudio
{
    public class Sort
    {
        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Double) in decending order by kp.Value
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Double)- passed back to caller.</param>
        public static void ValuesDescending(ref Dictionary<Int32, Double> matches)
        {
            Dictionary<Int32, Double> matchesOrdered = new Dictionary<Int32, Double>();
            List<Double> tempValues = new List<Double>();

            foreach (KeyValuePair<Int32, Double> kp in matches)
            {
                tempValues.Add(kp.Value);
            }

            tempValues.Sort();
            tempValues.Reverse();

            foreach (Double d in tempValues)
            {
                Dictionary<Int32, Double>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Value != d)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }
        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Int32) in decending order by kp.Value
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Int32)- passed back to caller.</param>
        public static void ValuesDescending(ref Dictionary<Int32, Int32> matches)
        {
            Dictionary<Int32, Int32> matchesOrdered = new Dictionary<Int32, Int32>();
            List<Double> tempValues = new List<Double>();

            foreach (KeyValuePair<Int32, Int32> kp in matches)
            {
                tempValues.Add(kp.Value);
            }

            tempValues.Sort();
            tempValues.Reverse();

            foreach (Int32 i in tempValues)
            {
                Dictionary<Int32, Int32>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Value != i)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }

        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Double) in ascending order by kp.Value
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Double)- passed back to caller.</param>
        public static void ValuesAscending(ref Dictionary<Int32, Double> matches)
        {
            Dictionary<Int32, Double> matchesOrdered = new Dictionary<Int32, Double>();
            List<Double> tempValues = new List<Double>();

            foreach (KeyValuePair<Int32, Double> kp in matches)
            {
                tempValues.Add(kp.Value);
            }

            tempValues.Sort();

            foreach (Double d in tempValues)
            {
                Dictionary<Int32, Double>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Value != d)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }
        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Int32) in ascending order by kp.Value
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Int32)- passed back to caller.</param>
        public static void ValuesAscending(ref Dictionary<Int32, Int32> matches)
        {
            Dictionary<Int32, Int32> matchesOrdered = new Dictionary<Int32, Int32>();
            List<Int32> tempValues = new List<Int32>();

            foreach (KeyValuePair<Int32, Int32> kp in matches)
            {
                tempValues.Add(kp.Value);
            }

            tempValues.Sort();

            foreach (Int32 d in tempValues)
            {
                Dictionary<Int32, Int32>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Value != d)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }


        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Double) in decending order by kp.Key
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Double)- passed back to caller.</param>
        public static void KeysDescending(ref Dictionary<Int32, Double> matches)
        {
            Dictionary<Int32, Double> matchesOrdered = new Dictionary<Int32, Double>();
            List<Int32> tempKeys = new List<Int32>();

            foreach (KeyValuePair<Int32, Double> kp in matches)
            {
                tempKeys.Add(kp.Key);
            }

            tempKeys.Sort();
            tempKeys.Reverse();

            foreach (Int32 i in tempKeys)
            {
                Dictionary<Int32, Double>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Key != i)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }
        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Int32) in decending order by kp.Key
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Int32)- passed back to caller.</param>
        public static void KeysDescending(ref Dictionary<Int32, Int32> matches)
        {
            Dictionary<Int32, Int32> matchesOrdered = new Dictionary<Int32, Int32>();
            List<Int32> tempKeys = new List<Int32>();

            foreach (KeyValuePair<Int32, Int32> kp in matches)
            {
                tempKeys.Add(kp.Key);
            }

            tempKeys.Sort();
            tempKeys.Reverse();

            foreach (Int32 i in tempKeys)
            {
                Dictionary<Int32, Int32>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Key != i)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }


        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Double) in ascending order by kp.Key
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Double)- passed back to caller.</param>
        public static void KeysAscending(ref Dictionary<Int32, Double> matches)
        {
            Dictionary<Int32, Double> matchesOrdered = new Dictionary<Int32, Double>();
            List<Int32> tempKeys = new List<Int32>();

            foreach (KeyValuePair<Int32, Double> kp in matches)
            {
                tempKeys.Add(kp.Key);
            }

            tempKeys.Sort();

            foreach (Int32 i in tempKeys)
            {
                Dictionary<Int32, Double>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Key != i)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }
        /// <summary>
        /// This method orders the passed-in Dictionary(Int32,Int32) in ascending order by kp.Key
        /// </summary>
        /// <param name="matches">Dictionary(Int32,Int32)- passed back to caller.</param>
        public static void KeysAscending(ref Dictionary<Int32, Int32> matches)
        {
            Dictionary<Int32, Int32> matchesOrdered = new Dictionary<Int32, Int32>();
            List<Int32> tempKeys = new List<Int32>();

            foreach (KeyValuePair<Int32, Int32> kp in matches)
            {
                tempKeys.Add(kp.Key);
            }

            tempKeys.Sort();

            foreach (Int32 i in tempKeys)
            {
                Dictionary<Int32, Int32>.Enumerator matchesEnum = matches.GetEnumerator();
                matchesEnum.MoveNext();
                while (matchesEnum.Current.Key != i)
                {
                    matchesEnum.MoveNext();
                }
                matchesOrdered.Add(matchesEnum.Current.Key, matchesEnum.Current.Value);
                matches.Remove(matchesEnum.Current.Key);
            }

            matches = matchesOrdered;
            matchesOrdered = null;
        }


    }

}
