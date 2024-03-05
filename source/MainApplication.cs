using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

[assembly: InternalsVisibleTo("WordSearchTest")]
namespace WordSearch;
public class MainApplication{

    private static List<ITextSource> __textSources = new List<ITextSource>();
    public static void Main(string[] args){
        MainApplication mainApp = new();
        bool isValid = true;
        do{
            try{
                mainApp.AddSources();
                mainApp.CommenceSearches();
                Console.WriteLine("Goodbye!");
                isValid = false;
            }
            catch (FormatException){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input.. let's try again");
            }
            catch (ArgumentException e){
                Console.Write(e.Message);
            }
            Console.ResetColor();
            Console.WriteLine();
        }while(isValid);
    }

    public MainApplication(){
        Console.WriteLine("Welcome to WordSearcher!");
    }

    private void AddSources(){
            int userNumSources = 0; 
            do{
                Console.WriteLine("How many sources would you like to add?");
                userNumSources = Convert.ToInt32(GetValidInput());
            }
            while(!NumSourcesInput(userNumSources));
            int counter = 0;
            do{
                AddSource();
                counter++;
            }
            while(counter < userNumSources);
    }

    private void CommenceSearches(){
        string userWantToContinue = "Y";
        do{
            SearchKeyWord();
            Console.WriteLine("Would you like to continue? (Y) or (N)");
            userWantToContinue= GetValidInput();
        }
        while(!ContinueInput(userWantToContinue));
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
        Console.WriteLine($" \nWhat is the keyword you would like to search for?");
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

    internal static bool NumSourcesInput(int numSources){
        if (numSources <= 0){
            throw new ArgumentException("Number or sources cannot be less than or equal to 0");
        }
        return true;
    }
    
    internal static bool ContinueInput(string input){
        if (!input.Equals("Y", StringComparison.OrdinalIgnoreCase) && !input.Equals("N", StringComparison.OrdinalIgnoreCase)){
            throw new ArgumentException("Please enter either Y or N");
        }
        if(input.Equals("N", StringComparison.OrdinalIgnoreCase)) return true;
        else return false;
    }
}
