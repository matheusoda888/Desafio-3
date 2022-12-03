using Desafio3.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text;

namespace Desafio3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            AtosEntity3Context contexto = new AtosEntity3Context();
            Cliente p = new Cliente();
            p.Nome = textBox_Nome.Text;


            contexto.Clientes.Add(p);
            contexto.SaveChanges();
            
        }

        private void buttonGravarFornecedor_Click(object sender, EventArgs e)
        {
            AtosEntity3Context contexto = new AtosEntity3Context();
            Fornecedore f = new Fornecedore();
            f.Nome = textBox_NomeFornecedor.Text;


            contexto.Fornecedores.Add(f);
            contexto.SaveChanges();
        }

        private void buttonGravarProduto_Click(object sender, EventArgs e)
        {
            AtosEntity3Context contexto = new AtosEntity3Context();
            Produto p = new Produto();
            p.Nome = textBox_NomeProduto.Text;
            p.IdFornecedor = int.Parse(textBox_FornecedorProduto.Text);


            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        private void buttonGravarCompra_Click(object sender, EventArgs e)
        {
            textBox_IdCliente.Enabled = false;
            AtosEntity3Context contexto = new AtosEntity3Context();
            ClientesProduto p = new ClientesProduto();
            p.IdCliente = int.Parse(textBox_IdCliente.Text);
            p.IdProduto = int.Parse(textBox_IdProduto.Text);

            contexto.ClientesProdutos.Add(p);
            contexto.SaveChanges();
            
            
        }
       

        private void button_GerarNota_Click(object sender, EventArgs e)
        {
            AtosEntity3Context contexto = new AtosEntity3Context();

            //int idFiltro = int.Parse(textBox_IdCliente.Text);


            //Produto p = contexto.Produtos.ToList().FirstOrDefault();
            //.Include(t => t.Nome).FirstOrDefault(t => t.Id == idFiltro)
            //List<ClientesProduto> lista = (from ClientesProduto p in contexto.ClientesProdutos join Cliente c in contexto.Clientes on p.IdCliente equals c.Id select p )
            //    .Where(t => t.IdCliente == int.Parse(textBox_IdCliente.Text)).ToList<ClientesProduto>();

            List<ClientesProduto> lista = (from ClientesProduto p in contexto.ClientesProdutos join Cliente c in contexto.Clientes on p.IdCliente equals c.Id select p)
                .Where(t => t.IdCliente == int.Parse(textBox_IdCliente.Text)).ToList<ClientesProduto>();

            List<Produto> lista2 = (from Produto p in contexto.Produtos select p)
                            .ToList<Produto>();
            List<string> lista3 = new List<string>();
            
            foreach (ClientesProduto compra in lista)
            {
                    foreach(Produto pro in lista2)
                    {
                    if (compra.IdProduto == pro.Id)
                    {
                        lista3.Add(pro.Nome.ToString());
                        
                    }
                    }
                    
            }
            

            listBox1.DataSource = lista3;
            

            

            
            
            

            
            //button1.Enabled = true;
            StreamWriter writer = new StreamWriter(@"C:\Users\OS2676\Desktop\Nota.txt");//apos o diretorio é possivel por o paramentro append = true para sobrescrever auto
            foreach (string s in lista3)
            {
                writer.WriteLine(s+' ');
            }
            //PERCORRE CADA item NA LISTA linhas E OS ESCREVE NO ARQUIVO
            

            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtosEntity3Context contexto = new AtosEntity3Context();
            List<ClientesProduto> p = contexto.ClientesProdutos.ToList<ClientesProduto>();
            foreach(ClientesProduto item in p)
            {
                if (item.IdCliente == int.Parse(textBox_IdCliente.Text))
                {
                    contexto.ClientesProdutos.Remove(item);
                    contexto.SaveChanges();
                }
                
            }

        }
    }
}