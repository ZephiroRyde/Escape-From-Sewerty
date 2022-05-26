using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Texto Info")]
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image infoTextPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject VictoryPanel;


    public void LoadText(string actualtext)
    {
        print("cargar texto");
        infoText.text = actualtext;
    }

    public void ExitText()
    {
        infoTextPanel.gameObject.SetActive(false);
    }

    public void OpenText()
    {
        infoTextPanel.gameObject.SetActive(true);
    }

    public void LoadVictoryPanel()
    {
        VictoryPanel.SetActive(true);
    }
}
