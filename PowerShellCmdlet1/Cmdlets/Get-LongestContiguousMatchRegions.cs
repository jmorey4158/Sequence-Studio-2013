﻿using System.Collections.Generic;
using System.Management.Automation;

using SequenceStudio;
using SequenceStudio.Validate;
using System;

namespace SequencePowerShell
{
    [Cmdlet(VerbsCommon.Get, "LongestContiguousMatchRegions")]
    public class GetLongestContiguousMatchRegionsCmdlt : PSCmdlet
    {
        #region Properties

        [Alias("s")]
        [Parameter(Mandatory = true,
            ParameterSetName = "String",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a string")]
        [ValidateSequence]
        public string Sequence
        {
            get { return _seq; }
            set { _seq = value; }
        }
        private string _seq;


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
        [Parameter(Mandatory = true,
            HelpMessage = "Provide a valid DNA, RNA, or Poly sequence as a pattern to match agaisnt")]
        [ValidateSequence]
        public string Pattern
        {
            get { return _patt; }
            set { _patt = value; }

        }
        private string _patt;

        #endregion


        private Dictionary<int, int> _results;


        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Object")
            {
                if ((_seqObj.GetType() == typeof(DNA)) && (ValidateMethods.IsValidDna(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(((DNA)_seqObj).Sequence, _patt);
                }
                else if ((_seqObj.GetType() == typeof(RNA)) && (ValidateMethods.IsValidRna(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(((RNA)_seqObj).Sequence, _patt);
                }
                else if ((_seqObj.GetType() == typeof(Poly)) && (ValidateMethods.IsValidPolypeptide(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(((Poly)_seqObj).Sequence, _patt);
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Makre sure the sequence to ba matched and the pattern to match agasint it are of the same sequnce type.";
                    throw se;
                }
            }
            else if (this.ParameterSetName == "String")
            {
                if ((ValidateMethods.IsValidDna(_seq)) && (ValidateMethods.IsValidDna(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(_seq, _patt);
                }
                else if ((ValidateMethods.IsValidRna(_seq)) && (ValidateMethods.IsValidRna(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(_seq, _patt);
                }
                else if ((ValidateMethods.IsValidPolypeptide(_seq)) && (ValidateMethods.IsValidPolypeptide(_patt)))
                {
                    _results = Find.LongestContiguousMatchRegions(_seq, _patt);
                }
                else
                {
                    SequenceException se = new SequenceException();
                    se.ContextMessage = "Makre sure the sequence to ba matched and the pattern to match agasint it are of the same sequnce type.";
                    throw se;
                }
            }

            WriteObject(_results);
        }
    }
}