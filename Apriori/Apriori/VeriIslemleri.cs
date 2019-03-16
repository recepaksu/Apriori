using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    class ij
    {
        public decimal i;
        public decimal j;
        public ij(decimal _i, decimal _j)
        {
            i = _i;
            j = _j;
        }
    }

    class VeriIslemleri
    {
        #region eksik veri tamamlama
        //eksik verileri sayısal ise ortalama ile tamamlama
        public decimal Ortalama(List<ij> gelenler)
        {
            decimal toplam = 0;
            foreach (var item in gelenler)
            {
                toplam += item.j;
            }
            return toplam / gelenler.Count;
        }

        //her verinin tüm sütundaki oranını bulmak
        public Dictionary<string, decimal> OransalTamamlama(List<string> gelenler)
        {
            Dictionary<string, decimal> gidenler = new Dictionary<string, decimal>();
            Dictionary<string, decimal> temp = new Dictionary<string, decimal>();

            foreach (var item in gelenler)
            {
                if (temp.ContainsKey(item))
                {
                    temp[item]++;
                }
                else
                    temp.Add(item, 1);
            }

            decimal max = 0, toplam = 0;
            int dongu = temp.Count;
            string key = "";
            //oranlı dağıtmak için toplam bul
            foreach (KeyValuePair<string, decimal> item in temp)
            {
                toplam += item.Value;
            }

            //oranları büyükten küçüğe sıralı döndür
            for (int i = 0; i < dongu; i++)
            {
                max = 0;
                foreach (var item in temp)
                {
                    if (max < item.Value)
                    {
                        max = item.Value;
                        key = item.Key;
                    }
                }
                gidenler.Add(key, max / toplam);
                temp.Remove(key);
            }
            temp.Clear();
            return gidenler;
        }

        //missing valuelara verilerin oranlarına göre atama yapmak
        public List<List<string>> VeriDuzenleme(string dosya_yolu)
        {
            DosyaIslemleri di = new DosyaIslemleri();
            List<List<string>> gelenler = di.VerileriCek(dosya_yolu);
            List<string> baslik = di.BasligiCek(dosya_yolu);
            Dictionary<string, decimal> kelimeOranları = new Dictionary<string, decimal>();
            List<ij> sayilar = new List<ij>();
            List<string> yazilar = new List<string>();
            List<ij> kayiplar = new List<ij>();
            string temp;
            bool strorint = false, flag = false;//flag false string ,flag true int
            for (int j = 0; j < baslik.Count; j++)
            {
                flag = false;
                sayilar.Clear();
                yazilar.Clear();
                kayiplar.Clear();
                for (int i = 0; i < gelenler.Count; i++)
                {
                    temp = gelenler[i][j];
                    strorint = decimal.TryParse(temp, out decimal veri);

                    if (strorint)
                    {
                        yazilar.Add(temp);
                        sayilar.Add(new ij(i, veri));
                        flag = true;
                    }
                    else if (temp == "?")
                    {
                        kayiplar.Add(new ij(i, j));
                    }
                    else
                    {
                        yazilar.Add(temp);
                        flag = false;
                    }
                }

                if (flag)
                {
                    //düzenle
                    decimal ort = Ortalama(sayilar);
                    foreach (var item in kayiplar)
                    {
                        gelenler[(int)item.i][(int)item.j] = ((int)ort).ToString();
                    }
                }
                else
                {
                    //nomimnal verileri oranlı tamamlama
                    decimal toplam = 0;
                    int basla = 0;
                    kelimeOranları = OransalTamamlama(yazilar);
                    foreach (KeyValuePair<string, decimal> oran in kelimeOranları)
                    {
                        toplam += kayiplar.Count * oran.Value;
                        for (int k = basla; k < kayiplar.Count; k++)
                        {
                            if (k > toplam)
                            {
                                basla = k;
                                break;
                            }
                            else
                            {
                                gelenler[(int)kayiplar[k].i][(int)kayiplar[k].j] = oran.Key;
                            }
                        }
                    }

                    //farklı kolonlarda aynı verileri gelmesini engellemek için
                    for (int k = 0; k < gelenler.Count; k++)
                    {
                        gelenler[k][j] = baslik[j] + " = " + gelenler[k][j];
                    }
                }
            }
            VeriDuzenleme(baslik, gelenler);

            sayilar.Clear();
            yazilar.Clear();
            kayiplar.Clear();
            kelimeOranları.Clear();
            return gelenler;
        }
        #endregion

        #region MinMax
        //sayısal veriler için minmax normalizasyonu yap
        private List<ij> MinMaxNormalizasyon(List<ij> gelenler, decimal newMin, decimal newMax)
        {
            decimal min = gelenler[0].j, max = gelenler[0].j, temp;
            List<ij> gidenler = new List<ij>();
            foreach (var item in gelenler)
            {
                if (min > item.j) min = item.j;
                if (max < item.j) max = item.j;
            }

            foreach (var item in gelenler)
            {
                temp = ((item.j - min) / (max - min)) * (newMax - newMin) + newMin;
                gidenler.Add(new ij(item.i, temp));
            }

            return gidenler;
        }

        //verileri sayısal sözel olduklarına karar ver
        //sayısal olan verileri min max normalizasyonuna gönder ve ardından kutulama algoritması ile 4 gruba ayırıp atamalarını yap
        //sözel verileri eksik veri varsa oransal tamamlama yap
        public List<List<string>> VeriDuzenleme(List<string> baslik, List<List<string>> gelenler)
        {
            List<ij> sayilar = new List<ij>();
            string temp;
            bool strorint = false, flag = false;//flag false string ,flag true int
            for (int j = 0; j < baslik.Count; j++)
            {
                flag = false;
                sayilar.Clear();
                for (int i = 0; i < gelenler.Count; i++)
                {
                    temp = gelenler[i][j];
                    strorint = decimal.TryParse(temp, out decimal veri);

                    if (strorint)
                    {
                        sayilar.Add(new ij(i, veri));
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    List<ij> normalizeEdilenler = MinMaxNormalizasyon(sayilar, 0, 1);
                    normalizeEdilenler = normalizeEdilenler.OrderBy(i => i.j).ToList();
                    for (int i = 0; i < normalizeEdilenler.Count; i++)
                    {
                        gelenler[i][j] = normalizeEdilenler[i].j.ToString();
                    }
                    int n = gelenler.Count, kokn = (int)n / 4, sayac = 0, index = 1;
                    //kokn = (int)Math.Sqrt(n)
                    foreach (var item in normalizeEdilenler)
                    {
                        if (sayac == kokn)
                        {
                            sayac = 0;
                            index++;
                        }

                        gelenler[(int)item.i][j] =baslik[j] + " = Group"+ index.ToString();
                        sayac++;
                    }
                    normalizeEdilenler.Clear();
                }
            }
            sayilar.Clear();
            return gelenler;
        }
        #endregion

    }
}
