//  Jonathan Bodrero
//  June 13, 2025
//  Lab 4 Mastermind

//Console.Write("Hola Mundo!");

using System.Globalization;

int secretLength = 4;   // Length of secret code
int inputLength = 0;    // Use to verify input is correct length
int numberLetters = 7;
int topNumber = 97 + numberLetters;
int guessNumber = 1;      //  Count number of guesses
int numCorrect = 0; // Number of letters in correct location
int numWrong = 0;   // Number of letters in seq but in wrong location
string secret = "egad";
string inputGuess = "zzzz";
string currentGuess = "xxxx";
char[] hidden = new char[secretLength];
int randy;
char tempChar = 'z';
string tempString = "";

Random rand = new Random();
for (int i = 0; i < secretLength; i++)
{
    do
    {
        randy = rand.Next(97, topNumber);
        Console.WriteLine($"{randy}");  // Debugging
        tempChar = Convert.ToChar(randy);
        if (!tempString.Contains(tempChar))
        { tempString = string.Concat(tempString, tempChar); }
    } while (!tempString.Contains(tempChar));
    
}
Console.Clear();
//Console.WriteLine(hidden);  // Debugging.
secret = string.Concat(hidden);
//secret = Convert.ToString(hidden);  //  This didn't work.
Console.WriteLine($"secret = {secret}");

// Greeting and game instructions.
Console.WriteLine("Greetings!  Let's play a logic game called Mastermind.");
Console.WriteLine($"I will create a secret sequence of {secretLength} letters from 'a' to 'g' and no letter appears more than once.");
Console.WriteLine("Your job is to guess my secret sequence in as few guesses as possible.");
Console.WriteLine("At each turn, I'll tell you how many letters are in the correct location and \nhow many are in the sequence but in the wrong location (but not which ones).");
Console.WriteLine("Are you ready to play?  Press any key to continue.\n");
Console.ReadKey(true);


do
{
    numCorrect = 0;
    numWrong = 0;
    // Get input and check for correcdt length.
    Console.Write($"Guess #{guessNumber}: Please guess a sequence of {secret.Length} lowercase letters with no repeats.\n  ");
    do
    {
        inputLength = 0;
        inputGuess = Console.ReadLine().ToLower();
        if (inputGuess.Length != secret.Length)
        {
            Console.Write($"Oops.  That's not the right number of letters to guess.  Try again with {secret.Length} letters. \n  ");
        }
        else
        {
            inputLength = secret.Length;
        }
    }
    while (inputLength != secret.Length);

    currentGuess = inputGuess;  // If correct length, set currentGuess to inputGuess

    for (int i = 0; i < secretLength; i++)  //Check each position to see if letter is correct
    {
        if (currentGuess[i] == secret[i])
        { numCorrect++; }
        else
        {
            for (int j = 0; j < secretLength; j++)  //If not correct in posn, check other posns.
            {
                if (secret[i] == currentGuess[j])
                {
                    numWrong++;
                }
            }
        }

    }
    
    if (numCorrect == secretLength)  // Determine if game ends.  If not, move to next guess.
        {
            Console.WriteLine($"Congrats!  You found my secret code of {secret} in {guessNumber} guesses.");
        }
        else
        {
            Console.WriteLine($"\tYou have {numCorrect} letter(s) in the correct location.");
            Console.WriteLine($"\tYou have {numWrong} letter(s) in the wrong location.\n");
        }
    guessNumber++;  // Keep track of number of guesses.
}
while (currentGuess != secret);


