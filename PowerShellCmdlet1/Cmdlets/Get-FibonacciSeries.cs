using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.New, "FibonacciSeries")]
    public class NewFibonacciSeriesCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("l")]
        [Parameter(Mandatory = true, 
            HelpMessage="Enter an integer that defines the largest number in the series.")]
        public Int32 limit
        {
            get { return _lim; }
            set { _lim = System.Math.Abs(value); } //if we don't do this it might be a negative number. Not good.
        }
        private int _lim;

        #endregion

        protected override void ProcessRecord()
        {
            WriteObject(SequenceStudio.Math.FibonacciSeries(_lim));
        }
    }
}
