using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Audiomanager : MonoBehaviour {
    public Sound[] sounds;
    //used for getting difficulty, to change pitch:
    public String currentScene;
	// Use this for initialization
	void Awake () {
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;
            s.source.mute = s.mute;
        }
	}
    private void Update()
    {
        //get scene onload void to set playing to false
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Equals("load"))
        {
            FindObjectOfType<Audiomanager>().play("PixelMix");
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("audioManager"));
            SceneManager.LoadScene("Menu");
        }
        if (currentScene.Equals("Game"))
        {
            Debug.Log("game");
            //FindObjectOfType<Audiomanager>().stop("PixelMix");
            FindObjectOfType<Audiomanager>().play("PixelMix2");
        }
    }
    public void play(string name)
    {
        try
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }

    }
    public void stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
