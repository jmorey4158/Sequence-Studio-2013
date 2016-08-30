using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.New, "RandomStrand")]
    public class NewRandomStrandCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("n")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 length
        {
            get { return _len; }
            set { _len = value; }
        }
        private int _len;


        [Alias("t")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateStrandType]
        public String type
        {
            get { return _type.ToUpper(); }
            set { _type = value.ToUpper(); }
        }
        private string _type;


        #endregion

        protected override void ProcessRecord()
        {
            switch (_type)
            {
                case "DNA":
                    WriteObject(DnaMethods.GenerateRandomStrand(_len));
                    break;

                case "RNA":
                    WriteObject(RnaMethods.GenerateRandomStrand(_len));
                    break;


                case "POLYPEPTIDE":
                    WriteObject(PolyMethods.GenerateRandomStrand(_len));
                    break;

                default:
                    throw new SequenceException("The 'type' must be DNA, RNA, or POLYPEPTIDE.");
            }
        }

    }
}
