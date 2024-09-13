namespace WordSearch;
public class MockTextSource : ITextSource{
    private string __text;
    public MockTextSource(string textfromuser){
        __text = textfromuser;
    }
    public string ReadText(){
        return __text;
    }


}
