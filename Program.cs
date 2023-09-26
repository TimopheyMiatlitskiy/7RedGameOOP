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
        int firstCombinationLength = int.Parse(Console.ReadLine());
        Card[] set1 = new Card[firstCombinationLength];

        Console.WriteLine("Enter the cards of the first set. (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
        HintClass.Hint();
        for (int i = 0; i < firstCombinationLength; i++)
        {
            string cardString = Console.ReadLine();
            set1[i] = new Card(cardString);
        }

        Console.WriteLine("Enter the size of the second combination (from 1 to 7):");
        int n2 = int.Parse(Console.ReadLine());
        Card[] set2 = new Card[n2];

        Console.WriteLine("Enter the cards of the second set. (from 1 to 7) with color (R/O/Y/G/C/B/P) of the card:");
        HintClass.Hint();
        for (int i = 0; i < n2; i++)
        {
            string cardString = Console.ReadLine();
            set2[i] = new Card(cardString);
        }

        GameHelper.CompareSets(set1, set2);
    }
}
