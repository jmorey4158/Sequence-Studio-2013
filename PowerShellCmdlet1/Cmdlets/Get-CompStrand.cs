using System;
using System.Management.Automation;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "CompStrand")]
    public class GetCompStrandCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "String",
            HelpMessage = "Enter a valid DNA, RNA, or Polypeptide sequence")]
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
            HelpMessage = "Provide a valid DNA or RNA class instance")]
        [ValidateSequenceObject]
        public Object SequenceObject
        {
            get { return _seqObj; }
            set { _seqObj = value; }
        }
        private Object _seqObj;


        [Alias("rev")]
        [Parameter(Mandatory = false)]
        public SwitchParameter ReverseStrand
        {
            get { return _rev; }
            set { _rev = value; }
        }
        private bool _rev;


        #endregion

        protected override void ProcessRecord()
        {
            if (ReverseStrand)
            {
                if (this.ParameterSetName == "Object")
                {
                    if (_seqObj.GetType() == typeof(DNA))
                    {
                        WriteObject(DnaMethods.ReverseCompStrand((DNA)_seqObj));
                    }
                    else if (_seqObj.GetType() == typeof(RNA))
                    {
                        WriteObject(RnaMethods.ReverseCompStrand((RNA)_seqObj));
                    }
                    else if (_seqObj.GetType() == typeof(Poly))
                    {
                        SequenceException se = new SequenceException();
                        se.ContextMessage = "No valid sequence or DNA or RNA class instance was provided.";
                        throw se;
                    }
                }
                else
                {
                    if (ValidateMethods.IsValidDna(_seqStr))
                    {
                        DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                        WriteObject(DnaMethods.ReverseCompStrand(d));
                    }
                    else if (ValidateMethods.IsValidRna(_seqStr))
                    {
                        RNA r = new RNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                        WriteObject(RnaMethods.ReverseCompStrand(r));
                    }
                    else if (ValidateMethods.IsValidPolypeptide(_seqStr))
                    {
                        SequenceException se = new SequenceException();
                        se.ContextMessage = "No valid sequence or DNA or RNA class instance was provided.";
                        throw se;
                    }
                }
            }
            else
            {
                if (this.ParameterSetName == "Object")
                {
                    if (_seqObj.GetType() == typeof(DNA))
                    {
                        WriteObject(DnaMethods.ReverseCompStrand((DNA)_seqObj));
                    }
                    else if (_seqObj.GetType() == typeof(RNA))
                    {
                        WriteObject(RnaMethods.ReverseCompStrand((RNA)_seqObj));
                    }
                    else if (_seqObj.GetType() == typeof(Poly))
                    {
                        SequenceException se = new SequenceException();
                        se.ContextMessage = "No valid sequence or DNA or RNA class instance was provided.";
                        throw se;
                    }
                }
                else
                {
                    if (ValidateMethods.IsValidDna(_seqStr))
                    {
                        DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                        WriteObject(DnaMethods.ReverseCompStrand(d));
                    }
                    else if (ValidateMethods.IsValidRna(_seqStr))
                    {
                        RNA r = new RNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                        WriteObject(RnaMethods.ReverseCompStrand(r));
                    }
                    else if (ValidateMethods.IsValidPolypeptide(_seqStr))
                    {
                        SequenceException se = new SequenceException();
                        se.ContextMessage = "No valid sequence or DNA or RNA class instance was provided.";
                        throw se;
                    }
                }
            }
        }

    }
}
