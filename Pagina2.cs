using PrjConexao1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjBDDG
{
    public partial class Pagina2 : Form
    {
        ClasseConexao con;
        DataTable dt;
        Compartilha cp = new Compartilha();


        public Pagina2()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Pagina1 pagina1 = new Pagina1();
            pagina1.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            String sql = "Select * from contatos1 where nome like '%" + textBox1.Text + "%'";
            MessageBox.Show("Pesquisa realizada com sucesso!");
            con = new ClasseConexao();
            dt = con.executarSQL(sql);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                String id = dataGridView1.Rows[e.RowIndex].
                    Cells[0].Value.ToString();
                // MessageBox.Show(id);
                cp.setId(id);
            }
            
        }
    }
}