using System;
static class Extensions
{
    public static bool IsFibonacci(this int value)//Завдання 1
    {
        int a = 0;
        int b = 1;

        while (b < value)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }

        return b == value;
    }
    public static int WordCount(this string text)//Завдання 2
    {
        string[] words = text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public static int LastWord(this string str)//Завдання 3
    {
        string[] words = str.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length > 0)
        {
            string lastWord = words[words.Length - 1];
            return lastWord.Length;
        }
        else
        {
            return 0; 
        }
    }


    public static bool IsValid(this string str)//Завдання 4
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in str)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                    return false;

                char top = stack.Peek();
                if ((top == '(' && c == ')') || (top == '{' && c == '}') || (top == '[' && c == ']'))
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    public static int[] Filter(this int[] array, Func<int, bool> predicate)
    {
        return array.Where(predicate).ToArray();
    }

}
class Program
{
    static void Main(string[] args)
    {
        int n = 5;
        string Line = "My name I Yura";
        string str1 = "{}[]";
        string str2 = "{)))}[]";
        int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Console.WriteLine(n.IsFibonacci());
        Console.WriteLine(Line.WordCount());
        Console.WriteLine(Line.LastWord());
        Console.WriteLine(str1.IsValid()); 
        Console.WriteLine(str2.IsValid());
        int[] evenNumbers = Arr.Filter(x => x % 2 == 0);
        Console.WriteLine("Парнi числа:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

    }
}
