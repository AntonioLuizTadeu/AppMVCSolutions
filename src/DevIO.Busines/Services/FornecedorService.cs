﻿using DevIO.Busines.Interfaces;
using DevIO.Busines.Models;
using DevIO.Busines.Models.Validations;
using DevIO.Business.Models.Validations.Documentos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Busines.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificador notificador): base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            // validar o estado da entidade
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
               || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um  fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Adicional(fornecedor);
        }


        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado");
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

      

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProdutoEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
