using Desafio.Business.Interfaces;
using Desafio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Business
{
    public class QuestaoBusiness : IQuestaoBusiness
    {
        public string PrimeiraQuestao(PrimeiraQuestaoDto primeiraQuestaoDto)
        {
            int[] resultado = new int[] { };

            var lista = primeiraQuestaoDto.Numeros.ToList<int>();
            var flagAlvoEncontrado = false;

            lista.FirstOrDefault(x =>
            {
                for(int i = 0; i < lista.Count; i++)
                {
                    if (x + lista[i] == primeiraQuestaoDto.Alvo)
                    {
                        flagAlvoEncontrado = true;

                        var index = lista.IndexOf(x);
                        
                        resultado = new int[] { index, i };
                        break;
                    }
                }

                if (flagAlvoEncontrado)
                    return true;

                return false;
            });


            if (resultado.Length == 0)
                return "Não foi encontrado uma combinação que some dois index para atingir o Alvo definido.";

            return $"O Alvo encontrado foi através do somatório dos index [{resultado[0]}, {resultado[1]}].";
        }

        public string SegundaQuestao(SegundaQuestaoDto segundaQuestaoDto)
        {
            var bracketAbertura = new BracketDto[]
            {
                new BracketDto("{", 1),
                new BracketDto("[", 2),
                new BracketDto("(", 3) 
            };

            var bracketFechamento = new BracketDto[] 
            {
                new BracketDto("}", 1),
                new BracketDto("]", 2),
                new BracketDto(")", 3) 
            };

            var bracketsArray = segundaQuestaoDto.Brackets.ToArray();

            if (bracketFechamento.Any(x => x.Bracket == bracketsArray[0].ToString()))
                return $"{segundaQuestaoDto.Brackets}  NÃO";

            for(int i = 0; i < bracketsArray.Length; i++)
            {
                
                var posicaoTrasParaFrente = bracketsArray.Length - (i + 1);

                if (posicaoTrasParaFrente < i)
                    break;

                var bracketCorrente = bracketsArray[i].ToString();
                var grupoBracketAbertura = bracketAbertura.Where(x => x.Bracket == bracketCorrente).FirstOrDefault();

                
                var bracketTrasParaFrente = bracketsArray[posicaoTrasParaFrente].ToString();
                
                var grupoBracketFechamento = bracketFechamento.Where(x => x.Bracket == bracketTrasParaFrente).FirstOrDefault();

                if (grupoBracketAbertura.Grupo != grupoBracketFechamento.Grupo)
                {
                    return $"{segundaQuestaoDto.Brackets}  NÃO";
                }
            }

            return $"{segundaQuestaoDto.Brackets}  SIM";
        }

        public string TerceiraQuestao(TerceiraQuestaoDto terceiraQuestaoDto)
        {
            var listaDeGanhos = new List<int>();

            for(int i = 0; i < terceiraQuestaoDto.Acoes.Length; i++)
            {
                var valorCompra = terceiraQuestaoDto.Acoes[i];

                for (int j = 0; j < terceiraQuestaoDto.Acoes.Length; j++)
                {
                    if (i <= j)
                        continue;

                    var valorGanho = valorCompra - terceiraQuestaoDto.Acoes[j];

                    if (valorGanho <= 0)
                        continue;

                    listaDeGanhos.Add(valorGanho);
                }
            }

            if (listaDeGanhos.Count == 0)
                return "0";

            return listaDeGanhos.Max().ToString();
        }

        public string QuartaQuestao(QuartaQuestaoDto quartaQuestaoDto)
        {
            int soma = default(int);
            const int ALTURA_MAXIMA_BLOCO = 3;
            List<int> indicesJaVerificados = new List<int>();

            for (int i = 0; i < quartaQuestaoDto.MapaElevacao.Length; i++)
            {
                var blocoElevacao = quartaQuestaoDto.MapaElevacao[i];

                if (blocoElevacao == 0)
                    continue;

                for (int j = 0; j < quartaQuestaoDto.MapaElevacao.Length; j++)
                {
                    if (j <= i)
                        continue;

                    var proximoBlocoElevacao = quartaQuestaoDto.MapaElevacao[j];

                    if (blocoElevacao > proximoBlocoElevacao)
                        continue;

                    var distancia = j - (i + 1);

                    var k = i;

                    while (k < j)
                    {
                        // verifica se é o limite inicia e limite final de uma retençao
                        if (k == i || k == j)
                        {
                            k++;
                            continue;
                        }

                        if (indicesJaVerificados.Any(x => x == k))
                        {
                            k++;
                            continue;
                        }


                        if (quartaQuestaoDto.MapaElevacao[k] == 0)
                            soma += quartaQuestaoDto.MapaElevacao[i];
                        else if (ALTURA_MAXIMA_BLOCO == quartaQuestaoDto.MapaElevacao[i])
                            soma += (ALTURA_MAXIMA_BLOCO - quartaQuestaoDto.MapaElevacao[k]);
                        else
                            soma += (ALTURA_MAXIMA_BLOCO - (quartaQuestaoDto.MapaElevacao[i] - quartaQuestaoDto.MapaElevacao[k])) - 1;

                        indicesJaVerificados.Add(k);

                        k++;
                    }

                    break;
                }
            }

            return soma.ToString();
        }
    }
}
