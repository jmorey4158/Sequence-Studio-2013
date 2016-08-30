using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUtils;
using System.Xml;
using System.Net;
using System.IO;
using SequenceStudio;
using SequenceStudio.Internal.Classes;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string poly = "malwmrllpllallalwgpdpaaafvnqhlcgshlvealylvcgergffytpktrreaedlqvgqvelgggpgagslqplalegslqkrgiveqcctsicslyqlenycn";
            Poly p = new Poly(Guid.NewGuid(), "GI:386828", "AAA59172.1", "homo sapiens", "locus HUMINS01 accession J00265.1", "insulin [Homo sapiens]", poly);

            string poly2 = "msgrgkggkglgkggakrhrkvlrdniqgitkpairrlarrggvkrisgliyeetrgvlkvflenvirdavtytehakrktvtamdvvyalkrqgrtlygfgg";
            Poly p2 = new Poly(Guid.NewGuid(), "GI:32008", "CAA47464.1", "homo sapiens", "locus HUMINS01 accession J00265.1", "histone [Homo sapiens]", poly2);


            string poly3 = "msgrgkggkglgkggakrhrkvlrdniqgitkpairrlarrggvkrisgliyeetrgvlkvflenvirdavtytehakrktvtamdvvyalkrqgrtlygfgg";
            Poly p3 = new Poly(Guid.NewGuid(), "GI:34303875", "BAC82414.1", "chloroplast Plocamium telfairiae", "Rubisco small subunit, partial (chloroplast) [Plocamium telfairiae]", "Rubisco small subunit [Plocamium telfairiae]", poly3);

            string poly4 = "msgrgkggkglgkkvlrd";
            Poly p4 = new Poly(Guid.NewGuid(), "synthetic fragment", "synthetic fragment", "synthetic fragment", "synthetic fragment", "synthetic fragment", poly4);

            //Console.WriteLine(SourceSequence.GetNumberOfSourceSequenceAsString(p4));
            GridRow gi1 = new GridRow("Gi1", 10, 4, "kdlsjfskfsioufsdkjfklsdjfklsdroiesfkjsfioerfhajkheruryauihjkhfhranvjnakherfhdjhfkhfkhsdfkhaslkhf");

            GridRow gi2 = new GridRow("Gi2", 12, 5, "aaseurioasodjaeroihdkjvhautiorkjfdkgjharfgihjghlkfdhguyrtyhfnblkjdfugdhjfkjgjdfkshglkfdhgkljfdhglkhdlkgldih");

            Grid grid = new Grid();
            grid.AddItem(gi1);
            grid.AddItem(gi2);

            foreach (KeyValuePair<string, GridRow> kp in grid)
            {
                Console.WriteLine("GridItem: {0}\n{1}\n\n", kp.Key, kp.Value.ToString());
            }


            Console.ReadKey();
        }
    }
}
