using System.Security.Cryptography;

//Baralho Padrão
string[] baralho = new string[52];
for (int i = 0; i < 13; i++)
{
    baralho[i * 4] = (i + 1) + "-Copas";
    baralho[i * 4 + 1] = (i + 1) + "-Espadas";
    baralho[i * 4 + 2] = (i + 1) + "-Ouros";
    baralho[i * 4 + 3] = (i + 1) + "-Paus";
}
// for (int i = 0; i < 52; i++)
// {
//     Console.WriteLine(baralho[i]);

// }
//Dama Removida
int sorteado;
sorteado = RandomNumberGenerator.GetInt32(44, 49);
baralho[sorteado] = null!;
//Ordem Aleatoria
var Ramdom = new Random();
List<int> GeradorNum = Enumerable.Range(0, 52).ToList();
List<int> OrdemAle = new List<int>();
int Esse;
GeradorNum.RemoveAt(sorteado);
for (int i = 0; i < 51; i++)
{
    Esse = Ramdom.Next(0, GeradorNum.Count);
    OrdemAle.Add(GeradorNum[Esse]);
    GeradorNum.RemoveAt(Esse);
}

int Qt_Jogadores = 1;

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.BackgroundColor = ConsoleColor.White;
Console.Write("-----------------Solteirona-----------------");
Console.ResetColor();
Console.Write("\n\n\nQuantos BOTs quer adicionar (De 1 a 12)? ");
//TryParse
Qt_Jogadores += Convert.ToInt32(Console.ReadLine());
if (12 < Qt_Jogadores || Qt_Jogadores < 2)
    return;
int Tam;
Tam = (51 / Qt_Jogadores) + 10;

string[,] Mao = new string[Qt_Jogadores, Tam + 10];

int vez = 0;
for (int x = 0; x < Tam - 10; x++)
{
    for (int y = 0; y < Qt_Jogadores; y++)
    {
        // Console.WriteLine(vez+"-"+OrdemAle[vez]);
        Mao[y, x] = baralho[OrdemAle[vez]];
        vez += 1;
    }
}

if (vez != 51)
{
    for (int x = 0; x < 51 % Qt_Jogadores; x++)
    {
        Mao[x, Tam - 10] = baralho[OrdemAle[vez]];
        vez++;
    }
}

Console.Clear();


//Jogo
Console.Clear();
bool vitoria = true;
int escolha;
int Quem = 0;
string[,] Mesa = ConferirPares(Mao, Qt_Jogadores, Tam);
int Prox = 0;
while (vitoria)
{
    Console.Clear();
    MostrarMesa(Mesa);
    MaoJogador(Tam, Mao);
    for (Quem = 0; Quem < Qt_Jogadores; Quem++)
    {
        if (Quem == Qt_Jogadores - 1)
            Prox = 0;
        else
            Prox++;
        escolha = Escolher(Quem, Tam, Mao);
        Mao = MaosNovas(Mao, escolha, Quem, Qt_Jogadores, Prox);
        Mesa = AdicionarMesa(Mesa, Mao, Qt_Jogadores,Quem);
    }
    Console.ReadKey();
}

static string[,] MaosNovas(string[,] Mao, int escolha, int Quem, int Ult, int Prox)
{
    int TamR = 0;
    int y = 0;
    Console.WriteLine(Quem + "  " + Prox + "  " + y);
    if (Quem == 0)
        escolha++;
    for (int x = 0; x < escolha;)
    {
        Console.WriteLine(x + "  " + Mao[Prox, y] + "  " + y);
        if (Mao[Prox, y] == "" || Mao[Prox, y] == null)
        {
            y++;
        }
        else
        {
            x++;
        }
    }
    for (int x = 0, z = 0; x < 1; z++)
    {
        if (Mao[Quem, z] != null && Mao[Quem, z] != "")
        {
            TamR++;
        }
        else
        {
            x++;
        }
    }
    Console.WriteLine("Carta Pega: " + Mao[Prox, y]);
    Mao[Quem, TamR] = Mao[Prox, y];
    Mao[Prox, y] = "";
    return Mao;
}



static int Escolher(int Quem, int Tam, string[,] Mao)
{
    int p = 0;
    int escolha = 0;
    int TamR = 1;
    for (int x = 0; x < Tam + 9; x++)
    {
        if (Mao[Quem, x] != "" && Mao[Quem, x] != null)
        {
            TamR++;
        }
    }
    if (Quem == 0)
    {
        Console.Write($"\n\nEscolha um numero entre 1 e {TamR}: ");
        escolha = Convert.ToInt32(Console.ReadLine());
        if (1 > escolha || escolha > TamR)
            Environment.Exit(0);
    }
    else
    {
        escolha = RandomNumberGenerator.GetInt32(1, TamR + 1);
    }
    Console.Write(p);
    return escolha - 1;
}




