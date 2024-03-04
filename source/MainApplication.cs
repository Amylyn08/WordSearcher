using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace WordSearch;

public class MainApplication{

    private static List<ITextSource> __textSources = new List<ITextSource>();
    public static void Main(string[] args){
        bool isValid = true;
            do{
                try{
                int userNumSources = NumSourcesInput();
                int counter = 0;
                do{
                    AddSource();
                    counter++;
                }
                while(counter < userNumSources);
                
                bool userContinueSearch;
                do{
                    SearchKeyWord();
                    string userWantToContinue = ContinueInput();
                    userContinueSearch = userWantToContinue.Equals("Y", StringComparison.OrdinalIgnoreCase);
                }
                while(userContinueSearch);
                isValid = false;
                }
                catch (FormatException){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input.. let's restart");
                }
                catch (ArgumentException e){
                    Console.WriteLine(e.Message);
                }
                Console.ResetColor();

            }     
        while(isValid);
    }
    public static void AddSource(){
        Console.WriteLine("Please enter the number for the source of your text: ");
        Console.WriteLine("1. User Input");
        Console.WriteLine("2. Website");
        Console.WriteLine("3. File");
        int sourceOfText = Convert.ToInt32(GetValidInput());

        ITextSource source;

        switch (sourceOfText)
        {
            case 1:
                source = new UserTextSource();
                break;
            case 2:
                Console.WriteLine("Please enter the URL of the website:");
                //for url to test, use my URL: http://10.172.17.32:8888/
                string websiteUrl = GetValidInput();
                source = new WebTextSource(websiteUrl);
                break;
            case 3:
                Console.WriteLine("Please enter the file path:");
                string filePath = GetValidInput();
                source = new FileTextSource(filePath);
                break;
            default:
                throw new ArgumentException("Invalid choice. Please retry");
        }
        __textSources.Add(source);
    }

    public static void SearchKeyWord(){
        Console.WriteLine($" \n What is the keyword you would like to search for?");
        string userDesire = GetValidInput();
        foreach (ITextSource source in __textSources){
             WordSearcher searcher = new WordSearcher(source);
             int occurences = searcher.Search(userDesire);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n ---------Results---------");
            for(int i=0; i<occurences;i++){
                string result = searcher.FindOccurence(i);
                if (result.Equals("")){
                    Console.WriteLine("Nothing in the texts matches the keyword you've indicated.");
                }
                else{
                    Console.WriteLine(result);
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    //used code from Maintaining concentration lab
    //will keep reading line until user enters a non null value.
    private static string GetValidInput()
    {
        string? input;
        do
        {
            input = Console.ReadLine();
        } while (input == null);
        return input;
    }

    private static int NumSourcesInput(){
        Console.WriteLine("How many sources would you like to add?");
        int userNumSources = Convert.ToInt32(GetValidInput());
        if (userNumSources <= 0){
            throw new ArgumentException("Number or sources cannot be less than or equal to 0");
        }
        return userNumSources;
    }
    
    private static string ContinueInput(){
        Console.WriteLine("Would you like to continue? (Y) or (N)");
        string answer = GetValidInput();
        if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase) || !answer.Equals("N", StringComparison.OrdinalIgnoreCase)){
            throw new ArgumentException("Please enter either Y or N");
        }
        return answer;
    }
}
