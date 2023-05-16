using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControllerSc : MonoBehaviour
{
    public static UIControllerSc Instance;
    [SerializeField] GameObject Info;
    [SerializeField] TextMeshProUGUI bestScoreText;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void GameObjectClose(GameObject Screen)
    {
        Screen.SetActive(false);  
    }
    public void GameObjectOpen(GameObject Screen)
    {
        Screen.SetActive(true);
    }
    public void TimeScaleStarter()
    {
        Time.timeScale = 1;
    }
    public void TimeScaleStoper()
    {
        Time.timeScale = 0;
    }
    public void InfoPanelController(bool activity) {
        Info.SetActive(activity);
    }
    public void bestScoreUpdate(int score)
    {
        bestScoreText.text = "Best Score: " + score;
    }
    public void bestScoreClose()
    {
        bestScoreText.enabled = false;
    }
}
