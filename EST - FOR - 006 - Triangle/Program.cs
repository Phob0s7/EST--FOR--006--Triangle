/* Ce programme permet de déterminer des côtés et des angles d'un triangle à l'aide de trois valeurs
 * Date : 29.04.2019
 * Auteur : Sylvain Villoz TINF1
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
        /// <summary>
        /// Point d'entrée du programme
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Affichage();
            Calculer();
        }

        static int nombreCôté = 0;
        static int nombreAngles = 0;
        static double[] valeurSaisies = new double[3];

        static public void Affichage()
        {
            // Affichage du menu
            Console.WriteLine("Ce programme permet de déterminer des côtés et des angles d'un triangle à l'aide de trois valeurs");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            int nombreSaisi = 0;
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
                        nombreSaisi++;
                        nombreCôté++;
                        break;

                    case 2:
                        Console.Write("\nVeuillez saisir un angle : ");
                        valeurSaisies[index++] = double.Parse(Console.ReadLine());
                        Console.WriteLine("\n");
                        nombreSaisi++;
                        nombreAngles++;
                        break;

                    default:
                        Console.WriteLine("\nLa valeur saisie est incorrecte, veuillez réessayer.\n");
                        break;
                }
            } while (nombreSaisi < 3);
        }

        static public void Calculer()
        {
           
            //Cas 1 : S'il  y a 3 angles connus
            if (nombreAngles == 3)
            {
                Console.WriteLine("Il y a une infinité de solutions lorsqu'il y a 3 angles connus.");
            }

            //Cas 2 : S'il y a 3 côtés connus
            if (nombreCôté == 3)
            {
                double angleAlpha = Math.Acos((Math.Pow(valeurSaisies[1],2) + Math.Pow(valeurSaisies[2],2) - Math.Pow(valeurSaisies[0],2)) / (2 * valeurSaisies[1] * valeurSaisies[2])) * 180 / Math.PI;
                Console.WriteLine("Angle alpha = " + Math.Round(angleAlpha,1) + "°");

                double angleBeta = (Math.Acos((Math.Pow(valeurSaisies[0], 2) + Math.Pow(valeurSaisies[2], 2) - Math.Pow(valeurSaisies[1], 2)) / (2 * valeurSaisies[0] * valeurSaisies[2])) * 180 / Math.PI);
                Console.WriteLine("Angle bêta = " + Math.Round(angleBeta,1) + "°");

                double angleGamma = 180 - angleAlpha - angleBeta;
                Console.WriteLine("Angle gamma = " + Math.Round(angleGamma,1) + "°");
            }

            //Cas 3 : s'il  y a 1 côté et 2 angles
            if (nombreCôté == 1 && nombreAngles == 2)
            {
                double côtéB = valeurSaisies[0] * Math.Sin(valeurSaisies[1] * Math.PI / 180) / Math.Sin(valeurSaisies[2] * Math.PI / 180);
                Console.WriteLine("Côté B = " + côtéB);

                double côtéC = côtéB * Math.Sin((180 - valeurSaisies[1] - valeurSaisies[2]) * Math.PI / 180) / Math.Sin(valeurSaisies[1] * Math.PI / 180);
                Console.WriteLine("Côté C = " + côtéC);

                double angleGamma = 180 - valeurSaisies[1] - valeurSaisies[2];
                Console.WriteLine("Angle gamma = " + angleGamma);
            }

            //Cas 4 : s'il y a 2 côtés et 1 angles
            if (nombreCôté == 2 && nombreAngles == 1)
            {
                double angleBêta = (Math.Asin(valeurSaisies[1] * Math.Sin(valeurSaisies[2] * Math.PI / 180) / valeurSaisies[0])) * 180 / Math.PI;
                Console.WriteLine("Angle bêta = " + angleBêta);

				double angleGamma = 180 - valeurSaisies[2] - angleBêta;
				Console.WriteLine("Angle gamma = " + angleGamma);

				double côtéC = valeurSaisies[1] * Math.Sin(angleGamma * Math.PI / 180) / Math.Sin(angleBêta * Math.PI / 180);
				Console.WriteLine("Côté C = " + côtéC);
            }
        }
    }
}
