using System;
using System.Windows.Forms;

namespace Sea_Battle
{
    public partial class ShowDataBaseForm : Form
    {
        public ShowDataBaseForm()
        {
            InitializeComponent();
        }

        private void ShowDataBaseForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kP_dbDataSet.SeaBattleDB". При необходимости она может быть перемещена или удалена.
            this.seaBattleDBTableAdapter.Fill(this.kP_dbDataSet.SeaBattleDB);
        }
    }
}
