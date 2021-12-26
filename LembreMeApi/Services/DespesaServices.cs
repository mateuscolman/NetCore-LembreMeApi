using LembreMeApi.Domains.Dto;
using LembreMeApi.Models;
using LembreMeApi.Repository;

namespace LembreMeApi.Services
{
    public class DespesaServices
    {
        private readonly DespesaRepository _despesaRepository;

        public DespesaServices(DespesaRepository despesaRepository)
        {
            _despesaRepository = despesaRepository;
        }

        public InserirComSPModel InserirDesesa(CadastrarDespesaReq model)
        {
            return _despesaRepository.CadastrarDespesa(model);
        }
    }
}
