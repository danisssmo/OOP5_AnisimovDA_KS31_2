using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP5_AnisimovDA_KS31_2
{
    public partial class Form1 : Form
    {   
        private int addend1;
        private int addend2;
        private int minuend;
        private int subtrahend;
        private int multiplicand;
        private int multiplier;
        private int dividend;
        private int divisor;
        private int timeLeft;

        private Random randomizer = new Random();

        public Form1()  {  InitializeComponent();  }

        // Начало викторины
        private void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            dividend = multiplicand * multiplier;
            divisor = multiplicand;

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();

            timeLeft = 30;
            timeLabel.Text = timeLeft.ToString() + " seconds";

            timer1.Start();

            startButton.Enabled = false;
        }

        // Проверка ответов
        private bool CheckTheAnswer()
        {
            return (addend1 + addend2 == sum.Value) &&
                   (minuend - subtrahend == difference.Value) &&
                   (multiplicand * multiplier == product.Value) &&
                   (dividend / divisor == quotient.Value);
        }

        // Обработчик таймера
        private void timer1Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";

                if (timeLeft <= 5) { timeLabel.BackColor = Color.Red; }

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                timeLabel.BackColor = SystemColors.Control;

                if (CheckTheAnswer()) { MessageBox.Show("Правильно! Поздравляем!"); }
                else
                {
                    MessageBox.Show("Время вышло! Правильные ответы: " + (addend1 + addend2) + ", " +
                                    (minuend - subtrahend) + ", " + (multiplicand * multiplier) + ", " +
                                    (dividend / divisor), "Конец игры");
                }

                startButton.Enabled = true;
            }
        }

        private void inputClear(object sender, EventArgs e)
        {
            NumericUpDown numUpDown = sender as NumericUpDown;
            if (numUpDown != null) {  int lenghtOfAnswer = numUpDown.Value.ToString().Length;  numUpDown.Select(0, lenghtOfAnswer); }
        }


        // Звук при правильном ответе
        private void ValueChanged(object sender, EventArgs e)
        { if (CheckTheAnswer()) { System.Media.SystemSounds.Asterisk.Play(); } }


        // Начало
        private void startButton_Click(object sender, EventArgs e)  
            { StartTheQuiz(); sum.Value = 0; difference.Value = 0; product.Value = 0; quotient.Value = 0; }

         }
}
