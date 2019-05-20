/* Ecole Supérieure de Porrentruy (EST)
 * Date : 29.04.2019
 * Auteur : Sylvain Villoz TINF1
 * Descriptif : Ce programme permet de déterminer des côtés et des angles d'un triangle à l'aide de trois valeurs.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EST___FOR___006_Triangle
{
    class Program
    {
        static int nbreCôté = 0;
        static int nbreAngles = 0;
        static readonly double[] valeurSaisies = new double[3];

        /// <summary>
        /// Point d'entrée du programme
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            do
            {
                Affichage();
                Calculer();
            } while (Nouvellesaisie());
        }

        /// <summary>
        /// Permet d'afficher le menu d'accueil
        /// </summary>
        static public void Affichage()
        {
            Console.WriteLine("Ce programme permet de déterminer des côtés et des angles d'un triangle à l'aide de trois valeurs.");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");

            int nbreSaisi = 0;
            int index = 0;

            //Saisi des valeurs
            do
            {
                Console.WriteLine("Veuillez saisir un côté ou un angle");
                Console.WriteLine("\n1: Côté");
                Console.WriteLine("2: Angle\n");

                int choixValeur = int.Parse(Console.ReadLine());

                switch (choixValeur)
                {
                    case 1:
                        Console.Write("\nVeuillez saisir un côté : ");
                        valeurSaisies[index++] = double.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        nbreSaisi++;
                        nbreCôté++;
                        break;

                    case 2:
                        Console.Write("\nVeuillez saisir un angle : ");
                        valeurSaisies[index++] = double.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        nbreSaisi++;
                        nbreAngles++;
                        break;

                    default:
                        Console.WriteLine("\nLa valeur saisie est incorrecte, veuillez réessayer.\n");
                        break;
                }

            } while (nbreSaisi < 3);
        }

        /// <summary>
        /// Cette méthode permet calculer les angles et les côtés
        /// </summary>
        static public void Calculer()
        {
            string nouvelleSaisi = "";

            //Cas 1 : S'il  y a 3 angles connus
            if (nbreAngles == 3)
            {
                Console.WriteLine("Il y a une infinité de solutions lorsqu'il y a 3 angles connus.");
            }

            //Cas 2 : S'il y a 3 côtés connus
            else if (nbreCôté == 3)
            {
                double angleAlpha = Math.Acos((Math.Pow(valeurSaisies[1], 2) + Math.Pow(valeurSaisies[2], 2) - Math.Pow(valeurSaisies[0], 2)) / (2 * valeurSaisies[1] * valeurSaisies[2])) * 180 / Math.PI;
                Console.WriteLine("Angle alpha = " + Math.Round(angleAlpha, 1) + "°");

                double angleBeta = (Math.Acos((Math.Pow(valeurSaisies[0], 2) + Math.Pow(valeurSaisies[2], 2) - Math.Pow(valeurSaisies[1], 2)) / (2 * valeurSaisies[0] * valeurSaisies[2])) * 180 / Math.PI);
                Console.WriteLine("Angle bêta = " + Math.Round(angleBeta, 1) + "°");

                double angleGamma = 180 - angleAlpha - angleBeta;
                Console.WriteLine("Angle gamma = " + Math.Round(angleGamma, 1) + "°");
            }

            //Cas 3 : s'il  y a 1 côté et 2 angles
            else if (nbreCôté == 1 && nbreAngles == 2)
            {
                double côtéB = valeurSaisies[0] * Math.Sin(valeurSaisies[2] * Math.PI / 180) / Math.Sin(valeurSaisies[1] * Math.PI / 180);
                Console.WriteLine("Côté B = " + Math.Round(côtéB, 1));

                double côtéC = côtéB * Math.Sin((180 - valeurSaisies[1] - valeurSaisies[2]) * Math.PI / 180) / Math.Sin(valeurSaisies[2] * Math.PI / 180);
                Console.WriteLine("Côté C = " + Math.Round(côtéC, 1));

                double angleGamma = 180 - valeurSaisies[1] - valeurSaisies[2];
                Console.WriteLine("Angle gamma = " + Math.Round(angleGamma, 1) + "°");
            }

            //Cas 4 : s'il y a 2 côtés et 1 angles
           else if (nbreCôté == 2 && nbreAngles == 1)
            {
                double angleBêta = (Math.Asin(valeurSaisies[1] * Math.Sin(valeurSaisies[2] * Math.PI / 180) / valeurSaisies[0])) * 180 / Math.PI;
                Console.WriteLine("Angle bêta = " + Math.Round(angleBêta, 1) + "°");

                double angleGamma = 180 - valeurSaisies[2] - angleBêta;
                Console.WriteLine("Angle gamma = " + Math.Round(angleGamma, 1) + "°");

                double côtéC = valeurSaisies[1] * Math.Sin(angleGamma * Math.PI / 180) / Math.Sin(angleBêta * Math.PI / 180);
                Console.WriteLine("Côté C = " + Math.Round(côtéC, 1));
            }
            Console.Write("\n");

            Console.Write("Voulez-vous saisir à nouveau 3 valeurs ? (o/n) ");

            nouvelleSaisi = Console.ReadLine();

            if (nouvelleSaisi == "o" || nouvelleSaisi == "O")
            {
                Affichage();
                Calculer();
            }

            Console.WriteLine("\n");
        }

        static public bool Nouvellesaisie()
        {
            Console.Write("\n");

            Console.Write("Voulez-vous saisir à nouveau 3 valeurs ? (o/n)");

            string nouvelleSaisi = Console.ReadLine();

            if (nouvelleSaisi == "o" || nouvelleSaisi == "O")

            {
                Console.WriteLine("\n");
                return true;
            }

            {
                return false;
            }
        }
    }
}