// siglaA = Mao[0, 0].Substring(0,1);
// siglaB = Mao[0, 1].Substring(0,1);
// Console.Write($"Combine {siglaB} e {siglaA} ");
string[,] ConferirPares(string[,] Mao, int Qt_Jogadores, int Tam)
{
    int Ordem = 1;
    string[,] Mesa = new string[13, 50];
    for (int y = 0; y < Qt_Jogadores; y++)
    {
        // Console.WriteLine($"\n\nJogador {y + 1}: \nPares: ");
        int vez = 0;
        for (int x = 0; x < Tam + 9; x++)
        {
            for (int z = 0; z < Tam + 9; z++)
            {
                if (Mao[y, x] != "" && Mao[y, z] != "" && Mao[y, z] != null && Mao[y, x] != null)
                {
                    // Console.WriteLine(Mao[y, x] + "  " + Mao[y, z]);
                    if (Mao[y, x].IndexOf('-') == 2 && Mao[y, z].IndexOf('-') == 2)
                    {
                        // Console.Write($"Combine {siglaB} e {siglaA}");
                        if (Mao[y, z].Substring(0, 2) == Mao[y, x].Substring(0, 2) && z != x)
                        {
                            Mesa[y, vez] = $" |{Mao[y, z],-10} | {Mao[y, x],10}| ";
                            // Console.WriteLine($"Igual |{Mao[y, z]}{Mao[y, x]}|");
                            vez++;
                            Ordem++;
                            Mao[y, x] = "";
                            Mao[y, z] = "";
                            z = Tam - 10;
                        }
                    }
                    else if (Mao[y, x].IndexOf('-') == 1 && Mao[y, z].IndexOf('-') == 1)
                    {
                        // Console.Write($"Combine {siglaB} e {siglaA}");
                        if ((Mao[y, z].Substring(0, 1) == Mao[y, x].Substring(0, 1)) && z != x)
                        {
                            // Console.WriteLine($"Igual |{Mao[y, z]}{Mao[y, x]}|");
                            Mesa[y, vez] = $" |{Mao[y, z],-10} | {Mao[y, x],10}| ";
                            vez++;
                            Ordem++;
                            Mao[y, x] = "";
                            Mao[y, z] = "";
                            z = Tam;
                        }
                    }
                }
            }
        }
    }
    return Mesa;
}
string[,] AdicionarMesa(string[,] Mesa, string[,] Mao, int Qt,int Que)
{
    // Console.WriteLine($"\n\nJogador {y + 1}: \nPares: ");
        int Parte = 0;
        for (int a = 0; a < Mesa.GetLength(Que); a++)
        {
            Parte++;
        }
    for (int x = 0; x < Tam + 9; x++)
    {
        for (int z = 0; z < Tam + 9; z++)
        {
            if (Mao[Que, x] != "" && Mao[Que, z] != "" && Mao[Que, z] != null && Mao[Que, x] != null)
            {
                // Console.WriteLine(Mao[Que, x] + "  " + Mao[Que, z]);
                if (Mao[Que, x].IndexOf('-') == 2 && Mao[Que, z].IndexOf('-') == 2)
                {
                    // Console.Write($"Combine {siglaB} e {siglaA}");
                    if (Mao[Que, z].Substring(0, 2) == Mao[Que, x].Substring(0, 2) && z != x)
                    {
                        Mesa[Que, Parte] = $" |{Mao[Que, z],-10} | {Mao[Que, x],10}| ";
                        // Console.WriteLine($"Igual |{Mao[Que, z]}{Mao[Que, x]}|");
                        vez++;
                        Mao[Que, x] = "";
                        Mao[Que, z] = "";
                        z = Tam - 10;
                    }
                }
                else if (Mao[Que, x].IndexOf('-') == 1 && Mao[Que, z].IndexOf('-') == 1)
                {
                    // Console.Write($"Combine {siglaB} e {siglaA}");
                    if ((Mao[Que, z].Substring(0, 1) == Mao[Que, x].Substring(0, 1)) && z != x)
                    {
                        // Console.WriteLine($"Igual |{Mao[Que, z]}{Mao[Que, x]}|");
                        Mesa[Que, Parte] = $" |{Mao[Que, z],-10} | {Mao[Que, x],10}| ";
                        vez++;
                        Mao[Que, x] = "";
                        Mao[Que, z] = "";
                        z = Tam;
                    }
                }
        }
    }
    }
    return Mesa;

}

