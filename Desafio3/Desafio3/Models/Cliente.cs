using System;
using System.Collections.Generic;

namespace Desafio3.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<ClientesProduto> ClientesProdutos { get; } = new List<ClientesProduto>();
}
