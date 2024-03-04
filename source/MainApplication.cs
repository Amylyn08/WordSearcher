namespace WordSearch;

public class MainApplication{

    private List<ITextSource> __textSources;
    public static void AddSource(){
        Console.WriteLine("Hello. Please enter the number for the source of your text: ");
        Console.WriteLine("1. User Input");
        Console.WriteLine("2. Website");
        Console.WriteLine("3. File");
        int sourceOfText = Convert.ToInt32(GetValidInput());

        ITextSource source;

        switch (sourceChoice)
        {
            case 1:
                source = new UserTextSource();
                break;
            case 2:
                Console.WriteLine("Please enter the URL of the website:");
                string websiteUrl = Console.ReadLine();
                source = new WebTextSource(websiteUrl);
                break;
            case 3:
                Console.WriteLine("Please enter the file path:");
                string filePath = Console.ReadLine();
                source = new FileTextSource(filePath);
                break;
            default:
                throw new ArgumentException("Invalid choice. Please retry");
        }

        __textSources.Add(source);
    }

    public static void SearchKeyWord(){
        Console.WriteLine("What is the keyword you would like to search for?");
        string userDesire = GetValidInput();

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
}