using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "CodonCount")]
    [OutputType(typeof(Int32))]
    public class GetCodonCountCmdlt : PSCmdlet
    {
        [Alias("o")]
        [Parameter(Mandatory = true,
            ValueFromPipeline=true)]
        [ValidateSequenceObject]
        public Object Object
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private object _seqObj;

        protected override void ProcessRecord()
        {
            if (_seqObj.GetType() == typeof(DNA))
            {
                WriteObject( DnaMethods.CodonCount(  ((DNA)_seqObj).Sequence )  );
            }
            else if (_seqObj.GetType() == typeof(RNA))
            {
                WriteObject(DnaMethods.CodonCount(((RNA)_seqObj).Sequence));
            }
            else if (_seqObj.GetType() == typeof(String))
            {
                if (ValidateMethods.IsValidDna((String)_seqObj))
                {
                    WriteObject(DnaMethods.CodonCount((String)_seqObj));
                }
                else if (ValidateMethods.IsValidRna((String)_seqObj));
                {
                    WriteObject(DnaMethods.CodonCount((String)_seqObj));
                }
            }
            else
            {
                throw new SequenceException("Provide a valid DNA or RNA class instance or a DNA or RNA sequence string.");
            }
        }
    }
}
