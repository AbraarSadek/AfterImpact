using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Purpose: This Script is used to manage all sound-related functionalities.
 * 
 * Created By: Abraar Sadek
 * Date Created: 11/18/2025
 * 
 * Modified By: Abraar Sadek
 * Date Last Modified: 11/18/2025
 * What Was Modified: Initial Creation
 */

//SoundManager Class - Manages all sound-related functionalities
public class SoundManager : MonoBehaviour {

    [SerializeField] Slider volumeSlider; // Slider to control volume

    //Start Method - Is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        //If-Else Statement - Check If A Saved Sound Setting Exists
        if (!PlayerPrefs.HasKey("musicVolume")) {
            PlayerPrefs.SetFloat("musicVolume", 1f); //Set default volume to 1f if no saved setting exists
            Load(); //Call the Load method to load saved sound settings
        } else {
            Load(); //Call the Load method to load saved sound settings
        } //End of If-Else Statement

    } //End of Start Method

    //changeVolume Method - Changes the volume based on the slider value
    public void changeVolume() {

        AudioListener.volume = volumeSlider.value; //Set the AudioListener volume to the slider value
        Save(); //Call the Save method to save the current sound settings

    } //End of changeVolume Method

    //Load Method - Loads sound settings
    private void Load() {

        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f); //Load the volume slider value from PlayerPrefs, default to 1f if not found

    } //End of Load Method

    //Save Method - Saves sound settings
    private void Save() {

        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); //Save the volume slider value to PlayerPrefs

    } //End of Save Method

} //End of SoundManager Class
