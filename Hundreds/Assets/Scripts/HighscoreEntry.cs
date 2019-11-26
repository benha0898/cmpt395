using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreEntry
{
    private int _score;
    private string _name;

    public int getScore() { return _score; }
    public string getName() { return _name; }

    public HighscoreEntry(int score, string name)
    {
        _score = score;
        _name = name;
    }
}
