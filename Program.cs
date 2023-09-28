class Card : IComparable<Card>
{
    public int Value
    {
        get; set;
    }
    public char Color
    {
        get; set;
    }

    public Card(int value, char color)
    {
        Value = value;
        Color = color;
    }

    public Card(string cardString)
    {
        string[] cardParams = cardString.Split(' ');
        Value = int.Parse(cardParams[0]);
        Color = char.Parse(cardParams[1]);
    }

    public int CompareTo(Card other)
    {
        if (Value > other.Value)
            return 1;
        else if (Value < other.Value)
            return -1;
        else
        {
            string rainbowColors = "ROYGCBP";
            int index1 = rainbowColors.IndexOf(Color);
            int index2 = rainbowColors.IndexOf(other.Color);
            return index2.CompareTo(index1);
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Card))
            return false;
        Card other = (Card)obj;
        return Value == other.Value && Color == other.Color;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode() ^ Color.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Value} {Color}";
    }

    public static int CheckNumberInput(int number)
    {
        for (int i = 0; i < 1; i++)
        {
            int maxSize = 7;
            int minSize = 1;
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
            if (number > maxSize || number < minSize)
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }
        return number;
    }

    static bool CheckLetter(char Letter)
    {
        string colors = "ROYGCBP";
        int pulpe = colors.IndexOf(Letter);

        if (pulpe >= 0)
            return true;
        else
            return false;
    }

    public static string CheckNumLet(string cardStr)
    {
        for (int i = 0; i < 1; i++)
        {
            HintClass.Hint();
            int maxSize = 7;
            int minSize = 1;
            int cardLength = 2;
            string str = Console.ReadLine();
            string[] strSplit = str.Split();

            if (strSplit.Length != cardLength || !int.TryParse(strSplit[0], out _) || !char.TryParse(strSplit[1], out _))
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }

            if (Convert.ToInt32(strSplit[0]) <= maxSize && Convert.ToInt32(strSplit[0]) >= minSize && CheckLetter(Convert.ToChar(strSplit[1].ToUpper())))
            {
                cardStr = str;
            }
            else
            {
                Console.WriteLine("uncorrect input");
                i--;
                continue;
            }
        }
        return cardStr;
    }
}

class GameHelper
{
    public static void CompareSets(Card[] set1, Card[] set2)
    {
        Array.Sort(set1);
        Array.Sort(set2);
        Console.WriteLine("Sorted set 1:");
        foreach (Card card in set1)
            Console.WriteLine(card);
        Console.WriteLine("Sorted set 2:");
        foreach (Card card in set2)
            Console.WriteLine(card);
        Console.WriteLine();

        Card maxCard1 = set1[set1.Length - 1];
        Card maxCard2 = set2[set2.Length - 1];

        if (maxCard1.CompareTo(maxCard2) > 0)
            Console.WriteLine("Set 1 wins!");
        else if (maxCard1.CompareTo(maxCard2) < 0)
            Console.WriteLine("Set 2 wins!");
        else
            Console.WriteLine("It's a tie!");
    }


}

class HintClass
{
    public static void Hint()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("1 R");
        Console.ResetColor();
        Console.SetCursorPosition(0, Console.CursorTop);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the first combination (from 1 to 7):");
        //int firstCombinationLength = int.Parse(Console.ReadLine());
        int firstCombLength = 0;
        firstCombLength = Card.CheckNumberInput(firstCombLength);
        Card[] set1 = new Card[firstCombLength];

        Console.WriteLine("Enter the cards of the first set. (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
        for (int i = 0; i < firstCombLength; i++)
        {
            string cardString = "";
            cardString = Card.CheckNumLet(cardString);
            set1[i] = new Card(cardString);
        }

        Console.WriteLine("Enter the size of the second combination (from 1 to 7):");
        int secondCombLength = 0;
        secondCombLength = Card.CheckNumberInput(secondCombLength);
        Card[] set2 = new Card[secondCombLength];

        Console.WriteLine("Enter the cards of the second set. (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
        for (int i = 0; i < secondCombLength; i++)
        {
            string cardString = "";
            cardString = Card.CheckNumLet(cardString);
            set2[i] = new Card(cardString);
        }

        GameHelper.CompareSets(set1, set2);
    }
}
