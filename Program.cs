//  Jonathan Bodrero
//  June 13, 2025
//  Lab 4 Mastermind

//Console.Write("Hola Mundo!");
using System.ComponentModel.DataAnnotations;

int secretLength = 4;
int numberLetters = 7;
int guessNumber = 1;      //  Count number of guesses
int numCorrect = 0; // Number of letters in correct location
int numWrong = 0;   // Number of letters in seq but in wrong location
string secret = "egad";
string inputGuess = "zzzz";
string currentGuess = "xxxx";

// Greeting and game instructions.
Console.Clear();
Console.WriteLine("Greetings!  Let's play a logic game called Mastermind.");
Console.WriteLine($"I will create a secret sequence of {secretLength} letters from 'a' to 'g' and no letter appears more than once.");
Console.WriteLine("Your job is to guess my secret sequence in as few guesses as possible.");
Console.WriteLine("At each turn, I'll tell you how many letters are in the correct location (but not which ones) and \nhow many are in the sequence but in the wrong location.");
Console.WriteLine("Are you ready to play?  Press any key to continue.\n");
Console.ReadKey(true);


do
{
    Console.WriteLine($"Guess #{guessNumber}: Please guess a sequence of {secretLength} lowercase letters with no repeats.");
    currentGuess = Console.ReadLine().ToLower();


    guessNumber++;
}
while (currentGuess != secret);

