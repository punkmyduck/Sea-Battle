namespace Sea_Battle
{
    partial class ShowDataBaseForm
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
            this.seaBattleDBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kP_dbDataSet = new Sea_Battle.KP_dbDataSet();
            this.seaBattleDBTableAdapter = new Sea_Battle.KP_dbDataSetTableAdapters.SeaBattleDBTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeGameStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeGameEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerMovesCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computerMovesCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstMoveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerHitsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computerHitsCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.didPlayerGiveUpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.algorithmDifficultyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.seaBattleDBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kP_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // seaBattleDBBindingSource
            // 
            this.seaBattleDBBindingSource.DataMember = "SeaBattleDB";
            this.seaBattleDBBindingSource.DataSource = this.kP_dbDataSet;
            // 
            // kP_dbDataSet
            // 
            this.kP_dbDataSet.DataSetName = "KP_dbDataSet";
            this.kP_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // seaBattleDBTableAdapter
            // 
            this.seaBattleDBTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateTimeGameStartDataGridViewTextBoxColumn,
            this.dateTimeGameEndDataGridViewTextBoxColumn,
            this.winnerDataGridViewTextBoxColumn,
            this.playerMovesCountDataGridViewTextBoxColumn,
            this.computerMovesCountDataGridViewTextBoxColumn,
            this.firstMoveDataGridViewTextBoxColumn,
            this.playerHitsCountDataGridViewTextBoxColumn,
            this.computerHitsCountDataGridViewTextBoxColumn,
            this.didPlayerGiveUpDataGridViewTextBoxColumn,
            this.algorithmDifficultyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.seaBattleDBBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1125, 612);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // dateTimeGameStartDataGridViewTextBoxColumn
            // 
            this.dateTimeGameStartDataGridViewTextBoxColumn.DataPropertyName = "DateTimeGameStart";
            this.dateTimeGameStartDataGridViewTextBoxColumn.HeaderText = "DateTimeGameStart";
            this.dateTimeGameStartDataGridViewTextBoxColumn.Name = "dateTimeGameStartDataGridViewTextBoxColumn";
            // 
            // dateTimeGameEndDataGridViewTextBoxColumn
            // 
            this.dateTimeGameEndDataGridViewTextBoxColumn.DataPropertyName = "DateTimeGameEnd";
            this.dateTimeGameEndDataGridViewTextBoxColumn.HeaderText = "DateTimeGameEnd";
            this.dateTimeGameEndDataGridViewTextBoxColumn.Name = "dateTimeGameEndDataGridViewTextBoxColumn";
            // 
            // winnerDataGridViewTextBoxColumn
            // 
            this.winnerDataGridViewTextBoxColumn.DataPropertyName = "Winner";
            this.winnerDataGridViewTextBoxColumn.HeaderText = "Winner";
            this.winnerDataGridViewTextBoxColumn.Name = "winnerDataGridViewTextBoxColumn";
            // 
            // playerMovesCountDataGridViewTextBoxColumn
            // 
            this.playerMovesCountDataGridViewTextBoxColumn.DataPropertyName = "PlayerMovesCount";
            this.playerMovesCountDataGridViewTextBoxColumn.HeaderText = "PlayerMovesCount";
            this.playerMovesCountDataGridViewTextBoxColumn.Name = "playerMovesCountDataGridViewTextBoxColumn";
            // 
            // computerMovesCountDataGridViewTextBoxColumn
            // 
            this.computerMovesCountDataGridViewTextBoxColumn.DataPropertyName = "ComputerMovesCount";
            this.computerMovesCountDataGridViewTextBoxColumn.HeaderText = "ComputerMovesCount";
            this.computerMovesCountDataGridViewTextBoxColumn.Name = "computerMovesCountDataGridViewTextBoxColumn";
            // 
            // firstMoveDataGridViewTextBoxColumn
            // 
            this.firstMoveDataGridViewTextBoxColumn.DataPropertyName = "FirstMove";
            this.firstMoveDataGridViewTextBoxColumn.HeaderText = "FirstMove";
            this.firstMoveDataGridViewTextBoxColumn.Name = "firstMoveDataGridViewTextBoxColumn";
            // 
            // playerHitsCountDataGridViewTextBoxColumn
            // 
            this.playerHitsCountDataGridViewTextBoxColumn.DataPropertyName = "PlayerHitsCount";
            this.playerHitsCountDataGridViewTextBoxColumn.HeaderText = "PlayerHitsCount";
            this.playerHitsCountDataGridViewTextBoxColumn.Name = "playerHitsCountDataGridViewTextBoxColumn";
            // 
            // computerHitsCountDataGridViewTextBoxColumn
            // 
            this.computerHitsCountDataGridViewTextBoxColumn.DataPropertyName = "ComputerHitsCount";
            this.computerHitsCountDataGridViewTextBoxColumn.HeaderText = "ComputerHitsCount";
            this.computerHitsCountDataGridViewTextBoxColumn.Name = "computerHitsCountDataGridViewTextBoxColumn";
            // 
            // didPlayerGiveUpDataGridViewTextBoxColumn
            // 
            this.didPlayerGiveUpDataGridViewTextBoxColumn.DataPropertyName = "DidPlayerGiveUp";
            this.didPlayerGiveUpDataGridViewTextBoxColumn.HeaderText = "DidPlayerGiveUp";
            this.didPlayerGiveUpDataGridViewTextBoxColumn.Name = "didPlayerGiveUpDataGridViewTextBoxColumn";
            // 
            // algorithmDifficultyDataGridViewTextBoxColumn
            // 
            this.algorithmDifficultyDataGridViewTextBoxColumn.DataPropertyName = "AlgorithmDifficulty";
            this.algorithmDifficultyDataGridViewTextBoxColumn.HeaderText = "AlgorithmDifficulty";
            this.algorithmDifficultyDataGridViewTextBoxColumn.Name = "algorithmDifficultyDataGridViewTextBoxColumn";
            // 
            // ShowDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 612);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ShowDataBaseForm";
            this.Text = "ShowDataBaseForm";
            this.Load += new System.EventHandler(this.ShowDataBaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seaBattleDBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kP_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private KP_dbDataSet kP_dbDataSet;
        private System.Windows.Forms.BindingSource seaBattleDBBindingSource;
        private KP_dbDataSetTableAdapters.SeaBattleDBTableAdapter seaBattleDBTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeGameStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeGameEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerMovesCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn computerMovesCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstMoveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerHitsCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn computerHitsCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn didPlayerGiveUpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithmDifficultyDataGridViewTextBoxColumn;
    }
}