using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_ColineSoft.DAL.DataEnums.General
{
    public class GeneralEnums
    {
        public enum EstadoCivelEnum
        {
            Indefinido = 0,
            Solterio = 1,
            Casado = 2,
            Viúvo = 3,
            Desquitado = 4,
            Divorciado = 5,
            Marital = 6
        }

        public enum SimNaoEnum
        {
            Nao = 0,
            Sim = 1
        }

        public enum SexoEnum
        {
            Indefinido = 0,
            Masculino = 1,
            Feminino = 2
        }

        public enum MesesEnum
        {
            Janeiro = 1,
            Fevereiro = 2,
            Marco = 3,
            Abril = 4,
            Maio = 5,
            Junho = 6,
            Julho = 7,
            Agosto = 8,
            Setembrop = 9,
            Outubro = 10,
            Novembro = 11,
            Dezembro = 12
        }

        public enum DiasSemanaEnum
        {
            Domingo = 1,
            Segunda = 2,
            Terca = 3,
            Quarta = 4,
            Quinta = 5,
            Sexta = 6,
            Sabado = 7
        }

        public enum TipoPessoaEnum
        {
            Fisica = 1,
            Juridica = 2
        }
    }
}
