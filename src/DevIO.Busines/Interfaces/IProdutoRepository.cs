using DevIO.Busines.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Busines.Interfaces
{
   public  interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);

        Task<IEnumerable<Produto>> ObertProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
