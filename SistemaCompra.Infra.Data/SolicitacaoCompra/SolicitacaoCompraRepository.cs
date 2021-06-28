using System;
using System.Linq;
using CompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : CompraAgg.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }
        public void RegistrarCompra(CompraAgg.SolicitacaoCompra entity)
        {
            context.Set<CompraAgg.SolicitacaoCompra>().Add(entity);
        }
    }
}
