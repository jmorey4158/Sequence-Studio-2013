using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio.Internal
{
    public static class NcbiConstants
    {

        public const string baseESearchUrl = "http://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi?";
        public const string eSearchResult = "<eSearchResult><Count></Count><RetMax></RetMax><RetStart></RetStart><IdList></IdList><TranslationSet/><TranslationStack><TermSet><Term></Term><Field></Field><Count></Count><Explode>N</Explode></TermSet><OP></OP></TranslationStack><QueryTranslation></QueryTranslation></eSearchResult>";


        public const string db_nuccore = "nuccore";
        public const string db_gene = "gene";
        public const string db_genome = "genome";
        public const string db_protein = "protein";










    }
}
