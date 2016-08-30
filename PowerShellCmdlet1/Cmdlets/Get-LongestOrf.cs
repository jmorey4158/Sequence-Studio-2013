using System;
using System.Management.Automation;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "LongestOrf")]
    public class GetLongestOrfCmdlt : PSCmdlet
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


        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                WriteObject(ORFMethods.GetLongestORF((DNA)_seqObj));
            }
            else if (this.ParameterSetName == "String")
            {

                WriteObject(ORFMethods.GetLongestORF(new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr)));
            }
        }

    }
}
