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

        public InserirComSPModel? InserirDespesa(CadastrarDespesaReq model)
        {
            var retornoRepos = _despesaRepository.CadastrarDespesa(model);
            if (retornoRepos?.Id == "0")
                throw new Exception("Essa despesa já foi cadastrada!");
            return retornoRepos;
        }

        public List<DespesaModel> ConsultarDespesa(ConsultarDespesaReq model)
        {
            var retornoRepos = _despesaRepository.ConsultarDespesa(model);            
            return retornoRepos;
        }

        public InserirComSPModel BaixarDespesa(BaixarDespesaReq model)
        {
            var retornoRepos = _despesaRepository.BaixarDespesa(model);
            if (retornoRepos.Id == "0") throw new Exception("Despesa não foi encontrada, refaça a operação.");
            return retornoRepos;
        }

        public InserirComSPModel AlterarDespesa(AlterarDespesaReq model)
        {
            var retornoRepos = _despesaRepository.AlterarDespesa(model);
            if (retornoRepos.Id == "0") throw new Exception("Não foi possível alterar a despesa, campo não encontrado.");
            return retornoRepos;
        }
    }
}
