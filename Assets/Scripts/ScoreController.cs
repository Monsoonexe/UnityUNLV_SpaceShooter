using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : RichMonoBehaviour
{
    public TextMeshProUGUI uiText;

    public PlayerController playerController;

    //
    private void OnEnable()
    {
        //subscribe to events
        EventManager.onScoreUpdate.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        //unsubscribe to events
        //ALWAYS UNSUBSCRIBE TO EVENTS
        EventManager.onScoreUpdate.RemoveListener(UpdateUI);
    }

    /// <summary>
    /// Custom function. Only called when the UI needs an update, not every frame.
    /// </summary>
    private void UpdateUI()
    {
        uiText.text = "Score: " + playerController.score;        
    }
}
