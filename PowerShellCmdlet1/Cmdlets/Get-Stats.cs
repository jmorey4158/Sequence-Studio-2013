using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "Stats")]
    [OutputType(typeof(Dictionary<String, Int32>))]
    public class GetStatsCmdlt : PSCmdlet
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


        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (_seqObj.GetType() == typeof(DNA))
                {
                    WriteObject(DnaMethods.Stats((DNA)_seqObj));
                }
                else if (_seqObj.GetType() == typeof(RNA))
                {
                    WriteObject(RnaMethods.Stats((RNA)_seqObj));
                }
                else if (_seqObj.GetType() == typeof(Poly))
                {
                    WriteObject(PolyMethods.Stats((Poly)_seqObj));
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (ValidateMethods.IsValidDna(_seqStr))
                {
                    DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    WriteObject(DnaMethods.Stats(d));
                }
                else if (ValidateMethods.IsValidRna(_seqStr))
                {
                    RNA r = new RNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    WriteObject(RnaMethods.Stats(r));
                }
                else if (ValidateMethods.IsValidPolypeptide(_seqStr))
                {
                    Poly p = new Poly(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    WriteObject(PolyMethods.Stats(p));
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
