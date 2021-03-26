using System;

namespace Desafio.Dto
{
    public struct BracketDto
    {
        public BracketDto(string bracket, int grupo)
        {
            this.Bracket = bracket;
            this.Grupo = grupo;
        }

        public string Bracket { get; set; }

        public int Grupo { get; set; }

    }
}
