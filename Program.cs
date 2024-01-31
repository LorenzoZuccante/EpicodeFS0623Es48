using System;

namespace ContoCorrente
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            //Esercizio 1

            ContoBancario mioConto = new ContoBancario();

            while (!mioConto.ContoAperto)
            {
                Console.Write("Inserisci l'importo per aprire il tuo conto (minimo 1000 euro): ");
                decimal depositoIniziale;
                if (Decimal.TryParse(Console.ReadLine(), out depositoIniziale))
                {
                    mioConto.ApriConto(depositoIniziale);
                }
                else
                {
                    Console.WriteLine("Per favore, inserisci un importo valido.");
                }
            }

            bool uscita = false;
            while (!uscita)
            {
                Console.WriteLine("\nScegli un'operazione:");
                Console.WriteLine("1. Versamento");
                Console.WriteLine("2. Prelievo");
                Console.WriteLine("3. Controlla saldo");
                Console.WriteLine("4. Esci");
                Console.Write("Seleziona un'opzione (1-4): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Inserisci l'importo del versamento: ");
                        decimal importoVersamento;
                        if (Decimal.TryParse(Console.ReadLine(), out importoVersamento))
                        {
                            mioConto.Versamento(importoVersamento);
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;
                    case "2":
                        Console.Write("Inserisci l'importo del prelievo: ");
                        decimal importoPrelievo;
                        if (Decimal.TryParse(Console.ReadLine(), out importoPrelievo))
                        {
                            mioConto.Prelievo(importoPrelievo);
                        }
                        else
                        {
                            Console.WriteLine("Importo non valido.");
                        }
                        break;
                    case "3":
                        Console.WriteLine($"Il saldo attuale è: {mioConto.Saldo} euro.");
                        break;
                    case "4":
                        uscita = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }



            //Esercizio 2
            //string[] nomi = { "Pippo", "Franco", "Alberto" };

            //Console.Write("Inserisci il nome da cercare: ");
            //string nomeDaCercare = Console.ReadLine();

            //bool trovato = false;
            //foreach (string nome in nomi)
            //{
            //    if (nome.Equals(nomeDaCercare, StringComparison.OrdinalIgnoreCase))
            //    {
            //        trovato = true;
            //        break;
            //    }
            //}

            //if (trovato)
            //{
            //    Console.WriteLine("Il nome è presente nell'array.");
            //}
            //else
            //{
            //    Console.WriteLine("Il nome non è presente nell'array.");
            //}




            //Esercizio 3

            //Console.Write("Inserisci la dimensione dell'array: ");
            //int dimensione;
            //if (!int.TryParse(Console.ReadLine(), out dimensione) || dimensione <= 0)
            //{
            //    Console.WriteLine("Per favore, inserisci un numero intero positivo.");
            //    return;
            //}

            //int[] numeri = new int[dimensione];
            //int somma = 0;

            //for (int i = 0; i < dimensione; i++)
            //{
            //    Console.Write($"Inserisci il numero {i + 1}: ");
            //    int numero;
            //    while (!int.TryParse(Console.ReadLine(), out numero))
            //    {
            //        Console.Write("Per favore, inserisci un numero intero valido: ");
            //    }
            //    numeri[i] = numero;
            //    somma += numero;
            //}

            //double media = somma / (double)dimensione;

            //Console.WriteLine($"La somma dei numeri è: {somma}");
            //Console.WriteLine($"La media aritmetica è: {media}");

        }
    }
}

//Esercizio 1
public class ContoBancario
{
    public decimal Saldo { get; private set; }
    public bool ContoAperto { get; private set; }

    public ContoBancario()
    {
        Saldo = 0m;
        ContoAperto = false;
    }

    public void ApriConto(decimal depositoIniziale)
    {
        if (ContoAperto)
        {
            Console.WriteLine("Il conto è già stato aperto.");
            return;
        }

        if (depositoIniziale < 1000m)
        {
            Console.WriteLine("Il deposito iniziale deve essere di almeno 1000 euro.");
            return;
        }

        Saldo = depositoIniziale;
        ContoAperto = true;
        Console.WriteLine($"Conto aperto con successo. Saldo attuale: {Saldo} euro.");
    }

    public void Versamento(decimal importo)
    {
        if (!ContoAperto)
        {
            Console.WriteLine("Devi prima aprire un conto.");
            return;
        }

        Saldo += importo;
        Console.WriteLine($"Versamento effettuato. Saldo attuale: {Saldo} euro.");
    }

    public void Prelievo(decimal importo)
    {
        if (!ContoAperto)
        {
            Console.WriteLine("Devi prima aprire un conto.");
            return;
        }

        if (importo > Saldo)
        {
            Console.WriteLine("Saldo insufficiente per il prelievo.");
            return;
        }

        Saldo -= importo;
        Console.WriteLine($"Prelievo effettuato. Saldo attuale: {Saldo} euro.");
    }
}

