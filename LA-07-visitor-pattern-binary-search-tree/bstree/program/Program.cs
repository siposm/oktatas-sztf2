using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{



    class Program
    {
        static void Main(string[] args)
        {

            BinarisKeresoFa<string> bst = new BinarisKeresoFa<string>();

            bst.Beszuras(21,    "Tony Stark"    );
            bst.Beszuras(2234,  "Batman"        );
            bst.Beszuras(2,     "Two Face"      );
            bst.Beszuras(5,     "Joker"         );
            bst.Beszuras(4,     "Hulk"          );

            Console.WriteLine("\nPREORDER\n");
            bst.Bejaras(BejarasTipus.preorder);

            Console.WriteLine("\nINORDER\n");
            bst.Bejaras(BejarasTipus.inorder);

            Console.WriteLine("\nPOSTORDER\n");
            bst.Bejaras(BejarasTipus.postorder);


            Console.WriteLine("================================================");

            
            BinarisKeresoFa_genKulcs<string, int> bst2 = new BinarisKeresoFa_genKulcs<string, int>();

            bst2.Beszuras(21, "Tony Stark");
            bst2.Beszuras(2234, "Batman");
            bst2.Beszuras(2, "Two Face");
            bst2.Beszuras(5, "Joker");
            bst2.Beszuras(4, "Hulk");

            Console.WriteLine("\nPREORDER\n");
            bst2.Bejaras(BejarasTipus.preorder);

            Console.WriteLine("\nINORDER\n");
            bst2.Bejaras(BejarasTipus.inorder);

            Console.WriteLine("\nPOSTORDER\n");
            bst2.Bejaras(BejarasTipus.postorder);



            
            // bináris keresőfa, melyben egy elem egy (n elemű) láncolt lista (amely telefonokat tartalmaz)

            BinarisKeresoFa_genKulcs<LancoltLista<Telefon>, int> bst3 = new BinarisKeresoFa_genKulcs<LancoltLista<Telefon>, int>();

            LancoltLista<Telefon> telefonLista = new LancoltLista<Telefon>();
            telefonLista.ElejereBeszuras(new Telefon() { Marka = "Nokia" });
            telefonLista.ElejereBeszuras(new Telefon() { Marka = "Samsung" });
            telefonLista.ElejereBeszuras(new Telefon() { Marka = "Motorola" });

            bst3.Beszuras(23, telefonLista);


            // *********************************
            //
            // HÁZI FELADAT
            //
            // ADOTT KULCSÚ LISTÁT KIKERESNI A FÁBÓL, AMELY A TELJES LISTÁT VISSZAADJA
            // EHHEZ A LISTÁHOZ ÍGY ÚJRA HOZZÁ TUDUNK ADNI / EL TUDUNK VENNI ELEMET
            //
            // *********************************




            Console.ReadLine();
        }
    }
}
