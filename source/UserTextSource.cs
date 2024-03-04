namespace WordSearch;
public class UserTextSource : ITextSource{

    private string __text;

    public UserTextSource(){
        Console.WriteLine("Enter in some text");
        __text = Console.ReadLine();

    }
    public string ReadText(){
        return __text;
    }
}