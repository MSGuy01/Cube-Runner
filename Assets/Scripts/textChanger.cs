using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChanger : MonoBehaviour
{
    public Text text;
    public score getScore;
    public Slider livesSlider;
    public player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.gameObject.name)
        {
            case "scoreText":
                text.text = getScore.currentScore.ToString();
                break;
            case "livesText":
                text.text = "LIVES: " + playerScript.lives.ToString();
                break;
        }
    }
}
