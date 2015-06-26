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

namespace ROI_Hist_test
{
    public partial class Form1 : Form
    {
        IplImage 入力画像;
        IplImage 背景;
        
        public Form1()
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

                for (int x = 0; x < int.Parse(roi2[0]) - int.Parse(roi1[0]);x++ )
                    for (int y = 0; y < int.Parse(roi2[1]) - int.Parse(roi1[1]); y++)
                    {
                        CvScalar cs = Cv.Get2D(入力画像, y, x);
                        Cv.Set2D(背景, int.Parse(roi1[1])+y,int.Parse(roi1[0])+ x, cs);
                    }
                    pictureBoxIpl1.ImageIpl = 背景;
                Cv.ResetImageROI(入力画像);

            }
        }
    }
}
