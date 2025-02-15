Console.WriteLine("Oryginalna wiadomość:");
var inputMessage = "Dzisiaj jest czwartek,\nA jutro bedzie piatek.";
Console.WriteLine(inputMessage);
Console.WriteLine();

var outputMessage = "";
var messageLength = inputMessage.Length;
for (var i = 0; i < messageLength; i++)
{
    if (inputMessage.ElementAt(i).Equals(' '))
    {
        outputMessage += inputMessage.ElementAt(i+1).ToString().ToUpper();
        i++;
    } else
    {
        outputMessage += inputMessage.ElementAt(i);
    }
}
Console.WriteLine("Wiadomość po zmianie:");
Console.WriteLine(outputMessage);

