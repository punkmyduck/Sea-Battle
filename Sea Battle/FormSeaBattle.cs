using MyDB.Scheme;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

namespace Sea_Battle
{
    public partial class FormSeaBattle : Form
    {
        private string lastGamePath = @"..\..\..\lastGame.txt";
        private SeaLogger logger;
        private string strcompl = "hard";
        bool littleWait = false;
        private SeaBattleField computerField;
        private SeaBattleField playerField;
        private SeaBattleAI ai;
        public FormSeaBattle()
        {
            InitializeComponent();
            сохранитьИгруToolStripMenuItem.Enabled = false;
            computerField = new SeaBattleField();
            playerField = new SeaBattleField();

            ConfigurateDGVForField(dataGridViewComputerField);
            ConfigurateDGVForField(dataGridViewPlayerField);

            DrawSeaBattleField(dataGridViewPlayerField, playerField);
            comboBoxDifficulitySelection.SelectedIndex = 2;
            ai = new SeaBattleAIClassicModuleRandomSide(playerField);
        }
        private void ConfigurateDGVForField(DataGridView dgv)
        {
            for (int i = 0; i < 10; i++)
            {
                dgv.Columns.Add($"{i}", $"{i + 1}");
                dgv.Columns[i].Width = 40;
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.Rows.Add();
                dgv.Rows[i].Height = 40;
            }
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersWidth = 40;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ScrollBars = ScrollBars.None;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.ShowCellErrors = false;
            dgv.ShowCellToolTips = false;
            dgv.ShowEditingIcon = false;
            dgv.ShowRowErrors = false;
            dgv.CurrentCell.Selected = false;
        }

