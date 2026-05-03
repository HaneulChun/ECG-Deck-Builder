using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ApiManager : MonoBehaviour
{
    [SerializeField] private string binUrl;
    [SerializeField] private string apiKey;

    public IEnumerator Save(DeckData data)
    {
        string json = JsonConvert.SerializeObject(data);

        UnityWebRequest request = new UnityWebRequest(binUrl, "PUT");

        byte[] body = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("X-Master-Key", apiKey);

        Debug.Log("Deck count: " + data.decks.Count);

        foreach (var deck in data.decks)
        {
            Debug.Log("Deck:");
            foreach (var card in deck)
            {
                Debug.Log(card);
            }
        }

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
            Debug.LogError("SAVE FAILED: " + request.error);
        else
            Debug.Log("SAVE SUCCESS");
    }

    public IEnumerator Load(System.Action<DeckData> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(binUrl);
        request.SetRequestHeader("X-Master-Key", apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("LOAD FAILED: " + request.error);
            callback?.Invoke(null);
        }
        else
        {
            var wrapped =
                JsonUtility.FromJson<JsonBinResponse>(request.downloadHandler.text);

            callback?.Invoke(wrapped.record);
        }
    }
}