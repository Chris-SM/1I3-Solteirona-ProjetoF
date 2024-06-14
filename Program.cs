using System.Security.Cryptography;
//Baralho Padrão
string[] baralho = new string[52];
 for (int i = 0; i < 13;i++)
{
    baralho[i*4] = (i+1)+"-Copas";
    baralho[i*4+1] = (i+1)+"-Espadas";
    baralho[i*4+2] = (i+1)+"-Diamante";
    baralho[i*4+3] = (i+1)+"-Paus";
}
// for (int i = 0; i < 52; i++)
// {
//     Console.WriteLine(baralho[i]);
    
// }
//Dama Removida
int sorteado;
sorteado=RandomNumberGenerator.GetInt32(44,49);
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

int Qt_Jogadores=1;

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.BackgroundColor = ConsoleColor.White;
Console.Write("-----------------Solteirona-----------------");
Console.ResetColor();
Console.Write("\n\n\nQuantos BOTs quer adicionar (De 1 a 12)? ");
//TryParse
Qt_Jogadores += Convert.ToInt32(Console.ReadLine());
if(12<Qt_Jogadores || Qt_Jogadores<2)
return;
int Tam;
Tam = 51/Qt_Jogadores;

string[,] Mao= new string[Qt_Jogadores,Tam+1];

int vez = 0;
for (int x = 0; x < Tam; x++)
{
    for (int y = 0; y < Qt_Jogadores; y++)
    {
        // Console.WriteLine(vez+"-"+OrdemAle[vez]);
        Mao[y,x] = baralho[OrdemAle[vez]];
        vez +=1;
    }
}

if(vez != 51){
    for (int x = 0; x < 51%Qt_Jogadores; x++)
    {
        Mao[x,Tam] = baralho[OrdemAle[vez]];
        vez++;
    }
}

Console.Clear();
string[,] Mesa = new string[12,27];




Console.WriteLine("Sua Mão:");
for (int x = 0; x < Tam+1; x++)
{
    if(Mao[0,x] != null)
    {
        if(Mao[0,x].Contains("Copas"))
        Console.ForegroundColor = ConsoleColor.Red;
        else if(Mao[0,x].Contains("Espadas"))
        Console.ForegroundColor = ConsoleColor.Black;
        else if(Mao[0,x].Contains("Diamante"))
        Console.ForegroundColor = ConsoleColor.Yellow;
        else if(Mao[0,x].Contains("Paus"))
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write($"|{Mao[0,x]}|");
        Console.ResetColor();
        Console.Write(" ");
        if(x==10)
        Console.WriteLine();
    }
}
if(Mesa!=null)
{
    for (int x = 0; x < Qt_Jogadores; x++)
    {
        Console.WriteLine("");
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
//     baralho[i*4+2] = i+"-Diamante";
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
