using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "PrimePattern")]
    public class GetPrimePatternCmdlt : PSCmdlet
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


        [Alias("l")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 limit
        {
            get { return _lim; }
            set { _lim = value; }
        }
        private int _lim;

        #endregion

        protected override void ProcessRecord()
        {
            StringBuilder _sb = new StringBuilder();

            if (this.ParameterSetName == "Object")
            {
                if (_seqObj.GetType() == typeof(DNA))
                {
                    SequenceStudio.Math.PrimePattern(((DNA)_seqObj).Sequence, _lim, ref _sb);
                }
                else if (_seqObj.GetType() == typeof(RNA))
                {
                    SequenceStudio.Math.PrimePattern(((RNA)_seqObj).Sequence, _lim, ref _sb);
                }
                else if (_seqObj.GetType() == typeof(Poly))
                {
                    SequenceStudio.Math.PrimePattern(((Poly)_seqObj).Sequence, _lim, ref _sb);
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
                SequenceStudio.Math.PrimePattern(_seqStr, _lim, ref _sb);
            }

            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No valid DNA sequence or DNA class instance was provided.";
                throw se;
            }

            WriteObject(_sb);
        }
    }
}
