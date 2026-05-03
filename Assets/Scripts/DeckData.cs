using System.Collections.Generic;

[System.Serializable]
public class DeckData
{
    public string user_id;
    public List<List<string>> decks = new List<List<string>>();
}