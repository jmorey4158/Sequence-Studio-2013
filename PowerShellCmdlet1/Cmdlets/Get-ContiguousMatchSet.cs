using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "ContiguousMatchSet")]
    public class GetContiguousMatchSetCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            HelpMessage = "Enter a valid DNA, RNA, or Polypeptide sequence string")]
        [ValidateSequence]
        public string Sequence
        {
            get { return _seqStr; }
            set { _seqStr = value; }
        }
        private string _seqStr;


        [Alias("s")]
        [Parameter(Mandatory = true,
            HelpMessage = "Enter a valid DNA, RNA, or Polypeptide sequence string to match")]
        [ValidateSequence]
        public string Pattern
        {
            get { return _patt; }
            set { _patt = value; }
        }
        private string _patt;


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


        [Alias("t")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateThreshold]
        public double threshold
        {
            get { return _thres; }
            set { _thres = value; }

        }
        private double _thres;

        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if ((_seqObj.GetType() == typeof(DNA)) && (ValidateMethods.IsValidDna(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(((DNA)_seqObj).Sequence, _patt, _thres));
                }
                if ((_seqObj.GetType() == typeof(RNA)) && (ValidateMethods.IsValidRna(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(((RNA)_seqObj).Sequence, _patt, _thres));
                }
                if ((_seqObj.GetType() == typeof(Poly)) && (ValidateMethods.IsValidPolypeptide(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(((Poly)_seqObj).Sequence, _patt, _thres));
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
                if ((ValidateMethods.IsValidDna(_seqStr)) && (ValidateMethods.IsValidDna(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(_seqStr, _patt, _thres));
                }
                if ((ValidateMethods.IsValidRna(_seqStr)) && (ValidateMethods.IsValidRna(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(_seqStr, _patt, _thres));
                }
                if ((ValidateMethods.IsValidPolypeptide(_seqStr)) && (ValidateMethods.IsValidPolypeptide(_patt)))
                {
                    WriteObject(Find.ContiguousMatchRegions(_seqStr, _patt, _thres));
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
