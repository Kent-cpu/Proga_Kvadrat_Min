
namespace Proga_lab_3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calculateBtnN1 = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateBtnN2 = new System.Windows.Forms.ToolStripMenuItem();
            this.googleSheetsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.dataExcelBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.answerField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateBtnN1,
            this.calculateBtnN2,
            this.googleSheetsBtn,
            this.dataExcelBtn,
            this.exitBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calculateBtnN1
            // 
            this.calculateBtnN1.Name = "calculateBtnN1";
            this.calculateBtnN1.Size = new System.Drawing.Size(164, 24);
            this.calculateBtnN1.Text = "Рассчитать для n = 1";
            this.calculateBtnN1.Click += new System.EventHandler(this.calculateBtnN1_Click_1);
            // 
            // calculateBtnN2
            // 
            this.calculateBtnN2.Name = "calculateBtnN2";
            this.calculateBtnN2.Size = new System.Drawing.Size(164, 24);
            this.calculateBtnN2.Text = "Рассчитать для n = 2";
            this.calculateBtnN2.Click += new System.EventHandler(this.calculateBtnN2_Click);
            // 
            // googleSheetsBtn
            // 
            this.googleSheetsBtn.Name = "googleSheetsBtn";
            this.googleSheetsBtn.Size = new System.Drawing.Size(119, 24);
            this.googleSheetsBtn.Text = "Google Sheets";
            this.googleSheetsBtn.Click += new System.EventHandler(this.googleSheetsBtn_Click);
            // 
            // dataExcelBtn
            // 
            this.dataExcelBtn.Name = "dataExcelBtn";
            this.dataExcelBtn.Size = new System.Drawing.Size(57, 24);
            this.dataExcelBtn.Text = "Excel";
            this.dataExcelBtn.Click += new System.EventHandler(this.dataExcel_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(67, 24);
            this.exitBtn.Text = "Выход";
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // answerField
            // 
            this.answerField.Location = new System.Drawing.Point(38, 65);
            this.answerField.Name = "answerField";
            this.answerField.Size = new System.Drawing.Size(318, 22);
            this.answerField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ответ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xColumn,
            this.yColumn});
            this.dataGridView1.Location = new System.Drawing.Point(12, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(402, 258);
            this.dataGridView1.TabIndex = 11;
            // 
            // xColumn
            // 
            this.xColumn.HeaderText = "X";
            this.xColumn.MinimumWidth = 6;
            this.xColumn.Name = "xColumn";
            this.xColumn.Width = 125;
            // 
            // yColumn
            // 
            this.yColumn.HeaderText = "Y";
            this.yColumn.MinimumWidth = 6;
            this.yColumn.Name = "yColumn";
            this.yColumn.Width = 125;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(532, 121);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(642, 421);
            this.zedGraphControl1.TabIndex = 12;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 609);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.answerField);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem calculateBtnN1;
        private System.Windows.Forms.ToolStripMenuItem googleSheetsBtn;
        private System.Windows.Forms.ToolStripMenuItem dataExcelBtn;
        private System.Windows.Forms.TextBox answerField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yColumn;
        private System.Windows.Forms.ToolStripMenuItem exitBtn;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripMenuItem calculateBtnN2;
    }
}

