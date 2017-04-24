using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1_Day_at_the_races
{
    public partial class Form1 : Form
    {
        Guy[] Guys = new Guy[3];
        Greyhound[] GreyhoundArray = new Greyhound[4];
        public Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();
            
            // Zainicjowanie zmiennych dla każdego Guy
            Guys[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel };
            Guys[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            Guys[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetLabel };
            
            // Zainicjowanie zmiennych dla każdego Charta
            #region Greyhound initialization
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                MyRandom = MyRandomizer
            };
            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox5.Width,
                MyRandom = MyRandomizer
            };
            #endregion

            // Wyświetlenie minimalnej wartości zakładu na podstawie parametru minimum dla betAmount
            minimumBetLabel.Text = "Minimalny zakład: " + betAmount.Minimum + " zł";
            // Ustawienie domyślnie wyświetlanej osoby dla zakładu
            name.Text = "Joe";

            for (int i = 0; i < Guys.Length; i++)
            {
                Guys[i].ClearBet();
                Guys[i].UpdateLabels();
            }


        }

        #region Radio Buttons
        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = Guys[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = Guys[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = Guys[2].Name;
        }

        #endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            timer1.Start();
        }

        private void bet_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Guys.Length; i++)
            {
                if(Guys[i].Name == name.Text)
                {
                    if(Guys[i].PlaceBet((int)betAmount.Value, (int)betDog.Value))
                    {
                        Guys[i].MyBet = new Bet()
                        {
                            Amount = (int)betAmount.Value,
                            Dog = (int)betDog.Value,
                            Bettor = this.Guys[i]
                        };
                    }

                    Guys[i].MyLabel.Text = Guys[i].MyBet.GetDescription();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                if(GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    int winningDog = i + 1;
                    MessageBox.Show("Chart numer " + winningDog + " wygrał wyścig!");

                    for(int j = 0; j < Guys.Length; j++)
                    {
                        Guys[j].Collect(winningDog);
                        Guys[j].ClearBet();
                        Guys[j].UpdateLabels();
                    }

                    for (int k = 0; k < GreyhoundArray.Length; k++)
                        GreyhoundArray[k].TakeStartingPosition();
                    groupBox1.Enabled = true;
                    break;
                }
            }
        }
    }
}
