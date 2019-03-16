using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apriori
{
    class Veri
    {
        public double support, confidence, lift, leverage, conviction;
    }

    class XY
    {
        public List<string> sol = new List<string>();
        public List<string> sag = new List<string>();
    }

    class AprioriIslem
    {
        Dictionary<string, double> virgulluItemSet = new Dictionary<string, double>();
        List<List<string>> veriler = new List<List<string>>();
        int minSupportCount;
        Int64 kuralSayisi, kuralSayisiTemp;

        public AprioriIslem(List<List<string>> _veriler, int _minSupportCount, Int64 _kuralSayisi)
        {
            veriler = _veriler;
            minSupportCount = _minSupportCount;
            kuralSayisi = kuralSayisiTemp = _kuralSayisi;
        }

        //veriler içerisindeki tüm farklı verilerden bir itemset oluştur, min support counta göre filtrele
        private Dictionary<string, double> itemSetOlustur()
        {
            Dictionary<string, double> itemSet = new Dictionary<string, double>();
            foreach (var veri in veriler)
            {
                foreach (var item in veri)
                {
                    if (itemSet.ContainsKey(item))
                        itemSet[item]++;
                    else
                        itemSet.Add(item, 1);
                }
            }

            foreach (var item in itemSet.Keys.ToArray<string>())
            {
                if (itemSet[item] < minSupportCount)
                {
                    itemSet.Remove(item);
                }
            }

            return itemSet;
        }
        //veriler içerisindeki tüm farklı verilerden bir itemset oluştur, min support counta göre filtrele
        private Dictionary<string, double> itemSetOlustur(Dictionary<List<string>, double> dictVeriler)
        {
            Dictionary<string, double> itemSet = new Dictionary<string, double>();
            foreach (var veri in dictVeriler)
            {
                foreach (var item in veri.Key)
                {
                    if (itemSet.ContainsKey(item))
                        itemSet[item]++;
                    else
                        itemSet.Add(item, 1);
                }
            }

            foreach (var item in itemSet.Keys.ToArray<string>())
            {
                if (itemSet[item] < minSupportCount)
                {
                    itemSet.Remove(item);
                }
            }

            return itemSet;
        }
        //alt küme algoritması ile verilerden kurallar oluştur
        private Dictionary<List<string>, double> nElemanliAltKumeBul(Dictionary<string, double> itemSet, int altKumeElemanSayisi)
        {
            Dictionary<List<string>, double> altKumeler = new Dictionary<List<string>, double>();
            int n = itemSet.Count;
            decimal dongu = (decimal)Math.Pow(2, n);
            string[] elemanlar = itemSet.Keys.ToArray<string>();
            //elemanlar = elemanlar.OrderBy(x => x).ToArray();

            for (int i = 1; i < dongu - 1; i++)
            {
                int nTemp = n, temp = i;

                List<string> tempS = new List<string>();
                while (temp > 0)
                {
                    nTemp--;
                    if (temp % 2 == 1)
                        tempS.Add(elemanlar[nTemp]);
                    temp /= 2;
                }

                if (tempS.Count == altKumeElemanSayisi)
                {
                    tempS = tempS.OrderBy(x => x).ToList();
                    if (altKumeler.ContainsKey(tempS))
                        altKumeler[tempS]++;
                    else
                        altKumeler[tempS] = 1;
                }
            }
            return altKumeler;
        }
        //kurallardaki sağ ve soldaki verilerin çokluğuna göre büyükten küçüğe sırala
        private Dictionary<List<string>, double> dictSirala(Dictionary<List<string>, double> gelenler)
        {
            Dictionary<List<string>, double> gidenler = new Dictionary<List<string>, double>();
            while (gelenler.Count > 0)
            {
                int maxCount = 0;
                KeyValuePair<List<string>, double> tempKey = new KeyValuePair<List<string>, double>();
                foreach (var item in gelenler)
                {
                    if (maxCount < item.Key.Count)
                    {
                        maxCount = item.Key.Count;
                        tempKey = item;
                    }
                }
                gidenler[tempKey.Key] = tempKey.Value;
                gelenler.Remove(tempKey.Key);
            }
            return gidenler;
        }
        //bir itemin veri setinde kaç defa geçtiğini bul
        private Dictionary<List<string>, double> frequentitemSet()
        {
            Dictionary<List<string>, double> kalanlar = new Dictionary<List<string>, double>();
            Dictionary<string, double> itemSet = itemSetOlustur();
            int sayac = 0;

            for (int i = 2; i <= itemSet.Count; i++)
            {
                Dictionary<List<string>, double> gelenler = nElemanliAltKumeBul(itemSet, i);
                foreach (var liste in gelenler)
                {
                    foreach (var veri in veriler)
                    {
                        sayac = 0;
                        foreach (var item in liste.Key)
                        {
                            if (veri.Contains(item))
                                sayac++;
                            else
                                break;
                        }
                        if (sayac == i)
                        {
                            if (kalanlar.ContainsKey(liste.Key))
                                kalanlar[liste.Key]++;
                            else
                                kalanlar[liste.Key] = 1;
                        }
                    }
                }
                itemSet = itemSetOlustur(kalanlar);
                foreach (var item in kalanlar.ToList())
                {
                    if (kalanlar[item.Key] < minSupportCount)
                        kalanlar.Remove(item.Key);
                }
            }

            kalanlar = dictSirala(kalanlar);
            return kalanlar;
        }
        //alt küme algoritmasından dönen sonuçlar ile kural oluştur
        private List<XY> kuralOlustur(List<string> gelen)
        {
            List<XY> kurallar = new List<XY>();
            int n = gelen.Count;
            int dongu = (int)Math.Pow(2, n);
            string[] elemanlar = gelen.ToArray();
            elemanlar = elemanlar.OrderBy(x => x).ToArray();

            //alt kümesi boş ve full almamak için 1den başlıyor -1e kadar
            for (int i = 1; i < dongu - 1; i++)
            {
                int nTemp = n, temp = i;
                XY tempXY = new XY();
                int[] ikilik = new int[n];
                while (temp > 0)
                {
                    nTemp--;
                    if (temp % 2 == 1)
                        ikilik[nTemp] = 1;

                    temp /= 2;
                }

                for (int j = 0; j < n; j++)
                {

                    if (ikilik[j] == 1)
                        tempXY.sol.Add(elemanlar[j]);
                    else
                        tempXY.sag.Add(elemanlar[j]);
                }
                kurallar.Add(tempXY);
            }
            return kurallar;
        }

        //ilişkilendirme bölümü => support, confidence, lift, leverage, conviction hesabı yap
        public Dictionary<string, Veri> association()
        {
            bool flag = false;
            virgulluItemSet = VirgulluItemSet();
            double N = veriler.Count();
            Dictionary<string, Veri> Sonuclar = new Dictionary<string, Veri>();

            List<List<XY>> kurallar = new List<List<XY>>();
            foreach (var item in virgulluItemSet.Keys.ToList())
            {
                List<string> tempS = new List<string>();
                foreach (var item2 in item.Split(',').ToList())
                {
                    tempS.Add(item2);
                }
                List<XY> xy = kuralOlustur(tempS);
                foreach (var x in xy)
                {
                    Veri sonuc = new Veri();
                    string tempTotal = "";
                    for (int i = 0; i < x.sol.Count; i++)
                    {
                        sonuc.support = virgulluItemSet[item] / N;
                        string tempx = "";
                        foreach (var item3 in x.sol)
                        {
                            tempx += item3 + ",";
                        }
                        tempx = tempx.Substring(0, tempx.Length - 1);
                        string tempy = "";
                        foreach (var item3 in x.sag)
                        {
                            tempy += item3 + ",";
                        }
                        tempy = tempy.Substring(0, tempy.Length - 1);
                        tempTotal = tempx + " => " + tempy;
                        sonuc.confidence = virgulluItemSet[item] / virgulluItemSet[tempx];
                        sonuc.lift = sonuc.confidence / (virgulluItemSet[tempy] / N);
                        sonuc.leverage = (virgulluItemSet[item] / N) - ((virgulluItemSet[tempx] / N) * (virgulluItemSet[tempy] / N));
                        sonuc.conviction = (virgulluItemSet[tempx] / N) * (1 - virgulluItemSet[tempy] / N) / (virgulluItemSet[item] / N);
                    }
                    if (kuralSayisi == 0)
                    {
                        Sonuclar.Add(tempTotal, sonuc);
                    }
                    else if (kuralSayisiTemp > 0)
                    {
                        Sonuclar.Add(tempTotal, sonuc);
                        kuralSayisiTemp--;
                    }
                    else
                        flag = true;
                }
                if (flag)
                    break;
            }
            return Sonuclar;
        }
        //dictionary list<string> keyi ile arama yapamadığı için veri dönüşümü yap
        private Dictionary<string, double> VirgulluItemSet()
        {
            Dictionary<string, double> gidenler = new Dictionary<string, double>();
            Dictionary<List<string>, double> scMulti = frequentitemSet();
            Dictionary<string, double> sc1 = itemSetOlustur();
            foreach (var item in scMulti.ToList())
            {
                string temp = "";
                foreach (var s in item.Key)
                {
                    temp += s + ",";
                }
                gidenler[temp.Substring(0, temp.Length - 1)] = item.Value;
            }

            foreach (var item in sc1)
            {
                gidenler[item.Key] = item.Value;
            }
            return gidenler;
        }

    }
}
