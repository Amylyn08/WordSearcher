using WordSearch;

namespace WordSearchTest;
[TestClass]

public class MainApplicationTest{

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void testNumSourcesNotValidThrowsArgumentException(){
        //Arange, act
        bool isValid = MainApplication.NumSourcesInput(-1);
    }

    [TestMethod]
    public void testNumSourcesInputIsValid(){
        //Arrange,act
        bool isValid = MainApplication.NumSourcesInput(1);

        //Assert
        Assert.IsTrue(isValid);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ContinueInputThrowsArgumentException(){
        //Arrange
        string inputWrong = "banana";
        //Act
        MainApplication.ContinueInput(inputWrong);
    }

    [TestMethod]
    public void ContinueInputIsValid_returnsTrue(){
        //Arrange
        string inputNo = "N";

        //Act
        bool isValid = MainApplication.ContinueInput(inputNo);

        //Assert
        Assert.IsTrue(isValid);
    }

    [TestMethod]
    public void ContinueInputIsValid_returnsFalse(){
        //Arrange
        string inputYes = "Y";

        //Act
        bool isValid = MainApplication.ContinueInput(inputYes);

        //Assert
        Assert.IsFalse(isValid);
    }

}