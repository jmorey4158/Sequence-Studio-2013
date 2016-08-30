using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "LongestContiguousSelfMatch")]
    public class GetLongestContiguousSelfMatchCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a string")]
        [ValidateSequence]
        public string Sequence
        {
            get { return _seq; }
            set { _seq = value; }
        }
        private string _seq;


        [Alias("o")]
        [Parameter(Mandatory = true,
            ParameterSetName = "Object",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly class instance")]
        [ValidateSequenceObject]
        public Object SequenceObject
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private Object _seqObj;

        #endregion


        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (_seqObj.GetType() == typeof(DNA))
                {
                    WriteObject(Find.LongestContiguousSelfMatch(((DNA)_seqObj).Sequence));
                }
                else if (_seqObj.GetType() == typeof(RNA))
                {
                    WriteObject(Find.LongestContiguousSelfMatch(((RNA)_seqObj).Sequence));
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Makre sure the sequence to ba matched and the pattern to match agasint it are of the same sequnce type.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (ValidateMethods.IsValidDna(_seq))
                {
                    WriteObject(Find.LongestContiguousSelfMatch(_seq));
                }
                else if (ValidateMethods.IsValidRna(_seq))
                {
                    WriteObject(Find.LongestContiguousSelfMatch(_seq));
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Makre sure the sequence to ba matched and the pattern to match agasint it are of the same sequnce type.";
                    throw se;
                }
            }

            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No valid DNA sequence or DNA class instance was provided.";
                throw se;
            }
        }

    }
}
