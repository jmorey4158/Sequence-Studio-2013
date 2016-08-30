using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "MolWeight_OLD")]
    public class GetMolWeight_OLDCmdlt : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Sequence
        {
            get { return s_sequence; }
            set { s_sequence = value; }
        }
        private string s_sequence;

        protected override void ProcessRecord()
        {
            if (String.IsNullOrEmpty(s_sequence))
            {
                try
                {
                    DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", s_sequence);
                    WriteObject(DnaMethods.MolWeight(d));
                }
                catch (SequenceParameterException pe)
                {
                   throw pe;
                }
            }
            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No sequence or DNA instance was provided.";
                throw se;
            }
        }
    }
}
