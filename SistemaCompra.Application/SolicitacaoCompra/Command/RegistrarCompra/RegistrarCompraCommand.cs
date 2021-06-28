using MediatR;
using System;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime Data { get; set; }
        public decimal TotalGeral { get; set; }
        public int Situacao { get; set; }

    }
}
