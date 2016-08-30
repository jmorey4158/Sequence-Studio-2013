using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Text;


using SequenceStudio;
using SequenceStudio.Validate;



namespace SequencePowerShell
{

       public enum e_sort 
        {
            ValuesAscending = 0,
            ValuesDescending,
            KeysAscending,
            KeysDescending
        }

       public class SortMethods
       {
            public void DoSort(Dictionary<int, double> m, e_sort s)
            {

                switch (s)
                {
                    case e_sort.ValuesAscending:
                        try
                        {
                            SequenceStudio.Sort.ValuesAscending(ref m);
                        }
                        catch (SequenceStudio.SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.ValuesDescending:
                        try
                        {
                            SequenceStudio.Sort.ValuesDescending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.KeysAscending:
                        try
                        {
                            SequenceStudio.Sort.KeysAscending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.KeysDescending:
                        try
                        {
                            SequenceStudio.Sort.KeysDescending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    default:
                        SequenceException se2 = new SequenceException();
                        se2.ContextMessage = "The sort type was not recognize. The results were sorted using the default sort order.";
                        throw (se2);
                }


            }

            public void DoSort(Dictionary<int, int> m, e_sort s)
            {

                switch (s)
                {
                    case e_sort.ValuesAscending:
                        try
                        {
                            SequenceStudio.Sort.ValuesAscending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.ValuesDescending:
                        try
                        {
                            SequenceStudio.Sort.ValuesDescending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.KeysAscending:
                        try
                        {
                            SequenceStudio.Sort.KeysAscending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    case e_sort.KeysDescending:
                        try
                        {
                            SequenceStudio.Sort.KeysDescending(ref m);
                        }
                        catch (SequenceException se)
                        {
                            se.ContextMessage = "The match could not be found.";
                            throw;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        break;

                    default:
                        SequenceException se2 = new SequenceException();
                        se2.ContextMessage = "The sort type was not recognize. The results were sorted using the default sort order.";
                        throw (se2);
                }


            }
        }


		[Cmdlet(VerbsCommon.Get, "SequenceHelp")]
		public class GetSequenceHelpCmdlt : PSCmdlet
		{
			#region Membmers


			#endregion

			#region Properties


			#endregion

			#region Methods


			#endregion

			protected override void ProcessRecord()
			{
				base.ProcessRecord();
			}
		} //EMPTY



        //[Cmdlet(VerbsCommon.Get, "SourceSequences")]
        //public class GetSourceSequencesCmdlt : PSCmdlet
        //{
        //    #region Membmers

        //    private string p_SourceSequences;
        //    private int _max;
        //    private String[] l_SourceSequences;

        //    #endregion

        //    #region Properties

        //    [Alias("p")]
        //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        //    public string poly
        //    {
        //        get { return p_SourceSequences; }
        //        set { p_SourceSequences = value; }

        //    }

        //    [Alias("m")]
        //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        //    public int max
        //    {
        //        get { return _max; }
        //        set { _max = value; }

        //    }

        //    [Alias("l")]
        //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        //    public String[] sourceSequences
        //    {
        //        get { return l_SourceSequences; }
        //        set { l_SourceSequences = value; }

        //    }



        //    #endregion

        //    protected override void ProcessRecord()
        //    {
        //        try
        //        {
        //            l_SourceSequences = Generate.SourceSequences(p_SourceSequences, max);
        //            WriteObject(l_SourceSequences);
        //        }
        //        catch (SequenceException se)
        //        {
        //            se.ContextMessage = "One or more of the input parameters was not recognized.";
        //            throw;

        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
        //    }

        //}


    //    [Cmdlet(VerbsCommon.Get, "OpenReadingFrames")]
    //    public class GetOpenReadingFramesCmdlt : PSCmdlet
    //    {
    //        #region Membmers

    //        private DNA dna_seq;
    //        private List<KeyValuePair<Int32, String>> dict_orfs;

    //        #endregion

    //        #region Properties

    //        [Alias("d")]
    //        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //        public DNA dna
    //        {
    //            get { return dna_seq; }
    //            set { dna_seq = value; }
    //        }

    //        #endregion

    //        protected override void ProcessRecord()
    //        {
    //            try
    //            {
    //                dict_orfs = ORFMethods.GenerateORFs(dna_seq);
    //                WriteObject(dict_orfs);
    //            }
    //            catch (SequenceException se)
    //            {
    //                throw;
    //            }
    //            catch (Exception e)
    //            {
    //                throw;
    //            }
    //        }

    //    }

    //    [Cmdlet(VerbsCommon.Get, "ParsedFASTASequence")]
    //    public class GetParsedFASTASequenceCmdlt : PSCmdlet
    //    {
    //        #region Membmers

    //        private String s_infile;
    //        private String s_outfile;
    //        private String s_results;

    //        #endregion

    //        #region Properties

    //        [Alias("in")]
    //        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //        public String inputFile
    //        {
    //            get { return s_infile; }
    //            set { s_infile = value; }
    //        }

    //        [Alias("out")]
    //        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //        public String outputFile
    //        {
    //            get { return s_outfile; }
    //            set { s_outfile = value; }
    //        }

    //        #endregion

    //        protected override void ProcessRecord()
    //        {
    //            try
    //            {
    //                s_results = Serialize.ParseFASTA(s_infile);

    //                if (s_results != null)
    //                {
    //                    if (File.Exists(s_outfile))
    //                    {
    //                        File.Delete(s_outfile);
    //                    }
    //                    File.AppendAllText(s_outfile, s_results);

    //                    WriteObject("The file " + s_outfile + " was created.");
    //                }
    //                else
    //                {
    //                    SequenceException se_noContent = new SequenceException();
    //                    se_noContent.ContextMessage = "The FASTA file " + s_infile + " could not be found or parsed.";
    //                    throw (se_noContent);
    //                }
    //            }
    //            catch (SequenceException se)
    //            {
    //                se.ContextMessage = "The file " + s_outfile + " could not be created.";
    //                throw;
    //            }
    //            catch (Exception e)
    //            {
    //                throw;
    //            }
    //        }

    //    }

    //    [Cmdlet(VerbsCommon.Get, "SequenceFromXML")]
    //    public class GetSequenceFromXMLCmdlt : PSCmdlet
    //    {
    //        #region Membmers

    //        private String s_file;
    //        private String s_results;

    //        #endregion

    //        #region Properties

    //        [Alias("f")]
    //        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //        public String file
    //        {
    //            get { return s_file; }
    //            set { s_file = value; }
    //        }

    //        #endregion

    //        protected override void ProcessRecord()
    //        {
    //            try
    //            {

    //                s_results = Serialize.GetSequenceFromXML(s_file);

    //                if (s_results != null)
    //                {
    //                    WriteObject(s_results);
    //                }
    //                else
    //                {
    //                    SequenceException se_noContent = new SequenceException();
    //                    se_noContent.ContextMessage = "The FASTA file " + s_file + " could not be found or parsed.";
    //                    throw (se_noContent);
    //                }
    //            }
    //            catch (SequenceException se)
    //            {
    //                se.ContextMessage = "The file " + s_file + " could not be found or parsed.";
    //                throw;
    //            }
    //            catch (Exception e)
    //            {
                    
    //                throw;
    //            }
    //        }

    //    }



        //[Cmdlet(VerbsCommon.New, "NucleotideQuery")]
        //public class NewNucleotideQueryCmdlt : PSCmdlet
        //{
        //    #region Membmers

        //    private string s_organism;
        //    private string s_phrase;
        //    private Boolean b_flag;

        //    #endregion

        //    #region Properties

        //    [Alias("o")]
        //    [Parameter(Mandatory = false)]
        //    public string organsim
        //    {
        //        get { return s_organism; }
        //        set { s_organism = value; }
        //    }

        //    [Alias("p")]
        //    [Parameter(Mandatory = false)]
        //    public string phrase
        //    {
        //        get { return s_phrase; }
        //        set
        //        {
        //            s_phrase = value;
        //            s_phrase = s_phrase.Replace(" ", "+");
        //        }
        //    }


        //    #endregion

        //    protected override void ProcessRecord()
        //    {
        //        try
        //        {
        //            b_flag = false;
        //            StringBuilder sb_query = new StringBuilder();
        //            sb_query.Append(Entrez.baseTypes.baseURL);
        //            sb_query.Append("&db=nucleotide");

        //            if (s_organism != null) { sb_query.Append("&term" + s_organism + "[organism]"); b_flag = true; }
        //            if (s_phrase != null) { sb_query.Append("&term=" + s_phrase); b_flag = true; }

        //            if (b_flag == true)
        //            {
        //                WriteObject(sb_query.ToString());
        //            }
        //            else
        //            {
        //                WriteObject("The query did not cotain any elements and cannot be processed.");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
        //    }

        //}


        //[Cmdlet(VerbsCommon.New, "ProteinQuery")]
        //public class NewProteinQueryCmdlt : PSCmdlet
        //{
        //    #region Membmers

        //    private string s_organism;
        //    private string s_mol;
        //    private string s_phrase;
        //    private Boolean b_flag;

        //    #endregion

        //    #region Properties

        //    [Alias("o")]
        //    [Parameter(Mandatory = false)]
        //    public string organsim
        //    {
        //        get { return s_organism; }
        //        set { s_organism = value; }
        //    }

        //    [Alias("m")]
        //    [Parameter(Mandatory = false)]
        //    public string molweight
        //    {
        //        get { return s_mol; }
        //        set { s_mol = value; }
        //    }

        //    [Alias("p")]
        //    [Parameter(Mandatory = false)]
        //    public string phrase
        //    {
        //        get { return s_phrase; }
        //        set
        //        {
        //            s_phrase = value;
        //            s_phrase = s_phrase.Replace(" ", "+");
        //        }
        //    }


        //    #endregion

        //    protected override void ProcessRecord()
        //    {
        //        try
        //        {
        //            b_flag = false;
        //            StringBuilder sb_query = new StringBuilder();
        //            sb_query.Append(Entrez.baseTypes.baseURL);
        //            sb_query.Append("&db=protein");

        //            if (s_organism != null) { sb_query.Append("&term" + s_organism + "[organism]"); b_flag = true; }
        //            if (s_organism != null) { sb_query.Append("&term" + s_organism + "[molecular+weight]"); b_flag = true; }
        //            if (s_phrase != null) { sb_query.Append("&term=" + s_phrase); b_flag = true; }

        //            if (b_flag == true)
        //            {
        //                WriteObject(sb_query.ToString());
        //            }
        //            else
        //            {
        //                WriteObject("The query did not cotain any elements and cannot be processed.");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
        //    }
        //}

        //[Cmdlet(VerbsCommon.Get, "IDs")]
        //public class GetIDsCmdlt : PSCmdlet
        //{
        //    #region Membmers

        //    private string s_query;
        //    private string s_path;

        //    #endregion

        //    #region Properties

        //    [Alias("q")]
        //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName=true)]
        //    public string query
        //    {
        //        get { return s_query; }
        //        set { s_query = value; }
        //    }

        //    [Alias("p")]
        //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        //    public string path
        //    {
        //        get { return s_path; }
        //        set { s_path = value; }
        //    }


        //    #endregion

        //    protected override void ProcessRecord()
        //    {
        //        try
        //        {
        //            Entrez.ESearch.SaveIDAsFile(s_query, s_path);
        //            WriteObject(s_path);
        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
        //    }
        //}

}
