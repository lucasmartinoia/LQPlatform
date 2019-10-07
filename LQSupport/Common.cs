using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace LQ.Support
{
    public static class Common
    {
        private static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            //int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7 ;
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7 ; 
            return start.AddDays(daysToAdd);
        }
        public static DateTime GetDayOfWeek(string dia, DateTime fecha)
        {
            DayOfWeek dayOfWeek = DayOfWeek.Monday; 
            switch (dia.Trim())
            {
                case "1":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "2":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "3":
                    dayOfWeek = DayOfWeek.Wednesday ;
                    break;
                case "4":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "5":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case "6":
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                default:
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
            }
            DateTime nextDay = GetNextWeekday(fecha, dayOfWeek);
            return nextDay;

        }
        public static string SerializeToString<T>(T value)
        {
            string sReturn = "";

            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(value.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                serializer.Serialize(writer, value, emptyNamepsaces);
                sReturn = stream.ToString();

                // Add Calypso header.
                //sReturn = "<?xml version=\"1.0\" encoding=\"UTF - 8\" standalone=\"yes\"?>\n<CalypsoUploadDocument xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" UploadDate=\"04/25/2014\" ClientCode=\"CSVUPLOADER\" Version=\"1\" xsi:schemaLocation=\"\">\n"
                //          + sReturn;

                //// Add Calypso footer.
                //sReturn += "\n</CalypsoUploadDocument>";
            }

            return (sReturn);
        }
    }

    public class Number
    {
        private String[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
        private String[] DECENAS = { "diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ", "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ", "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa " };
        private String[] CENTENAS = { "", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ", "setecientos ", "ochocientos ", "novecientos " };

        private Regex r;

        public String ConvertToLiterals(String numero, bool mayusculas, string moneda = "PESOS")
        {

            String literal = "";
            String parte_decimal;
            //si el numero utiliza (.) en lugar de (,) -> se reemplaza
            numero = numero.Replace(".", ",");

            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(",") == -1)
            {
                numero = numero + ",00";
            }
            //se valida formato de entrada -> 0,00 y 999 999 999,00
            r = new Regex(@"\d{1,9},\d{1,2}");
            MatchCollection mc = r.Matches(numero);
            if (mc.Count > 0)
            {
                //se divide el numero 0000000,00 -> entero y decimal
                String[] Num = numero.Split(',');

                string MN = " M.N.";
                if (moneda != "PESOS")
                    MN = "";
                var lRest = long.Parse(Num[1]);

                //de da formato al numero decimal
                parte_decimal = moneda + " " + lRest.ToString() + "/100" + MN;
                //se convierte el numero a literal
                if (int.Parse(Num[0]) == 0)
                {//si el valor es cero
                    literal = "cero ";
                }
                else if (int.Parse(Num[0]) > 999999)
                    //si es millon
                    literal = getMillones(Num[0]);
                else if (int.Parse(Num[0]) > 999)
                    //si es miles
                    literal = getMiles(Num[0]);

                else if (int.Parse(Num[0]) > 99)
                {//si es centena
                    literal = getCentenas(Num[0]);
                }
                else if (int.Parse(Num[0]) > 9)
                {//si es decena
                    literal = getDecenas(Num[0]);
                }
                else
                {//sino unidades -> 9
                    literal = getUnidades(Num[0]);
                }
                //devuelve el resultado en mayusculas o minusculas
                if (mayusculas)
                {
                    return (literal + parte_decimal).ToUpper();
                }
                else
                {
                    return (literal + parte_decimal);
                }
            }
            else
            {//error, no se puede convertir
                return literal = null;
            }
        }

        /* funciones para convertir los numeros a literales */

        private String getUnidades(String numero)
        {   // 1 - 9
            //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
            String num = numero.Substring(numero.Length - 1);
            return UNIDADES[int.Parse(num)];
        }

        private String getDecenas(String num)
        {// 99
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return getUnidades(num);
            }
            else if (n > 19)
            {//para 20...99
                String u = getUnidades(num);
                if (u.Equals(""))
                { //para 20,30,40,50,60,70,80,90
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {//numeros entre 11 y 19
                return DECENAS[n - 10];
            }
        }

        private String getCentenas(String num)
        {// 999 o 099
            if (int.Parse(num) > 99)
            {//es centena
                if (int.Parse(num) == 100)
                {//caso especial
                    return " cien ";
                }
                else
                {
                    return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
                }
            }
            else
            {//por Ej. 099
                //se quita el 0 antes de convertir a decenas
                return getDecenas(int.Parse(num) + "");
            }
        }

        private String getMiles(String numero)
        {// 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = getCentenas(m);
                return n + "mil " + getCentenas(c);
            }
            else
            {
                return "" + getCentenas(c);
            }

        }

        private String getMillones(String numero)
        { //000 000 000
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (millon.Length > 1)
            {
                n = getCentenas(millon) + "millones ";
            }
            else
            {
                n = getUnidades(millon) + "millon ";
            }
            return n + getMiles(miles);
        }

    }
}
