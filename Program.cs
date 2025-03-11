Random random = new Random();

List<int> answer = new List<int>();

for (int i = 0; i < 4; i++)
{
    int randomNumber = random.Next(1, 7);
    answer.Add(randomNumber);
}

int attempts = 0;
bool gameWon = false;


Console.WriteLine($"In this game you will try to guess a secret 4 digit number. Each digit can between 1 and 6." +
           $"If you guess the correct number in the correct position a + will be returned. " +
           $"If you guess a correct number but in the wrong position a - will be returned. " +
           $"Nothing will be returned for an incorrect number. There may be duplicates in the secret number. You have 10 guesses to accurately identify the number");

while (attempts < 10)
{
    List<int> guess = new List<int>();
    List<int> tempAnswer = answer;
    string responsePluses = "";
    string responseMinuses = "";
    bool repeatErrorMessage = false;
    bool validationError = false;
    List<int> matches = new List<int>();
    
    Console.WriteLine($"Please guess a number. You have {10 - attempts} remaining guesses. For testing purposes the answer is {string.Join("", answer)}");
   
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
                if (!repeatErrorMessage)
                {
                    Console.WriteLine("All digits must be between 1 and 6");
                    repeatErrorMessage = true;
                    validationError = true;
                }
                continue;
            }
        }
    }
    else if (userInput.Length != 4)
    {
        Console.WriteLine("Your guess must be 4 digits in length");
        validationError = true;
        continue;
    }
    else
    {
        Console.WriteLine("You must enter a number");
        validationError = true;
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
                matches.Add(guess[g]);
            }
            else if(answer[a] == guess[g] && !matches.Contains(guess[g]))
            {
                responseMinuses += "-";
                matches.Add(guess[g]);
            }
        }
    }

    Console.WriteLine(responsePluses + responseMinuses);

    if (!validationError)
    {
        attempts++;
    }

    responsePluses = "";
    responseMinuses = "";
    repeatErrorMessage = false;
    validationError = false;
    matches.Clear();
}

if (gameWon)
{
    Console.WriteLine("You guessed the secret number, congratulations! Winner winner chicken dinner!");
} else
{
    Console.WriteLine($"You have used all of your guesses and still haven't guessed the secret number. You lose, the number was {string.Join("", answer)}");
}
