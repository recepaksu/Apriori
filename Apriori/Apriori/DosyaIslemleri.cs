using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    class DosyaIslemleri
    {
        #region veri okuma
        public List<string> BasligiCek(string dosya_yolu)
        {
            List<string> baslik = new List<string>();
            //dosya_yolu = @"C:\Users\recep\Desktop\ISBSG-raw-data-v2.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            baslik = sr.ReadLine().Split(',').ToList<string>();
            sr.Close();
            fs.Close();
            return baslik;
        }

        public List<List<string>> VerileriCek(string dosya_yolu)
        {
            List<List<string>> veriler = new List<List<string>>();
            //dosya_yolu = @"C:\Users\recep\Desktop\ISBSG-raw-data-v2.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.ReadLine();//başlık satırını atla
            string yazi = sr.ReadLine();
            while (yazi != null)
            {
                veriler.Add(yazi.Split(',').ToList<string>());
                yazi = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            return veriler;
        }
        public bool TXTYaz(bool flag,Dictionary<string,Veri> gelenler,string dosya_yolu)
        {
            try
            {
                string[] seperator = { ".txt" };
                dosya_yolu = dosya_yolu.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[0] + "_Sonuclar.txt";
                if (!File.Exists(dosya_yolu) || flag)
                {
                    FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("Kural;Support;Confidence;Lift;Leverage;Conviction");
                    foreach (var item in gelenler)
                    {
                        sw.WriteLine(item.Key + ";" +
                            item.Value.support.ToString() + ";" +
                            item.Value.confidence.ToString() + ";" +
                            item.Value.lift.ToString() + ";" +
                            item.Value.leverage.ToString() + ";" +
                            item.Value.conviction.ToString());
                    }
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
    }
}


/*
 * https://www.kodlamamerkezi.com/c-net/c-ile-dosya-okuma-ve-yazma-islemleri/
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
