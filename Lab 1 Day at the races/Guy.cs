using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_Day_at_the_races
{
    public class Guy
    {
        public string Name; // imię faceta
        public Bet MyBet; // Instancja klasy Bet przechowująca dane o zakładzie
        public int Cash; // Jak dużo pieniędzy posiada

        //Ostatnie dwa pola są kontrolkami GUI na formularzu
        public RadioButton MyRadioButton; // Moje pole wyboru
        public Label MyLabel; // Moja etykieta

        public void UpdateLabels()
        {
            // Ustaw MyLabel na opis zakłady, a napis obok
            // pola wyboru tak, aby pokazywał ilość pieniędzy ("Janek ma 43 zł")
        }

        public void ClearBet() { } // Wyczyść mój zakład, aby był równy zero

        public bool PlaceBet(int Amount, int DogToWin)
        {
            // Ustal nowy zakład i przechowaj go w polu MyBet
            // Zwróć true, jeżeli facet ma wystarczającą ilość pieniędzy, aby obstawić
        }

        public void Collect(int Winner)
        {
            // Poproś o wypłatę zakładu i zaktualizuj etykiety
        }
    }
}
