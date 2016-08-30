using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "MolWeight")]
    [OutputType(typeof(Double))]
    public class GetMolWeightCmdlt : PSCmdlet
    {
        [Alias("o")]
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly class instance or sequence")]
        [ValidateSequenceObject]
        public Object SequenceObject
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private Object _seqObj;


        protected override void ProcessRecord()
        {
            if (_seqObj.GetType() == typeof(DNA))
            {
                WriteObject(DnaMethods.MolWeight((DNA)_seqObj));
            }
            else if (_seqObj.GetType() == typeof(RNA))
            {
                WriteObject(RnaMethods.MolWeight((RNA)_seqObj));
            }
            else if (_seqObj.GetType() == typeof(Poly))
            {
                WriteObject(PolyMethods.MolWeight((Poly)_seqObj));
            }
            else if (_seqObj.GetType() == typeof(String))
            {
                if (ValidateMethods.IsValidDna(_seqObj.ToString()))
                {
                    DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", _seqObj.ToString());
                    WriteObject(DnaMethods.MolWeight(d));
                }
                else if (ValidateMethods.IsValidRna(_seqObj.ToString()))
                {
                    RNA r = new RNA(Guid.NewGuid(), "", "", "", "", "", _seqObj.ToString());
                    WriteObject(RnaMethods.MolWeight(r));
                }
                else if (ValidateMethods.IsValidPolypeptide(_seqObj.ToString()))
                {
                    Poly p = new Poly(Guid.NewGuid(), "", "", "", "", "", _seqObj.ToString());
                    WriteObject(PolyMethods.MolWeight(p));
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
