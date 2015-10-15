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
        IplImage 検査対象;
        IplImage マスク画像;
        IplImage 合成画像;
        IplImage 背景;
        
        public メイン画面()
        {
            InitializeComponent();
        }
        private void OnClick_検査対象(object sender, EventArgs e)
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
                if (検査対象 != null) 検査対象.Dispose();
                if (背景 != null) 背景.Dispose();

                検査対象 = Cv.LoadImage(dialog.FileName, LoadMode.GrayScale);
                背景 = 検査対象.Clone();

                if (マスク画像 != null && 検査対象 != null)
                {
                    合成画像 = 検査対象.Clone();
                    合成画像 = 画像合成(検査対象,マスク画像);
                    背景 = 合成画像;
 
                }
                //評価画面.Instance.Show();
                pictureBoxIpl1.ImageIpl = 背景;

                System.Diagnostics.Debug.WriteLine("検査対象画像の平均＝" + 検査対象.Avg().Val0.ToString("f"));
            }
        }

        private void OnClick_マスク画像(object sender, EventArgs e)
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
                if (マスク画像 != null) マスク画像.Dispose();
                if (背景 != null) 背景.Dispose();

                マスク画像 = Cv.LoadImage(dialog.FileName, LoadMode.GrayScale);
                マスク画像.Threshold(マスク画像,254,255,ThresholdType.Binary);
                背景 = マスク画像.Clone();
                if (マスク画像 != null && 検査対象 != null)
                {
                    合成画像 = 検査対象.Clone();
                    合成画像 = 画像合成(検査対象, マスク画像);
                    背景 = 合成画像;

                }
                //評価画面.Instance.Show();
                pictureBoxIpl1.ImageIpl = 背景;

                System.Diagnostics.Debug.WriteLine("マスク画像の平均＝" + マスク画像.Avg().Val0.ToString("f"));
            }

        }
        IplImage 画像合成(IplImage src, IplImage mask)
        {
            IplImage dst=src.Clone();
            dst.Zero();
            Cv.Copy(src, dst, mask);
            return dst;
        }

        private void OnClick_ROI実行(object sender, EventArgs e)
        {
            if (背景 != null)
            {
                IplImage buff = 背景.Clone();
                buff.Zero();
                string[] roi1 = textBox_roi1.Text.Split(',');
                string[] roi2 = textBox_roi2.Text.Split(',');

                CvPoint roiPoint = new CvPoint(int.Parse(roi1[0]), int.Parse(roi1[1]));
                CvSize roiSize = new CvSize(int.Parse(roi2[0]) - int.Parse(roi1[0]), int.Parse(roi2[1]) - int.Parse(roi1[1]));

                Cv.SetImageROI(背景, new CvRect(roiPoint, roiSize));
                //黒画像に重ねる．ポインタを弄るしか描画方法がないらしい
                for (int x = 0; x < int.Parse(roi2[0]) - int.Parse(roi1[0]); x++)
                    for (int y = 0; y < int.Parse(roi2[1]) - int.Parse(roi1[1]); y++)
                    {
                        CvScalar cs = Cv.Get2D(背景, y, x);
                        Cv.Set2D(buff, int.Parse(roi1[1]) + y, int.Parse(roi1[0]) + x, cs);
                    }
                label_roi_info.Text = 画像情報を取得(背景, roiSize);
                pictureBoxIpl1.ImageIpl = buff;
                Cv.ResetImageROI(背景);
                buff.Dispose();
            }
        }

        private string 画像情報を取得(IplImage src,CvSize size)
        {
            string info="";
            double 平均, 分散;

            平均 = src.Avg().Val0;
            double sum = 0,max=0,min=255;
            for (int x = 0; x < size.Width; x++)
                for (int y = 0; y < size.Height; y++)
                {
                    CvScalar cs = Cv.Get2D(src, y, x);
                    sum += Math.Pow(cs.Val0-平均,2);
                    if (cs.Val0 > max) max = cs.Val0;
                    if (cs.Val0 < min) min = cs.Val0;
                }
            分散 = sum / (size.Width * size.Height);
            info =     "平均="+平均.ToString("f") + "\n"
                     + "分散="+分散.ToString("f") + "\n"
                     + "最大="+max.ToString("f")  + "\n"
                     + "最小="+min.ToString("f");

            return info;
        }
        string csvフォーマットを取得(IplImage src, CvSize size,string type)
        {
            string info = "";
            double 平均, 分散;

            平均 = src.Avg().Val0;
            double sum = 0, max = 0, min = 255;
            for (int x = 0; x < size.Width; x++)
                for (int y = 0; y < size.Height; y++)
                {
                    CvScalar cs = Cv.Get2D(src, y, x);
                    sum += Math.Pow(cs.Val0 - 平均, 2);
                    if (cs.Val0 > max) max = cs.Val0;
                    if (cs.Val0 < min) min = cs.Val0;
                }
            分散 = sum / (size.Width * size.Height);
            info = 平均.ToString("f")+","+分散.ToString("f")+","+max.ToString("f")+","+min.ToString("f")+","+type;

            return info;
 
        }
        private void OnClick_csv出力(object sender, EventArgs e)
        {
            if (合成画像 != null)
            {
                string 結果 = "";
                int x,y;
                CvSize roiSize = new CvSize(9,9);
                CvPoint roiPoint;
                for (x = 0; x < 合成画像.Width - 9; x++)
                {
                    System.Diagnostics.Debug.WriteLine(x + "\n" + 結果);
                    for (y = 0; y < 合成画像.Height - 9; y++)
                    {
                        string buff = "";
                        roiPoint = new CvPoint(x, y);
                        Cv.SetImageROI(検査対象, new CvRect(roiPoint, roiSize));
                        Cv.SetImageROI(マスク画像, new CvRect(roiPoint, roiSize));

                        if (checkBox_all.Checked)
                        {
                            if (マスク画像.Avg().Val0 == 0) buff = csvフォーマットを取得(検査対象, roiSize, "0");
                            else if (マスク画像.Avg().Val0 == 255) buff = csvフォーマットを取得(検査対象, roiSize, "1");
                        }
                        else if (checkBox_black.Checked)
                        {
                            if (マスク画像.Avg().Val0 == 0) buff = csvフォーマットを取得(検査対象, roiSize, "0");
                        }
                        else
                        {
                            if (マスク画像.Avg().Val0 == 255) buff = csvフォーマットを取得(検査対象, roiSize, "1");
                        }

                        if(buff!="")結果 += buff + "\n";

                        Cv.ResetImageROI(マスク画像);
                        Cv.ResetImageROI(検査対象);
                    }
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
