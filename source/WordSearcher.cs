namespace WordSearch;

public class WordSearcher{
    
    private readonly ITextSource __textSource;

    //representing last word searched for
    private string __keyWord;
    public string Keyword{
        get => __keyWord;
        set => __keyWord = value;
    }
    public WordSearcher(ITextSource textSource){
        __textSource = textSource;
        __keyWord = "";
    }

    public int Search(string keyword){
        string userText = __textSource.ReadText();
        __keyWord = keyword;

        int count = 0;
        int index = userText.IndexOf(keyword);

        //if no further occurences happen, -1 shoudl be returned and the loop is over.
        while ( index != -1){
            count ++;
            //ensures searching does not overlap from eachother. Length+1 prohibits that.
            index = __textSource.ReadText().IndexOf(keyword, index + keyword.Length);
        }
        return count;
    }

    public string FindOccurence(int occurenceToFind)
    {
        string userText = __textSource.ReadText();
        string result = "";
        
        int index = userText.IndexOf(Keyword);
        for (int i = 0; i < occurenceToFind; i++)
        {
            index = userText.IndexOf(Keyword, index + Keyword.Length);
            if (index == -1)
                return "";
        }
        
        int start = Math.Max(0, index - 15);
        int end = Math.Min(index + Keyword.Length + 15, userText.Length);
        result = userText.Substring(start, end - start);
        
        return result;
    }

}

//apple pepeee apple pepee papplelkjhflkhasdgkbjsadlnksadfkbjasdflkn