using System.Text;

namespace Business;

public enum State
{
    Cross,
    Zero,
    Unset
}

public enum Winner
{
    Cross,
    Zero,
    None
}

public class TicTacToeGame
{
    private readonly State[] _board = new State[9];

    public TicTacToeGame()
    {
        for (var i = 0; i < _board.Length; i++) _board[i] = State.Unset;
    }

    public int MovesCounter { get; private set; }


    public void MakeMove(int i)
    {
        if (i is < 1 or > 9)
            throw new ArgumentOutOfRangeException(nameof(i), "Move must be between 1 and 9 inclusive.");

        if (GetState(i) != State.Unset)
            throw new InvalidOperationException($"Square {i} is already occupied.");

        _board[i - 1] = MovesCounter % 2 == 0 ? State.Zero : State.Cross;
        MovesCounter++;
    }

    public void MakeMoves(params int[] moves)
    {
        foreach (var move in moves) MakeMove(move);
    }

    public Winner GetWinner()
    {
        for (var i = 0; i < 3; i++)
        {
            if (_board[i * 3] != State.Unset &&
                _board[i * 3] == _board[i * 3 + 1] &&
                _board[i * 3] == _board[i * 3 + 2])
                return _board[i * 3] == State.Cross ? Winner.Cross : Winner.Zero;

            if (_board[i] != State.Unset &&
                _board[i] == _board[i + 3] &&
                _board[i] == _board[i + 6])
                return _board[i] == State.Cross ? Winner.Cross : Winner.Zero;
        }

        if (_board[0] != State.Unset &&
            _board[0] == _board[4] &&
            _board[0] == _board[8])
            return _board[0] == State.Cross ? Winner.Cross : Winner.Zero;

        if (_board[2] != State.Unset &&
            _board[2] == _board[4] &&
            _board[2] == _board[6])
            return _board[2] == State.Cross ? Winner.Cross : Winner.Zero;

        return Winner.None;
    }

    public State GetState(int i)
    {
        return _board[i - 1];
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var i = 1; i <= 9; i++)
        {
            var state = GetState(i);
            sb.Append(' ');
            sb.Append(state switch
            {
                State.Cross => 'X',
                State.Zero => 'O',
                _ => ' '
            });
            sb.Append(' ');

            if (i % 3 == 0)
            {
                if (i >= 9) continue;
                sb.AppendLine();
                sb.AppendLine("---+---+---");
            }
            else
            {
                sb.Append('|');
            }
        }

        return sb.ToString();
    }
}