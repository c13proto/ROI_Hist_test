﻿namespace ROI_Hist_test
{
    partial class Form1
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
            this.button_開く = new System.Windows.Forms.Button();
            this.button_ROI = new System.Windows.Forms.Button();
            this.textBox_roi1 = new System.Windows.Forms.TextBox();
            this.textBox_roi2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(85, 4);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(410, 325);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // button_開く
            // 
            this.button_開く.Location = new System.Drawing.Point(4, 4);
            this.button_開く.Name = "button_開く";
            this.button_開く.Size = new System.Drawing.Size(75, 23);
            this.button_開く.TabIndex = 1;
            this.button_開く.Text = "開く";
            this.button_開く.UseVisualStyleBackColor = true;
            this.button_開く.Click += new System.EventHandler(this.OnClick開く);
            // 
            // button_ROI
            // 
            this.button_ROI.Location = new System.Drawing.Point(4, 134);
            this.button_ROI.Name = "button_ROI";
            this.button_ROI.Size = new System.Drawing.Size(75, 23);
            this.button_ROI.TabIndex = 2;
            this.button_ROI.Text = "ROI実行";
            this.button_ROI.UseVisualStyleBackColor = true;
            this.button_ROI.Click += new System.EventHandler(this.OnClick_ROI実行);
            // 
            // textBox_roi1
            // 
            this.textBox_roi1.Location = new System.Drawing.Point(29, 84);
            this.textBox_roi1.Name = "textBox_roi1";
            this.textBox_roi1.Size = new System.Drawing.Size(50, 19);
            this.textBox_roi1.TabIndex = 3;
            this.textBox_roi1.Text = "0,0";
            // 
            // textBox_roi2
            // 
            this.textBox_roi2.Location = new System.Drawing.Point(29, 109);
            this.textBox_roi2.Name = "textBox_roi2";
            this.textBox_roi2.Size = new System.Drawing.Size(50, 19);
            this.textBox_roi2.TabIndex = 4;
            this.textBox_roi2.Text = "100,100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ROI p1->p2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "p1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "p2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(507, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_roi2);
            this.Controls.Add(this.textBox_roi1);
            this.Controls.Add(this.button_ROI);
            this.Controls.Add(this.button_開く);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button_開く;
        private System.Windows.Forms.Button button_ROI;
        private System.Windows.Forms.TextBox textBox_roi1;
        private System.Windows.Forms.TextBox textBox_roi2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

