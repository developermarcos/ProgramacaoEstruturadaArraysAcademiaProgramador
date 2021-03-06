using System;

namespace ProgramacaoEstruturada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variáveis
            int[] arrayNumeros = { 2, 3, 9, -1, 0, 5, -4, 7, 2, 15 };
            int maiorNumero = 0;
            int menorNumero;
            double media;
            int[] tresMaioresNumeroArray = new int[3];
            int[] numerosNegativos;
            int valorParaSerRetirado = 2;
            int[] novoArrayComPosicoesRetiradas;

            #region chamada dos metodos
            OrdenarArray(ref arrayNumeros);
            MaiorNumeroArray(ref arrayNumeros, ref maiorNumero);
            MenorNumeroArray(ref arrayNumeros, out menorNumero);
            tresMaioresNumeroArray = TresMaioresNumeroDoArray(ref arrayNumeros);
            media = MediaArray(ref arrayNumeros);
            NumerosNegativosDoArray(ref arrayNumeros, out numerosNegativos);
            RetirarPosicaoArray(ref arrayNumeros, valorParaSerRetirado, out novoArrayComPosicoesRetiradas);
            #endregion

            #region impressões na tela
            Imprimir("Maior numero do array: "+maiorNumero.ToString(), true);
            
            Imprimir("", true);
            Imprimir("Menor numero do array: "+menorNumero.ToString(), true);

            Imprimir("", true);
            Imprimir("A média do array listado acima foi de: "+media.ToString(), true);

            Imprimir("", true);
            Imprimir("Segue abaixo os 3 maiores numeros do array", true);
            ImprimirArray(tresMaioresNumeroArray, true);

            Imprimir("Lista de numeros negativos abaixo", true);
            ImprimirArray(numerosNegativos, true);

            Imprimir("Array completo abaixo", true);
            ImprimirArray(arrayNumeros, true);

            Imprimir("Array completo retirando os valores: "+valorParaSerRetirado, true);
            ImprimirArray(novoArrayComPosicoesRetiradas, true);
            #endregion
            Console.ReadKey();
        }
        #region Metodos
        private static void Imprimir(string imprimir, bool quebrarLinha)
        {
            if(quebrarLinha == true)
                Console.WriteLine(imprimir);
            else
                Console.Write(imprimir);
        }
                
        private static void ImprimirArray(int[] arrayNumeros, bool quebrarLinha)
        {
            for (int i = 0; i < arrayNumeros.Length; i++)
                Console.WriteLine("Posição {0} com o valor: {1}", i.ToString(), arrayNumeros[i].ToString());
            
            if (quebrarLinha == true)
                Console.WriteLine("");
        }

        public static void OrdenarArray(ref int[] arrayParaordenar)
        {
            for (int i = 0; i < arrayParaordenar.Length; i++)
            {
                for (int z = 0; z < (arrayParaordenar.Length - 1); z++)
                {
                    int troca;
                    if(arrayParaordenar[z] > arrayParaordenar[z +1])
                    {
                        troca = arrayParaordenar[z];
                        arrayParaordenar[z] = arrayParaordenar[z+1];
                        arrayParaordenar[z + 1] = troca;
                    }
                }
            }
        }
        public static void MaiorNumeroArray(ref int[] arrayParaObterMaior, ref int maiorNumero)
        {
            maiorNumero = arrayParaObterMaior[arrayParaObterMaior.Length - 1];
        }
        public static void MenorNumeroArray(ref int[] arrayParaObterMaior, out int menorNumero)
        {
            menorNumero = arrayParaObterMaior[0];
        }
        public static double MediaArray(ref int[] arrayParaEncontrarMedia)
        {
            double media = 0;

            for (int i = 0; i < arrayParaEncontrarMedia.Length; i++)
                media += arrayParaEncontrarMedia[i];
            
            media /= arrayParaEncontrarMedia.Length;
            return media;
        }
        private static int[] TresMaioresNumeroDoArray(ref int[] arrayNumero)
        {
            int[] tresMaioresDoArray = new int[3];
            int posicao = 0;
            int posicaoMaximaDoArray = arrayNumero.Length -1;
            for (int i = posicaoMaximaDoArray; i > (posicaoMaximaDoArray -3); i--)
            {
                tresMaioresDoArray[posicao] = arrayNumero[i];
                posicao++;
            }
            return tresMaioresDoArray;
        }
        public static void NumerosNegativosDoArray(ref int[] arrayNumero, out int[] numerosNegativos)
        {
            string result = "";

            for (int i = 0; i < arrayNumero.Length; i++)
            {
                if(arrayNumero[i] < 0)
                    result += arrayNumero[i].ToString()+",";
            }
            string[] numeroNegativosString = result.Split(',');
            int[] numeroNegativosDoArray = new int[numeroNegativosString.Length - 1];
            
            for (int i = 0; i < numeroNegativosDoArray.Length; i++)
                numeroNegativosDoArray[i] = Convert.ToInt32(numeroNegativosString[i]);
            

            numerosNegativos = numeroNegativosDoArray;
        }
        public static void RetirarPosicaoArray(ref int[] arrayNumero, int posicaoParaSerRetirada, out int[] novoArrayComPosicoesRetiradas)
        {
            int contaPosicoesParaRetirarDoArray = 0;
            int posicaoParaRetirarDoArray = posicaoParaSerRetirada;
            for (int i = 0; i < arrayNumero.Length; i++)
            {
                if(arrayNumero[i] == posicaoParaRetirarDoArray)
                    contaPosicoesParaRetirarDoArray++;
            }
            int[] arrayNovo = new int[(arrayNumero.Length - contaPosicoesParaRetirarDoArray)];
            int diminuirPosicaoArray = 0;
            for (int i = 0; i < arrayNumero.Length; i++)
            {
                if (arrayNumero[i] != posicaoParaRetirarDoArray)
                    arrayNovo[i- diminuirPosicaoArray] = arrayNumero[i];
                else
                    diminuirPosicaoArray++;
            }

            novoArrayComPosicoesRetiradas = arrayNovo;
        }
        #endregion
    }
}