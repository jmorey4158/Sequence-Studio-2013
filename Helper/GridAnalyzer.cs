using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceStudio
{
    public  static class GridAnalyzer
    {

        public static Dictionary<String, String> AlignGrid(Dictionary<String, String> grid)
        {
            Dictionary<string, string> alignedGrid= new Dictionary<string, string>();

            // TODO: Add CODE

            return alignedGrid;
        }



        public static Dictionary<String, String> GetVerticalGrid(Dictionary<String, String> grid)
        {
            Dictionary<string, string> vGrid= new Dictionary<string, string>();

            // TODO: Add CODE

            return vGrid;
        }

    }


    public class GridRow
    {
        public string ID;
        public int Locus;
        public int BlockLength;
        public int Length;
        public string Sequence;
        public Dictionary<string, int> Pattern;

        public GridRow() { }

        public GridRow(string id, int loc, int len, string seq)
        {
            ID = id;
            Locus = loc;
            BlockLength = len;
            Sequence = seq.ToUpper();
            Length = seq.Length;

            Pattern = Stats(Sequence, (seq.ToUpper().Select(c => c.ToString()).ToList()).Distinct().ToArray<string>());
        }


        internal Dictionary<String, Int32> Stats(string seq, String[] pat)
        {
            Dictionary<String, Int32> units = new Dictionary<String, Int32>();
            Int32 count = 0;

            foreach (String s in pat)
            {
                for (Int32 index = 0; index < seq.Length - 1; ++index)
                {
                    if (seq.Substring(index, 1) == s)
                    {
                        count++;
                    }
                }
                units.Add(s, count);
                count = 0;
            }
            return units;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ID: " + this.ID + "\n");
            sb.Append("Locus: " + this.Locus.ToString() + "\n");
            sb.Append("BlockLength " + this.BlockLength.ToString() + "\n");
            sb.Append("Length " + this.Length.ToString() + "\n");
            sb.Append("UsagePattern: \n");
            foreach (KeyValuePair<string, int> kp in this.Pattern)
            {
                sb.Append(kp.Key + "   :" + kp.Value.ToString() + "\n");
            }

            sb.Append("Sequence: " + this.Sequence + "\n\n");


            return sb.ToString();
        }

    }

    public class GridColumn : Dictionary<string, string>
    {
        public GridColumn() { } 
    }


    public class Grid : Dictionary<string, GridRow>
    {
        public GridRow item;


        public Grid() { }

        public void AddItem(GridRow i)
        {
            this.Add(i.ID, i);
        }

        public void RemoveItem(GridRow i)
        {
            this.Remove(i.ID);
        }

        public void ReOrder(GridColumn gc)
        {
            Grid nGrid = new Grid();
            GridRow gi;

            foreach(KeyValuePair<string, string> kp in gc)
            {
                if (this.TryGetValue(kp.Key, out gi))
                {
                    nGrid.AddItem(gi);
                } 
            }

            this.Clear();
            
            foreach (KeyValuePair<string, GridRow> kp in nGrid)
            {
                this.Add(kp.Key, kp.Value);
            }
        }

    }

}
