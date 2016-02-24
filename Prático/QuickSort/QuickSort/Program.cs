using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace sortQuick
{
    class quickSort
    {
        

        private int len;
        int[] numOrd = new int[100000];
        public void QuickSort()
        {
            sort(0, len - 1); // chama o método sort
        }

        public void sort(int esquerda, int direita)
        {
           
            int pivo, e, d;

            e = esquerda;
            d = direita;
            pivo = numOrd[esquerda];

            while (esquerda < direita)
            {
                while ((numOrd[direita] >= pivo) && (esquerda < direita))
                {
                    direita--;
                }

                if (esquerda != direita)
                {
                    numOrd[esquerda] = numOrd[direita];
                    esquerda++;
                }

                while ((numOrd[esquerda] <= pivo) && (esquerda < direita))
                {
                    esquerda++;
                }

                if (esquerda != direita)
                {
                    numOrd[direita] = numOrd[esquerda];
                    direita--;
                }
            }

            numOrd[esquerda] = pivo;
            pivo = esquerda;
            esquerda = e;
            direita = d;

            if (esquerda < pivo)
            {
                sort(esquerda, pivo - 1);
            }

            if (direita > pivo)
            {
                sort(pivo + 1, direita);
            }
        }
         


        
        public static void Main()
        {
            quickSort q_Sort = new quickSort();//Método construtor
            

            int max = 0;
            string line;

            StreamReader file = new StreamReader(@"\dados.txt"); //Importando o arquivo txt
            while ((line = file.ReadLine()) != null) //Fazendo a contagem de elementos que o arquivo txt possui, linha por linha
            {
                max++;
            }


            file.Close();// Fecha o arquivo txt

            int[] numOrd = new int[max]; //Declara o vetor, com o índice igual ao número de elementos do arquivo txt

            StreamReader file2 = new StreamReader(@"\dados.txt"); //Importa novamente o arquivo txt
            for (int i = 0; i < max; i++)
            {
                line = file2.ReadLine();
                numOrd[i] = Convert.ToInt32(line); //Colocando no vetor todos os elementos do arquivo txt, um índice por linha
            }

            int[] numOrdCopia = new int[max];

            for (int i = 0; i < max; i++)
            {
                
                numOrdCopia[i] = numOrd[i]; //Colocando no vetor todos os elementos do arquivo txt, um índice por linha
            }

            
            q_Sort.numOrd = numOrd;
            q_Sort.len = max;
            
            q_Sort.QuickSort(); //Chama o método quicksort

            Console.Write("\nOrdenação usando o algoritmo QuickSort\n\nSistema de Alerta de Desmatamento (SAD) Dados do desmatamento na Amazônia Legal (Em KM²):  ");

            
            Console.WriteLine("\nA patir de 04/2008\n"); 
            for (int i = 0; i < max; i++)
            {
                int contador = 0;
                Console.Write(i + 1 + "º: " + numOrd[i]);//Apenas mostra o vetor, após ele ter sido ordenado
                int j = 0;
                while (numOrd[i] != numOrdCopia[j])
                {
                    contador++;
                    j++;
                }
                numOrdCopia[j] = -1;

                int cont2 = contador;

                while (cont2 > 11)
                {
                    cont2 = cont2 - 12;
                }
                if (cont2 == 0)
                {
                    Console.Write(" KM² em Abril");
                }
                else if (cont2 == 1)
                {
                    Console.Write(" KM² em Maio");
                }
                else if (cont2 == 2)
                {
                    Console.Write(" KM² em Junho");
                }
                else if (cont2 == 3)
                {
                    Console.Write(" KM² em Julho");
                }
                else if (cont2 == 4)
                {
                    Console.Write(" KM² em Agosto");
                }
                else if (cont2 == 5)
                {
                    Console.Write(" KM² em Setembro");
                }
                else if (cont2 == 6)
                {
                    Console.Write(" KM² em Outubro");
                }
                else if (cont2 == 7)
                {
                    Console.Write(" KM² em Novembro");
                }
                else if (cont2 == 8)
                {
                    Console.Write(" KM² em Dezembro");
                }
                else if (cont2 == 9)
                {
                    Console.Write(" KM² em Janeiro");
                }
                else if (cont2 == 10)
                {
                    Console.Write(" KM² em Fevereiro");
                }
                else if (cont2 == 11)
                {
                    Console.Write(" KM² em Março");
                }


                int ano = 2008;
                while (contador > 8)
                {
                    ano = ano + 1;
                    contador = contador - 12;

                }

                Console.Write(" de " + ano);


                Console.Write("\n");
            }





            Console.WriteLine("\n\nAperte qualquer tecla para encerrar o programa...");
          
            Console.ReadKey();
        }
    }
}