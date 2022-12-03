using System;
using System.Collections.Generic;

namespace Desafio3.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int IdFornecedor { get; set; }

    public virtual ICollection<ClientesProduto> ClientesProdutos { get; } = new List<ClientesProduto>();

    public virtual Fornecedore IdFornecedorNavigation { get; set; } = null!;
}
