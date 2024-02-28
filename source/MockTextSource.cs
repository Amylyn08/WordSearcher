namespace WordSearch;
public class MockTextSource : ITextSource{
    private String __text;

    public override String ReadText(){
        // this.__text = Console.ReadLine() NOT READING 
    }

    public MockTextSource(String text){
        this.__text = text;
    }
}
