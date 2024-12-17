
     class Program
    {
        // Opciones posibles para el juego
        private static readonly string[] opciones = { "Piedra", "Papel", "Tijera" };

        // Resultados de cada jugador
        private static string resultadoJugador1 = "";
        private static string resultadoJugador2 = "";

        // Objetos para sincronización
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando partida de Piedra, Papel o Tijera...\n");

            // Crear los hilos
            Thread jugador1 = new Thread(Jugador1);
            Thread jugador2 = new Thread(Jugador2);

            // Iniciar los hilos
            jugador1.Start();
            jugador2.Start();

            // Esperar a que los hilos terminen
            jugador1.Join();
            jugador2.Join();

            // Determinar el ganador
            Console.WriteLine($"\nJugador 1 eligió: {resultadoJugador1}");
            Console.WriteLine($"Jugador 2 eligió: {resultadoJugador2}");

            DeterminarGanador(resultadoJugador1, resultadoJugador2);

            Console.WriteLine("\nFin de la partida.");
        }

        // Método del jugador 1
        static void Jugador1()
        {
            lock (lockObject)
            {
                Random random = new Random();
                resultadoJugador1 = opciones[random.Next(opciones.Length)];
                Thread.Sleep(100); // Simula tiempo de espera para la selección
                Console.WriteLine("Jugador 1 ha elegido.");
            }
        }

        // Método del jugador 2
        static void Jugador2()
        {
            lock (lockObject)
            {
                Random random = new Random();
                resultadoJugador2 = opciones[random.Next(opciones.Length)];
                Thread.Sleep(100); // Simula tiempo de espera para la selección
                Console.WriteLine("Jugador 2 ha elegido.");
            }
        }

        // Método para determinar el ganador
        static void DeterminarGanador(string jugador1, string jugador2)
        {
            if (jugador1 == jugador2)
            {
                Console.WriteLine("¡Es un empate!");
                return;
            }

            if ((jugador1 == "Piedra" && jugador2 == "Tijera") ||
                (jugador1 == "Papel" && jugador2 == "Piedra") ||
                (jugador1 == "Tijera" && jugador2 == "Papel"))
            {
                Console.WriteLine("¡Jugador 1 gana!");
            }
            else
            {
                Console.WriteLine("¡Jugador 2 gana!");
            }
        }
    }
