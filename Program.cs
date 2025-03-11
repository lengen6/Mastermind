Random random = new Random();

List<int> answer = new List<int>();

for (int i = 0; i <= 4; i++)
{
    int randomNumber = random.Next(1, 7);
    answer.Add(randomNumber);
}

int attempts = 0;
bool gameWon = false;

while (attempts <= 10)
{
    List<int> guess = new List<int>();
    string responsePluses = "";
    string responseMinuses = "";

    if (attempts == 0)
    {
        Console.WriteLine($"In this game you will try to guess a secret 4 digit number. Each digit can between 1 and 6. If you guess the correct number in the correct position a + will be returned. If you " +
            $" guess a correct number but in the wrong position a - will be returned. Nothing will be returned for an incorrect number. There may be duplicates in the secret number. You have 10 guesses to accurately identify the number");
    }
    else
    {
        Console.WriteLine($"Please guess a number. You have {10 - attempts} remaining guesses");
    }

    var userInput = Console.ReadLine();

    if (int.TryParse(userInput, out int x) && userInput.Length == 4)
    {
        foreach (char c in userInput)
        {
            if (int.TryParse(c.ToString(), out int number) && number >= 1 && number <= 6)
            {
                guess.Add(number);
            }
            else
            {
                Console.WriteLine("All digits must be between 1 and 6");
                continue;
            }
        }
    }
    else if (userInput.Length != 4)
    {
        Console.WriteLine("Your guess must be 4 digits in length");
        continue;
    }
    else
    {
        Console.WriteLine("You must enter a number");
        continue;
    }

    if(guess.SequenceEqual(answer))
    {
        gameWon = true;
        break;
    }

    for(int a = 0; a < answer.Count; a++)
    {
        for(int g = 0; g < guess.Count; g++)
        {
            if(a == g && answer[a] == guess[g])
            {
                responsePluses += "+";
            }
            else if(answer[a] == guess[g])
            {
                responseMinuses += "-";
            }
        }
    }

    Console.WriteLine(responsePluses + responseMinuses);
    attempts++;
}

if (gameWon)
{
    Console.WriteLine("You guessed the secret number, congratulations! Winner winner chicken dinner!");
} else
{
    Console.WriteLine($"You have used all of your guesses and still haven't guessed the secret number. You lose, the number was {answer.ToString()}");
}
