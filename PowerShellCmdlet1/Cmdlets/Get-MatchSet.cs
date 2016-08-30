using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "MatchSet")]
    public class GetMatchSetCmdlt : PSCmdlet
    {

        #region Properties


        [Alias("o1")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly class instance")]
        [ValidateSequenceObject]
        public Object SequenceObject
        {
            get { return _seqObj1; }
            set { _seqObj1 = value; }
        }
        private Object _seqObj1;


        [Alias("o2")]
        [Parameter(Mandatory = true,
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
            HelpMessage = "Provide a minimum match percentage.")]
        [ValidateThreshold]
        public Double Threshold
        {
            get { return _thresh; }
            set { _thresh = value; }
        }

        #endregion


        private Double _thresh;
        private string _thisSeq1;
        private string _thisSeq2;

        protected override void ProcessRecord()
        {
            if ((_seqObj1.GetType() == typeof(DNA)) && (_seqObj2.GetType() == typeof(DNA)))
            {
                _thisSeq1 = ((DNA)_seqObj1).Sequence;
                _thisSeq2 = ((DNA)_seqObj2).Sequence;
            }
            else if ((_seqObj1.GetType() == typeof(RNA)) && (_seqObj2.GetType() == typeof(RNA)))
            {
                _thisSeq1 = ((RNA)_seqObj1).Sequence;
                _thisSeq2 = ((RNA)_seqObj2).Sequence;
            }
            else if ((_seqObj1.GetType() == typeof(Poly)) && (_seqObj2.GetType() == typeof(Poly)))
            {
                _thisSeq1 = ((Poly)_seqObj1).Sequence;
                _thisSeq2 = ((Poly)_seqObj2).Sequence;
            }
            else if ((_seqObj1.GetType() == typeof(String)) && (_seqObj2.GetType() == typeof(String)))
            {
                if ((ValidateMethods.IsValidDna(_seqObj1.ToString())) &&
                    (ValidateMethods.IsValidDna(_seqObj2.ToString())))
                {
                    _thisSeq1 = _seqObj1.ToString();
                    _thisSeq2 = _seqObj2.ToString();
                }
                else if ((ValidateMethods.IsValidRna(_seqObj1.ToString())) &&
                    (ValidateMethods.IsValidRna(_seqObj2.ToString())))
                {
                    _thisSeq1 = _seqObj1.ToString();
                    _thisSeq2 = _seqObj2.ToString();
                }
                else if ((ValidateMethods.IsValidPolypeptide(_seqObj1.ToString())) &&
                    (ValidateMethods.IsValidPolypeptide(_seqObj2.ToString())))
                {
                    _thisSeq1 = _seqObj1.ToString();
                    _thisSeq2 = _seqObj2.ToString();
                }
            }
            WriteObject(Find.MatchSet(_thisSeq1, _thisSeq2, _thresh));
        }
    }
}
