using System.IO;
using System.Windows.Forms;

namespace Sea_Battle
{
    public partial class MatchesLogForm : Form
    {
        public MatchesLogForm()
        {
            InitializeComponent();
            richTextBox1.Text = File.ReadAllText(@"..\..\..\gamelog.txt");
        }
    }
}
