using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsDiagnostic.Test, "IsPrime")]
    public class GetIsPrimeCmdlt : PSCmdlet
    {

        [Alias("n")]
        [Parameter(Mandatory = true)]
        public int number
        {
            get { return _num; }
            set { _num = System.Math.Abs(value); }

        }
        private int _num;


        protected override void ProcessRecord()
        {
            WriteObject(SequenceStudio.Math.IsPrime(number));
        }
    }
}
