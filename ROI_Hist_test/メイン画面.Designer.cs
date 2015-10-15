namespace ROI_Hist_test
{
    partial class メイン画面
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_検査対象 = new System.Windows.Forms.Button();
            this.button_ROI = new System.Windows.Forms.Button();
            this.textBox_roi1 = new System.Windows.Forms.TextBox();
            this.textBox_roi2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_csv出力 = new System.Windows.Forms.Button();
            this.label_roi_info = new System.Windows.Forms.Label();
            this.button_マスク画像 = new System.Windows.Forms.Button();
            this.checkBox_black = new System.Windows.Forms.CheckBox();
            this.checkBox_all = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(85, 4);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(410, 325);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // button_検査対象
            // 
            this.button_検査対象.Location = new System.Drawing.Point(4, 4);
            this.button_検査対象.Name = "button_検査対象";
            this.button_検査対象.Size = new System.Drawing.Size(75, 23);
            this.button_検査対象.TabIndex = 1;
            this.button_検査対象.Text = "検査対象";
            this.button_検査対象.UseVisualStyleBackColor = true;
            this.button_検査対象.Click += new System.EventHandler(this.OnClick_検査対象);
            // 
            // button_ROI
            // 
            this.button_ROI.Location = new System.Drawing.Point(4, 259);
            this.button_ROI.Name = "button_ROI";
            this.button_ROI.Size = new System.Drawing.Size(75, 23);
            this.button_ROI.TabIndex = 2;
            this.button_ROI.Text = "ROI実行";
            this.button_ROI.UseVisualStyleBackColor = true;
            this.button_ROI.Click += new System.EventHandler(this.OnClick_ROI実行);
            // 
            // textBox_roi1
            // 
            this.textBox_roi1.Location = new System.Drawing.Point(29, 133);
            this.textBox_roi1.Name = "textBox_roi1";
            this.textBox_roi1.Size = new System.Drawing.Size(50, 19);
            this.textBox_roi1.TabIndex = 3;
            this.textBox_roi1.Text = "0,0";
            // 
            // textBox_roi2
            // 
            this.textBox_roi2.Location = new System.Drawing.Point(29, 158);
            this.textBox_roi2.Name = "textBox_roi2";
            this.textBox_roi2.Size = new System.Drawing.Size(50, 19);
            this.textBox_roi2.TabIndex = 4;
            this.textBox_roi2.Text = "100,100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ROI p1->p2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "p1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "p2";
            // 
            // button_csv出力
            // 
            this.button_csv出力.Location = new System.Drawing.Point(4, 288);
            this.button_csv出力.Name = "button_csv出力";
            this.button_csv出力.Size = new System.Drawing.Size(75, 23);
            this.button_csv出力.TabIndex = 8;
            this.button_csv出力.Text = "csv出力";
            this.button_csv出力.UseVisualStyleBackColor = true;
            this.button_csv出力.Click += new System.EventHandler(this.OnClick_csv出力);
            // 
            // label_roi_info
            // 
            this.label_roi_info.AutoSize = true;
            this.label_roi_info.Location = new System.Drawing.Point(6, 185);
            this.label_roi_info.Name = "label_roi_info";
            this.label_roi_info.Size = new System.Drawing.Size(48, 12);
            this.label_roi_info.TabIndex = 9;
            this.label_roi_info.Text = "ROI情報";
            // 
            // button_マスク画像
            // 
            this.button_マスク画像.Location = new System.Drawing.Point(4, 33);
            this.button_マスク画像.Name = "button_マスク画像";
            this.button_マスク画像.Size = new System.Drawing.Size(75, 23);
            this.button_マスク画像.TabIndex = 10;
            this.button_マスク画像.Text = "マスク画像";
            this.button_マスク画像.UseVisualStyleBackColor = true;
            this.button_マスク画像.Click += new System.EventHandler(this.OnClick_マスク画像);
            // 
            // checkBox_black
            // 
            this.checkBox_black.AutoSize = true;
            this.checkBox_black.Location = new System.Drawing.Point(4, 63);
            this.checkBox_black.Name = "checkBox_black";
            this.checkBox_black.Size = new System.Drawing.Size(81, 16);
            this.checkBox_black.TabIndex = 11;
            this.checkBox_black.Text = "黒領域のみ";
            this.checkBox_black.UseVisualStyleBackColor = true;
            // 
            // checkBox_all
            // 
            this.checkBox_all.AutoSize = true;
            this.checkBox_all.Location = new System.Drawing.Point(4, 86);
            this.checkBox_all.Name = "checkBox_all";
            this.checkBox_all.Size = new System.Drawing.Size(60, 16);
            this.checkBox_all.TabIndex = 12;
            this.checkBox_all.Text = "全領域";
            this.checkBox_all.UseVisualStyleBackColor = true;
            // 
            // メイン画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(507, 341);
            this.Controls.Add(this.checkBox_all);
            this.Controls.Add(this.checkBox_black);
            this.Controls.Add(this.button_マスク画像);
            this.Controls.Add(this.label_roi_info);
            this.Controls.Add(this.button_csv出力);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_roi2);
            this.Controls.Add(this.textBox_roi1);
            this.Controls.Add(this.button_ROI);
            this.Controls.Add(this.button_検査対象);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "メイン画面";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button_検査対象;
        private System.Windows.Forms.Button button_ROI;
        private System.Windows.Forms.TextBox textBox_roi1;
        private System.Windows.Forms.TextBox textBox_roi2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_csv出力;
        private System.Windows.Forms.Label label_roi_info;
        private System.Windows.Forms.Button button_マスク画像;
        private System.Windows.Forms.CheckBox checkBox_black;
        private System.Windows.Forms.CheckBox checkBox_all;
    }
}

