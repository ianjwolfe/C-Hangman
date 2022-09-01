/*
C# Hangman Game
• Picks a word at random, RandomWord function is passed into the Game function.
• Player guesses a letter, only loses a guess if letter has no matches.
• Game ends in a loss when out of guesses.
• Game ends in a win if word is fully deciphered.
*/
namespace Hangman
{
    internal class Program
    {
        static void Main()
        {
            Game(RandomWord());
        }

        static void Game(string chosenword)
        {
            string word = chosenword.ToLower();
            char[] guess = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
                guess[i] = '*';

            var guesscheck = new string(guess.ToArray());


            char playerGuess = 'S';

            bool CorrectGuess = false;


            int guessleft = 3;


            Console.WriteLine("Word: " + new string(guess));
            Console.WriteLine("Guesses left: " + guessleft.ToString());
            Console.WriteLine();

            while (word != guesscheck && guessleft > 0)
            {
                guesscheck = new string(guess.ToArray());

                if (word != guesscheck)
                {
                    Console.Write("Guess: ");
                    try
                    {
                        playerGuess = char.Parse(Console.ReadLine().ToLower());
                        CorrectGuess = false;
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("That's not a single letter.");
                        // Don't penalize for misinputs
                        CorrectGuess = true;
                    }
                }

                for (int j = 0; j < word.Length; j++)
                {
                    if (playerGuess == word[j])
                    {
                        guess[j] = playerGuess;
                        CorrectGuess = true;
                    }
                }

                if (CorrectGuess == false)
                {
                    guessleft--;
                }

                if (word != guesscheck)
                {
                    Console.WriteLine("Word: " + new string(guess));
                    Console.WriteLine("Guesses left: " + guessleft.ToString());
                    Console.WriteLine();

                }
            }

            Console.WriteLine(guessleft > 0 ? "You won!" : "You lost.");
        }

        static string RandomWord()
        {
            string[] words = { 
                "Animal", 
                "Beautiful", 
                "Carriage", 
                "Earth", 
                "Broom", 
                "Education" };

            Random rnd = new Random();

            return (words[rnd.Next(0,words.Length)]);
        }
    }
}