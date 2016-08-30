using System;
using System.Management.Automation;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.New, "DNA")]
    public class NewDNASequenceCmdlt : PSCmdlet
    {
        #region Properties

        [ValidateDna]
        [Alias("s")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Sequence
        {
            get { return _seq; }
            set { _seq = value; }
        }
        private string _seq;


        [Alias("e")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Enumeration
        {
            get { return _enum; }
            set { _enum = value; }
        }
        private string _enum;


        [Alias("a")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Accession   
        {
            get { return _acc; }
            set { _acc = value; }
        }
        private string _acc;


        [Alias("0")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Organism   
        {
            get { return _org; }
            set { _org = value; }
        }
        private string _org;


        [ValidateDna]
        [Alias("l")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Locus
        {
            get { return _loc; }
            set { _loc = value; }
        }
        private string _loc;


        [ValidateDna]
        [Alias("d")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        private string _desc;

        #endregion


        protected override void BeginProcessing()
        {
            if (String.IsNullOrEmpty(_enum)) {_enum = "";};
            if (String.IsNullOrEmpty(_acc)) {_acc = "";};
            if (String.IsNullOrEmpty(_org)) {_org = "";};
            if (String.IsNullOrEmpty(_loc)) {_loc = "";};
            if (String.IsNullOrEmpty(_desc)) {_desc = "";};
        }

        protected override void ProcessRecord()
        {
             WriteObject(new DNA(Guid.NewGuid(), _enum, _acc, _org, _loc, _desc, _seq));
        }

    }

}
