using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI bestScoreText;

    public void NewStringTyped(string playerName)
    {
        // add code here to handle when a color is selected
        GameManager.Instance.currentPlayerName = playerName;
        Debug.Log(playerName);
    }
    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(NewStringTyped);
        SetBestScoreText();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    void SetBestScoreText()
    {
        bestScoreText.text = "Best Score : " + GameManager.Instance.bestPlayerName + $" : {GameManager.Instance.bestPlayerScore}";
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
