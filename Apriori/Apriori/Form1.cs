using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apriori
{

    public partial class Form1 : Form
    {
        List<string> baslik = new List<string>();
        List<List<string>> veriler = new List<List<string>>();
        Dictionary<string, Veri> Sonuclar = new Dictionary<string, Veri>();

        string dosya_yolu;
        public Form1()
        {
            InitializeComponent();
            tbSupport.Text = "0.3";
            tbConfidence.Text = "0.5";
            tbLift.Text = "1";
            tbLeverage.Text = "0";
            tbConviction.Text = "0";
            tbKural.Text = "0";
            toolStripStatusLabel1.Text = "";
            btnApriori.Visible = false;
            tbSupport.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            tbLift.Visible = false;
            tbConfidence.Visible = false;
            tbConviction.Visible = false;
            tbLeverage.Visible = false;
            btnAra.Visible = false;
            tbKural.Visible = false;
            btnFiltre.Visible = false;
            btnDosyaYaz.Visible = false;
        }

        private void btnDosya_Click(object sender, EventArgs e)
        {
            if (DosyaYolu())
            {
                DosyaIslemleri di = new DosyaIslemleri();
                baslik = di.BasligiCek(dosya_yolu);
                veriler = di.VerileriCek(dosya_yolu);
                DataGridViewOlustur(veriler);
                btnAra.Visible = true;
                btnDosya.Enabled = false;
            }
            else
                MessageBox.Show("Dosya alırken hata oluştu.");

        }

        private void DataGridViewOlustur(List<List<string>> basilacakVeriler)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            foreach (string item in baslik)
            {
                dataGridView1.Columns.Add(item, item);
            }

            foreach (var item in basilacakVeriler)
            {
                dataGridView1.Rows.Add(item.ToArray());
            }
        }

        private void btnApriori_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(tbSupport.Text) >= 0 && Convert.ToDouble(tbSupport.Text) <= 1 && Convert.ToInt64(tbKural.Text) >= 0)
            {
                btnApriori.Enabled = false;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                AprioriIslem ak = new AprioriIslem(veriler, (int)(Convert.ToDouble(tbSupport.Text) * veriler.Count), Convert.ToInt64(tbKural.Text));
                Sonuclar = ak.association();
                List<string> baslik2 = new List<string>();
                baslik2.Add("Kural 1");
                baslik2.Add("Kural 2");
                baslik2.Add("Support");
                baslik2.Add("Confidence");
                baslik2.Add("Lift");
                baslik2.Add("Leverage");
                baslik2.Add("Conviction");

                foreach (string item in baslik2)
                {
                    dataGridView2.Columns.Add(item, item);
                }
                object[] obj = new object[7];
                string[] seperator = { "=>" };
                foreach (var item in Sonuclar)
                {

                    obj[0] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[0];
                    obj[1] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[1];
                    obj[2] = item.Value.support;
                    obj[3] = item.Value.confidence;
                    obj[4] = item.Value.lift;
                    obj[5] = item.Value.leverage;
                    obj[6] = item.Value.conviction;
                    dataGridView2.Rows.Add(obj);
                }
                btnApriori.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                tbLift.Visible = true;
                tbConfidence.Visible = true;
                tbConviction.Visible = true;
                tbLeverage.Visible = true;
                btnFiltre.Visible = true;
                toolStripStatusLabel1.Text = "Oluşturulan Kural Sayısı = " + Sonuclar.Count.ToString();
                btnDosyaYaz.Visible = true;
            }
            else
                MessageBox.Show("Lütfen 0 - 1 arası değer giriniz.");

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            VeriIslemleri vi = new VeriIslemleri();
            veriler = vi.VeriDuzenleme(dosya_yolu);
            DataGridViewOlustur(veriler);
            btnApriori.Visible = true;
            tbSupport.Visible = true;
            label1.Visible = true;
            btnAra.Enabled = false;
            label6.Visible = true;
            tbKural.Visible = true;
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (Convert.ToDouble(tbKural.Text) >= 0)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Kural sayısı 0'dan büyük olmalıdır.");
            }
            if (flag && Convert.ToDouble(tbSupport.Text) >= 0 && Convert.ToDouble(tbSupport.Text) <= 1)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Support 0 - +1 arasında olmalıdır.");
            }
            if (flag && Convert.ToDouble(tbConfidence.Text) >= 0 && Convert.ToDouble(tbConfidence.Text) <= 1)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Confidence 0 - +1 arasında olmalıdır.");
            }
            if (flag && Convert.ToDouble(tbLift.Text) >= 0)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Lift >= 0 olmalıdır.");
            }
            if (flag && Convert.ToDouble(tbLeverage.Text) >= 0 && Convert.ToDouble(tbLeverage.Text) <= 1)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Leverage -0.25 - +0.25 arasında olmalıdır.");
            }
            if (flag && Convert.ToDouble(tbConviction.Text) >= 0 && Convert.ToDouble(tbConviction.Text) <= 1)
                flag = true;
            else
            {
                flag = false;
                MessageBox.Show("Conviction >= 0 olmalıdır.");
            }


            if (flag)
            {
                Int64 sayac = 0;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();
                List<string> baslik2 = new List<string>();
                baslik2.Add("Kural 1");
                baslik2.Add("Kural 2");
                baslik2.Add("Support");
                baslik2.Add("Confidence");
                baslik2.Add("Lift");
                baslik2.Add("Leverage");
                baslik2.Add("Conviction");

                foreach (string item in baslik2)
                {
                    dataGridView2.Columns.Add(item, item);
                }
                object[] obj = new object[7];
                string[] seperator = { "=>" };
                foreach (var item in Sonuclar)
                {
                    if (0 == Convert.ToDouble(tbKural.Text))
                    {
                        if (!(item.Value.support < Convert.ToDouble(tbSupport.Text) ||
                            item.Value.confidence < Convert.ToDouble(tbConfidence.Text) ||
                            item.Value.lift < Convert.ToDouble(tbLift.Text) ||
                            item.Value.leverage < Convert.ToDouble(tbLeverage.Text) ||
                            item.Value.conviction < Convert.ToDouble(tbConviction.Text)))
                        {
                            obj[0] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[0];
                            obj[1] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[1];
                            obj[2] = item.Value.support;
                            obj[3] = item.Value.confidence;
                            obj[4] = item.Value.lift;
                            obj[5] = item.Value.leverage;
                            obj[6] = item.Value.conviction;
                            dataGridView2.Rows.Add(obj);
                        }
                    }
                    else if (sayac < Convert.ToDouble(tbKural.Text))
                    {
                        if (!(item.Value.support < Convert.ToDouble(tbSupport.Text) ||
                            item.Value.confidence < Convert.ToDouble(tbConfidence.Text) ||
                            item.Value.lift < Convert.ToDouble(tbLift.Text) ||
                            item.Value.leverage < Convert.ToDouble(tbLeverage.Text) ||
                            item.Value.conviction < Convert.ToDouble(tbConviction.Text)))
                        {
                            obj[0] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[0];
                            obj[1] = item.Key.Split(seperator, System.StringSplitOptions.RemoveEmptyEntries)[1];
                            obj[2] = item.Value.support;
                            obj[3] = item.Value.confidence;
                            obj[4] = item.Value.lift;
                            obj[5] = item.Value.leverage;
                            obj[6] = item.Value.conviction;
                            dataGridView2.Rows.Add(obj);
                            sayac++;
                        }
                    }
                }
            }

        }

        public bool DosyaYolu()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Something|*.txt", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dosya_yolu = ofd.FileName;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void btnDosyaYaz_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            DosyaIslemleri di = new DosyaIslemleri();
            if (di.TXTYaz(false,Sonuclar, dosya_yolu))
                MessageBox.Show("Kurallar dosyaya yazdırıldı.");
            else
            {
                dr = MessageBox.Show("Aynı isimde sonuç dosyası var, üzerine yazdırmak ister misiniz ?", "Dikkat", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    if(di.TXTYaz(true, Sonuclar, dosya_yolu))
                        MessageBox.Show("Kurallar dosyaya yazdırıldı.");
                    else
                        MessageBox.Show("Bilinmeyen Hata");
            }
        }
    }
}
