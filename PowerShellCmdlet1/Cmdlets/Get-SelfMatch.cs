using System;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;


using SequenceStudio;
using SequenceStudio.Validate;


namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "SelfMatch")]
    public class GetSelfMatchSetCmdlt : PSCmdlet
    {
        #region Membmers

        private string s_SelfMatchSet;
        private double t_SelfMatchSet;
        private Dictionary<int, int> m_SelfMatchSet;

        #endregion

        #region Properties


        [Alias("s")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateDna]
        public string sequence
        {
            get { return s_SelfMatchSet; }
            set { s_SelfMatchSet = value; }

        }

        [Alias("t")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateThreshold]
        public double threshold
        {
            get { return t_SelfMatchSet; }
            set { t_SelfMatchSet = value; }
        }

        #endregion

        protected override void ProcessRecord()
        {
            try
            {
                m_SelfMatchSet = SequenceStudio.Find.SelfMatchRegion(s_SelfMatchSet, t_SelfMatchSet);
                if (m_SelfMatchSet.Count > 0)
                {
                    WriteObject(m_SelfMatchSet);
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "No matches were found.";
                    throw se;
                }
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

    }
}
