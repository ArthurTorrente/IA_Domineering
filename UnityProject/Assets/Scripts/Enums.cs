public enum GameState
{
    MainMenu,           // 0
    Game,               // 1
    Pause,              // 2
    Options,            // 3
}

public enum GameMode
{
    None,               // 0
    PlayerVersurPlayer, // 1
    PlayerVersusAi,     // 2
    AiVersusAi          // 3
}

public enum Orientation
{
    None,               // 0
    Horizontal,         // 1
    Vertical,           // 2
}

public enum FirstPlayer
{
    Player,             // 0
    Ai,                 // 1
}

public enum AiMode
{
    BrutForce,          // 0
    MinMax,             // 1
    NegaMax,            // 2
    AlphaBeta,          // 3
    NegaAlphaBeta,      // 4
    Iteration,          // 5
    KillingMove,        // 6
    KillingMoveWithTimer,
    Heuristique,        // 7
    HeuristiqueWithTimer
}