using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    public GameObject DatabaseManager;
    public GameObject entryTemplate;
    private Transform entryContainer;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    // Start is called before the first frame update
    void Start()
    {
        entryContainer = transform.Find("Scroll View/Viewport/Content/EntryContainer");

        highscoreEntryList = DatabaseManager.GetComponent<DatabaseManager>().GetEndless();

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container).transform;
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "th"; break;
            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }
        entryTransform.Find("Rank").GetComponent<TextMeshProUGUI>().text = rankString;
        int score = highscoreEntry.getScore();
        entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = score.ToString();
        string name = highscoreEntry.getName();
        entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    /*

    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    */
}
