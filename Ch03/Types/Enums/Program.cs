using System;
using System.IO;

namespace Enums
{
    class Program
    {
        static void Main()
        {
            var porridge = new Porridge { Temperature = PorridgeTemperature.JustRight };

            switch (porridge.Temperature)
            {
                case PorridgeTemperature.TooHot:
                    GoOutsideForABit();
                    break;

                case PorridgeTemperature.TooCold:
                    MicrowaveMyBreakfast();
                    break;

                case PorridgeTemperature.JustRight:
                    NomNomNom();
                    break;
            }
        }

        private static void GoOutsideForABit()
        {
        }

        private static void MicrowaveMyBreakfast()
        {
        }

        private static void NomNomNom()
        {
        }

        public static void Arguments(string path)
        {
            var stream = new MemoryStream();

            using var rdr = new StreamReader(stream, true);

            using var fs = new FileStream(path, FileMode.Append);
        }
    }
}
