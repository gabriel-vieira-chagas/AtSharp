class Program
{
    static void Main(string[] args)
    {
        string nome = "Gabriel Vieira Chagas";
        Console.WriteLine("Nome inicial: " + nome);

        char[] caracteres = nome.ToCharArray(); //Utiliza metodo nativo do C# para criar um array dos caracteres do nome

        for (int i = 0; i < caracteres.Length; i++) // Executa o código seguinte no tamanho de letras existentes no array
        {
            char Letra = caracteres[i]; //Cria variável auxiliar, para alterar o caractere no array
            if (char.IsLetter(Letra)) //Utiliza metodo nativo do C# para verificar se é letra
            {
                char deslocado = (char)(Letra + 2); //Cria variavel para deslocar o caractere

                if ((char.IsUpper(Letra) && deslocado > 'Z') || (char.IsLower(Letra) && deslocado > 'z'))
                //Verifica com método nativo se é minúsculo ou maiusculo e se o deslocado passou de Z. 
                {
                    deslocado = (char)(deslocado - 26); //Caso tenha passado, volta 26 caracteres
                }

                caracteres[i] = deslocado; //Altera o caracter no array na mesma posição
            }
        }

        string nomeCodificado = new string(caracteres); //Transforma todo o array numa string
        Console.WriteLine("Nome codificado: " + nomeCodificado); //Exibe o resultado
    }
}

/*
 Inicialmente foi criado um array de caracteres utilizando o método nativo do C#, “ToCharArray()”.
Então é criado um for que executará o código inserido nele para cada letra desse array. 
É criado uma variável Letra para verificar se o caractere é uma letra, 
pois caso seja um espaço ou outro caractere especial, ele não será alterado. 
Caso seja uma letra, cria-se uma variável para atribuir o deslocamento de duas posições.
Após isso, verificasse se passou dez maiúsculo ou minúscula, sendo essa verificação da escrita feita com um método nativo.
Caso tenha passado, o programa volta 26 posições, para encontrar sua letra correspondente, que agora está no início.
Por fim, o caractere é alterado no array, e o array é transformado em uma única string para exibir o resultado.
 */