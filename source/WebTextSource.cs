namespace WordSearch;
public class WebTextSource : ITextSource{

    private String __filePath {get; set;}

    public WebTextSource(String filepath){
        this.__filePath = filepath
    }
    public override String ReadText(){
        //Creating a webClient instant 
        WebClient myWebClient = new WebClient();
        //Download home page data.
        Stream myStream = myWebclient.OpenRead(this.__filePath);
        StreamReader sr = new StreamReader(myStream);
        String dataToString = sr.ReadToEnd();

        myStream.Close();
        
        return dataToString;
    }
}