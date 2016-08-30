using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "ConsensusSourceSequence")]
    public class GetConsensusSourceSequenceCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            HelpMessage = "Enter a valid Polypeptide sequence string")]
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
            HelpMessage = "Provide a valid Poly class instance")]
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
                if (_seqObj.GetType() == typeof(Poly))
                {
                    WriteObject(PolyMethods.ConsensusSourceSequence( (Poly)_seqObj));
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "No valid sequence or DNA, RNA, or Poly class instance was provided.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (ValidateMethods.IsValidPolypeptide(_seqStr))
                {
                    Poly p = new Poly(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    WriteObject(PolyMethods.ConsensusSourceSequence(p));
                }
                else
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
