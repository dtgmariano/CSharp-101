namespace GA
{
    partial class MapView
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
            this.zgcMap = new ZedGraph.ZedGraphControl();
            this.btGo = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.GAtimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numGenerations = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numPopulation = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numPoints = new System.Windows.Forms.NumericUpDown();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // zgcMap
            // 
            this.zgcMap.Location = new System.Drawing.Point(256, 12);
            this.zgcMap.Name = "zgcMap";
            this.zgcMap.ScrollGrace = 0D;
            this.zgcMap.ScrollMaxX = 0D;
            this.zgcMap.ScrollMaxY = 0D;
            this.zgcMap.ScrollMaxY2 = 0D;
            this.zgcMap.ScrollMinX = 0D;
            this.zgcMap.ScrollMinY = 0D;
            this.zgcMap.ScrollMinY2 = 0D;
            this.zgcMap.Size = new System.Drawing.Size(778, 611);
            this.zgcMap.TabIndex = 0;
            // 
            // btGo
            // 
            this.btGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btGo.Location = new System.Drawing.Point(158, 165);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(54, 32);
            this.btGo.TabIndex = 1;
            this.btGo.Text = "Go";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btStart.Location = new System.Drawing.Point(98, 165);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(54, 32);
            this.btStart.TabIndex = 2;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // GAtimer
            // 
            this.GAtimer.Tick += new System.EventHandler(this.GAtimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Timer (ms):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of points:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numGenerations);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numPopulation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numPoints);
            this.groupBox1.Controls.Add(this.btGo);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numTimer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 203);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // numGenerations
            // 
            this.numGenerations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numGenerations.Location = new System.Drawing.Point(157, 122);
            this.numGenerations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(67, 26);
            this.numGenerations.TabIndex = 9;
            this.numGenerations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Generations nº:";
            // 
            // numPopulation
            // 
            this.numPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numPopulation.Location = new System.Drawing.Point(157, 90);
            this.numPopulation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPopulation.Name = "numPopulation";
            this.numPopulation.Size = new System.Drawing.Size(67, 26);
            this.numPopulation.TabIndex = 7;
            this.numPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Population size:";
            // 
            // numPoints
            // 
            this.numPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numPoints.Location = new System.Drawing.Point(157, 26);
            this.numPoints.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPoints.Name = "numPoints";
            this.numPoints.Size = new System.Drawing.Size(67, 26);
            this.numPoints.TabIndex = 6;
            this.numPoints.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numTimer
            // 
            this.numTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numTimer.Location = new System.Drawing.Point(157, 58);
            this.numTimer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTimer.Name = "numTimer";
            this.numTimer.Size = new System.Drawing.Size(67, 26);
            this.numTimer.TabIndex = 3;
            this.numTimer.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 221);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(238, 25);
            this.progressBar.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(12, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Distance = ";
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 630);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zgcMap);
            this.Name = "MapView";
            this.Text = "MapView";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zgcMap;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Timer GAtimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPoints;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numGenerations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPopulation;
        private System.Windows.Forms.Label label4;
    }
}