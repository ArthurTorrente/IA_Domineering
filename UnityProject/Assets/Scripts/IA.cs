using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class Move
{
    public Move()
    {
        x1 = 0;
        x2 = 0;
        y1 = 0;
        y2 = 0;
    }

    public Move(int _x1, int _y1, int _x2, int _y2)
    {
        x1 = _x1;
        y1 = _y1;
        
        x2 = _x2;
        y2 = _y2;
    }

    public int x1;
    public int y1;
    public int x2;
    public int y2;
}

public class IA
{
    static bool MAXPLAYER = false;
    static bool CURRENTPLAYER = false;
    static int INITIALDEPTH = 3;

    static List<Move> getAllMove(bool isVertical, GameSettingScript settigns, BoardManagerScript board)
    {
        List<Move> am = new List<Move>();

        if(isVertical)
        {
            for(int i = 0; i < settigns.BoardSize - 1; ++i)
            {
                for(int j = 0; j < settigns.BoardSize; ++j)
                {

                }
            }
        }
        else
        {

        }

        return am;
    }

    static void play(GameSettingScript settigns, BoardManagerScript board, Move move)
    {
    }

    static void undo(GameSettingScript settigns, BoardManagerScript board, Move move)
    {

    }

    static int getMoveCount(bool isVertical, GameSettingScript settigns, BoardManagerScript board)
    {
        //return move count for vertical player or horizontal player
        return 0;
    }

    static int evaluation(bool isVertical, GameSettingScript settings, BoardManagerScript board)
    {
        return getMoveCount(isVertical, settings, board) - getMoveCount(!isVertical, settings, board);
    }

    static int max(GameSettingScript settings, BoardManagerScript board, Move bestMove, int depth)
    {
        if (depth == 0)
            return evaluation(MAXPLAYER, settings, board);

        int eval = -10000;

        List<Move> availiableMove = getAllMove(CURRENTPLAYER, settings, board);

        if (availiableMove.Count == 0)
            return eval + 1;

        CURRENTPLAYER = !CURRENTPLAYER;

        for (var i = 0; i < availiableMove.Count; ++i)
        {
            var move = availiableMove[i];

            play(settings, board, move);

            int e = min(settings, board, bestMove, depth - 1);

            undo(settings, board, move);

            if(e > eval)
            {
                eval = e;

                if (depth == INITIALDEPTH)
                    bestMove = move;
            }
        }

        CURRENTPLAYER = !CURRENTPLAYER;
        return eval;
    }

    static int min(GameSettingScript settings, BoardManagerScript board, Move bestMove, int depth)
    {
        if (depth == 0)
            return evaluation(MAXPLAYER, settings, board);

        int eval = 10000;

        List<Move> availiableMove = getAllMove(CURRENTPLAYER, settings, board);

        if (availiableMove.Count == 0)
            return eval - 1;

        CURRENTPLAYER = !CURRENTPLAYER;

        for (var i = 0; i < availiableMove.Count; ++i)
        {
            var move = availiableMove[i];

            play(settings, board, move);

            int e = max(settings, board, bestMove, depth - 1);

            undo(settings, board, move);

            if (e < eval)
            {
                eval = e;

                if (depth == INITIALDEPTH)
                    bestMove = move;
            }
        }

        CURRENTPLAYER = !CURRENTPLAYER;
        return eval;
    }
}
