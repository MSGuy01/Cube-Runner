using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public GameObject storageObject;
    public storage storageScript;
    public GameObject audioObject;
    // Start is called before the first frame update
    void Start()
    {
        audioObject = GameObject.FindGameObjectWithTag("audioManager");
        storageObject = GameObject.FindGameObjectWithTag("storage");
        storageScript = storageObject.GetComponent<storage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonPressed()
    {
        Debug.Log(this.gameObject.name.ToString());
        DontDestroyOnLoad(storageObject);
        DontDestroyOnLoad(audioObject);
        switch (this.gameObject.name)
        {
            case "start":
                SceneManager.LoadScene("Game Settings");
                break;
            case "instructions":
                SceneManager.LoadScene("instructions");
                break;
            case "credits":
                SceneManager.LoadScene("credits");
                break;
            case "easy":
                storageObject.gameObject.name = "easy";
                storageScript.difficulty = 1;
                SceneManager.LoadScene("Game");
                break;
            case "medium":
                storageObject.gameObject.name = "medium";
                storageScript.difficulty = 2;
                SceneManager.LoadScene("Game");
                break;
            case "hard":
                storageObject.gameObject.name = "hard";
                storageScript.difficulty = 3;
                SceneManager.LoadScene("Game");
                break;
            case "back":
                SceneManager.LoadScene("Menu");
                break;
            case "settings":
                SceneManager.LoadScene("settings");
                break;
        }
    }
}
