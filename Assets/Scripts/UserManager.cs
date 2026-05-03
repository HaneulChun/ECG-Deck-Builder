using System;
using UnityEngine;

public class UserManager : MonoBehaviour
{
    private const string USER_ID_KEY = "USER_ID";

    public static UserManager Instance { get; private set; }

    private void Awake()
    {
        // optional singleton safety
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ---------------- USER ID ----------------

    public string GetUserId()
    {
        return PlayerPrefs.GetString(USER_ID_KEY, "");
    }

    public bool HasValidUser()
    {
        return !string.IsNullOrEmpty(GetUserId());
    }

    public string CreateUser()
    {
        string id = Guid.NewGuid().ToString();

        PlayerPrefs.SetString(USER_ID_KEY, id);
        PlayerPrefs.Save();

        Debug.Log("New User Created: " + id);

        return id;
    }

    public void ClearUser()
    {
        PlayerPrefs.DeleteKey(USER_ID_KEY);
        PlayerPrefs.Save();

        Debug.Log("User cleared");
    }
}