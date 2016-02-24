using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Web; 
using System.IO;

namespace MergeSort
{
    class Program
    {
        
        

        static public void Merge(int[] numOrd, int esquerda, int mid, int direita)// Este método irá receber as variáveis esquerda e direita, que serão usadas para representar os índices dos vetores. Os valores que correspondem a estes índices, serão ordenados entre eles próprios. Ou seja, no começo ele irá dividir o vetor em várias partes de 2 índices cada, ordena essas partes, e depois junta com as outras partes, ordenando também e assim gradativamentente
        {
            int[] temp = new int[100000];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = esquerda;
            num = (direita - esquerda + 1);

            while ((esquerda <= eol) && (mid <= direita)) //Nas próximas três estruturas While, o programa irá verificar dois números e coloca o menor deles em uma posição inferior no vetor temp
            {
                if (numOrd[esquerda] <= numOrd[mid])
                {
                    temp[pos++] = numOrd[esquerda++];

                }
                else
                {
                    temp[pos++] = numOrd[mid++];
                }
            }


            while (esquerda <= eol) 
                temp[pos++] = numOrd[esquerda++];
            

            while (mid <= direita)
                temp[pos++] = numOrd[mid++];

            for (i = 0; i < num; i++) // passa os dados ordenados do vetor temp para o vetor numOrd 

            {
                numOrd[direita] = temp[direita];
                direita--;
            }
        }

        static public void MergeSort(int[] numOrd, int esquerda, int direita) //Este método vai "dividir" o vetor numOrd e enviar para o método Merge os valores das variáveis esquerda e direita
        {
            int mid;

            if (direita > esquerda)
            {

                mid = (direita + esquerda) / 2;

                MergeSort(numOrd, esquerda, mid);
                MergeSort(numOrd, (mid + 1), direita);

                Merge(numOrd, esquerda, (mid + 1), direita);
            }
        }

        static void Main(string[] args)
        {
            int max = 0;
            string line;

            StreamReader file = new StreamReader(@"\dados.txt"); //Importando o arquivo txt
            Console.Write("\nOrdenação usando o algoritmo MergeSort\n\nSistema de Alerta de Desmatamento (SAD) Dados do desmatamento na Amazônia Legal (Em KM²):  ");
            while ((line = file.ReadLine()) != null) //Fazendo a contagem de elementos que o arquivo txt possui, linha por linha
            {
                max++;
            }

            
            file.Close();// Fecha o arquivo txt

            int[] numOrd = new int[max]; //Declara o vetor, com o índice igual ao número de elementos do arquivo txt
            int[] numOrdCopia = new int[max];
            StreamReader file2 = new StreamReader(@"\dados.txt"); //Importa novamente o arquivo txt
            for (int i = 0; i < max; i++)
            {
                line = file2.ReadLine();
                numOrd[i] = Convert.ToInt32(line); //Colocando no vetor todos os elementos do arquivo txt, um índice por linha
            }

            for (int i = 0; i < max; i++)
            {
               
                numOrdCopia[i] = numOrd[i]; //Colocando no vetor todos os elementos do arquivo txt, um índice por linha
            } 


            Console.WriteLine("\nA partir de abril de 2008\n");

          

            MergeSort(numOrd, 0, max - 1); //Chama o método MergeSort que fará a ordenação dos dados
        

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
                numOrdCopia[j] = 0;
                int cont2 = contador;

                while (cont2 > 11)
                {
                    cont2 = cont2 - 12;
                }
                if (cont2 == 0 )
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