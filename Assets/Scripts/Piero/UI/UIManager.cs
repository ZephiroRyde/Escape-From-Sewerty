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
   


    public void LoadText(string actualtext)
    {
        infoText.text = "" + actualtext;
    }

    public void ExitText()
    {
        infoTextPanel.gameObject.SetActive(false);
    }

    public void OpenText()
    {
        infoTextPanel.gameObject.SetActive(true);
    }
}
