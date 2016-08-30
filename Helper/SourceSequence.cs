using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio
{
    public class SourceSequence
    {

        #region Helper Methods

        public static String GetNumberOfSourceSequenceAsString(Poly poly)
        {
            Boolean f = false;
            Decimal src = SafeNumberOfSourceSequences(poly, ref f);
            
            if (f)
            {
                return (String.Format("Possible SourceSequence sequences: 1x10^{0}", src));
            }

            return (String.Format("Possible SourceSequence sequences: {0}", src));
        }

        #endregion



        #region Direct Methods

        public static Decimal SafeNumberOfSourceSequences(Poly poly, ref Boolean IsExt)
        {
            Decimal safeResults = 0;
            IsExt = false;
            safeResults = NumberOfSourceSequences(poly);

            if (safeResults == 0)
            {
                safeResults = NumberOfSourceSequencesExponent(poly);
                IsExt = true;
            }

            return safeResults;
        }


        public static Decimal NumberOfSourceSequences(Poly poly)
        {
            Decimal templates = 1;
            String p = poly.Sequence;
            Int32 len = p.Length;

            for (Int32 index = 0; index <= len - 1; index++)
            {
                try
                {

                    #region Switch
                    switch (p.Substring(index, 1))
                    {
                        case "A": //Alanine
                            templates = templates * 4;
                            break;

                        case "C": //Cysteine
                            templates = templates * 2;
                            break;

                        case "D": //Aspartic Acid
                            templates = templates * 2;
                            break;

                        case "E": //Glutamic Acid
                            templates = templates * 2;
                            break;

                        case "F": //Phenylalanine
                            templates = templates * 1;
                            break;

                        case "G": //Glycine
                            templates = templates * 4;
                            break;

                        case "H": //Histidine
                            templates = templates * 2;
                            break;

                        case "I": //Isoleucine
                            templates = templates * 3;
                            break;

                        case "K": //Lysine
                            templates = templates * 2;
                            break;

                        case "L": //Leucine
                            templates = templates * 6;
                            break;

                        case "M": //Methionine
                            templates = templates * 1;
                            break;

                        case "N": //Asparagine
                            templates = templates * 2;
                            break;

                        case "P": //Proline
                            templates = templates * 4;
                            break;

                        case "Q": //Glutamine
                            templates = templates * 2;
                            break;

                        case "R": //Arginine
                            templates = templates * 6;
                            break;

                        case "S": //Serine
                            templates = templates * 5;
                            break;

                        case "T": //Threonine
                            templates = templates * 4;
                            break;

                        case "V": //Valine
                            templates = templates * 4;
                            break;

                        case "W": //Tryptophan
                            templates = templates * 1;
                            break;

                        case "Y": //Tyrosine
                            templates = templates * 1;
                            break;

                        default:
                            break;
                    }
                    #endregion
                }
                catch (OverflowException oe)
                {
                    return 0;
                }

            }

            return templates;
        }


        public static Decimal NumberOfSourceSequencesExponent(Poly poly)
        {
            Double templates = 1;
            String p = poly.Sequence;
            Int32 len = p.Length;

            for (Int32 index = 0; index <= len - 1; index++)
            {

                #region Switch
                switch (p.Substring(index, 1))
                {
                    case "A": //Alanine
                        templates += 0.602059991327962;
                        break;

                    case "C": //Cysteine
                        templates += 0.301029995663981;
                        break;

                    case "D": //Aspartic Acid
                        templates += 0.301029995663981;
                        break;

                    case "E": //Glutamic Acid
                        templates += 0.301029995663981;
                        break;

                    case "F": //Phenylalanine
                        break;

                    case "G": //Glycine
                        templates += 0.602059991327962;
                        break;

                    case "H": //Histidine
                        templates += 0.301029995663981;
                        break;

                    case "I": //Isoleucine
                        templates += 0.477121254719662;
                        break;

                    case "K": //Lysine
                        templates += 0.301029995663981;
                        break;

                    case "L": //Leucine
                        templates += 0.778151250383644;
                        break;

                    case "M": //Methionine
                        break;

                    case "N": //Asparagine
                        templates += 0.301029995663981;
                        break;

                    case "P": //Proline
                        templates += 0.602059991327962;
                        break;

                    case "Q": //Glutamine
                        templates += 0.301029995663981;
                        break;

                    case "R": //Arginine
                        templates += 0.778151250383644;
                        break;

                    case "S": //Serine
                        templates += 0.698970004336019;
                        break;

                    case "T": //Threonine
                        templates += 0.602059991327962;
                        break;

                    case "V": //Valine
                        templates += 0.602059991327962;
                        break;

                    case "W": //Tryptophan
                        break;

                    case "Y": //Tyrosine
                        break;

                    default:
                        break;
                }
                #endregion


            }

            return (Decimal)templates;
        }


        public static String CompositeSourceSequence(Poly poly)
        {
            String polypeptide = poly.Sequence;
            Int32 len = polypeptide.Length;
            StringBuilder sb = new StringBuilder();

            for (int index = 0; index <= len - 1; index++)
            {
                #region Switch
                switch (polypeptide.Substring(index, 1))
                {
                    case "A": //Alanine
                        sb.Append("GCN");
                        break;

                    case "C": //Cysteine
                        sb.Append("UG[T|C]");
                        break;

                    case "D": //Aspartic Acid
                        sb.Append("GA[T|C]");
                        break;

                    case "E": //Glutamic Acid
                        sb.Append("GA[A|G]");
                        break;

                    case "F": //Phenylalanine
                        sb.Append("TT[T|C]");
                        break;

                    case "G": //Glycine
                        sb.Append("GGN");
                        break;

                    case "H": //Histidine
                        sb.Append("CA[T|C]");
                        break;

                    case "I": //Isoleucine
                        sb.Append("AT[T|C|A]");
                        break;

                    case "K": //Lysine
                        sb.Append("AA[A|G]");
                        break;

                    case "L": //Leucine
                        sb.Append("CTN|[TT[A|G]]");
                        break;

                    case "M": //Methionine
                        sb.Append("ATG");
                        break;

                    case "N": //Asparagine
                        sb.Append("AA[T|C]");
                        break;

                    case "P": //Proline
                        sb.Append("CCN");
                        break;

                    case "Q": //Glutamine
                        sb.Append("CA[A|G]");
                        break;

                    case "R": //Arginine
                        sb.Append("CGN|[AG[A|G]]");
                        break;

                    case "S": //Serine
                        sb.Append("TCN|[AG[T|C]]");
                        break;

                    case "T": //Threonine
                        sb.Append("ACN");
                        break;

                    case "V": //Valine
                        sb.Append("GTN");
                        break;

                    case "W": //Tryptophan
                        sb.Append("TGG");
                        break;

                    case "Y": //Tyrosine
                        sb.Append("TA[T|C]");
                        break;

                    case "X": //STOP
                        sb.Append("TA[A|G]|[TGA]");
                        break;

                    case "+": //START
                        sb.Append("ATG");
                        break;

                    default:
                        break;
                }
                #endregion
            }
            return sb.ToString();
        }

        #endregion

    }
}
