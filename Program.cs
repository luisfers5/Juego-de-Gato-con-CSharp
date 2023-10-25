using System;


namespace Juego_de_Gato
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int jugador = 2;
            int ingreso = 0;
            bool ingresoCorrecto = true;

            do
            {
                if (jugador == 2)
                {
                    jugador = 1;
                    PonerXoO(jugador, ingreso);
                }else if (jugador == 1)
                {
                    jugador = 2;
                    PonerXoO(jugador, ingreso);
                }

                CreaTablero();

                //Codigo que verifica si hay un ganador
                #region

                char[] cadaSigno = { 'X', 'O'};

                foreach (char signo in cadaSigno)
                {
                    if ((tableroJuego[0, 0] == signo) && (tableroJuego[0, 1] == signo) && (tableroJuego[0, 2] == signo)
                        || (tableroJuego[1, 0] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[1, 2] == signo)
                        || (tableroJuego[2, 0] == signo) && (tableroJuego[2, 1] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 0] == signo) && (tableroJuego[1, 0] == signo) && (tableroJuego[2, 0] == signo)
                        || (tableroJuego[0, 1] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 1] == signo)
                        || (tableroJuego[0, 2] == signo) && (tableroJuego[1, 2] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 0] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 2] == signo)
                        || (tableroJuego[0, 2] == signo) && (tableroJuego[1, 1] == signo) && (tableroJuego[2, 0] == signo))
                    {
                        if(signo == 'X')
                        {
                            Console.WriteLine("Felicitaciones, ha ganado el jugador 1");
                        }
                        else
                        {
                            Console.WriteLine("Felicitaciones, ha ganado el jugador 2");
                        }
                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                        Console.Read();
                        Resetear();
                        ingreso = 0;
                        break;

                    }
                    else if(turnos == 10)
                    {
                        Console.WriteLine("\nEMPATE");
                        Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                        Console.Read();
                        Resetear();
                        ingreso = 0;
                        break;
                    }

                }
                #endregion
                //Do-While que verifica si el valor ingresado es valido
                #region 
                do
                {
                    Console.WriteLine($"\nJugador {jugador}: Por favor elija un casillero...");
                    try
                    {
                        ingreso = Convert.ToInt32(Console.ReadLine());
                    }
                    catch 
                    {

                        Console.WriteLine("Por favor solo ingresa numero del 1 al 9 que no hayan sido usados"); ;
                    }
                    if ((ingreso == 1) && (tableroJuego[0, 0] == '1'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 2) && (tableroJuego[0, 1] == '2'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 3) && (tableroJuego[0, 2] == '3'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 4) && (tableroJuego[1, 0] == '4'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 5) && (tableroJuego[1, 1] == '5'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 6) && (tableroJuego[1, 2] == '6'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 7) && (tableroJuego[2, 0] == '7'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 8) && (tableroJuego[2, 1] == '8'))
                        ingresoCorrecto = true;
                    else if ((ingreso == 9) && (tableroJuego[2, 2] == '9'))
                        ingresoCorrecto = true;
                    else
                    {
                        Console.WriteLine("\nPor favor ingrese un campo que no haya sido usado");
                        ingresoCorrecto = false;
                    }


                } while (!ingresoCorrecto);
                #endregion

            } while (true);
        }

        //Metodo para identificar jugador
        public static void PonerXoO(int jugador, int ingreso)
        {
            char signo = ' ';

            if (jugador == 1)
            {
                signo = 'X';
            }
            else if (jugador == 2)
            {
                signo = 'O';
            }

            switch (ingreso)
            {
                case 1: tableroJuego[0, 0] = signo; break;
                case 2: tableroJuego[0, 1] = signo; break;
                case 3: tableroJuego[0, 2] = signo; break;
                case 4: tableroJuego[1, 0] = signo; break;
                case 5: tableroJuego[1, 1] = signo; break;
                case 6: tableroJuego[1, 2] = signo; break;
                case 7: tableroJuego[2, 0] = signo; break;
                case 8: tableroJuego[2, 1] = signo; break;
                case 9: tableroJuego[2, 2] = signo; break;

            }
        }

        //Array 2Dimensional que contiene las variables del juego

        static char[,] tableroJuego =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        //Array 2Dimensional que contiene las variables del juego INICIAL

        static char[,] tableroJuegoInicial =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        static int turnos = 0;


        //Metodo que crea visualmente el tablero
        public static void CreaTablero()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",tableroJuego[0,0], tableroJuego[0,1],tableroJuego[0,2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",tableroJuego[1, 0], tableroJuego[1, 1], tableroJuego[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}",tableroJuego[2, 0], tableroJuego[2, 1], tableroJuego[2, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("                            ");
            turnos++;

        }

        //Metodo que reinicia todo el juego
        public static void Resetear()
        {
            tableroJuego = tableroJuegoInicial;
            CreaTablero();
            turnos = 0;
        }

    }
}