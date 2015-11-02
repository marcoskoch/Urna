using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public class Eleicoes
    {
        public CargoRepositorio BaseDeCargos { get; set; }
        public PartidoRepositorio BaseDePartidos { get; set; }
        public CandidatoRepositorio BaseDeCandidatos { get; set; }

        public Eleicoes()
        {
            BaseDeCargos = new CargoRepositorio();
            BaseDePartidos = new PartidoRepositorio();
            BaseDeCandidatos = new CandidatoRepositorio();
        }

        public string CadastrarCandidato(Candidato candidato)
        {
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

        public string CadastrarPartido(Partido partido)
        {
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
    }
}
