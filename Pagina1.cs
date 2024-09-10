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
    public partial class Pagina1 : Form
    {
        ClasseConexao con;
        DataTable dt;
        int pos = 0;
        int qtde = 0;
        Compartilha cp = new Compartilha();

        public Pagina1()
        {
            InitializeComponent();
        }

        private void mostrarDados(int pos)
        {
            txtId.Text = dt.Rows[pos]["id"].ToString();
            txtNome.Text = dt.Rows[pos]["nome"].ToString();
            txtEmail.Text = dt.Rows[pos]["email"].ToString();
            txtTelefone.Text = dt.Rows[pos]["telefone"].ToString();
        }

        private void consultarDados(String sql)
        {
            con = new ClasseConexao();
            dt = new DataTable();
            dt = con.executarSQL(sql);
            qtde = dt.Rows.Count;
            mostrarDados(0);
        }




        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pagina2 pagina2 = new Pagina2();
            pagina2.ShowDialog();
           
        }

        private void Pagina1_Load(object sender, EventArgs e)
        {
            consultarDados("select * from contatos1");
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos >= qtde - 1)
                pos = qtde - 1;
            mostrarDados(pos);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos < 0)
                pos = 0;
            mostrarDados(pos);
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            pos = 0;
            mostrarDados(pos);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            pos = qtde - 1;
            mostrarDados(pos);
        }

        private void Pagina1_Activated(object sender, EventArgs e)
        {
            if (cp.getId() != null)
            {
                con = new ClasseConexao();
                dt = new DataTable();
                String sql = "select * from contatos1 where id= " + cp.getId();
                dt = con.executarSQL(sql);
                qtde = dt.Rows.Count;
                mostrarDados(0);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
          
            String t0 = txtNome.Text;
            con = new ClasseConexao();
            con.executarSQL("DELETE FROM contatos1 WHERE Nome = '" + t0 + "'");
            consultarDados("select * from contatos1"); 
            MessageBox.Show("Deletado com sucesso!");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            String t1 = txtNome.Text, t2 = txtEmail.Text, t3 = txtTelefone.Text;
            con = new ClasseConexao(); 
            con.executarSQL("insert into contatos1 values('" + t1 + "','" + t2 + "','" + t3 + "');");
            consultarDados("select * from contatos1"); 
            MessageBox.Show("Incluído com sucesso!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            String t1 = txtNome.Text, t2 = txtEmail.Text, t3 = txtTelefone.Text;

            con = new ClasseConexao();
            con.executarSQL("UPDATE Contatos1 SET Nome = '" + t1 + "', Email = '" + t2 + "' WHERE Telefone = '" + t3 + "'");
            consultarDados("select * from contatos1");
            MessageBox.Show("Alterado com sucesso!"); 
        }
    }
}
