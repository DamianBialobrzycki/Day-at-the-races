using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Day_at_the_races
{
    public class Bet
    {
        public int Amount; // Ilość postawionych pieniędzy
        public int Dog; // Numer psa, na którego postawiono
        public Guy Bettor; // Facet, który zawarł zakład

        public string GetDescription()
        {
            // Zwraca string, który określa, kto obstawił wyścig, jak dużo pieniędzy
            // postawił i na którego psa ("Janek postawił 8 zł na psa numer 4").
            // Jeżeli ilość jest równa zero, zakład nie został zawarty
            // ("Janek nie zawarł zakładu)
            Bettor = new Guy();

            if (Amount == 0)
                return Bettor.Name + " nie zawarł zakładu";

            return Bettor.Name + "postawił " + Amount + " zł na psa numer " + Dog;
        }

        public int PayOut(int Winner)
        {
            // Parametrem jest zwycięzca wyścigu. Jeżeli pies wygrał,
            // zwróć wartość postawioną. W przeciwnym razie zwróć wartość
            // postawioną ze znakiem minus

            if (Dog == Winner)
                return Amount;
            else
                return -Amount;
        }
    }
}
