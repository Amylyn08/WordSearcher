namespace WordSearch;
public class UserTextSource : ITextSource{

    private String __text;
    private override String ReadText(){
        Console.WriteLine("Please enter some text:");
        __text = Console.ReadLine();
        return __text;
    }

}