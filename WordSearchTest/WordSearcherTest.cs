using System.Runtime.CompilerServices;
using WordSearch;

namespace WordSearchTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void WordSearcherInstantiatingCorrectly(){
        //Arrange
        string someText ="C# (pronounced C sharp)[b] is a general-purpose high-level programming language supporting multiple paradigms. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines";
        MockTextSource mocker = new(someText);
        //Act
        WordSearcher searcher = new(mocker);
        //Assert
        Assert.AreEqual(mocker, searcher.__textSource);
    }

    [TestMethod]
    public void TestSearchGivesCorrectNums(){
        //Arrange
        string someText ="C# (pronounced C sharp)[b] is a general-purpose high-level programming language supporting multiple paradigms. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines";
        MockTextSource mocker = new(someText);
        WordSearcher searcher = new(mocker);

        //Act
        int occurences = searcher.Search("programming");

        //Assert
        Assert.AreEqual(occurences, 2);
    }
    
    [TestMethod]
    public void TestSearchGivesNothing(){
        //Arrange
        string someText ="C# (pronounced C sharp)[b] is a general-purpose high-level programming language supporting multiple paradigms. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines";
        MockTextSource mocker = new(someText);
        WordSearcher searcher = new(mocker);

        //Act
        int occurences = searcher.Search("kittens");

        //Assert
        Assert.AreEqual(occurences, 0);
    }

    [TestMethod]
    public void FindFirstOccurenceOfTextCorrect(){
        //Arrange
        string someText ="C# (pronounced C sharp)[b] is a general-purpose high-level programming language supporting multiple paradigms. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines";
        MockTextSource mocker = new(someText);
        WordSearcher searcher = new(mocker);

        //Act
        string result = searcher.FindOccurence(1);

        //Assert
        StringAssert.Equals(result, "ose high-level programming language suppo");
    }

    [TestMethod]
    public void FindOccurenceGivesEmptyString(){
        //Arrange
        string someText ="C# (pronounced C sharp)[b] is a general-purpose high-level programming language supporting multiple paradigms. C# encompasses static typing, strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines";
        MockTextSource mocker = new(someText);
        WordSearcher searcher = new(mocker);
        searcher.Keyword = "Kitten";

        //Act
        string result = searcher.FindOccurence(1);

        //Assert
        Assert.AreEqual(result, "");
    }
}

