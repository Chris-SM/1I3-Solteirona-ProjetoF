using System.Security.Cryptography;

int qt_jog = 0, qt_bot = 0;

Console.WriteLine("------Solteirona------");
Console.Write("Quantos Jogadores irão jogar (De 1 á 12): ");
qt_jog = int.Parse(Console.ReadLine()!);
if(qt_jog<=1){return;}
if(qt_jog<12 && qt_jog>1){
Console.Write($"Quantos Bots irão jogar (De 0 á {12-qt_jog}): ");
qt_bot = int.Parse(Console.ReadLine()!);
if(qt_bot<0 || qt_bot> 12-qt_jog){return;}}
else if(qt_jog<12){
Console.Write($"Quantos Bots irão jogar (De 0 á {12-qt_jog}): ");
qt_bot = int.Parse(Console.ReadLine()!);
if(qt_bot<1 || qt_bot> 12-qt_jog){return;}}
string[] baralho = new string[52];
int qt_taM = Convert.ToInt32(Math.Round(Convert.ToDecimal(51/(qt_jog+qt_bot)+1)));
string[,] mao = new string[qt_jog + qt_bot, qt_taM];
for (int i = 0; i < 13;i++)
{
    baralho[i*4] = i+"-Copas";
    baralho[i*4+1] = i+"-Espadas";
    baralho[i*4+2] = i+"-Diamante";
    baralho[i*4+3] = i+"-Paus";
}
// for (int i = 0; i < 52; i++)
// {
//     Console.WriteLine(baralho[i]);
    
// }

int sorteado;
sorteado=RandomNumberGenerator.GetInt32(44,49);
baralho[sorteado] = null!;
for (int i = 0; i < (qt_jog+qt_bot); i++)
{
    for (int x = 0; x < qt_taM; x++)
    {
        sorteado = RandomNumberGenerator.GetInt32(1,52);
        if(baralho[sorteado] == null)
        {
            x--;
        }
        else
        {
            mao[i,x] = baralho[sorteado];
            baralho[sorteado] = null!;
        }
    }
    if(1 == qt_taM%2)
    {
        for (int x = 0; x < 1; x++)
        {
        sorteado = RandomNumberGenerator.GetInt32(1,52);
        if(baralho[sorteado] == null)
        {
            x--;
        }
        else
        {
            mao[i,x] = baralho[sorteado];
            baralho[sorteado] = null!;
        }
        }
    }
}

for (int i = 0; i < (qt_jog+qt_bot); i++)
{
    Console.WriteLine("Cara "+i);
    for (int x = 0; x < 52/(qt_jog+qt_bot); x++)
    {
    Console.WriteLine(mao[i,x]);
    }
}
Console.WriteLine("A");