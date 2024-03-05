using System.Net;

namespace WordSearch;
public class WebTextSource : ITextSource{

    private string __filePath{get; set;}

    public WebTextSource(string filepath){
        __filePath = filepath;
    }
    public string ReadText(){
        //Creating a webClient instant 
        WebClient myWebClient = new WebClient();

        //Download home page data.
        Stream myStream = myWebClient.OpenRead(__filePath);
        StreamReader sr = new StreamReader(myStream);
        string dataToString = sr.ReadToEnd();

        myStream.Close();
        
        return dataToString;
    }
}