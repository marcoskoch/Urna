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

        public string CadastrarPartido(Partido partido)
        {
            string message;
            if(BaseDePartidos.ValidarSePartidoExiste(partido.Nome, partido.Sigla))
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
            if(BaseDePartidos.ValidarSePartidoExiste(partido.Nome, partido.Sigla))
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
