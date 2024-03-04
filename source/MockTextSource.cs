namespace WordSearch;
public class MockTextSource : ITextSource{
    private String __text;

    public override String ReadText(){
        return __text;
    }

    public MockTextSource(String textfromuser){
        __text = textfromuser;
    }
}
