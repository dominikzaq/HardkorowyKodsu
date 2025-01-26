namespace Client
{
    partial class MainForm
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
            list = new ListBox();
            gridColumns = new DataGridView();
            btnLoadViews = new Button();
            btnLoadTables = new Button();
            ((System.ComponentModel.ISupportInitialize)gridColumns).BeginInit();
            SuspendLayout();
            // 
            // list
            // 
            list.Location = new Point(11, 12);
            list.Name = "list";
            list.Size = new Size(188, 604);
            list.TabIndex = 4;
            list.SelectedIndexChanged += listTables_SelectedIndexChanged;
            // 
            // gridColumns
            // 
            gridColumns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridColumns.Location = new Point(227, 12);
            gridColumns.Name = "gridColumns";
            gridColumns.RowHeadersWidth = 51;
            gridColumns.Size = new Size(899, 602);
            gridColumns.TabIndex = 1;
            gridColumns.DataBindingComplete += GridColumns_DataBindingComplete;
            // 
            // btnLoadViews
            // 
            btnLoadViews.Location = new Point(12, 630);
            btnLoadViews.Name = "btnLoadViews";
            btnLoadViews.Size = new Size(187, 69);
            btnLoadViews.TabIndex = 3;
            btnLoadViews.Text = "Load Views";
            btnLoadViews.UseVisualStyleBackColor = true;
            btnLoadViews.Click += btnLoadViews_Click;
            // 
            // btnLoadTables
            // 
            btnLoadTables.Location = new Point(218, 630);
            btnLoadTables.Name = "btnLoadTables";
            btnLoadTables.Size = new Size(187, 69);
            btnLoadTables.TabIndex = 6;
            btnLoadTables.Text = "Load Tables";
            btnLoadTables.UseVisualStyleBackColor = true;
            btnLoadTables.Click += btnLoadTables_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1185, 726);
            Controls.Add(btnLoadTables);
            Controls.Add(btnLoadViews);
            Controls.Add(gridColumns);
            Controls.Add(list);
            Name = "MainForm";
            Text = "AdventureWork";
            ((System.ComponentModel.ISupportInitialize)gridColumns).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox list;
        private DataGridView gridColumns;
        private Button btnLoadViews;
        private Button btnLoadTables;
    }
}
