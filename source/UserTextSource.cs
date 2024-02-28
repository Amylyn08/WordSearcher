namespace WordSearch;
public class UserTextSource : ITextSource{

    private String __text;
    private override String ReadText(){
        String userinput = Console.ReadLine();
        // return userinput;
    }

}