//  Jonathan Bodrero
//  June 13-17, 2025
//  Lab 4 Mastermind

using System.Globalization;

// Set some initial parameters.
int secretLength = 4;   
int inputLength = 0;    // Use to verify input is correct length
int guessNumber = 1;      //  Count number of guesses
int numCorrect = 0; // Number of letters in correct location
int numWrong = 0;   // Number of letters in seq but in wrong location
string secret = "egad";
string inputGuess = "zzzz";
string currentGuess = "xxxx";
int randy;
char tempChar = 'z';
string tempString = "";


// Greeting and game instructions.
Console.Clear();
Console.WriteLine("Greetings!  Let's play a logic game called Mastermind.");
Console.WriteLine("I will create a secret sequence of letters (no repeats) and you'll try to guess the sequence in as few turns as possible.");
Console.WriteLine("Are you ready to play?  Press any key to continue.");
Console.ReadKey(true);
Console.Write("How many letters long do you want the sequence to be?  Enter a whole number from 4 to 9. ");  // Get Length of secret code; Top value could easily be made a variable instead of 9.
bool inLengthBool = false;
do
{

    int inLength = Convert.ToInt32(Console.ReadLine());
    if (inLength >= 4 && inLength <= 9)
    {
        inLengthBool = true;
        secretLength = inLength;
    }
    if (inLength < 4 || inLength > 9)
    {
        Console.WriteLine("Oops. That's not a number from 4 to 9.  Try again.");
    }
} while (inLengthBool == false);

//  Get number of letters to use.  
Console.Write($"\nStarting with the letter 'a', how many different letters do you want me to choose from?\nThis must be at least as many letters as the length of the sequence, {secretLength}, and up to 10 letters."  );
int numberLetters = 4;  //  Set initial numberLetters = 4.
bool inNumberLettersBool = false;
do
{

    int inNumberLetters = Convert.ToInt32(Console.ReadLine());
    if (inNumberLetters >= secretLength && inNumberLetters <= 10)
    {
        inNumberLettersBool = true;
        numberLetters = inNumberLetters;
    }
    if (inNumberLetters < secretLength || inNumberLetters > 10)
    {
        Console.WriteLine($"Oops. That's not a number from {secretLength} to 10.  Try again.");
    }
} while (inNumberLettersBool == false);


int topNumber = 97 + numberLetters;
Random rand = new Random();     //Generate a random sequence of different values to turn into letters.
for (int i = 0; i < secretLength; i++)
{
    do
    {
        randy = rand.Next(97, topNumber);  // Generate random number in bounds for characters a - ?
        tempChar = Convert.ToChar(randy);   //  Convert random number to a character.

        if (!tempString.Contains(tempChar)) //  Check to see if string already has character
        { tempString = string.Concat(tempString, tempChar); }   //  If new character, add to string
    } while (tempString.Length < i + 1);            // else pick a new random number.

}
// secret = tempString;        //  Set secret to the randomly generated string.
Console.WriteLine($"{secret}");  // Used for debugging code.
do
{
    numCorrect = 0;
    numWrong = 0;
    // Get input and check for correct length.
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
            Console.WriteLine($"Congrats!  You found my secret code of \"{secret}\" in {guessNumber} guesses.");
        }
        else
        {
            Console.WriteLine($"\tYou have {numCorrect} letter(s) in the correct location.");
            Console.WriteLine($"\tYou have {numWrong} letter(s) in the wrong location.\n");
        }
    guessNumber++;  // Keep track of number of guesses.
}
while (currentGuess != secret);
