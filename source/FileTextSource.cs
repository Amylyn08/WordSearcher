namespace WordSearch;
public class FileTextSource : ITextSource{

    private string __path;

    public FileTextSource(string path){
        __path = path;
    }
    
    //open the file to read from!!
    public string ReadText(){
        return File.ReadAllText(__path);
    }

    
}