using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "MatchArray")]
    public class GetMatchArrayCmdlt : PSCmdlet
    {
        #region Membmers

        private string s_MatchArray;
        private Dictionary<int, string> sa_MatchArray;
        private Dictionary<int, int> d_MatchArray;

        #endregion

        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateDna]
        public string sequence
        {
            get { return s_MatchArray; }
            set { s_MatchArray = value; }
        }

        [Alias("a")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Dictionary<int, int> matchArray
        {
            get { return d_MatchArray; }
            set { d_MatchArray = value; }
        }


        #endregion

        protected override void ProcessRecord()
        {
            if (d_MatchArray.Count != 0)
            {
                try
                {
                    sa_MatchArray = SequenceStudio.Find.MatchGrid(d_MatchArray, sequence);
                    WriteObject(sa_MatchArray);
                }
                catch (SequenceException se)
                {
                    se.ContextMessage = "One or more of the input parameters was not recognized.";
                    throw;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                SequenceException se_zero = new SequenceException();
                se_zero.ContextMessage = "No matches were found in the matchSet provided.";
                throw (se_zero);
            }
        }

    }
}
