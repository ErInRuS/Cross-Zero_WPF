using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tic_tak_toy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //победы
        int[] score = new int[2];
        //макс шаги
        int steps = 0;
        //создание матрицы(поля игры) 3 на 3
        char[,] Marix = new char[3, 3];
        //переключатель хода
        bool hodX = false;
        public MainWindow()
        {
            InitializeComponent();
            Cross.Content = $"Крестики: {score[0]}";
            Zero.Content = $"Нолики: {score[1]}";
        }
        void method(int r,int g)
        {
            Cross.Content = $"Крестики: {score[0]}";
            Zero.Content = $"Нолики: {score[1]}";


            //проверка хода
            if (Marix[r, g] != 'O' & hodX)//если в клетке нет О и ход Х то тогда ставим Х
            {
                Marix[r, g] = 'X';
                hodX = false;
                steps++;
            }
            else if (Marix[r, g] != 'X' & !hodX)//если в клетке нет Х и ход О то тогда ставим О
            {
                Marix[r, g] = 'O';
                hodX = true;
                steps++;
            }
            else//если клетка заменена
            {
                MessageBox.Show("Ошибка хода!");
            }
            //отрисовка крестиков и ноликов
            r0g0.Content = Marix[0, 0];
            r0g1.Content = Marix[0, 1];
            r0g2.Content = Marix[0, 2];

            r1g0.Content = Marix[1, 0];
            r1g1.Content = Marix[1, 1];
            r1g2.Content = Marix[1, 2];

            r2g0.Content = Marix[2, 0];
            r2g1.Content = Marix[2, 1];
            r2g2.Content = Marix[2, 2];
            //прверка всех возможных ходов :D
            if (Marix[0, 0] == 'O' & Marix[0, 1] == 'O' & Marix[0, 2] == 'O' |
                Marix[1, 0] == 'O' & Marix[1, 1] == 'O' & Marix[1, 2] == 'O' |
                Marix[2, 0] == 'O' & Marix[2, 1] == 'O' & Marix[2, 2] == 'O' |
                Marix[0, 0] == 'O' & Marix[1, 1] == 'O' & Marix[2, 2] == 'O' |
                Marix[2, 0] == 'O' & Marix[1, 1] == 'O' & Marix[0, 2] == 'O'
                | Marix[0, 0] == 'O' & Marix[1, 0] == 'O' & Marix[2, 0] == 'O'
                | Marix[0, 1] == 'O' & Marix[1, 1] == 'O' & Marix[2, 1] == 'O'
                | Marix[0, 2] == 'O' & Marix[1, 2] == 'O' & Marix[2, 2] == 'O'
                )
            {
                score[1]++;
                //Спрашиваем закончить ли игру?
                var res = MessageBox.Show("Нолики победили!\nПродолжить?", "Игра закончена", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (res)
                {
                    case MessageBoxResult.Yes://если да
                        Array.Clear(Marix, 0, Marix.Length);

                        Cross.Content = $"Крестики: {score[0]}";
                        Zero.Content = $"Нолики: {score[1]}";

                        r0g0.Content = Marix[0, 0];
                        r0g1.Content = Marix[0, 1];
                        r0g2.Content = Marix[0, 2];

                        r1g0.Content = Marix[1, 0];
                        r1g1.Content = Marix[1, 1];
                        r1g2.Content = Marix[1, 2];

                        r2g0.Content = Marix[2, 0];
                        r2g1.Content = Marix[2, 1];
                        r2g2.Content = Marix[2, 2];
                        steps = 0;
                        break;
                    case MessageBoxResult.No://Если нет
                        this.Close();
                        break;
                }
            }
            if (Marix[0, 0] == 'X' & Marix[0, 1] == 'X' & Marix[0, 2] == 'X' |
                Marix[1, 0] == 'X' & Marix[1, 1] == 'X' & Marix[1, 2] == 'X' |
                Marix[2, 0] == 'X' & Marix[2, 1] == 'X' & Marix[2, 2] == 'X' |
                Marix[0, 0] == 'X' & Marix[1, 1] == 'X' & Marix[2, 2] == 'X' |
                Marix[2, 0] == 'X' & Marix[1, 1] == 'X' & Marix[0, 2] == 'X'
                | Marix[0, 0] == 'X' & Marix[1, 0] == 'X' & Marix[2, 0] == 'X'
                | Marix[0, 1] == 'X' & Marix[1, 1] == 'X' & Marix[2, 1] == 'X'
                | Marix[0, 2] == 'X' & Marix[1, 2] == 'X' & Marix[2, 2] == 'X')
            {
                score[0]++;
                var res = MessageBox.Show("Крестики победили!\nПродолжить?", "Игра закончена", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (res)
                {
                    case MessageBoxResult.Yes://если да
                        Array.Clear(Marix, 0, Marix.Length);

                        Cross.Content = $"Крестики: {score[0]}";
                        Zero.Content = $"Нолики: {score[1]}";

                        r0g0.Content = Marix[0, 0];
                        r0g1.Content = Marix[0, 1];
                        r0g2.Content = Marix[0, 2];

                        r1g0.Content = Marix[1, 0];
                        r1g1.Content = Marix[1, 1];
                        r1g2.Content = Marix[1, 2];

                        r2g0.Content = Marix[2, 0];
                        r2g1.Content = Marix[2, 1];
                        r2g2.Content = Marix[2, 2];
                        steps = 0;
                        break;
                    case MessageBoxResult.No://Если нет
                        this.Close();
                        break;
                }
            }
            if (steps > 8)
            {
                MessageBox.Show("Ничя!", "Игра продолжится");
                Array.Clear(Marix, 0, Marix.Length);

                Cross.Content = $"Крестики: {score[0]}";
                Zero.Content = $"Нолики: {score[1]}";

                r0g0.Content = Marix[0, 0];
                r0g1.Content = Marix[0, 1];
                r0g2.Content = Marix[0, 2];

                r1g0.Content = Marix[1, 0];
                r1g1.Content = Marix[1, 1];
                r1g2.Content = Marix[1, 2];

                r2g0.Content = Marix[2, 0];
                r2g1.Content = Marix[2, 1];
                r2g2.Content = Marix[2, 2];
                steps = 0;
            }

        }
        //методы вызывающие method со своими координатами
        private void r0g0_Click(object sender, RoutedEventArgs e)
        {
            method(0,0);
        }

        private void r0g1_Click(object sender, RoutedEventArgs e)
        {
            method(0, 1);
        }

        private void r0g2_Click(object sender, RoutedEventArgs e)
        {
            method(0, 2);
        }

        private void r1g0_Click(object sender, RoutedEventArgs e)
        {
            method(1, 0);
        }

        private void r1g1_Click(object sender, RoutedEventArgs e)
        {
            method(1, 1);
        }

        private void r1g2_Click(object sender, RoutedEventArgs e)
        {
            method(1, 2);
        }

        private void r2g0_Click(object sender, RoutedEventArgs e)
        {
            method(2, 0);
        }

        private void r2g1_Click(object sender, RoutedEventArgs e)
        {
            method(2, 1);
        }

        private void r2g2_Click(object sender, RoutedEventArgs e)
        {
            method(2, 2);
        }
    }
}
