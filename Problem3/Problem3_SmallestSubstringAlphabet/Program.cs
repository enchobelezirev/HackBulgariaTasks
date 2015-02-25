using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_SmallestSubstringAlphabet
{
    class Program
    {
        const int ALPHABET_LETTERS_COUNT = 26;
        static void printLetters(List<char> letters)
        {
            foreach (char letter in letters)
            {
                Console.Write("{0}", letter);
            }
        }
        static List<char> findAlphabetInAnyHalf(int start, int end, string str)
        {
            List<char> lettersFound = new List<char>();
            List<char> alphabetLettersFoundList = new List<char>();
            bool addElement = false;
            int alphabetLettersFound = 0;
            for (int index = start; index < end; index++)
            {
                if (alphabetLettersFound == ALPHABET_LETTERS_COUNT)
                {
                    break;
                }
                if (str[index] >= 'a' && str[index] <= 'z')
                {
                    if (!alphabetLettersFoundList.Contains(str[index]))
                    {
                        lettersFound.Add(str[index]);
                        addElement = true;
                        alphabetLettersFound++;
                        alphabetLettersFoundList.Add(str[index]);
                    }
                    else
                    {
                        lettersFound.Add(str[index]);
                    }
                }
                else if (addElement)
                {
                    lettersFound.Add(str[index]);
                }

            }

            return lettersFound;
        }
        static int checkHalfSubstring(int startIndex, int endIndex, string str)
        {
            int symbolsCounter = 0;
            string halfSubstr = str.Substring(startIndex, endIndex - startIndex);
            for (int index = startIndex; index < endIndex; index++)
            {
                if (str[index] == 'z')
                {
                    symbolsCounter++;
                }
                if (str[index] >= 'a' && str[index] <= 'z')
                {
                    int nextCharAscii = str[index] + 1;
                    if (halfSubstr.Contains((char)nextCharAscii))
                    {
                        symbolsCounter++;
                    }
                }
            }
            return symbolsCounter;
        }
        static bool checkForAlphabet(string str)
        {
            bool isAlphabet = false;
            for (int index = 0; index < str.Length; index++)
            {
                if (str[index] >= 'a' && str[index] <= 'z')
                {
                    int nextLetterAscii = (int)str[index] + 1;
                    if (str.Contains((char)nextLetterAscii))
                    {
                        isAlphabet = true;
                    }
                    
                }
            }
            return isAlphabet;
        }
        static void smallestSubstringContainingTheAlphabet(string str)
        {
            bool isAlphabet = checkForAlphabet(str);
            if (isAlphabet)
            {
                int middle = str.Length / 2;
                int firstHalfAlphabetLettersCount = checkHalfSubstring(0, middle, str);
                int secondHalfAlphabetLettersCount = checkHalfSubstring(middle, str.Length, str);

                if (firstHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT && secondHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT)
                {
                    List<char> lettersInTheFirstHalf = findAlphabetInAnyHalf(0, middle, str);
                    List<char> lettersInTheScondHalf = findAlphabetInAnyHalf(middle, str.Length, str);
                    int fakeElementsInFirstHalf = lettersInTheFirstHalf.Count(x => x < 'a' || x > 'z');
                    int fakeElementsInSecondHalf = lettersInTheScondHalf.Count(x => x < 'a' || x > 'z');
                    if (fakeElementsInFirstHalf < fakeElementsInSecondHalf)
                    {
                        printLetters(lettersInTheFirstHalf);
                    }
                    else
                    {
                        printLetters(lettersInTheScondHalf);
                        
                    }
                }
                else if (secondHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT)
                {
                    List<char> letters = findAlphabetInAnyHalf(middle, str.Length, str);
                    printLetters(letters);
                }
                else if (firstHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT)
                {
                    List<char> letters = findAlphabetInAnyHalf(0, middle, str);
                    printLetters(letters);
                }
                else if (firstHalfAlphabetLettersCount != ALPHABET_LETTERS_COUNT && secondHalfAlphabetLettersCount != ALPHABET_LETTERS_COUNT)
                {
                    List<char> lettersAlphabetInHalfs = new List<char>();
                    int endIndexForTheFirstHalf = 0;
                    int startIndexForTheSecondHalf = 0;
                    for (int index = middle; index < str.Length; index++)
                    {
                        if (firstHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT)
                        {
                            endIndexForTheFirstHalf = index + 1;
                            break;
                        }
                        if (str[index] >= 'a' && str[index] <= 'z')
                        {
                            if (!lettersAlphabetInHalfs.Contains(str[index]))
                            {
                                firstHalfAlphabetLettersCount++;
                                lettersAlphabetInHalfs.Add(str[index]);
                            }
                            
                        }
                    }

                    List<char> lettersInFirstHalf = findAlphabetInAnyHalf(0, endIndexForTheFirstHalf, str);
                    lettersAlphabetInHalfs = new List<char>();
                    for (int index = str.Length-1; index >= middle; index--)
                    {
                        lettersAlphabetInHalfs.Add(str[index]);
                    }
                    for (int index = middle; index >= 0; index--)
                    {
                        if (secondHalfAlphabetLettersCount == ALPHABET_LETTERS_COUNT)
                        {
                            startIndexForTheSecondHalf = index;
                            break;
                        }
                        if (str[index] >= 'a' && str[index] <= 'z')
                        {
                            if (!lettersAlphabetInHalfs.Contains(str[index]))
                            {
                                secondHalfAlphabetLettersCount++;
                                lettersAlphabetInHalfs.Add(str[index]);
                            }
                            
                        }

                    }

                    List<char> lettersInSecondHalf = findAlphabetInAnyHalf(startIndexForTheSecondHalf, str.Length, str);
                    int fakeElementsInFirstHalf = lettersInFirstHalf.Count(x => x < 'a' || x > 'z');
                    int fakeElementsInSecondHalf = lettersInSecondHalf.Count(x => x < 'a' || x > 'z');
                    if (fakeElementsInFirstHalf < fakeElementsInSecondHalf)
                    {
                        printLetters(lettersInFirstHalf);
                        
                    }
                    else
                    {
                        printLetters(lettersInSecondHalf);
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no alphabet in the input string");
            }
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string inputString = Console.ReadLine();
            smallestSubstringContainingTheAlphabet(inputString);
            Console.WriteLine();
        }
    }
}
