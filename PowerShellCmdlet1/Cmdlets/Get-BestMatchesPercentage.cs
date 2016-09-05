using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "BestMatchesPercentage")]
    public class GetBestMatchesPercentageCmdlt : PSCmdlet
    {
        #region Parameters

        [Alias("s")]
        [Parameter(Mandatory = true, 
            ParameterSetName="String",
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



        [Alias("p")]
        [Parameter(Mandatory = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a pattern to match against")]
        [ValidateSequence]
        public string Pattern
        {
            get { return _patt; }
            set { _patt = value; }

        }
        private string _patt;

        #endregion

        private string _results;
        private string _pattern;

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (  (_seqObj.GetType() == typeof(DNA))   &&   (ValidateMethods.IsValidDna(_patt))  )
                {
                    _results = ((DNA)_seqObj).Sequence;
                    _pattern = _patt;
                }
                else if (  (_seqObj.GetType() == typeof(RNA))   &&   (ValidateMethods.IsValidRna(_patt))  )
                {
                    _results = ((RNA)_seqObj).Sequence;
                    _pattern = _patt;
                }
                else if (  (_seqObj.GetType() == typeof(Poly))   &&   (ValidateMethods.IsValidPolypeptide(_patt))  )
                {
                    _results = ((Poly)_seqObj).Sequence;
                    _pattern = _patt;
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Make sure the sequence to be matched and the pattern to match against it are of the same sequence type.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (  (ValidateMethods.IsValidDna(_seq)) &&   (ValidateMethods.IsValidDna(_patt))  )
                {
                    _results = _seq;
                    _pattern = _patt;
                }
                else if (  (ValidateMethods.IsValidRna(_seq)) &&   (ValidateMethods.IsValidRna(_patt))  )
                {
                    _results = _seq;
                    _pattern = _patt;
                }
                else if (  (ValidateMethods.IsValidPolypeptide(_seq))  &&  (ValidateMethods.IsValidPolypeptide(_patt)) )
                {
                    _results = _seq;
                    _pattern = _patt;
                }
                else 
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Make sure the sequence to be matched and the pattern to match against it are of the same sequence type.";
                    throw se;
                }
            }

            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No valid DNA sequence or DNA class instance was provided.";
                throw se;
            }

            WriteObject(Find.BestMatchesPercentage(_results, _pattern));
        }

    }
}
