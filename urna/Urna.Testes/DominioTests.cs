using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using urna;

namespace Urna.Testes
{
    [TestClass]
    public class DominioTests
    {
        /*[TestMethod]
        public void MedodoCadastraPartidoECandidato()
        {
            Eleicao eleicao = new Eleicao();
            Partido partido = new Partido("Um partido", "somos 1 partido", "S1P");
            PartidoRepositorio pr = new PartidoRepositorio();
            CandidatoRepositorio cr = new CandidatoRepositorio();
            string nomeC = "Nome completo";
            string nomeP = "Nome pop";
            DateTime dataNasc = new DateTime(1949, 3, 3);
            string regTRE = "RegTRE";
            int idPartido = 5;
            int numero = 09098;
            int idCargo = 1;
            Candidato candidato = new Candidato(nomeC, nomeP, dataNasc, regTRE, idPartido, "", numero, idCargo, true);

            string msgCadastroPartido = eleicao.CadastrarPartido(partido);
            string msgCadastroCandidato = eleicao.CadastrarCandidato(candidato);

            string message1 = "Candidato cadastrado com sucesso";
            string message2 = "Partido cadastrado com sucesso";

            bool achouCandidato = cr.BuscarPorNumero(numero) != null;
            bool achouPartido = pr.BuscarPorId(5) != null;

            Assert.AreEqual(msgCadastroPartido, message2);
            Assert.AreEqual(msgCadastroCandidato, message1);
            Assert.IsTrue(achouCandidato);
            Assert.IsTrue(achouPartido);

        }*/

        [TestMethod]
        public void CandidatoNãoéCadastradoPorCausaDoNomeNulo()
        {
            Eleicao eleicao = new Eleicao();
            CandidatoRepositorio cr = new CandidatoRepositorio();
            string nomeC = "";
            string nomeP = "";
            DateTime dataNasc = new DateTime(1949, 3, 3);
            string regTRE = "regTRE2";
            int idPartido = 1;
            int numero = 011101;
            int idCargo = 1;
            Candidato candidato = new Candidato(nomeC, nomeP, dataNasc, regTRE, idPartido, "", numero, idCargo, true);

            string msgCadastroCandidato = eleicao.CadastrarCandidato(candidato);

            string message1 = "O nome popular e o nome Completo não podem estar vazios";

            bool achouCandidato = cr.BuscarPorNumero(numero) != null;

            Assert.AreEqual(msgCadastroCandidato, message1);
            Assert.IsFalse(achouCandidato);
        }
    }
}
