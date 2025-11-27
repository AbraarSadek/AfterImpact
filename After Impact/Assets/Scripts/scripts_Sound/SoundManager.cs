using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Purpose: This Script is used to manage all sound-related functionalities 
 *          (master volume + background music per scene).
 * 
 * Created By: Abraar Sadek
 * Date Created: 11/18/2025
 * 
 * Modified By: ChatGPT (assistant)
 * Date Last Modified: 11/18/2025
 * What Was Modified: 
 *   - Added singleton + DontDestroyOnLoad so SoundManager persists
 *   - Added background music that changes based on current scene
 *   - Volume setting persists between scenes via PlayerPrefs
 *   - Added runtime slider registration so sliders work in any scene
 */

//SoundManager Class - Manages all sound-related functionalities
public class SoundManager : MonoBehaviour
{
    //Singleton instance so there is only ONE SoundManager in the whole game
    public static SoundManager Instance;

    [Header("Volume Settings")]
    [SerializeField] private Slider volumeSlider;   // Assigned at runtime by sliders
    private float currentVolume = 1f;               // Stores the current master volume

    [Header("Background Music")]
    [SerializeField] private AudioSource musicSource;     // AudioSource that will play background music
    [SerializeField] private AudioClip mainMenuMusic;     // Music for Main Menu scene
    [SerializeField] private AudioClip gameplayMusic;     // Music for gameplay scene
    [SerializeField] private AudioClip gameOverMusic;     // Music for Game Over scene
    [SerializeField] private AudioClip settingsMusic;     // Music for Settings scene
    // You can add more clips and scene checks as needed

    //Awake Method - Called before Start. Used to set up the singleton and persistence.
    private void Awake()
    {
        // If another SoundManager already exists, destroy this one to avoid duplicates
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the active instance and make it persistent through scene loads
        Instance = this;
        DontDestroyOnLoad(gameObject);
    } //End of Awake Method

    //OnEnable - Subscribe to sceneLoaded event
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //OnDisable - Unsubscribe from sceneLoaded event
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Start Method - Called once before the first Update
    private void Start()
    {
        // Load saved volume setting (or use default)
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f); //Set default volume to 1f if no saved setting exists
            Load();                                  //Load saved sound settings
        }
        else
        {
            Load();                                  //Load saved sound settings
        }

        ApplyVolume(); //Apply loaded volume to AudioListener and musicSource

        // Play appropriate music for the first scene (the one currently loaded)
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    } //End of Start Method

    //This method is called automatically every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Decide which music to play based on scene name
        AudioClip clipToPlay = null;
        bool isGameOver = false;
        // NOTE: Scene names must match your Build Settings
        if (scene.name == "scene_MainMenu")
        {
            clipToPlay = mainMenuMusic;
        }
        else if (scene.name == "scene_Level")
        {
            clipToPlay = gameplayMusic;
        }
        else if (scene.name == "scene_GameOver")
        {
            clipToPlay = gameOverMusic;
            isGameOver = true;
        }
        else if (scene.name == "scene_SettingsMenu")
        {
            clipToPlay = settingsMusic;
        }
        else
        {
            // No music for this scene (optional)
            clipToPlay = null;
        }

        // If no music is assigned for this scene, stop playing
        if (clipToPlay == null)
        {
            if (musicSource != null && musicSource.isPlaying)
            {
                musicSource.Stop();
            }
            return;
        }

        // If the correct clip is already playing, do nothing
        if (musicSource != null)
        {
            if (musicSource.clip == clipToPlay && musicSource.isPlaying)
                return;

            //Assign and play the clip
            musicSource.clip = clipToPlay;
            if (isGameOver)
            {
                musicSource.loop = false;
            }
            else {
                musicSource.loop = true;            // Background music usually loops
            }
            musicSource.Play();
        }
    }

    //changeVolume Method - If you still want to call it directly from UI
    public void ChangeVolume()
    {
        if (volumeSlider == null)
            return;

        currentVolume = volumeSlider.value; //Update stored volume
        ApplyVolume();                      //Apply to audio system
        Save();                             //Save to PlayerPrefs
    } //End of ChangeVolume Method

    //ApplyVolume Method - Applies currentVolume to AudioListener and musicSource
    private void ApplyVolume()
    {
        //Master volume for all sounds
        AudioListener.volume = currentVolume;

        //Optional: also directly control music source volume
        if (musicSource != null)
        {
            musicSource.volume = currentVolume;
        }
    } //End of ApplyVolume Method

    //Load Method - Loads sound settings
    private void Load()
    {
        currentVolume = PlayerPrefs.GetFloat("musicVolume", 1f); //Get saved volume

        //If a slider exists in this scene, sync it with loaded volume
        if (volumeSlider != null)
        {
            volumeSlider.value = currentVolume;
        }
    } //End of Load Method

    //Save Method - Saves sound settings
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", currentVolume); //Save the current volume
    } //End of Save Method

    // 🔹 NEW: Internal handler for slider value changes
    private void OnSliderValueChanged(float value)
    {
        currentVolume = value;
        ApplyVolume();
        Save();
    }

    //Optional helper: call from other scripts if they add a slider later
    public void RegisterSlider(Slider newSlider)
    {
        // Remove old listener if we had a previous slider
        if (volumeSlider != null && volumeSlider != newSlider)
        {
            volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        volumeSlider = newSlider;

        if (volumeSlider != null)
        {
            // Sync slider to current saved volume
            volumeSlider.value = currentVolume;

            // Make sure we don't double-subscribe
            volumeSlider.onValueChanged.RemoveListener(OnSliderValueChanged);
            volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

} //End of SoundManager Class
