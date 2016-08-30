using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.New, "PrimeSeries")]
    public class NewPrimeSeriesCmdlt : PSCmdlet
    {

        [Alias("l")]
        [Parameter(Mandatory = true)]
        public Int32 limit
        {
            get { return _lim; }
            set { _lim = value; }

        }
        private int _lim;

        protected override void ProcessRecord()
        {
            WriteObject(SequenceStudio.Math.PrimeSeries(_lim));
        }
    }
}
