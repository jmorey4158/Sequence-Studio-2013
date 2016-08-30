using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "CodonMatrix")]
    public class GetCodonMatrixCmdlt : PSCmdlet
    {
        #region Membmers

        private string s_sequence;
        private DNA d_dna;

        #endregion

        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "String")]
        [ValidateSequence]
        public string Sequence
        {
            get { return _seqStr; }
            set { _seqStr = value; }
        }
        private string _seqStr;


        [Alias("o")]
        [Parameter(Mandatory = true, 
            ParameterSetName = "Object")]
        [ValidateSequenceObject]
        public Object Object
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private object _seqObj;

        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (_seqObj.GetType() == typeof(DNA))
                {
                    WriteObject( DnaMethods.CodonMatrix(  ((DNA)_seqObj).Sequence )  );
                }
                else if (_seqObj.GetType() == typeof(RNA))
                {
                    WriteObject(DnaMethods.CodonMatrix(((RNA)_seqObj).Sequence));
                }
                else if (_seqObj.GetType() == typeof(Poly))
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "No valid sequence or DNA, RNA, or Poly class instance was provided.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (ValidateMethods.IsValidDna(_seqStr))
                {
                    WriteObject(DnaMethods.CodonMatrix(_seqStr));
                }
                else if (ValidateMethods.IsValidRna(_seqStr))
                {
                    WriteObject(DnaMethods.CodonMatrix(_seqStr));
                }
                else if (ValidateMethods.IsValidPolypeptide(_seqStr))
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "No valid sequence or DNA, RNA, or Poly class instance was provided.";
                    throw se;
                }
            }

            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No valid sequence or DNA, RNA, or Poly class instance was provided.";
                throw se;
            }
        }
    }
}
