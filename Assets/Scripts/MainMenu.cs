using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private UserManager userManager;

    [Header("UI")]
    [SerializeField] private Button continueButton;
    [SerializeField] private TMPro.TextMeshProUGUI userText;

    private void Start()
    {
        RefreshUI();
    }

    // ---------------- UI STATE ----------------

    void RefreshUI()
    {
        bool hasUser = userManager.HasValidUser();

        continueButton.interactable = hasUser;

        if (userText != null)
        {
            userText.text = hasUser
                ? "User: " + userManager.GetUserId()
                : "No saved user";
        }
    }

    // ---------------- BUTTONS ----------------

    public void OnNewUserClicked()
    {
        string id = userManager.CreateUser();

        Debug.Log("Logging in new user: " + id);

        SceneManager.LoadScene("DeckBuilder");
    }

    public void OnContinueClicked()
    {
        if (!userManager.HasValidUser())
        {
            Debug.Log("No user exists");
            return;
        }

        Debug.Log("Continuing user: " + userManager.GetUserId());

        SceneManager.LoadScene("DeckBuilder");
    }
}