using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesController : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + playerController.lives;   
    }
}
