using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "MatchSequences")]
    public class GetMatchSequencesCmdlt : PSCmdlet
    {
        #region Properties


        [Alias("s1")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a string")]
        [ValidateSequence]
        public string Sequence1
        {
            get { return _seq1; }
            set { _seq1 = value; }
        }
        private string _seq1;


        [Alias("o1")]
        [Parameter(Mandatory = true,
            ParameterSetName = "Object",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly class instance")]
        [ValidateSequenceObject]
        public Object SequenceObject
        {
            get { return _seqObj1; }
            set { _seqObj1 = value; }
        }
        private Object _seqObj1;


        [Alias("s2")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a string")]
        [ValidateSequence]
        public string Sequence2
        {
            get { return _seq2; }
            set { _seq2 = value; }
        }
        private string _seq2;


        [Alias("o2")]
        [Parameter(Mandatory = true,
            ParameterSetName = "Object",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly class instance")]
        [ValidateSequenceObject]
        public Object SequenceObject2
        {
            get { return _seqObj2; }
            set { _seqObj2 = value; }
        }
        private Object _seqObj2;


        [Alias("t")]
        [Parameter(Mandatory = true,
            HelpMessage = "PRovide a minimum match percentage.")]
        [ValidateThreshold]
        public Double Threshold
        {
            get { return _thresh; }
            set { _thresh = value; }
        }
        private Double _thresh;

        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (  (_seqObj1.GetType() == typeof(DNA))   &&   (_seqObj2.GetType() == typeof(DNA))  )
                {
                    WriteObject(Find.MatchSequences( ((DNA)_seqObj1).Sequence, ((DNA)_seqObj2).Sequence, _thresh));
                }
                else if  (  (_seqObj1.GetType() == typeof(RNA))   &&   (_seqObj2.GetType() == typeof(RNA))  )
                {
                    WriteObject(Find.MatchSequences( ((RNA)_seqObj1).Sequence, ((RNA)_seqObj2).Sequence, _thresh));
                }
                else if  (  (_seqObj1.GetType() == typeof(Poly))   &&   (_seqObj2.GetType() == typeof(Poly))  )
                {
                    WriteObject(Find.MatchSequences( ((Poly)_seqObj1).Sequence, ((Poly)_seqObj2).Sequence, _thresh));
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Make sure the sequence to ba matched and the pattern to match agasint it are of the same sequnce type.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (  (ValidateMethods.IsValidDna(_seq1)) &&   (ValidateMethods.IsValidDna(_seq2))  )
                {
                    WriteObject(Find.MatchSequences(_seq1, _seq2, _thresh));
                }
                else if (  (ValidateMethods.IsValidRna(_seq1)) &&   (ValidateMethods.IsValidRna(_seq2))  )
                {
                    WriteObject(Find.MatchSequences(_seq1, _seq2, _thresh));
                }
                else if (  (ValidateMethods.IsValidPolypeptide(_seq1)) &&   (ValidateMethods.IsValidPolypeptide(_seq2))  )
                {
                    WriteObject(Find.MatchSequences(_seq1, _seq2, _thresh));
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
