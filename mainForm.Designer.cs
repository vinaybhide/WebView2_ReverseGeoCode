namespace ReverseGeoCode
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetAddress = new System.Windows.Forms.Button();
            this.txtFullJson = new System.Windows.Forms.TextBox();
            this.txtParsedAddress = new System.Windows.Forms.TextBox();
            this.txtLatMap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLonMap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.lblpostalcode = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnSearchMapAddress = new System.Windows.Forms.Button();
            this.btnSearchMapLatLong = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(79, 35);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(138, 26);
            this.txtLat.TabIndex = 1;
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(311, 37);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(138, 26);
            this.txtLon.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Logitude:";
            // 
            // btnGetAddress
            // 
            this.btnGetAddress.Location = new System.Drawing.Point(481, 39);
            this.btnGetAddress.Name = "btnGetAddress";
            this.btnGetAddress.Size = new System.Drawing.Size(140, 35);
            this.btnGetAddress.TabIndex = 4;
            this.btnGetAddress.Text = "Get Address";
            this.btnGetAddress.UseVisualStyleBackColor = true;
            this.btnGetAddress.Click += new System.EventHandler(this.btnGetAddress_Click);
            // 
            // txtFullJson
            // 
            this.txtFullJson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullJson.Location = new System.Drawing.Point(648, 28);
            this.txtFullJson.Multiline = true;
            this.txtFullJson.Name = "txtFullJson";
            this.txtFullJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFullJson.Size = new System.Drawing.Size(1038, 64);
            this.txtFullJson.TabIndex = 5;
            // 
            // txtParsedAddress
            // 
            this.txtParsedAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParsedAddress.Location = new System.Drawing.Point(17, 98);
            this.txtParsedAddress.Multiline = true;
            this.txtParsedAddress.Name = "txtParsedAddress";
            this.txtParsedAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParsedAddress.Size = new System.Drawing.Size(1669, 99);
            this.txtParsedAddress.TabIndex = 6;
            // 
            // txtLatMap
            // 
            this.txtLatMap.Location = new System.Drawing.Point(115, 18);
            this.txtLatMap.Name = "txtLatMap";
            this.txtLatMap.Size = new System.Drawing.Size(138, 26);
            this.txtLatMap.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Latitude:";
            // 
            // txtLonMap
            // 
            this.txtLonMap.Location = new System.Drawing.Point(115, 60);
            this.txtLonMap.Name = "txtLonMap";
            this.txtLonMap.Size = new System.Drawing.Size(138, 26);
            this.txtLonMap.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Logitude:";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(74, 162);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(179, 26);
            this.txtStreet.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Street:";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(74, 194);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(179, 26);
            this.txtCity.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "City:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(74, 226);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(179, 26);
            this.txtState.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "State:";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(115, 258);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(138, 26);
            this.txtPostalCode.TabIndex = 17;
            // 
            // lblpostalcode
            // 
            this.lblpostalcode.AutoSize = true;
            this.lblpostalcode.Location = new System.Drawing.Point(10, 258);
            this.lblpostalcode.Name = "lblpostalcode";
            this.lblpostalcode.Size = new System.Drawing.Size(99, 20);
            this.lblpostalcode.TabIndex = 16;
            this.lblpostalcode.Text = "Postal Code:";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(17, 221);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnSearchMapAddress);
            this.splitContainer2.Panel1.Controls.Add(this.txtPostalCode);
            this.splitContainer2.Panel1.Controls.Add(this.lblpostalcode);
            this.splitContainer2.Panel1.Controls.Add(this.txtState);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.txtCity);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.txtStreet);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.btnSearchMapLatLong);
            this.splitContainer2.Panel1.Controls.Add(this.txtLonMap);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtLatMap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.webView21);
            this.splitContainer2.Size = new System.Drawing.Size(1669, 710);
            this.splitContainer2.SplitterDistance = 284;
            this.splitContainer2.TabIndex = 8;
            // 
            // btnSearchMapAddress
            // 
            this.btnSearchMapAddress.Location = new System.Drawing.Point(33, 300);
            this.btnSearchMapAddress.Name = "btnSearchMapAddress";
            this.btnSearchMapAddress.Size = new System.Drawing.Size(194, 55);
            this.btnSearchMapAddress.TabIndex = 18;
            this.btnSearchMapAddress.Text = "Search using Address";
            this.btnSearchMapAddress.UseVisualStyleBackColor = true;
            this.btnSearchMapAddress.Click += new System.EventHandler(this.btnSearchMapAddress_Click);
            // 
            // btnSearchMapLatLong
            // 
            this.btnSearchMapLatLong.Location = new System.Drawing.Point(33, 92);
            this.btnSearchMapLatLong.Name = "btnSearchMapLatLong";
            this.btnSearchMapLatLong.Size = new System.Drawing.Size(194, 55);
            this.btnSearchMapLatLong.TabIndex = 10;
            this.btnSearchMapLatLong.Text = "Search using Lat && Long";
            this.btnSearchMapLatLong.UseVisualStyleBackColor = true;
            this.btnSearchMapLatLong.Click += new System.EventHandler(this.btnSearchMapLatLong_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1379, 708);
            this.webView21.Source = new System.Uri("http://maps.google.com", System.UriKind.Absolute);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnGetAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtLon);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1680, 212);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1704, 943);
            this.Controls.Add(this.txtParsedAddress);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.txtFullJson);
            this.Controls.Add(this.groupBox1);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetAddress;
        private System.Windows.Forms.TextBox txtFullJson;
        private System.Windows.Forms.TextBox txtParsedAddress;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label lblpostalcode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLonMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLatMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSearchMapLatLong;
        private System.Windows.Forms.Button btnSearchMapAddress;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

