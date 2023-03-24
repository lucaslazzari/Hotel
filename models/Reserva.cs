using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reserva
    {
        public Reserva(int id, Suite suite, int diasReservados)
        {
            Id = id;
            Suite = suite;
            DiasReservados = diasReservados;
        }

        public int Id { get; set; }
        public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public void AdicionarHospede(Pessoa hospede)
        {
            if (Hospedes.Count < Suite.Capacidade)
            {
                Hospedes.Add(hospede);
            }
            else
            {
                throw new Exception("O numero de hospedes é maior do suportavel na suite");
            }
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorTotalReserva()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = valor - (valor / 10);
            }
            return valor;
        }


        public override string ToString()
        {
            return $"ID:{Id} SUITE:{Suite.TipoSuite} CAPACIDADE:{Suite.Capacidade}  " +
                   $"VALOR DIARIA:{Suite.ValorDiaria} VALOR TOTAL:{CalcularValorTotalReserva()} " +
                   $"HOSPEDES: {Hospedes}";
        }
    }
}