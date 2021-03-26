using Desafio.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Business.Interfaces
{
    public interface IQuestaoBusiness
    {
        string PrimeiraQuestao(PrimeiraQuestaoDto primeiraQuestaoDto);

        string SegundaQuestao(SegundaQuestaoDto segundaQuestaoDto);

        string TerceiraQuestao(TerceiraQuestaoDto terceiraQuestaoDto);

        string QuartaQuestao(QuartaQuestaoDto quartaQuestaoDto);
    }
}
