using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_VigenereEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Source : https://www.dcode.fr/chiffre-vigenere

            Console.Write("Quel est le texte à coder/décoder ? ");
            string texteClair = Console.ReadLine().ToUpper();

            Console.Write("Quel est le décalage ? ");
            int decalage = int.Parse(Console.ReadLine());

            Console.Write("Quel est la clé ? ");
            string cle = Console.ReadLine().ToUpper();

            string texteCode = vigenere(texteClair, decalage, cle);
            Console.WriteLine($"Texte codé : {texteCode}");

            string texteCodeInverse = vigenere(texteClair, decalage, cle, false);
            Console.WriteLine($"Texte décodé : {texteCodeInverse}");

            Console.ReadLine();
        }

        static string vigenere(string texte, int decalage, string cle, bool encode = true)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int nbCarac = alphabet.Length;
            string texteCode = "";
            int idCle = 0;
            foreach (char car in texte)
            {
                if (car != ' ')
                {
                    int posFinale = 0;
                    int posDeCle = 0;
                    int posDeTexte = alphabet.IndexOf(car);

                    if (string.IsNullOrEmpty(cle) && cle != "")
                    {
                        posDeCle = alphabet.IndexOf(cle[idCle]);
                    }

                    if (encode)
                    {
                        posFinale = mod((posDeTexte + decalage + posDeCle), nbCarac);
                    }
                    else
                    {
                        posFinale = mod((posDeTexte - decalage - posDeCle), nbCarac);
                    }
                    texteCode += alphabet[posFinale];

                    idCle++;
                    if (idCle >= cle.Length)
                    {
                        idCle = 0;
                    }
                }
            }

            return formatOutput(texteCode, 5);
        }

        static string formatOutput(string texte, int regroupement)
        {
            string output = "";
            int cpt = 0;
            foreach (char c in texte)
            {
                output += c;
                cpt++;
                if (cpt >= regroupement)
                {
                    output += " ";
                    cpt = 0;
                }
            }

            return output;
        }

        // remplace le modulo "%" qui ne prend pas en compte les nombres négatifs...
        static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
