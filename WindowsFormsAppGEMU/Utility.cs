using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryStream
{
    public class swrClass
    {
        /// <summary>
        /// Funzione per scrivere su un file una variabile
        /// </summary>
        /// <param name="f">File in cui scrivere</param>
        /// <param name="v">Variabile da scrivere</param>
        public void WriteVar(string f,string v)
        {
            StreamWriter sw = new StreamWriter(f);
            sw.WriteLine(v);
            sw.Close();

        }
        /// <summary>
        /// Funzione per scrivere su un file un vettore
        /// </summary>
        /// <param name="f">File in cui scrivere</param>
        /// <param name="v">Variabile da scrivere</param>
        public void WriteVett(string f, string[] v)
        {
            StreamWriter sw = new StreamWriter(f);
            foreach (var eV in v)
            {
                sw.WriteLine(eV);
            }
            sw.Close();
        }
        /// <summary>
        /// Funzione per leggere una variabile contenuta in un file
        /// </summary>
        /// <param name="f">File da cui leggere la variabile</param>
        /// <returns> la varaibile contenuta nel file</returns>
        public string ReadVar(string f)
        {
            StreamReader sr = new StreamReader(f);
            string v = sr.ReadLine();
            sr.Close();
            return v;            
        }
        /// <summary>
        /// Funzione per leggere un vettore contenuto in un file
        /// </summary>
        /// <param name="f">File da cui leggere il vettore</param>
        /// <returns>Il vettore contenuto nel file</returns>
        public string[] ReadVet(string f)
        {
            StreamReader sr = new StreamReader(f);
            int vettL=0;
            do
            {
                sr.ReadLine();
                vettL++;
            } while (!sr.EndOfStream);
            string[] v = new string[vettL];
            int iR = 0;
            do
            {
                v[iR] = sr.ReadLine();
                iR++;
            } while (!sr.EndOfStream);
            sr.Close();
            return v;
        }
        /// <summary>
        /// Ricava il nome del file da un percorso
        /// </summary>
        /// <param name="path"> Percorso da cui ricavare il file</param>
        /// <returns></returns>
        public string Split(string path)
        {

            int c = path.Length - path.Replace("/", "").Length;
            string[] forSplit = new string[c];
            forSplit = path.Split('\\');
            path = forSplit[forSplit.Length - 1];
            return path;
        }


    }
}
