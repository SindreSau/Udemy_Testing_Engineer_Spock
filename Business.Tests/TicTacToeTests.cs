namespace Business.Tests;

[TestFixture]
public class TicTacToeTests
{
    [Test]
    public void CreateGame_ZeroMoves()
    {
        var game = new TicTacToeGame();
        Assert.That(game.MovesCounter, Is.EqualTo(0));
    }

    [Test]
    public void MakeMove_IncrementsMovesCounter()
    {
        var game = new TicTacToeGame();
        game.MakeMove(1);
        Assert.That(game.MovesCounter, Is.EqualTo(1));
    }

    [Test]
    public void MakeInvalidMove_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var game = new TicTacToeGame();
            game.MakeMove(0);
        });
    }

    [Test]
    public void MoveOnTheSameSquare_ThrowsException()
    {
        var game = new TicTacToeGame();
        game.MakeMove(1);
        Assert.Throws<InvalidOperationException>(() => game.MakeMove(1));
    }

    [Test]
    public void MakingMoves_SetStateCorrectly()
    {
        var game = new TicTacToeGame();
        game.MakeMove(1);
        game.MakeMove(2);
        game.MakeMove(3);
        game.MakeMove(4);

        Assert.Multiple(() =>
        {
            Assert.That(game.MovesCounter, Is.EqualTo(4));
            Assert.That(game.GetState(1), Is.EqualTo(State.Zero));
            Assert.That(game.GetState(2), Is.EqualTo(State.Cross));
            Assert.That(game.GetState(3), Is.EqualTo(State.Zero));
            Assert.That(game.GetState(4), Is.EqualTo(State.Cross));
        });
    }

    [Test]
    public void InitialBoardState_AllUnset()
    {
        var game = new TicTacToeGame();
        Assert.Multiple(() =>
        {
            for (var i = 1; i <= 9; i++)
                Assert.That(
                    game.GetState(i),
                    Is.EqualTo(State.Unset)
                );
        });
    }

    [Test]
    public void GetWinner_ZeroWinVertically_ReturnsZeroes()
    {
        var game = new TicTacToeGame();
        game.MakeMoves(1, 2, 4, 5, 7, 8);

        Assert.That(game.GetWinner(), Is.EqualTo(Winner.Zero));
    }

    [Test]
    public void GetWinner_CrossWinHorizontally_ReturnsCrosses()
    {
        var game = new TicTacToeGame();
        game.MakeMoves(4, 1, 5, 2, 7, 3);

        Assert.That(game.GetWinner(), Is.EqualTo(Winner.Cross));
    }
}