using System;
/*Створити консольний додаток, що моделює таку гру. Ігрове поле –
квадрат розміром 7*7. Переміщатися по полю можна з лівого нижнього кута до
центру по спіралі за годинниковою стрілкою. Два гравці прагнуть дістатися в
центр поля, переміщаючись на кількість кроків, що відповідає очками при кидку
гральної кості (випадкове число від 1 до 6). Гравцям надається однакова
кількість кидків. Після кожного кидка необхідно виводити положення гравців
на полі.
Гра закінчується, якщо після чергового кидка обох гравців, хоча б один з
них досягне центру поля. Вивести повідомлення про результати гри.*/
namespace _1Praktika
{
    class Program
    {
        static void Feald(int[,] PlayingField)
        { 
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    Console.Write("|" + PlayingField[i,j] + "|" + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Player(int[,] PlayingField, ref int i, ref int j, ref int n, ref int m,int FirstPlayer,int SecondPlayer)
        {
            bool first = false, second = false;
            for (i = 0; i < 7; ++i)
            {
                for (j = 0; j < 7; ++j)
                {
                    if (PlayingField[i, j] == 1 && !(FirstPlayer >= 49) && !(SecondPlayer >= 49))
                    {
                        first = true;
                        break;
                    }           
                }
                if (first == true)
                {
                    break;
                }
            }
            for (n = 0; n < 7; ++n)
            {
                for (m = 0; m < 7; ++m)
                {
                    if (PlayingField[n, m] == 2 && !(FirstPlayer >= 49) && !(SecondPlayer >= 49))
                    {
                        second = true;
                        break;
                    }
                    
                }
                if (second == true)
                {
                    break;
                }
            }
            if (first == false && second == false)
            {
                for (i = 0; i < 7; ++i)
                {
                    for (j = 0; j < 7; ++j)
                    {
                        if (PlayingField[i, j] == 3 && !(FirstPlayer >= 49) && !(SecondPlayer >= 49))
                        {
                            n = i;
                            first = true;
                            m = j;
                            second = true;
                            break;
                        }

                    }
                    if (first == true && second == true)
                    {

                        break;
                    }
                }
            }
        }
        
        static int Dice(int number)
        {
            Random random = new Random();
          number = random.Next(1, 7);
            return number;
        }
        static void Moving(int[,] PlayingField, int[,] MovesField,int Firstdice,int Seconddice, int dice, ref int FirstPlayer,ref int SecondPlayer )
        {

            PlayingField[6, 0] = 0;
            bool first = false, second = false;
            FirstPlayer += Firstdice;
            SecondPlayer += Seconddice;
            if (FirstPlayer >= 49 && SecondPlayer >= 49)
            {
                Console.WriteLine("\n");
                PlayingField[3, 3] = 3;
            }
            else {
                if (FirstPlayer >= 49)
                {
                    Console.WriteLine("\n");
                    PlayingField[3, 3] = 1;
                }
                else
                {
                    for (int i = 0; i < 7; ++i)
                    {
                        for (int j = 0; j < 7; ++j)
                        {
                            if (MovesField[i, j] == FirstPlayer)
                            {
                                PlayingField[i, j] = 1;

                                first = true;
                                Console.WriteLine($"|FirstPlayer [{i}], [{j}] |");

                                break;
                            }
                        }
                        if (first == true && !(FirstPlayer >= 49) && !(SecondPlayer >= 49))
                        {
                            break;
                        }
                    }
                }
                if (SecondPlayer >= 49)
                {
                    Console.WriteLine("\n");                
                    PlayingField[3, 3] = 2;
                }
                else
                {
                    for (int i = 0; i < 7; ++i)
                    {
                        for (int j = 0; j < 7; ++j)
                        {
                            if (MovesField[i, j] == SecondPlayer )
                            {
                                PlayingField[i, j] = 2;
                                second = true;
                                Console.WriteLine($"|SecondPlayer [{i}], [{j}]|");
                                Console.WriteLine("-----------------------");
                                if (FirstPlayer == SecondPlayer)
                                {
                                    PlayingField[i, j] = 3;
                                    break;
                                }
                                break;
                            }
                        }
                        if (second == true)
                        {
                            break;
                        }
                    }
                }
            
            }
        }
      static void Winer(int[,] PlayingField)
        {
            if (PlayingField[3, 3] == 1)
            {
                Console.WriteLine("FirstPlayer is winer\n\n");
            }else if (PlayingField[3, 3] == 2){
                Console.WriteLine("SecondPlayer is winer");
            }
            else
            {
                Console.WriteLine("It is a draw");
            }
        }
        static void Pause()
        {
            Console.ReadLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            
            int i = 6, j = 0, n = 6, m = 0, dice = 1, FirstPlaer = 1, SecondPleyer = 1, Firstdice, Seconddice ;
            int[,] PlayingField = new int[7, 7];
            PlayingField[6, 0] = 3;
            int[,] MovesFiesld ={
                { 7,8,9,10,11, 12, 13 },
                { 6,29,30,31,32,33,14 },
                { 5,28,43,44,45,34,15 },
                { 4,27,42,49,46,35,16 },
                { 3,26,41,48,47,36,17 },
                { 2,25,40,39,38,37,18 },
                { 1,24,23,22,21,20,19 } };       
            while (PlayingField[3, 3] == 0 )
            {
               
                Feald(PlayingField);
                Player(PlayingField, ref i, ref j, ref n, ref m,FirstPlaer,SecondPleyer);
                PlayingField[i, j] = 0;
                PlayingField[n, m] = 0;
                Firstdice = Dice(dice);
                Console.WriteLine("-----------------------");
                Console.WriteLine($"|Firstdice is: {Firstdice}      |");
                Seconddice = Dice(dice);
                Console.WriteLine($"|Seconddice is: {Seconddice}     |");
                Moving(PlayingField, MovesFiesld, Firstdice, Seconddice, dice, ref FirstPlaer, ref SecondPleyer);
                Console.WriteLine("\n");
                Pause();
            }
            Winer(PlayingField);
            for (int z = 0; z < 7; ++z)
            {
                for (int x = 0; x < 7; ++x)
                {
                    Console.Write("|" + PlayingField[z, x] + "|" + "\t");
                }
                Console.WriteLine();
            }
        }     
    }
}
