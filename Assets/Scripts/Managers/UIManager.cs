using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerData _pdata;

    [Header("Texto Info")]
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Image infoTextPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private TextMeshProUGUI _victoryText;

    private void Start()
    {
        _pdata = GameManager.GetInstance.GetPlayerController.pData;
    }

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
        _victoryText.text = "Felicidades!!, tan solo el 9,6% de los jugadores logran escapar Conseguiste " + _pdata.cheeseAmount + " de 2 quesos";
        
    }
}
