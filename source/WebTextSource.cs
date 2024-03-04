namespace WordSearch;
public class WebTextSource : ITextSource{

    private String __filePath {get; set;}

    public WebTextSource(String filepath){
        __filePath = filepath;
    }
    public override String ReadText(){
        //Creating a webClient instant 
        WebClient myWebClient = new WebClient();

        //Download home page data.
        Stream myStream = myWebclient.OpenRead(__filePath);
        StreamReader sr = new StreamReader(myStream);
        String dataToString = sr.ReadToEnd();

        myStream.Close();
        
        return dataToString;
    }
}