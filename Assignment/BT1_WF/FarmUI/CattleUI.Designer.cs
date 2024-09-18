namespace FarmUI
{
    partial class CattleUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AddData = new Button();
            Title = new Label();
            SoBoLabel = new Label();
            SoCuuLabel = new Label();
            SoDeLabel = new Label();
            SoCuu = new TextBox();
            SoBo = new TextBox();
            SoDe = new TextBox();
            TiengKeuLabel = new Label();
            CattleType = new ComboBox();
            CattleGridView = new DataGridView();
            LoadData = new Button();
            ((System.ComponentModel.ISupportInitialize)CattleGridView).BeginInit();
            SuspendLayout();
            // 
            // AddData
            // 
            AddData.Font = new Font("Segoe UI", 13F);
            AddData.Location = new Point(688, 383);
            AddData.Name = "AddData";
            AddData.Size = new Size(100, 46);
            AddData.TabIndex = 0;
            AddData.Text = "Add";
            AddData.UseVisualStyleBackColor = true;
            AddData.Click += AddData_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 24F);
            Title.Location = new Point(245, 20);
            Title.Name = "Title";
            Title.Size = new Size(301, 45);
            Title.TabIndex = 1;
            Title.Text = "Cattle Management";
            // 
            // SoBoLabel
            // 
            SoBoLabel.AutoSize = true;
            SoBoLabel.Font = new Font("Segoe UI", 13F);
            SoBoLabel.Location = new Point(44, 393);
            SoBoLabel.Name = "SoBoLabel";
            SoBoLabel.Size = new Size(54, 25);
            SoBoLabel.TabIndex = 2;
            SoBoLabel.Text = "SoBo";
            // 
            // SoCuuLabel
            // 
            SoCuuLabel.AutoSize = true;
            SoCuuLabel.Font = new Font("Segoe UI", 13F);
            SoCuuLabel.Location = new Point(245, 395);
            SoCuuLabel.Name = "SoCuuLabel";
            SoCuuLabel.Size = new Size(64, 25);
            SoCuuLabel.TabIndex = 3;
            SoCuuLabel.Text = "SoCuu";
            // 
            // SoDeLabel
            // 
            SoDeLabel.AutoSize = true;
            SoDeLabel.Font = new Font("Segoe UI", 13F);
            SoDeLabel.Location = new Point(472, 392);
            SoDeLabel.Name = "SoDeLabel";
            SoDeLabel.Size = new Size(55, 25);
            SoDeLabel.TabIndex = 4;
            SoDeLabel.Text = "SoDe";
            // 
            // SoCuu
            // 
            SoCuu.Location = new Point(331, 395);
            SoCuu.Name = "SoCuu";
            SoCuu.Size = new Size(100, 23);
            SoCuu.TabIndex = 5;
            // 
            // SoBo
            // 
            SoBo.Location = new Point(117, 395);
            SoBo.Name = "SoBo";
            SoBo.Size = new Size(100, 23);
            SoBo.TabIndex = 6;
            // 
            // SoDe
            // 
            SoDe.Location = new Point(558, 395);
            SoDe.Name = "SoDe";
            SoDe.Size = new Size(100, 23);
            SoDe.TabIndex = 7;
            // 
            // TiengKeuLabel
            // 
            TiengKeuLabel.AutoSize = true;
            TiengKeuLabel.Font = new Font("Segoe UI", 13F);
            TiengKeuLabel.Location = new Point(144, 332);
            TiengKeuLabel.Name = "TiengKeuLabel";
            TiengKeuLabel.Size = new Size(165, 25);
            TiengKeuLabel.TabIndex = 8;
            TiengKeuLabel.Text = "Nghe tiếng kêu của";
            // 
            // CattleType
            // 
            CattleType.FormattingEnabled = true;
            CattleType.Location = new Point(331, 335);
            CattleType.Name = "CattleType";
            CattleType.Size = new Size(100, 23);
            CattleType.TabIndex = 9;
            CattleType.SelectedIndexChanged += comboBoxCattle_SelectedIndexChanged;
            // 
            // CattleGridView
            // 
            CattleGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CattleGridView.Location = new Point(60, 79);
            CattleGridView.Name = "CattleGridView";
            CattleGridView.Size = new Size(680, 237);
            CattleGridView.TabIndex = 10;
            // 
            // LoadData
            // 
            LoadData.Font = new Font("Segoe UI", 13F);
            LoadData.Location = new Point(688, 322);
            LoadData.Name = "LoadData";
            LoadData.Size = new Size(100, 46);
            LoadData.TabIndex = 11;
            LoadData.Text = "Load";
            LoadData.UseVisualStyleBackColor = true;
            LoadData.Click += LoadData_Click;
            // 
            // CattleUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoadData);
            Controls.Add(CattleGridView);
            Controls.Add(CattleType);
            Controls.Add(TiengKeuLabel);
            Controls.Add(SoDe);
            Controls.Add(SoBo);
            Controls.Add(SoCuu);
            Controls.Add(SoDeLabel);
            Controls.Add(SoCuuLabel);
            Controls.Add(SoBoLabel);
            Controls.Add(Title);
            Controls.Add(AddData);
            Name = "CattleUI";
            Text = "CattleUI";
            ((System.ComponentModel.ISupportInitialize)CattleGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void comboBoxCattle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCattle = CattleType.SelectedItem.ToString();
            string tiengKeu = this._cattleService.Keu(selectedCattle);
            if(tiengKeu != "")
                MessageBox.Show(tiengKeu);
        }

        #endregion

        private Button AddData;
        private Label Title;
        private Label SoBoLabel;
        private Label SoCuuLabel;
        private Label SoDeLabel;
        private TextBox SoCuu;
        private TextBox SoBo;
        private TextBox SoDe;
        private Label TiengKeuLabel;
        private ComboBox CattleType;
        private DataGridView CattleGridView;
        private Button LoadData;
    }
}