        /*/async/*/
        private void ComputerShooting()
        {
            littleWait = true;
            bool b = true;
            while (b)
            {
                byte hit = playerField.ShootIntoFieldCell(ai.shots[ai.move].X, ai.shots[ai.move].Y);
                logger.AddLine(false, ai.shots[ai.move].X, ai.shots[ai.move].Y, hit);
                b = ai.hit[ai.move++];
                //await Task.Run(() => Thread.Sleep(250));
                if (playerField.destroyedShipsCount == 10)
                {
                    DrawSeaBattleField(dataGridViewPlayerField, playerField);
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (computerField.GetFieldCellValue(i, j) == 1) dataGridViewComputerField.Rows[j].Cells[i].Style.BackColor = Color.LightBlue;
                        }
                    }
                    logger.FinishLog(false, false);
                    SendToDB();
                    MessageBox.Show("Поражение!", "Игра закончена", MessageBoxButtons.OK);
                    RestartGame();
                    littleWait = false;
                    return;
                }
            }
            DrawSeaBattleField(dataGridViewPlayerField, playerField);
            littleWait = false;
        }

        private void SendToDB()
        {
            DBWorker db = new DBWorker();
            db.AddLines(logger.GetInfo());
        }

        private void RestartGame()
        {
            panelOverlap.Visible = true;
            buttonGiveUp.Enabled = false;
            buttonStartGame.Enabled = true;
            buttonFillRandomly.Enabled = true;
            comboBoxDifficulitySelection.Enabled = true;
            сохранитьИгруToolStripMenuItem.Enabled = false;
            загрузитьИгруToolStripMenuItem.Enabled = true;

            playerField = new SeaBattleField(playerField);
            DrawSeaBattleField(dataGridViewPlayerField, playerField);
            comboBoxDifficulitySelection_SelectedIndexChanged(null, null);
            computerField = new SeaBattleField();
            ClearSeaBattleField(dataGridViewComputerField);
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            panelOverlap.Visible = false;
            buttonStartGame.Enabled = false;
            buttonFillRandomly.Enabled = false;
            comboBoxDifficulitySelection.Enabled = false;
            buttonGiveUp.Enabled = true;
            сохранитьИгруToolStripMenuItem.Enabled = true;
            загрузитьИгруToolStripMenuItem.Enabled = false;

            logger = new SeaLogger(strcompl);
            if (new Random().Next(0, 2) == 0)
            {
                ComputerShooting();
            }
        }

        private void buttonGiveUp_Click(object sender, EventArgs e)
        {
            logger.FinishLog(false, true);
            SendToDB();
            RestartGame();
        }

        private void dataGridViewComputerField_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewComputerField.CurrentCell.Selected = false;
            dataGridViewComputerField.Update();
            if (e.RowIndex < 0 || e.RowIndex > 9 || e.ColumnIndex < 0 || e.ColumnIndex > 9 || littleWait) return;

            byte b = computerField.ShootIntoFieldCell(e.ColumnIndex, e.RowIndex);
            logger.AddLine(true, e.ColumnIndex, e.RowIndex, b);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (computerField.GetFieldCellValue(j, i) == 2) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;
                    if (computerField.GetFieldCellValue(j, i) == 3) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    if (computerField.GetFieldCellValue(j, i) == 5) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                }
            }

            if (computerField.destroyedShipsCount == 10)
            {
                MessageBox.Show("Победа!", "Игра закончена", MessageBoxButtons.OK);
                logger.FinishLog(true, false);
                SendToDB();
                RestartGame();
                return;
            }

            if (b == 5) ComputerShooting();
        }

        private void buttonFillRandomly_Click(object sender, EventArgs e)
        {
            playerField = new SeaBattleField();
            comboBoxDifficulitySelection_SelectedIndexChanged(sender, e);
            DrawSeaBattleField(dataGridViewPlayerField, playerField);
        }

        private void DrawSeaBattleField(DataGridView dgv, SeaBattleField field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field.GetFieldCellValue(i, j) == 0) dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (field.GetFieldCellValue(i, j) == 1) dgv.Rows[i].Cells[j].Style.BackColor = Color.LightBlue;
                    if (field.GetFieldCellValue(i, j) == 2) dgv.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;
                    if (field.GetFieldCellValue(i, j) == 3) dgv.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    if (field.GetFieldCellValue(i, j) == 4) dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (field.GetFieldCellValue(i, j) == 5) dgv.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                }
            }
            dgv.Update();
        }

        private void ClearSeaBattleField(DataGridView dgv)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                e.PaintBackground(e.CellBounds, true);
                using (SolidBrush br = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString($"{(char)('A' + e.RowIndex)}", e.CellStyle.Font, br, e.CellBounds.X + 13, e.CellBounds.Y + 13);
                }
                e.Handled = true;
            }
        }
        private void dataGridViewPlayerField_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {
                e.PaintBackground(e.CellBounds, true);
                using (SolidBrush br = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString($"{(char)('A' + e.RowIndex)}", e.CellStyle.Font, br, e.CellBounds.X + 13, e.CellBounds.Y + 13);
                }
                e.Handled = true;
            }
        }
        private void dataGridViewPlayerField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewPlayerField.CurrentCell.Selected = false;
        }

        private void buttonCollapseForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCloseGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxDifficulitySelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxDifficulitySelection.SelectedIndex)
            {
                case 0:
                    ai = new SeaBattleAIRandom(playerField);
                    strcompl = "easy";
                    break;
                case 1:
                    ai = new SeaBattleAILongestLineFinding(playerField);
                    strcompl = "normal";
                    break;
                case 2:
                    ai = new SeaBattleAIClassicModuleRandomSide(playerField);
                    strcompl = "hard";
                    break;
            }
        }

        private void показатьБазуДанныхToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowDataBaseForm formdb = new ShowDataBaseForm();
            formdb.Show();
        }

        private void показатьЖурналМатчейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatchesLogForm formlog = new MatchesLogForm();
            formlog.Show();
        }
        public void saveCurGame()
        {
            string str1 = "";
            string str2 = "";
            int n = ai.move;
            Info info = logger.GetInfo();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    str1 += $"{playerField.GetFieldCellValue(i, j)}";
                    str2 += $"{computerField.GetFieldCellValue(i, j)}";
                }
            }
            str1 += "\n";
            str2 += "\n";
            File.WriteAllText(lastGamePath, "");
            File.AppendAllText(lastGamePath, str1);
            File.AppendAllText(lastGamePath, str2);
            File.AppendAllText(lastGamePath, $"{n}\n");
            File.AppendAllText(lastGamePath, $"{playerField.destroyedShipsCount}\n");
            File.AppendAllText(lastGamePath, $"{computerField.destroyedShipsCount}\n");
            File.AppendAllText(lastGamePath, $"{Convert.ToInt32(comboBoxDifficulitySelection.SelectedIndex)}");
        }

        private void сохранитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCurGame();
            MessageBox.Show("Игра успешно сохранена!", "Сохранение игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void загрузитьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadPrevGame();
            MessageBox.Show("Игра успешно загружена!", "Загрузка игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void loadPrevGame()
        {
            string str = File.ReadAllText(lastGamePath);
            byte[,] player = new byte[10, 10];
            byte[,] comp = new byte[10, 10];

            int m = 0;
            int n = 0;
            int pnt = 0;
            for (int i = 0; str[i] != '\n'; i++)
            {
                player[m, n] = (byte)Convert.ToInt16(str[i] - '0');
                n++;
                if (n==10)
                {
                    m++;
                    n = 0;
                }
                pnt = i;
            }
            m = 0;
            n = 0;
            pnt += 2;
            for (int i = pnt; str[i] != '\n'; i++)
            {
                comp[m, n] = (byte)Convert.ToInt16(str[i] - '0');
                n++;
                if (n == 10)
                {
                    m++;
                    n = 0;
                }
                pnt = i;
            }
            pnt += 2;
            string sss = $"{str[pnt]}{str[pnt + 1]}";
            int sh = 1;
            if (str[pnt + 1] == '\n') sh = 0;
            int mv = Convert.ToInt32(sss);
            int dp = Convert.ToInt32(str[pnt + 2 + sh]-'0');
            int dc = Convert.ToInt32(str[pnt + 4 + sh]-'0');
            playerField = new SeaBattleField(player, dp);
            comboBoxDifficulitySelection.SelectedIndex = Convert.ToInt32(str[pnt + 6 + sh]-'0');
            //MessageBox.Show($"{mv} {dp} {dc} {comboBoxDifficulitySelection.SelectedIndex}");
            comboBoxDifficulitySelection_SelectedIndexChanged(null, null);
            ai.move = mv;
            computerField = new SeaBattleField(comp, dc);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (computerField.GetFieldCellValue(j, i) == 2) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.DeepSkyBlue;
                    if (computerField.GetFieldCellValue(j, i) == 3) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    if (computerField.GetFieldCellValue(j, i) == 5) dataGridViewComputerField.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                }
            }
            DrawSeaBattleField(dataGridViewPlayerField, playerField);

            panelOverlap.Visible = false;
            buttonStartGame.Enabled = false;
            buttonFillRandomly.Enabled = false;
            comboBoxDifficulitySelection.Enabled = false;
            buttonGiveUp.Enabled = true;
            сохранитьИгруToolStripMenuItem.Enabled = true;
            загрузитьИгруToolStripMenuItem.Enabled = false;
            logger = new SeaLogger(strcompl);
        }
    }
}