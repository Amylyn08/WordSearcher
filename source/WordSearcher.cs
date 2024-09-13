namespace WordSearch;

public class WordSearcher{
    
    public ITextSource __textSource{get;}

    //representing last word searched for
    private string __keyWord;

    //getter and setter 
    public string Keyword{
        get => __keyWord;
        set => __keyWord = value;
    }
    public WordSearcher(ITextSource textSource){
        __textSource = textSource;
        __keyWord = "";
    }

    /**This method reads text, acquires keyword, goes in a while loop and iterates count everytime IndexOf finds a keyword in the text. 
        Quits the while loop when index is -1, and returns count of how many occurences there is. **/
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

    /** Uses loop with int occurenceToFind to set the index to the occurence that user wants. Returns empty if nothing is found. 
    sets a start and and end range to create a substring to return, subtracting start from end to get range for substring **/
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
        //making sure it doesn't surpass the textlength.
        int end = Math.Min(index + Keyword.Length + 15, userText.Length);
        result = userText.Substring(start, end - start);
        return result;
    }

}

