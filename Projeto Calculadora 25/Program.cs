using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Calculadora_25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)

            {
                Console.Clear();
                Console.WriteLine("\n\n     Menu de conversão de base:      ");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("|                                   |");
                Console.WriteLine("| 1.  Decimal     ->   Binário      |");
                Console.WriteLine("| 2.  Binário     ->   Decimal      |");
                Console.WriteLine("| 3.  Decimal     ->   Octal        |");
                Console.WriteLine("| 4.  Octal       ->   Decimal      |");
                Console.WriteLine("| 5.  Decimal     ->   Hexadecimal  |");
                Console.WriteLine("| 6.  Hexadecimal ->   Decimal      |");
                Console.WriteLine("| 7.  Binário     ->   Octal        |");
                Console.WriteLine("| 8.  Octal       ->   Binário      |");
                Console.WriteLine("| 9.  Binário     ->   Hexadecimal  |");
                Console.WriteLine("| 10. Hexadecimal ->   Binário      |");
                Console.WriteLine("| 11. Octal       ->   Hexadecimal  |");
                Console.WriteLine("| 12. Hexadecimal ->   Octal        |");
                Console.WriteLine("|                                   |");
                Console.WriteLine("| 0. Sair                           |");
                Console.WriteLine("-------------------------------------");
                Console.Write("Opção: ");

                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 0) break;

                switch (opcao)
                {

                    case 1:
                        DecimalBinario();
                        break;
                    case 2:
                        BinarioDecimal();
                        break;
                    case 3:
                        DecimalOctal();
                        break;
                    case 4:
                        OctalDecimal();
                        break;
                    case 5:
                        DecimalHexadecimal();
                        break;
                    case 6:
                        HexadecimalDecimal();
                        break;
                    case 7:
                        BinarioOctal();
                        break;
                    case 8:
                        OctalBinario();
                        break;
                    case 9:
                        BinarioHexadecimal();
                        break;
                    case 10:
                        HexadecimalBinario();
                        break;
                    case 11:
                        OctalHexadecimal();
                        break;
                    case 12:
                        HexadecimalOctal();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            }
        }


        static void DecimalBinario()
        {

            int numero;
            string binario = " ";
            int resto;
            int pass = 1;
            int quocinte = 0;

            Console.WriteLine("Passo 1: Recebemos o valor a converter ");
            Console.WriteLine("Escreva o numero que deseja converter");
            numero = Convert.ToInt32(Console.ReadLine());


            while (numero > 0)
            {
                Console.WriteLine("passo->" + pass);
                quocinte = numero / 2;
                Console.WriteLine("Quociente ->" + quocinte);
                resto = numero % 2;
                Console.WriteLine("Resto ->" + resto);
                binario = resto + binario;
                numero = numero / 2;
                pass++;

            }

        }

        static void BinarioDecimal()
        {
            {
                string numeroBinario;
                Console.WriteLine("\nDigite um número binário: ");
                numeroBinario = Console.ReadLine();

                int numeroDecimal = ConvertBinarioParaDecimal(numeroBinario);
                Console.WriteLine($"\nO número binário {numeroBinario} é igual a {numeroDecimal} em decimal.");
            }

            int ConvertBinarioParaDecimal(string numeroBinario)
            {
                int numeroDecimal = 0;
                Console.WriteLine("\nPassos de conversão:");

                for (int i = numeroBinario.Length - 1; i >= 0; i--)

                {
                    int digitValue = numeroBinario[i] == '1' ? 1 : 0;
                    int digitWeight = (int)Math.Pow(2, numeroBinario.Length - 1 - i);
                    int digitContribution = digitValue * digitWeight;

                    Console.WriteLine($"- {digitValue} * 2^{numeroBinario.Length - 1 - i} = {digitContribution}");

                    numeroDecimal += digitContribution;

                }

                Console.WriteLine($"\nSoma total dos valores dos passos de conversão: {numeroDecimal}");

                return numeroDecimal;
            }
        }

        static void DecimalOctal()
        {
            {
                Console.WriteLine("\nDigite um número decimal para converter para octal: ");
                int numeroDecimal = int.Parse(Console.ReadLine());

                string numeroOctal = ConvertDecimalParaOctal(numeroDecimal);
                Console.WriteLine($"O número decimal {numeroDecimal} é igual a {numeroOctal} em octal.\n");
            }
        }
         static string ConvertDecimalParaOctal(int numeroDecimal)
            {
                string numeroOctal = "";
                string passosConversao = "";

                while (numeroDecimal > 0)
                {
                    int resto = numeroDecimal % 8;

                    numeroOctal = resto.ToString() + numeroOctal;

                    numeroDecimal /= 8;

                    passosConversao = $"{resto} + {passosConversao}";

                    Console.WriteLine($"Passo: {numeroDecimal} / 8 = {numeroDecimal / 8} (resto {resto})");
                }

                passosConversao = passosConversao.Remove(passosConversao.Length - 2);

                Console.WriteLine(passosConversao);

                return numeroOctal;
            }
        

        static void OctalDecimal()
        {
            Console.WriteLine("\nDigite um número octal para converter para decimal: ");
            string numeroOctal = Console.ReadLine();

            int numeroDecimal = ConvertOctalParaDecimal(numeroOctal);
            Console.WriteLine($"\nO número octal {numeroOctal} é igual a {numeroDecimal} em decimal.");
        }

        static int ConvertOctalParaDecimal(string numeroOctal)
        {
            int numeroDecimal = 0;

            Console.WriteLine("\nPassos de conversão:");

            for (int i = 0; i < numeroOctal.Length; i++)
            {
                int digito = int.Parse(numeroOctal[i].ToString());

                int potencia = numeroOctal.Length - 1 - i;
                int contribuicao = digito * (int)Math.Pow(8, potencia);

                Console.WriteLine($"Dígito: {digito}, Posição: {potencia}, Contribuição: {digito} * 8^{potencia} = {contribuicao}");

                numeroDecimal += contribuicao;
            }

            Console.WriteLine($"\nSoma total das contribuições: {numeroDecimal}");

            return numeroDecimal;
        }

        static void DecimalHexadecimal()
        {
            int numero;
            string binario = "";
            int resto;
            int pass = 1;
            int quociente = 0;


            Console.WriteLine("Escreva o número que deseja converter para hexadecimal");
            numero = Convert.ToInt32(Console.ReadLine());


            while (numero > 0)
            {

                quociente = numero / 2;
                resto = numero % 2;
                binario = resto + binario;
                numero = numero / 2;
                pass++;



            }
            Console.WriteLine("Seu número em binário é:" + binario);

            int posicoes = binario.Length;
            int resto2 = posicoes % 4;
            string hexadecimal = "";



            if (resto2 > 0)
            {

                int novoszeros = 4 - resto2;


                for (int i = 0; i < novoszeros; i++)
                {
                    binario = "0" + binario;
                }

            }

            hexadecimal += Hexadecimal(binario);
            Console.WriteLine("Seu número em hexadecimal é:" + hexadecimal);


        }

        static string Hexadecimal(string binario)
        {

            string hexadecimal = "";

            for (int i = 0; i < binario.Length; i += 4)
            {
                string conversao = "";

                for (int a = 0; a < 4; a++)
                {
                    if (i + a < binario.Length)
                    {
                        conversao += binario[i + a];
                    }
                    else
                    {
                        conversao += "0";
                    }


                }
                switch (conversao)
                {
                    case "0000": hexadecimal += "0"; break;
                    case "0001": hexadecimal += "1"; break;
                    case "0010": hexadecimal += "2"; break;
                    case "0011": hexadecimal += "3"; break;
                    case "0100": hexadecimal += "4"; break;
                    case "0101": hexadecimal += "5"; break;
                    case "0110": hexadecimal += "6"; break;
                    case "0111": hexadecimal += "7"; break;
                    case "1000": hexadecimal += "8"; break;
                    case "1001": hexadecimal += "9"; break;
                    case "1010": hexadecimal += "A"; break;
                    case "1011": hexadecimal += "B"; break;
                    case "1100": hexadecimal += "C"; break;
                    case "1101": hexadecimal += "D"; break;
                    case "1110": hexadecimal += "E"; break;
                    case "1111": hexadecimal += "F"; break;
                }
            }
            return hexadecimal;
        }

        static void HexadecimalDecimal()
        {
            string numero;

            Console.WriteLine("Digite o numero hexadecimal que deseja converter:");
            numero = Convert.ToString(Console.ReadLine());

            int tamanho = 0;

            while (tamanho < numero.Length && numero[tamanho] != '\0')
            {
                tamanho++;
            }

            int numerodecimal = 0;

            for (int i = tamanho - 1, expoente = 0; i >= 0; i--, expoente++)
            {
                int numerodigitado;
                char caractere = numero[i];

                if (caractere >= '0' && caractere <= '9')
                {
                    numerodigitado = caractere - '0';
                }
                else if (caractere > -'A' && caractere <= 'F')
                {
                    numerodigitado = 10 + (caractere - 'A');
                }
                else if (caractere >= 'a' && caractere <= 'f')
                {
                    numerodigitado = 10 + (caractere - 'a');
                }
                else
                {
                    Console.WriteLine("Seu número hexadecimal é invalido para a conversão");
                    return;
                }

                numerodecimal += numerodigitado * (int)Math.Pow(16, expoente);
                Console.WriteLine("O resultado da conversão de hexadecimal para decimal é:" + numerodecimal);
            }
        }

        static void BinarioOctal()
        {
            Console.WriteLine("\nDigite um número binário para converter para octal: ");
            string numeroBinario = Console.ReadLine();

            string numeroOctal = ConvertBinarioParaOctal(numeroBinario);
            Console.WriteLine($"\nO número binário {numeroBinario} é igual a {numeroOctal} em octal.");
        }

        static string ConvertBinarioParaOctal(string numeroBinario)
        {
            while (numeroBinario.Length % 3 != 0)
            {
                numeroBinario = "0" + numeroBinario;
            }

            string numeroOctal = "";
            Console.WriteLine("\nPassos de conversão:");

            for (int i = 0; i < numeroBinario.Length; i += 3)
            {
                string grupoBinario = numeroBinario.Substring(i, 3);

                int digitoOctal = 0;
                int potencia = 2;

                Console.WriteLine($"Grupo binário: {grupoBinario}");

                for (int j = 0; j < 3; j++)
                {
                    int digitoBinario = grupoBinario[j] - '0';
                    int contribuicao = digitoBinario * (int)Math.Pow(2, potencia);
                    Console.WriteLine($"Dígito binário: {digitoBinario}, Posição: 2^{potencia}, Contribuição: {digitoBinario} * 2^{potencia} = {contribuicao}");
                    digitoOctal += contribuicao;
                    potencia--;
                }

                numeroOctal += digitoOctal.ToString();

                Console.WriteLine($"Resultado do grupo binário {grupoBinario} -> Octal: {digitoOctal}\n");
            }

            return numeroOctal;
        }

        static void OctalBinario()
        {
            Console.WriteLine("\nDigite um número octal para converter para binário: ");
            string numeroOctal = Console.ReadLine();

            string numeroBinario = ConvertOctalParaBinario(numeroOctal);
            Console.WriteLine($"\nO número octal {numeroOctal} é igual a {numeroBinario} em binário.");
        }

        static string ConvertOctalParaBinario(string numeroOctal)
        {
            string numeroBinario = "";
            Console.WriteLine("\nPassos de conversão:");

            for (int i = 0; i < numeroOctal.Length; i++)
            {
                int digitoOctal = int.Parse(numeroOctal[i].ToString());
                string grupoBinario = Convert.ToString(digitoOctal, 2).PadLeft(3, '0');

                Console.WriteLine($"Dígito octal: {digitoOctal} -> Binário: {grupoBinario}");

                numeroBinario += grupoBinario;
            }

            return numeroBinario;
        }

        static void BinarioHexadecimal()
        {
            string binario = "";
            string hexadecimal = "";

            Console.WriteLine("Escreva o número binário que deseja converter:");
            binario = Convert.ToString(Console.ReadLine());

            int zeros_a_adicionar = 4 - (binario.Length % 4);
            if (zeros_a_adicionar != 4)
            {
                binario = new string('0', zeros_a_adicionar) + binario;
            }


            for (int i = 0; i < binario.Length; i += 4)
            {
                string conversao = binario.Substring(i, 4);

                switch (conversao)
                {
                    case "0000": hexadecimal += "0"; break;
                    case "0001": hexadecimal += "1"; break;
                    case "0010": hexadecimal += "2"; break;
                    case "0011": hexadecimal += "3"; break;
                    case "0100": hexadecimal += "4"; break;
                    case "0101": hexadecimal += "5"; break;
                    case "0110": hexadecimal += "6"; break;
                    case "0111": hexadecimal += "7"; break;
                    case "1000": hexadecimal += "8"; break;
                    case "1001": hexadecimal += "9"; break;
                    case "1010": hexadecimal += "A"; break;
                    case "1011": hexadecimal += "B"; break;
                    case "1100": hexadecimal += "C"; break;
                    case "1101": hexadecimal += "D"; break;
                    case "1110": hexadecimal += "E"; break;
                    case "1111": hexadecimal += "F"; break;
                }

            }
            Console.WriteLine("Seu número em hexadecimal é: " + hexadecimal);

        }


        static void HexadecimalBinario()
        {
            string hexadecimal = "";
            string binario = "";

            Console.WriteLine("Escreva o número hexadecimal que deseja converter:");
            hexadecimal = Console.ReadLine();


            string hexadecimalMaiusculo = "";
            foreach (char caractere in hexadecimal)
            {
                if (caractere >= 'a' && caractere <= 'f')
                {

                    hexadecimalMaiusculo += (char)(caractere - 'a' + 'A');
                }
                else
                {

                    hexadecimalMaiusculo += caractere;
                }
            }

            foreach (char digito in hexadecimalMaiusculo)
            {
                switch (digito)
                {
                    case '0': binario += "0000"; break;
                    case '1': binario += "0001"; break;
                    case '2': binario += "0010"; break;
                    case '3': binario += "0011"; break;
                    case '4': binario += "0100"; break;
                    case '5': binario += "0101"; break;
                    case '6': binario += "0110"; break;
                    case '7': binario += "0111"; break;
                    case '8': binario += "1000"; break;
                    case '9': binario += "1001"; break;
                    case 'A': binario += "1010"; break;
                    case 'B': binario += "1011"; break;
                    case 'C': binario += "1100"; break;
                    case 'D': binario += "1101"; break;
                    case 'E': binario += "1110"; break;
                    case 'F': binario += "1111"; break;
                    default:
                        Console.WriteLine("Caractere inválido no número hexadecimal.");
                        return;
                }
            }


            int primeiroUm = 0;
            while (primeiroUm < binario.Length && binario[primeiroUm] == '0')
            {
                primeiroUm++;
            }
            binario = binario.Substring(primeiroUm);

            if (binario == "")
            {
                binario = "0";
            }

            Console.WriteLine("Seu número em binário é: " + binario);
        }
    

        static void OctalHexadecimal()
        {
            int numero;

            Console.WriteLine("Escreva o numero que deseja converter:");
            numero = Convert.ToInt32(Console.ReadLine());
        }
       
        static void HexadecimalOctal()
        {
            int numero;

            Console.WriteLine("Escreva o numero que deseja converter:");
            numero = Convert.ToInt32(Console.ReadLine());
        }
    }
}