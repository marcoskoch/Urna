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
        public string CadastrarCargo(Cargo cargo)
        {
            string message;
            if (BaseDeCargos.ValidarExistencia(cargo))
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
            if(BaseDeCargos.ValidarExistencia(cargoAtivo))
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
            if (BaseDeCargos.ValidarExistencia(cargoAtivo))
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