void MostrarMesa(string[,] Mesa)
{
    Console.Clear();
    Console.WriteLine("Mesa atual:");
    for (int x = 0; x < 12; x++)
    {
        for (int y = 0; y < 26; y++)
        {
            if (Mesa[x, y] != null)
            {
                if (x == 0)
                    Console.WriteLine($"{Mesa[x, y]} - Você colocou");
                else
                    Console.WriteLine($"{Mesa[x, y]}");
            }
        }
    }
}

static void MaoJogador(int Tam, string[,] Mao)
{
    Console.WriteLine("Sua Mão:");
    for (int x = 0; x < Tam + 1; x++)
    {
        if (Mao[0, x] != "" && Mao[0, x] != null)
        {
            if (Mao[0, x].Contains("Copas"))
                Console.ForegroundColor = ConsoleColor.Red;
            else if (Mao[0, x].Contains("Espadas"))
                Console.ForegroundColor = ConsoleColor.Black;
            else if (Mao[0, x].Contains("Ouros"))
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (Mao[0, x].Contains("Paus"))
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($"|{Mao[0, x]}|");
            Console.ResetColor();
            Console.Write(" ");
            if (x == 11)
                Console.WriteLine();
        }
    }
}







// Carta de cada jogador
// for (int x = 0; x < Qt_Jogadores; x++)
// {
//     for (int y = 0; y < Tam+1; y++)
//     {
//         if(Mao[x,y] != null)
//     Console.WriteLine("Jogador: "+(x+1)+"\nCarta: "+Mao[x,y]);
//     }

// }



// for (int i = 0; i < Tam; i++)
// {
//     for (int x = 0; x < Qt_Jogadores; x++)
//     {
//     }
// }

















//Ver divisão
//     Console.Clear();
// for (int i = 1; i != 12; i++)
// {
// Console.WriteLine(51/i);
// Console.WriteLine(51%i+"\n\n");

// }



// int qt_jog = 0, qt_bot = 0;

// Console.WriteLine("------Solteirona------");
// Console.Write("Quantos Jogadores irão jogar (De 1 á 12): ");
// qt_jog = int.Parse(Console.ReadLine()!);
// if(qt_jog<=1){return;}
// if(qt_jog<12 && qt_jog>1){
// Console.Write($"Quantos Bots irão jogar (De 0 á {12-qt_jog}): ");
// qt_bot = int.Parse(Console.ReadLine()!);
// if(qt_bot<0 || qt_bot> 12-qt_jog){return;}}
// else if(qt_jog<12){
// Console.Write($"Quantos Bots irão jogar (De 0 á {12-qt_jog}): ");
// qt_bot = int.Parse(Console.ReadLine()!);
// if(qt_bot<1 || qt_bot> 12-qt_jog){return;}}
// string[] baralho = new string[52];
// int qt_taM = Convert.ToInt32(Math.Round(Convert.ToDecimal(51/(qt_jog+qt_bot)+1)));
// string[,] mao = new string[qt_jog + qt_bot, qt_taM];
// for (int i = 0; i < 13;i++)
// {
//     baralho[i*4] = i+"-Copas";
//     baralho[i*4+1] = i+"-Espadas";
//     baralho[i*4+2] = i+"-Ouros";
//     baralho[i*4+3] = i+"-Paus";
// }
// // for (int i = 0; i < 52; i++)
// // {
// //     Console.WriteLine(baralho[i]);

// // }

// int sorteado;
// sorteado=RandomNumberGenerator.GetInt32(44,49);
// baralho[sorteado] = null!;
// for (int i = 0; i < (qt_jog+qt_bot); i++)
// {
//     for (int x = 0; x < qt_taM; x++)
//     {
//         sorteado = RandomNumberGenerator.GetInt32(1,52);
//         if(baralho[sorteado] == null)
//         {
//             x--;
//         }
//         else
//         {
//             mao[i,x] = baralho[sorteado];
//             baralho[sorteado] = null!;
//         }
//     }
//     if(1 == qt_taM%2)
//     {
//         for (int x = 0; x < 1; x++)
//         {
//         sorteado = RandomNumberGenerator.GetInt32(1,52);
//         if(baralho[sorteado] == null)
//         {
//             x--;
//         }
//         else
//         {
//             mao[i,x] = baralho[sorteado];
//             baralho[sorteado] = null!;
//         }
//         }
//     }
// }

// for (int i = 0; i < (qt_jog+qt_bot); i++)
// {
//     Console.WriteLine("Cara "+i);
//     for (int x = 0; x < 52/(qt_jog+qt_bot); x++)
//     {
//     Console.WriteLine(mao[i,x]);
//     }
// }
// Console.WriteLine("A");
