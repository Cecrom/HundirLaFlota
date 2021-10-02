using System;
/*
Hay 6 barcos:
    1 barco de longitud 5 (Denominado como U)
    1 barco de longitud 4 (Denominado como V)
    2 barcos de longitud 3 (Denominado como W y X)
    2 barcos de longitud 2 (Denominado como Y y Z)

Los barcos no pueden ser colocados de modo que parte de los mismos salgan del tablero de juego.
El tablero de juego medirá 10 columnas x 7 filas
Solo habrá un jugador, que pondrá los barcos y que luego probará el propio juego.
40 turnos para terminar el juego
*/

namespace Hundir_la_flota
{
    class Program
    {
        // Como pido las coordenadas en char y en int son mucho más sencillas de utilizar en el tablero, las convierto con estas dos funciones.

        static void coor_fila_a_int (char[] coordenada, ref int[] coordenadas_int)
        {
            switch (coordenada[0])
            {
                case '1':
                    coordenadas_int[0] = 0;
                    break;
                case '2':
                    coordenadas_int[0] = 1;
                    break;
                case '3':
                    coordenadas_int[0] = 2;
                    break;
                case '4':
                    coordenadas_int[0] = 3;
                    break;
                case '5':
                    coordenadas_int[0] = 4;
                    break;
                case '6':
                    coordenadas_int[0] = 5;
                    break;
                case '7':
                    coordenadas_int[0] = 6;
                    break;
            }
        }
        static void coor_columna_a_int(char[] coordenada, ref int[] coordenadas_int)
        {
            switch (coordenada[1])
            {
                case 'A':
                    coordenadas_int[1] = 0;
                    break;
                case 'B':
                    coordenadas_int[1] = 1;
                    break;
                case 'C':
                    coordenadas_int[1] = 2;
                    break;
                case 'D':
                    coordenadas_int[1] = 3;
                    break;
                case 'E':
                    coordenadas_int[1] = 4;
                    break;
                case 'F':
                    coordenadas_int[1] = 5;
                    break;
                case 'G':
                    coordenadas_int[1] = 6;
                    break;
                case 'H':
                    coordenadas_int[1] = 7;
                    break;
                case 'I':
                    coordenadas_int[1] = 8;
                    break;
                case 'J':
                    coordenadas_int[1] = 9;
                    break;
            }
        }

        // Esta función convierte de string a número, siempre que sea posible

        static void conversión(string número, ref int convertido, ref bool prueba)
        {
            prueba = Int32.TryParse(número, out _);
            if (prueba == true)
            {
                convertido = Convert.ToInt32(número);
            }
            else
            {
                Console.WriteLine("Introduzca un número, por favor");
            }
        }

        // Estas funciones sirven para dibujar el título, el menú y los tableros (tanto el vacío como el completo)

