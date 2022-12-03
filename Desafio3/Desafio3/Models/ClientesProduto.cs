using System;
using System.Collections.Generic;

namespace Desafio3.Models;

public partial class ClientesProduto
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int IdProduto { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
