using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using CompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly CompraAgg.ISolicitacaoCompraRepository compraRepository;

        public RegistrarCompraCommandHandler(CompraAgg.ISolicitacaoCompraRepository compraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.compraRepository = compraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new CompraAgg.SolicitacaoCompra(request.NomeFornecedor, request.UsuarioSolicitante);
            compraRepository.RegistrarCompra(compra);

            Commit();
            PublishEvents(compra.Events);

            return Task.FromResult(true);
        }
    }
}