        static void dibujar_titulo()
        {
            Console.WriteLine("");
            Console.WriteLine(@"      █     █ █      █ ██    █ █■■■■■   ■■■█■■■  █■■■■       ");
            Console.WriteLine(@"      █     █ █      █ █ █   █ █     █     █     █    █      ");
            Console.WriteLine(@"      █■■■■■█ █      █ █  █  █ █     █     █     █■■■■       ");
            Console.WriteLine(@"      █     █ █      █ █   █ █ █     █     █     █   █       ");
            Console.WriteLine(@"      █     █  ■■■■■■  █    ██ █■■■■■   ■■■█■■■  █    █      ");
            Console.WriteLine(@"                                                             ");
            Console.WriteLine(@"                      █         ■■■■■■                       ");
            Console.WriteLine(@"                      █        █      █                      ");
            Console.WriteLine(@"                      █        █      █                      ");
            Console.WriteLine(@"                      █        █■■■■■■█                      ");
            Console.WriteLine(@"                      █■■■■■■  █      █                      ");
            Console.WriteLine(@"                                                             ");
            Console.WriteLine(@"         █■■■■■■ █        ■■■■■■  ■■■■■■■■■  ■■■■■■          ");
            Console.WriteLine(@"         █       █       █      █     █     █      █         ");
            Console.WriteLine(@"         █■■■■   █       █      █     █     █      █         ");
            Console.WriteLine(@"         █       █       █      █     █     █■■■■■■█         ");
            Console.WriteLine(@"         █       █■■■■■■  ■■■■■■      █     █      █         ");
            Console.WriteLine("                                                              ");
            Console.WriteLine("                Pulse cualquier tecla para comenzar           ");
        }
        static void dibujar_menu()
        {
            Console.Clear();
            Console.WriteLine("                                                              ");
            Console.WriteLine(@"           /█\                          //    /█\            ");
            Console.WriteLine(@"            █    █     █ █████ █    █ █   █    █             ");
            Console.WriteLine(@"            █    ██   ██ █     ██   █ █   █    █             ");
            Console.WriteLine(@"            █    █ █ █ █ ████  █ █  █ █   █    █             ");
            Console.WriteLine(@"            █    █  █  █ █     █  █ █ █   █    █             ");
            Console.WriteLine(@"            █    █     █ █████ █   ██ █████    █             ");
            Console.WriteLine(@"           \█/                                \█/            ");
            Console.WriteLine("                                                              ");
            Console.WriteLine(@"                 Seleccione qué desea hacer                  ");
            Console.WriteLine(@"                                                             ");
            Console.WriteLine(@"               (1)          Jugar                            ");
            Console.WriteLine(@"               (2)          Salir                            ");
            Console.WriteLine(@"                                                             ");
        }
        static void dibujar_tablero(ref char[,] tablero)
        {
            Console.WriteLine("");
            Console.WriteLine("     A   B   C   D   E   F   G   H   I   J  ");
            Console.WriteLine("   ┌───┬───┬───┬───┬───┬───┬───┬───┬───┬───┐");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(" " + (i + 1));
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" │ "+tablero[i,j]);
                }
                Console.WriteLine(" │");
                if (i < 6)
                {
                    Console.WriteLine("   ├───┼───┼───┼───┼───┼───┼───┼───┼───┼───┤");
                }
            }
            Console.WriteLine("   └───┴───┴───┴───┴───┴───┴───┴───┴───┴───┘");
        }

        // Funciones sobre la validación de la posición de los barcos y su introducción en el tablero

        static void introducir_barcos(char barco, string dirección, int[] coordenadas, ref char[,] tablero_completo)
        {
            int tamaño;
            switch (barco)
            {
                case 'U':
                    tamaño = 5;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
                case 'V':
                    tamaño = 4;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
                case 'W':
                    tamaño = 3;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
                case 'X':
                    tamaño = 3;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
                case 'Y':
                    tamaño = 2;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
                case 'Z':
                    tamaño = 2;
                    for (int i = 0; i < tamaño; i++)
                    {
                        tablero_completo[coordenadas[0], coordenadas[1]] = barco;
                        if (dirección == "v")
                        {
                            coordenadas[0] += 1;
                        }
                        else if (dirección == "h")
                        {
                            coordenadas[1] += 1;
                        }
                    }
                    break;
            }
        }

        // La validación se hace para que no se salgan del tablero (con lenght) y para que no se pisen entre barcos, con un booleano y una comprobación moviéndote por la matriz.

        static bool validación_barco(char barco, string dirección, char[] columnas,char[] filas, char[] coordenadas, char[,] tablero)
        {
            bool validación = false;
            int tamaño;
            switch (barco)
            {
                case 'U':
                    tamaño = 5;
                    int posición_columna_u = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_u = Array.IndexOf(filas, coordenadas[0]);
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_u;
                        if(total > columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                            
                        }
                        else
                        {
                            validación = true;
                            return validación;
                        }
                    }
                    else if(dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_u;
                        if (total > filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                            
                        }
                        else
                        {
                            validación = true;
                            return validación;
                        }
                    }
                    return validación;
                case 'V':
                    tamaño = 4;
                    int posición_columna_v = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_v = Array.IndexOf(filas, coordenadas[0]);
                    bool choca_v = false;
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_v;
                        if (total > columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_columna_v; i <= total; i++)
                        {
                            if (tablero[posición_fila_v, i] != ' ')
                            {
                                choca_v = true;
                            }

                        }
                        if(choca_v == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    else if (dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_v;

                        if (total > filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_fila_v; i < total; i++)
                        {
                            if (tablero[i, posición_columna_v] != ' ')
                            {
                                choca_v = true;
                            }
                        }
                        if (choca_v == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    return validación;
                case 'W':
                    tamaño = 3;
                    int posición_columna_w = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_w = Array.IndexOf(filas, coordenadas[0]);
                    bool choca_w = false;
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_w;
                        if (total > columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_columna_w; i <= total; i++)
                        {
                            if (tablero[posición_fila_w, i] != ' ')
                            {
                                choca_w = true;
                            }

                        }
                        if (choca_w == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    else if (dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_w;

                        if (total > filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_fila_w; i < total; i++)
                        {
                            if (tablero[i, posición_columna_w] != ' ')
                            {
                                choca_w = true;
                            }
                        }
                        if (choca_w == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    return validación;
                case 'X':
                    tamaño = 3;
                    int posición_columna_x = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_x = Array.IndexOf(filas, coordenadas[0]);
                    bool choca_x = false;
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_x;

                        if (total > columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_columna_x; i <= total; i++)
                        {
                            if (tablero[posición_fila_x, i] != ' ')
                            {
                                choca_x = true;
                            }

                        }
                        if (choca_x == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    else if (dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_x;

                        if (total > filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_fila_x; i < total; i++)
                        {
                            if (tablero[i, posición_columna_x] != ' ')
                            {
                                choca_x = true;
                            }
                        }
                        if (choca_x == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    return validación;
                case 'Y':
                    tamaño = 2;
                    int posición_columna_y = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_y = Array.IndexOf(filas, coordenadas[0]);
                    bool choca_y = false;
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_y;

                        if (total >= columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_columna_y; i <= total; i++)
                        {
                            if (tablero[posición_fila_y, i] != ' ')
                            {
                                choca_y = true;
                            }

                        }
                        if (choca_y == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    else if (dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_y;

                        if (total >= filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_fila_y; i < total; i++)
                        {
                            if (tablero[i, posición_columna_y] != ' ')
                            {
                                choca_y = true;
                            }
                        }
                        if (choca_y == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    return validación;
                case 'Z':
                    tamaño = 2;
                    int posición_columna_z = Array.IndexOf(columnas, coordenadas[1]);
                    int posición_fila_z = Array.IndexOf(filas, coordenadas[0]);
                    bool choca_z = false;
                    if (dirección == "h")
                    {
                        int total = (tamaño - 1) + posición_columna_z;
                        if (total >= columnas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por la derecha");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_columna_z; i <= total; i++)
                        {
                            if (tablero[posición_fila_z, i] != ' ')
                            {
                                choca_z = true;
                            }

                        }
                        if (choca_z == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    else if (dirección == "v")
                    {
                        int total = (tamaño - 1) + posición_fila_z;

                        if (total >= filas.Length)
                        {
                            Console.WriteLine("El barco se sale del tablero por abajo");
                            validación = false;
                            return validación;
                        }
                        for (int i = posición_fila_z; i < total; i++)
                        {
                            if (tablero[i, posición_columna_z] != ' ')
                            {
                                choca_z = true;
                            }
                        }
                        if (choca_z == true)
                        {
                            Console.WriteLine("El barco colisionaría con otro ya colocado. Vuelva a intentarlo");
                            validación = false;
                            return validación;
                        }
                        else
                        {
                            validación = true;
                            return validación;

                        }
                    }
                    return validación;
                default:
                    return validación;
            }
        }
        static void disparo (int[] coordenadas, ref char[,] tablero_completo, ref char[,] tablero_vacío, ref int barcoU, ref int barcoV, ref int barcoW, ref int barcoX, ref int barcoY, ref int barcoZ)
        {
            if (tablero_completo[coordenadas[0],coordenadas[1]] != ' ' & tablero_completo[coordenadas[0], coordenadas[1]] != '~' & tablero_completo[coordenadas[0], coordenadas[1]] != 'O')
            {
                Console.WriteLine("¡Tocado!");
                switch (tablero_completo[coordenadas[0], coordenadas[1]])
                {
                    case 'U':
                        barcoU -= 1;
                        if (barcoU == 0)
                        {
                            Console.WriteLine("y... el barco U ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    case 'V':
                        barcoV -= 1;
                        if (barcoV == 0)
                        {
                            Console.WriteLine("y... el barco V ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    case 'W':
                        barcoW -= 1;
                        if (barcoW == 0)
                        {
                            Console.WriteLine("y... el barco W ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    case 'X':
                        barcoX -= 1;
                        if (barcoX == 0)
                        {
                            Console.WriteLine("y... el barco X ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    case 'Y':
                        barcoY -= 1;
                        if (barcoY == 0)
                        {
                            Console.WriteLine("y... el barco Y ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    case 'Z':
                        barcoZ -= 1;
                        if (barcoZ == 0)
                        {
                            Console.Write(" y... el barco Z ha sido....... ¡HUNDIDO!");
                        }
                        break;
                    default:
                        Console.WriteLine("Ya has disparado aquí, enhorabuena, turno perdido. Mira el tablero, por favor, que está todo bien clarito. Gracias");
                        break;
                }
                tablero_vacío[coordenadas[0], coordenadas[1]] = 'O';
            }
            else if (tablero_completo[coordenadas[0], coordenadas[1]] == ' ')
            {
                Console.WriteLine("Oh, no, es AGUA");
                tablero_vacío[coordenadas[0], coordenadas[1]] = '~';
            }
            else
            {
                Console.WriteLine("Ya has disparado aquí, enhorabuena, turno perdido. Mira el tablero, por favor, que está todo bien clarito. Gracias");
            }
        }

        static void Main(string[] args)
        {
            // Fijamos el tamaño de la ventana

            //Console.SetWindowSize(75, 50);
            //Console.SetBufferSize(75, 50);

            // Indexación de variables 

            char[,] tablero_completo = new char[7, 10];                                         // Tablero de juego
            char[,] tablero_vacío = new char[7, 10];                                            // Tablero de juego vacío
            bool prueba = false;                                                                // Para las comprobaciónes de números

            // Variable del tamaño de los barcos, para saber cuándo se hunden.

            int U = 5;
            int V = 4;
            int W = 3;
            int X = 3;
            int Y = 2;
            int Z = 2;

            // Fin de las variables, para saber cuándo se hunden.

            string intento;                                                                     // Para las comprobaciones de números
            int elección = 0;                                                                   // Para la elección del menú
            int contador_turnos = 40;                                                           // Sirve como contador de los turnos
            string dirección;                                                                   // Para elegir la dirección del barco
            char[] coordenadas = new char[2];                                                   // Para introducir las coordenadas de los barcos
            char[] coord_filas = { '1', '2', '3', '4', '5', '6', '7' };                         // Coordenadas de las filas
            char[] coord_columnas = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };       // Coordenadas de las columnas
            string coord_barco;                                                                 // En esta variable se almacena lo que el usuario introduce como coordenadas, para comprobarlas
            char[] coord_barco_char = new char[2];                                              // En esta array se almacecna la coordenada que ha dado el usuario, dividida en caracteres, para poder verificarlas
            int[] coord_barco_int = new int[2];                                                 // Con esta conversión podemos usar las coordenadas en el tablero
            bool validación = false;                                                            // Se usa esta variable para almacenar el booleano de la función que valida la posición de los barcos
            string coord_disparo;                                                               // Se usa para recibir las coordenadas del disparo
            int[] coord_disparo_int = new int[2];                                               // Se usa para que las coordenadas del disparo sea viables para el tablero
            char[] coord_disparo_char = new char[2];                                            // Se usa para almacenar las coordenadas del disparo

            // Barcos:

            char[] barcos = { 'U', 'V', 'W', 'X', 'Y', 'Z' };

            // Fin de barcos.

            // Rellenamos el tablero vacío

            for (int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    tablero_vacío[i, j] = ' ';
                    tablero_completo[i, j] = ' ';
                }
            }

            // Iniciamos el programa

            dibujar_titulo();

            Console.ReadKey(true);

            dibujar_menu();

            // Fin de la presentación e inicio del menú de juego

            do
            {
                do
                {
                    string elec_menu_str = Console.ReadLine();
                    conversión(elec_menu_str, ref elección, ref prueba);
                } while (prueba == false);
                if (elección != 1 & elección != 2)
                {
                    Console.WriteLine("Por favor, introduzca una opción válida: 1 o 2");
                }

            } while (elección != 1 & elección != 2);

            switch (elección)
            {
                case 1:       // Hundir la flota
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("              Tablero de juego:");
                    dibujar_tablero(ref tablero_vacío);
                    Console.WriteLine("\n        Dispones de los siguientes barcos: ");
                    Console.WriteLine("\n            U, el barco de 5 casillas.");
                    Console.WriteLine("            V, el barco de 4 casillas.");
                    Console.WriteLine("            W, un barco de 3 casillas.");
                    Console.WriteLine("            X, un barco de 3 casillas.");
                    Console.WriteLine("            Y, un barco de 2 casillas.");
                    Console.WriteLine("            Z, un barco de 2 casillas.");
                    Console.WriteLine("\nIntroducirás los barcos en ese orden, recuerda que no pueden salirse del tablero ni chocar entre ellos.");
                    foreach (char barco in barcos)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("¿En qué dirección desea introducir el barco " + barco + ", [H]orizontal] o [V]ertical]?");

                        do
                        {

                            do //Validación de que se introduce "horizontal" o "vertical"
                            {
                                dirección = Console.ReadLine();
                                dirección = dirección.ToLower();
                                if (dirección != "h" & dirección != "v")
                                {
                                    Console.WriteLine("Por favor, introduzca una opción válida (Horizontal o vertical)");
                                }
                            } while (dirección != "h" & dirección != "v");
                            Console.WriteLine("");
                            Console.WriteLine("¿En qué coordenada deseas que se encuentre la primera casilla del barco? Te en cuenta que si has elegido vertical, se introducirá hacia abajo y si has elegido horizontal se introducirá hacia la derecha.");
                            Console.WriteLine("");
                            do // Validación de las coordenadas. Que no haya coordenadas no incluidas en el tablero y que ambas coordenadas sea número y letra.
                            {
                                do // Que no haya más de dos caracteres en las coordenadas
                                {
                                    coord_barco = Console.ReadLine();
                                    coord_barco = coord_barco.ToUpper();
                                    if (coord_barco.Length != 2)
                                    {
                                        Console.WriteLine("Por favor, introduzca unas coordenadas de dos caracteres");
                                    }
                                } while (coord_barco.Length != 2);

                                coord_barco_char = coord_barco.ToCharArray();
                                Array.Sort(coord_barco_char);   //Ordenamos el array para que no importe en qué orden se introduzcan las coordenadas.
                                if (Array.Exists(coord_filas, element => element == coord_barco_char[0]) == false || Array.Exists(coord_columnas, element => element == coord_barco_char[1]) == false)
                                {
                                    Console.WriteLine("Por favor, introduzca unas coordenadas dentro de los límites del tablero.");
                                }
                            } while (Array.Exists(coord_filas, element => element == coord_barco_char[0]) == false || Array.Exists(coord_columnas, element => element == coord_barco_char[1]) == false);
                            //"Mientras que lo introducido no incluya una coordenadas de las filas y otra de las columnas" Así nos aseguramos de que no introduzca dos números o dos letras.

                        validación = validación_barco(barco, dirección, coord_columnas, coord_filas, coord_barco_char, tablero_completo);

                        } while (validación == false);

                        // Transformamos las coordenadas a int para poder usarlas en el tablero de forma más cómoda

                        coor_fila_a_int(coord_barco_char, ref coord_barco_int);
                        coor_columna_a_int(coord_barco_char, ref coord_barco_int);

                        // Introducimos el barco en el tablero
                        Console.Clear();
                        introducir_barcos(barco, dirección, coord_barco_int, ref tablero_completo);
                        dibujar_tablero(ref tablero_completo);
                        Console.WriteLine("\n        Dispones de los siguientes barcos: ");
                        Console.WriteLine("\n            U, el barco de 5 casillas.");
                        Console.WriteLine("            V, el barco de 4 casillas.");
                        Console.WriteLine("            W, un barco de 3 casillas.");
                        Console.WriteLine("            X, un barco de 3 casillas.");
                        Console.WriteLine("            Y, un barco de 2 casillas.");
                        Console.WriteLine("            Z, un barco de 2 casillas.");
                    }
                    Console.WriteLine("Pulse cualquier tecla para iniciar el BOMBARDEO");

                    Console.ReadKey(true);

                    // Comienza el turno de los disparos

                    Console.Clear();
                    dibujar_tablero(ref tablero_vacío);
                    Console.WriteLine("A partir de ahora tienes 40 turnos para hundir todos los barcos");
                    do
                    {
                        Console.WriteLine("Le quedan " + contador_turnos + " turnos antes de que se acabe el juego");
                        Console.WriteLine("Indique las coordenadas del disparo");
                        do // Validación de las coordenadas. Que no haya coordenadas no incluidas en el tablero y que ambas coordenadas sea número y letra.
                        {
                            do // Que no haya más de dos caracteres en las coordenadas
                            {
                                coord_disparo = Console.ReadLine();
                                coord_disparo = coord_disparo.ToUpper();
                                if (coord_disparo.Length != 2)
                                {
                                    Console.WriteLine("Por favor, introduzca unas coordenadas de dos caracteres");
                                }
                            } while (coord_disparo.Length != 2);

                            coord_disparo_char = coord_disparo.ToCharArray();
                            Array.Sort(coord_disparo_char);   //Ordenamos el array para que no importe en qué orden se introduzcan las coordenadas.
                            if (Array.Exists(coord_filas, element => element == coord_disparo_char[0]) == false || Array.Exists(coord_columnas, element => element == coord_disparo_char[1]) == false)
                            {
                                Console.WriteLine("Por favor, introduzca unas coordenadas dentro de los límites del tablero.");
                            }
                        } while (Array.Exists(coord_filas, element => element == coord_disparo_char[0]) == false || Array.Exists(coord_columnas, element => element == coord_disparo_char[1]) == false);

                        coor_fila_a_int(coord_disparo_char, ref coord_disparo_int);
                        coor_columna_a_int(coord_disparo_char, ref coord_disparo_int);

                        disparo(coord_disparo_int, ref tablero_completo, ref tablero_vacío, ref U, ref V, ref W, ref X, ref Y, ref Z);

                        Console.WriteLine("Pulse cualquier tecla para el siguiente turno");
                        Console.ReadKey(true);

                        Console.Clear();

                        dibujar_tablero(ref tablero_vacío);
                        if(U == 0 & V == 0 & W == 0 & X == 0 & Y == 0 & Z == 0) // Si no quedan barcos, has ganado, este if lo comprueba gracias a las variables que almacenan su tamaño.
                        {
                            Console.WriteLine("ENHORABUENA. has ganao.");
                            Environment.Exit(1);
                        }

                        contador_turnos -= 1; // Se van reduciendo los turnos para que cuando se llegue a 0 el programa se cierre
                        if(contador_turnos == 0)
                        {
                            Console.WriteLine("Lo siento, has perdido");
                        }
                    } while (contador_turnos != 0);
                    break;

                case 2:     //Salir del programa
                    Environment.Exit(1);
                    break;
            }
        }
    }
}