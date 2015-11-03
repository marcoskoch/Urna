using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Eleicao
    {
        public CargoRepositorio BaseDeCargos { get; set; }
        public PartidoRepositorio BaseDePartidos { get; set; }
        public CandidatoRepositorio BaseDeCandidatos { get; set; }
        public VotoRepositorio BaseDeVotos { set; get; }
        public EleitorRepositorio BaseDeEleitores { set; get; }
        public bool EleicaoComecou { get; set; }
        
        public Eleicao()
        {
            BaseDeCargos = new CargoRepositorio();
            BaseDePartidos = new PartidoRepositorio();
            BaseDeCandidatos = new CandidatoRepositorio();
            BaseDeEleitores = new EleitorRepositorio();
            BaseDeVotos = new VotoRepositorio();
        }

        public void IniciarEleicoes()
        {
            EleicaoComecou = true;
        }

        public string ExibirEstatistica()
        {
            IList<Estatistica> lista = BaseDeVotos.BuscarEstatistica();
            string estatistica = "";
            foreach (Estatistica stat in lista)
            {
                estatistica += stat.ToString();
            }
                return estatistica;
        }

        public string CadastrarCandidato(Candidato candidato)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            bool nomeEstaVazio = string.IsNullOrEmpty(candidato.NomeCompleto) || string.IsNullOrEmpty(candidato.NomePopular);
            if (nomeEstaVazio)
            {
                message = "O nome popular e o nome Completo não podem estar vazios";
            }
            else
            {
                int idCargoPrefeito = BaseDeCargos.BuscarIDDoCargoPorNome("Prefeito");

                bool jaExistePrefeitoNestePartido = BaseDeCandidatos
                    .ExisteCandidatoAPrefeitoNestePartido(idCargoPrefeito, candidato.IDPartido);

                if(candidato.IDCargo == idCargoPrefeito && jaExistePrefeitoNestePartido)
                {
                    message = "Já existe um candidato a prefeito neste partido";
                }
                else
                {
                    if (BaseDeCandidatos.ValidarSeCandidatoExiste(candidato))
                    {
                        message = "O número, o registro TRE e o nome popular deve ser único";
                    }
                    else
                    {
                        BaseDeCandidatos.Cadastrar(candidato);
                        message = "Candidato cadastrado com sucesso";
                    }
                }
            }
            return message;
        }

        public string EditarCandidato(int id,Candidato candidato)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            bool nomeEstaVazio = string.IsNullOrEmpty(candidato.NomeCompleto) || string.IsNullOrEmpty(candidato.NomePopular);
            if (nomeEstaVazio)
            {
                message = "O nome popular e o nome Completo não podem estar vazios";
            }
            else
            {
                int idCargoPrefeito = BaseDeCargos.BuscarIDDoCargoPorNome("Prefeito");

                bool jaExistePrefeitoNestePartido = BaseDeCandidatos
                    .ExisteCandidatoAPrefeitoNestePartido(idCargoPrefeito, candidato.IDPartido);

                if (candidato.IDCargo == idCargoPrefeito && jaExistePrefeitoNestePartido)
                {
                    message = "Já existe um candidato a prefeito neste partido";
                }
                else
                {
                    if (BaseDeCandidatos.ValidarSeCandidatoExiste(candidato))
                    {
                        message = "O número, o registro TRE e o nome popular deve ser único";
                    }
                    else
                    {
                        BaseDeCandidatos.AtualizarPorId(id,candidato);
                        message = "Candidato editado com sucesso";
                    }
                }
            }
            return message;
        }

        public string DeletarCandidato(Candidato candidato)
        {
            string message;
            bool eCandidatoNuloOuBranco = "Voto Nulo".Equals(candidato.NomePopular)
                || "Voto em Branco".Equals(candidato.NomePopular);
            if (eCandidatoNuloOuBranco)
            {
                message = "Não é possível excluir candidado Voto Nulo e Candidato Voto Em Branco";
            }
            else
            {
                BaseDeCandidatos.DeletarPorNomePopular(candidato.NomePopular);
                message = "Candidato deletado com sucesso";
            }
            return message;
        }

        public string CadastrarPartido(Partido partido)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            if(!(BaseDePartidos.ValidarSeNaoPartidoExiste(partido.Nome, partido.Sigla)))
            {
                message = "Este partido já existe";
            }
            else
            {
                BaseDePartidos.Cadastrar(partido);
                message = "Partido cadastrado com sucesso";
            }
            return message;
        }

        public string EditarPartido(int id, Partido partido)
        {
            string message;
            if(!(BaseDePartidos.ValidarSeNaoPartidoExiste(partido.Nome, partido.Sigla)))
            {
                message = "O partido deve ter nome e sigla únicos";
            }
            else
            {
                BaseDePartidos.AtualizarPorId(id, partido);
                message = "Partido atualizado com sucesso";
            }
            return message;
        }

        public string DeletarPartido(int id)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            if(BaseDePartidos.BuscarPorId(id) == null)
            {
                message = "Não existem partidos com este ID";
            }
            else
            {
                BaseDePartidos.DeletarPorId(id);
                message = "Partido deletado com sucesso";
            }
            return message;
        }

        public string CadastrarCargo(Cargo cargo)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            if (BaseDeCargos.ValidarExistencia(cargo.Nome))
            {
                message = "Este cargo já existe";
            }
            else
            {
                BaseDeCargos.Cadastrar(cargo);
                message = "Cargo cadastrado com sucesso";
            }
            return message;
        }

        public string AtualizarCargoPorNome(string nome, Cargo cargo)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            if (BaseDeCargos.ValidarExistencia(nome))
            {
                //Verifica se está tentando alterar o nome para o mesmo nome de outro cargo
                //Se o nome for o mesmo do antigo tudo bem
                if (!(nome.Equals(cargo.Nome)) && BaseDeCargos.ValidarExistencia(cargo.Nome))
                {
                    message = "Não é possível atualizar o nome do cargo para um nome que já existe";
                }
                else
                {
                    BaseDeCargos.AtualizarPorNome(nome, cargo);
                    message = "Cargo atualizado com sucesso";
                }
            }
            else
            {
                message = "Este cargo não existe";
            }
            return message;
        }

        public string AtivarCargo(string nome)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            Cargo cargoAtivo = new Cargo(nome, 'A');
            if(BaseDeCargos.ValidarExistencia(nome))
            {
                BaseDeCargos.Atualizar(cargoAtivo);
                message = "Cargo ativado com sucesso";
            }
            else
            {
                message = "Este cargo não existe";
            }
            return message;
        }

        public string DesativarCargo(string nome)
        {
            if (EleicaoComecou)
                return "Alterações não podem ser feitas após o inicio das eleições";
            string message;
            Cargo cargoAtivo = new Cargo(nome, 'I');
            if (BaseDeCargos.ValidarExistencia(nome))
            {
                BaseDeCargos.Atualizar(cargoAtivo);
                message = "Cargo desativado com sucesso";
            }
            else
            {
                message = "Este cargo não existe";
            }
            return message;
        }

        public string RegistrarVoto (string cpf, int numeroCandidato)
        {
            string message = "";
            var candidato = BaseDeCandidatos.BuscarPorNumero(numeroCandidato);
            var eleitor = BaseDeEleitores.validarEleitor(cpf);
            if(eleitor && (candidato != null))
            {
                BaseDeVotos.RegistrarVoto(candidato.IdCandidato);
                message = "Voto registrado";
            } else if (candidato == null)
            {
                BaseDeVotos.RegistrarVoto(1);
                message = "Voto nulo";
            }

            return message;
        }
    }
}
