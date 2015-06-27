using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;

namespace ROI_Hist_test
{
    public partial class メイン画面 : Form
    {
        IplImage 入力画像;
        IplImage 背景;
        
        public メイン画面()
        {
            InitializeComponent();
        }

        private void OnClick開く(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                if (入力画像 != null) 入力画像.Dispose();
                if (背景 != null) 背景.Dispose();

                入力画像 = Cv.LoadImage(dialog.FileName,LoadMode.GrayScale);
                背景 = 入力画像.Clone();

                //評価画面.Instance.Show();
                pictureBoxIpl1.Size = pictureBoxIplのサイズ調整(入力画像);
                pictureBoxIpl1.ImageIpl = 入力画像;

                System.Diagnostics.Debug.WriteLine("入力画像の平均＝"+入力画像.Avg().Val0.ToString("f"));
            }
        }
        public static System.Drawing.Size pictureBoxIplのサイズ調整(IplImage sample)
        {
            return new System.Drawing.Size(sample.Width, sample.Height);
        }

        private void OnClick_ROI実行(object sender, EventArgs e)
        {
            if (入力画像 != null)
            {
                背景.Zero();
                string[] roi1 = textBox_roi1.Text.Split(',');
                string[] roi2 = textBox_roi2.Text.Split(',');

                CvPoint roiPoint = new CvPoint(int.Parse(roi1[0]), int.Parse(roi1[1]));
                CvSize roiSize = new CvSize(int.Parse(roi2[0]) - int.Parse(roi1[0]), int.Parse(roi2[1]) - int.Parse(roi1[1]));

                Cv.SetImageROI(入力画像, new CvRect(roiPoint,roiSize));
                pictureBoxIpl1.Size = pictureBoxIplのサイズ調整(入力画像);
                //黒画像に重ねる．ポインタを弄るしか描画方法がないらしい
                for (int x = 0; x < int.Parse(roi2[0]) - int.Parse(roi1[0]);x++ )
                    for (int y = 0; y < int.Parse(roi2[1]) - int.Parse(roi1[1]); y++)
                    {
                        CvScalar cs = Cv.Get2D(入力画像, y, x);
                        Cv.Set2D(背景, int.Parse(roi1[1])+y,int.Parse(roi1[0])+ x, cs);
                    }
                label_平均と分散.Text = 画像の平均と分散を取得(入力画像,roiSize);
                pictureBoxIpl1.ImageIpl = 背景;
                Cv.ResetImageROI(入力画像);
                
            }
        }

        private string 画像の平均と分散を取得(IplImage src,CvSize size)
        {
            string 平均と分散="";
            double 平均, 分散;

            平均 = src.Avg().Val0;
            double sum = 0;
            for (int x = 0; x < size.Width; x++)
                for (int y = 0; y < size.Height; y++)
                {
                    CvScalar cs = Cv.Get2D(src, y, x);
                    sum += Math.Pow(cs.Val0-平均,2);
                }
            分散 = sum / (size.Width * size.Height);
            平均と分散 = "" + 平均.ToString("f") + "," + 分散.ToString("f");

            return 平均と分散;
        }

        private void OnClick_csv出力(object sender, EventArgs e)
        {
            if (入力画像 != null)
            {
                string 結果 = "";
                int x_num,y_num;
                CvSize roiSize = new CvSize(入力画像.Width/9, 入力画像.Height/9);
                CvPoint roiPoint;
                for (x_num = 0; x_num < 9; x_num++)
                    for (y_num = 0; y_num < 9; y_num++)
                    {
                        string buff = "";
                        roiPoint = new CvPoint(x_num * roiSize.Width, y_num * roiSize.Height);
                        Cv.SetImageROI(入力画像, new CvRect(roiPoint, roiSize));
                        buff= ""+x_num+","+y_num+","+画像の平均と分散を取得(入力画像, roiSize);
                        結果 += buff+"\n";
                        System.Diagnostics.Debug.WriteLine(buff);

                        Cv.ResetImageROI(入力画像);
                    }

                stringをcsv出力(結果,DateTime.Now.ToString("yy-MM-dd_")+this.Text);
            }
        }
        private void stringをcsv出力(string 出力内容,string ファイル名)
        {
            System.IO.Directory.CreateDirectory(@"result");

            using (StreamWriter w = new StreamWriter(@"result\" + ファイル名 + ".csv"))
            {
                w.Write(出力内容);
            }
        }
    }
}
