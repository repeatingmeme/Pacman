namespace Pacman
{
  partial class Main
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
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        this.pctPlayField = new System.Windows.Forms.PictureBox();
        this.tmrStep = new System.Windows.Forms.Timer(this.components);
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.lblScore = new System.Windows.Forms.Label();
        this.lblLivesCount = new System.Windows.Forms.Label();
        this.lblPause = new System.Windows.Forms.Label();
        this.lblStart = new System.Windows.Forms.Label();
        this.lblHelp = new System.Windows.Forms.Label();
        this.tmrSplash = new System.Windows.Forms.Timer(this.components);
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.pctPlayField)).BeginInit();
        this.SuspendLayout();
        // 
        // pctPlayField
        // 
        this.pctPlayField.Image = global::Pacman.Properties.Resources.start;
        this.pctPlayField.Location = new System.Drawing.Point(0, 0);
        this.pctPlayField.Margin = new System.Windows.Forms.Padding(4);
        this.pctPlayField.Name = "pctPlayField";
        this.pctPlayField.Size = new System.Drawing.Size(500, 500);
        this.pctPlayField.TabIndex = 0;
        this.pctPlayField.TabStop = false;
        // 
        // tmrStep
        // 
        this.tmrStep.Interval = 200;
        this.tmrStep.Tick += new System.EventHandler(this.tmrStep_Tick);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.ForeColor = System.Drawing.Color.Coral;
        this.label1.Location = new System.Drawing.Point(446, 507);
        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(35, 13);
        this.label1.TabIndex = 2;
        this.label1.Text = "label1";
        this.label1.Visible = false;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.ForeColor = System.Drawing.Color.Coral;
        this.label2.Location = new System.Drawing.Point(331, 507);
        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(35, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "label2";
        this.label2.Visible = false;
        // 
        // lblScore
        // 
        this.lblScore.AutoSize = true;
        this.lblScore.BackColor = System.Drawing.Color.Black;
        this.lblScore.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblScore.ForeColor = System.Drawing.Color.Coral;
        this.lblScore.Location = new System.Drawing.Point(317, 510);
        this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblScore.Name = "lblScore";
        this.lblScore.Size = new System.Drawing.Size(23, 23);
        this.lblScore.TabIndex = 4;
        this.lblScore.Text = "0";
        // 
        // lblLivesCount
        // 
        this.lblLivesCount.AutoSize = true;
        this.lblLivesCount.Font = new System.Drawing.Font("Courier New", 15.75F);
        this.lblLivesCount.ForeColor = System.Drawing.Color.Coral;
        this.lblLivesCount.Location = new System.Drawing.Point(192, 510);
        this.lblLivesCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblLivesCount.Name = "lblLivesCount";
        this.lblLivesCount.Size = new System.Drawing.Size(23, 23);
        this.lblLivesCount.TabIndex = 5;
        this.lblLivesCount.Text = "3";
        // 
        // lblPause
        // 
        this.lblPause.BackColor = System.Drawing.Color.Transparent;
        this.lblPause.Font = new System.Drawing.Font("Courier New", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblPause.ForeColor = System.Drawing.Color.Coral;
        this.lblPause.Location = new System.Drawing.Point(-7, 498);
        this.lblPause.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblPause.Name = "lblPause";
        this.lblPause.Size = new System.Drawing.Size(507, 39);
        this.lblPause.TabIndex = 6;
        this.lblPause.Text = "Paused";
        this.lblPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        this.lblPause.Visible = false;
        // 
        // lblStart
        // 
        this.lblStart.AutoSize = true;
        this.lblStart.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblStart.ForeColor = System.Drawing.Color.DodgerBlue;
        this.lblStart.Location = new System.Drawing.Point(412, 510);
        this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblStart.Name = "lblStart";
        this.lblStart.Size = new System.Drawing.Size(75, 23);
        this.lblStart.TabIndex = 8;
        this.lblStart.Text = "Start";
        this.lblStart.Click += new System.EventHandler(this.lblStart_Click_1);
        // 
        // lblHelp
        // 
        this.lblHelp.AutoSize = true;
        this.lblHelp.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblHelp.ForeColor = System.Drawing.Color.DodgerBlue;
        this.lblHelp.Location = new System.Drawing.Point(13, 510);
        this.lblHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.lblHelp.Name = "lblHelp";
        this.lblHelp.Size = new System.Drawing.Size(62, 23);
        this.lblHelp.TabIndex = 9;
        this.lblHelp.Text = "Help";
        this.lblHelp.Click += new System.EventHandler(this.lblHelp_Click);
        // 
        // tmrSplash
        // 
        this.tmrSplash.Enabled = true;
        this.tmrSplash.Interval = 2400;
        this.tmrSplash.Tick += new System.EventHandler(this.tmrSplash_Tick_1);
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Font = new System.Drawing.Font("Courier New", 15.75F);
        this.label4.ForeColor = System.Drawing.Color.Coral;
        this.label4.Location = new System.Drawing.Point(97, 510);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(88, 23);
        this.label4.TabIndex = 10;
        this.label4.Text = "Lives:";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Font = new System.Drawing.Font("Courier New", 15.75F);
        this.label5.ForeColor = System.Drawing.Color.Coral;
        this.label5.Location = new System.Drawing.Point(222, 510);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(88, 23);
        this.label5.TabIndex = 11;
        this.label5.Text = "Score:";
        // 
        // Main
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Black;
        this.ClientSize = new System.Drawing.Size(500, 538);
        this.Controls.Add(this.lblPause);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.lblHelp);
        this.Controls.Add(this.lblStart);
        this.Controls.Add(this.lblLivesCount);
        this.Controls.Add(this.lblScore);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.pctPlayField);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.Name = "Main";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "PacMan";
        this.Load += new System.EventHandler(this.Main_Load);
        this.Shown += new System.EventHandler(this.Main_Shown);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
        ((System.ComponentModel.ISupportInitialize)(this.pctPlayField)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pctPlayField;
    private System.Windows.Forms.Timer tmrStep;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblScore;
    private System.Windows.Forms.Label lblLivesCount;
    private System.Windows.Forms.Label lblPause;
    private System.Windows.Forms.Label lblStart;
    private System.Windows.Forms.Label lblHelp;
    private System.Windows.Forms.Timer tmrSplash;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
  }
}

