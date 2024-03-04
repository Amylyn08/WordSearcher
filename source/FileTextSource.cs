namespace WordSearch;
public class FileTextSource : ITextSource{

    private string __path;

    public FileTextSource(string path){
        __path = path;
    }
    public string ReadText(){
        //open the file to read from!!
        return File.ReadAllText(__path);
    }

    
}