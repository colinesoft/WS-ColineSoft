using System.Runtime.CompilerServices;
using System.Text;

namespace WS_ColineSoft.Functions
{
    public enum CriptoValues
    {
        Cripto = 0,
        Uncripto = 1
    }
    public static class FunctionsString
    {
        #region EXTENSIONS
        /// <summary>
        /// Método de extensão para criptar/descriptar uma string mediante uma chave int.
        /// Lucas Aguiar
        /// </summary>
        /// <param name="keycode">Chave para criptografar ou descriptografar (padrão 1)</param>
        /// <param name="cmd">Define o comando para Cripto ou Uncripto (padrão Cripto)</param>
        /// <returns></returns>
        public static string Cripto(this string str, int keycode = 1, CriptoValues cmd = CriptoValues.Cripto)
        {
            const string SIMBOLOS_VALIDOS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*()-_=+[]{} .<>áéíóúàèìòùâêîôûãõÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇç";
            const string SIMBOLOS_SUBSTIT = "çaÇbÕcÃdÛeÔfÎgÊhÂiÙjÒkÌlÈmÀnÚoÓpÍqÉrÁsõtãuûvôwîxêyâzù0ò1ì2è3à4ú5ó6í7é8á9>A<B.C D}E{F]G[H+I=J_K-L)M(N*O&P%Q$R#S@T!UVWXYZ";
            string retorno = "";
            int pos;
            char letraSubstituta;

            for (int i = 0; i < keycode; i++)
            {
                foreach (var item in str)
                {
                    pos = cmd == CriptoValues.Cripto ? SIMBOLOS_VALIDOS.IndexOf(item) : SIMBOLOS_SUBSTIT.IndexOf(item);
                    letraSubstituta = cmd == CriptoValues.Cripto ? SIMBOLOS_SUBSTIT.ElementAt(pos) : SIMBOLOS_VALIDOS.ElementAt(pos);
                    retorno = letraSubstituta + retorno; 
                }
                i++;
                str = retorno;
            }
            return retorno;
        }

        /// <summary>
        /// Método para inverter os caracteres de um string
        /// Lucas Aguiar
        /// </summary>
        /// <param name="str">string que será invertido</param>
        /// <returns></returns>
        public static string InverterString(this string str)
        {
            var retorno = "";
            foreach(var item in str)
                retorno = item + retorno;
            return retorno;
        }

        /// <summary>
        /// Método de extensão para retornar apenas números
        /// Lucas Aguiar
        /// </summary>
        /// <param name="str">string que será usada</param>
        /// <returns></returns>
        public static string SomenteNumeros(this string str)
        {
            return String.Join("", System.Text.RegularExpressions.Regex.Split(str, @"[^\d]"));
        }
        #endregion EXTENSIONS

        /// <summary>
        /// Método Valida CPF
        /// Marcoratti
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool CpfValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Método Valida CNPJ
        /// Marcoratti
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool CnpjValido(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        /// <summary>
        /// Método Valida PIS
        /// Marcoratti
        /// </summary>
        /// <param name="pis"></param>
        /// <returns></returns>
        public static bool PisValido(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }

        /// <summary>
        /// Formata um CPF válido para para a máscara ###.###.###-##
        /// Lucas Aguiar
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static string FormatarCpf(string cpf)
        {
            if (!CpfValido(cpf))
                return cpf;
            return Convert.ToUInt64(cpf.PadLeft(11, '0')).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Método para formatar Cnpj válido para márcara 00.000.000.0000-00
        /// Lucas Aguiar
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static string FormatarCnpj(string cnpj)
        {
            if (!CnpjValido(cnpj))
                return cnpj;
            return Convert.ToUInt64(cnpj.PadLeft(14, '0')).ToString(@"00\.000\.000\.0000\-00");
        }

        /// <summary>
        /// Método para formatar PIS válido com máscara 000.00000.00.0
        /// </summary>
        /// <param name="pis"></param>
        /// <returns></returns>
        public static string FormatarPis(string pis)
        {
            if (!PisValido(pis))
                return pis;
            return Convert.ToUInt64(pis.PadLeft(11, '0')).ToString(@"000\.00000\.00\.0");
            
        }
    }
}