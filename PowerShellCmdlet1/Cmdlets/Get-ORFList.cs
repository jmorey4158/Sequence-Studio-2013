using System;
using System.Management.Automation;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "OrfList")]
    public class GetOrfListCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            HelpMessage = "Enter a valid DNA, RNA, or Polypeptide sequence")]
        [ValidateDna]
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
            HelpMessage = "Provide a valid DNA or RNA class instance")]
        public DNA SequenceObject
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private DNA _seqObj;


        [Alias("l")]
        [Parameter(Mandatory = true,
            HelpMessage = "Provide a valid DNA or RNA class instance")]
        public int MinLength
        {
            get { return _len; }
            set { _len = System.Math.Abs(value); }
        }
        private int _len;


        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                WriteObject(new OpenReadingFrames((DNA)_seqObj, _len));
            }
            else if (this.ParameterSetName == "String")
            {
                WriteObject(new OpenReadingFrames(new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr), _len));
            }
        }

    }
}
