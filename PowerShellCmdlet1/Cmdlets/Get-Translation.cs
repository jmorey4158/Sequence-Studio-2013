using System;
using System.Management.Automation;
using System.Collections.Generic;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "Translation")]
    public class GetTranslationCmdlt : PSCmdlet
    {
        #region Membmers


        private string _trans;

        #endregion

        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            HelpMessage = "Enter a valid DNA, RNA, or Polypeptide sequence as a string")]
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



        [Alias("p")]
        [Parameter(Mandatory = false,
            HelpMessage = "Makes the cmdlet to produce a Poly class instance rather than a string.")]
        [ValidateSequenceObject]
        public SwitchParameter AsPoly
        {
            get { return _asPoly; }
            set { _asPoly = value; }
        }
        private bool _asPoly;


        #endregion

        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if (_seqObj.GetType() == typeof(DNA))
                {
                    _trans = DnaMethods.Translate((DNA)_seqObj);
                }
                else if (_seqObj.GetType() == typeof(RNA))
                {
                    _trans = DnaMethods.Translate(RnaMethods.ReverseTranscribe((RNA)_seqObj));
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if (ValidateMethods.IsValidDna(_seqStr))
                {
                    DNA d = new DNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    _trans = DnaMethods.Translate(d);
                }
                else if (ValidateMethods.IsValidRna(_seqStr))
                {
                    RNA r = new RNA(Guid.NewGuid(), "", "", "", "", "", _seqStr);
                    _trans = DnaMethods.Translate(RnaMethods.ReverseTranscribe(r));
                }
            }
            else
            {
                SequenceException se = new SequenceException();
                se.ContextMessage = "No valid sequence or DNA or RNA class instance was provided.";
                throw se;
            }


            if (_asPoly)
            {
                Poly p = new Poly(Guid.NewGuid(),"","","","","",_trans);
                WriteObject(p);
            }
            else
            {
                WriteObject(_trans);
            }


        }

    }
}
