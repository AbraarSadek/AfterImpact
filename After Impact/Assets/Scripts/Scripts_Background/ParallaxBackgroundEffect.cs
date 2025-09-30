using UnityEngine;

/*
 * Purpose: This Script is used to add a parallax effect to the background.
 * 
 * Created By: Abraar Sadek
 * Date Created: 09/27/2025
 * 
 * Modified By: Abraar Sadek
 * Date Last Modified: 09/27/2025
 * What Was Modified: Initial Creation
 */

//ParallaxBackgroundEffect Class
public class ParallaxBackgroundEffect : MonoBehaviour {

    //Game Object References
    [Header("Game Object References")]
    public GameObject mainCamera; //Reference to the Main Camera game object

    [Header("Parallax Effect Settings")]
    public float parallaxEffectMultiplier; //Float variable that will hold the multiplier for the parallax effect

    //Private Variables
    private float backgroundLength; //Float variables that will hold the length of the background
    private float backgroundStartingPosition; //Float variables that will hold the starting position of the background

    //Start Method - Is Called Once Before the First Frame
    void Start() {

        backgroundLength = GetComponent<SpriteRenderer>().bounds.size.x; //Store the length of the background
        backgroundStartingPosition = transform.position.x; //Store the starting position of the background

    } //End of Start Method

    //LateUpdate Mehtod - Is Called Once Per Frame After All Update Methods Have Been Called
    void LateUpdate() {

        //Calculate And Store The Main Camera's X Position Times 1 Minus The Parallax Effect Multiplier
        float cameraRelativePosition = (mainCamera.transform.position.x * (1 - parallaxEffectMultiplier));

        //Calculate And Store The Distance Moved By The Camera On The X Axis Times The Parallax Effect Multiplier
        float distanceMoved = (mainCamera.transform.position.x * parallaxEffectMultiplier);

        transform.position = new Vector3(backgroundStartingPosition + distanceMoved, transform.position.y, transform.position.z);

        /*
         * 
         * NOTE: 
         * 
         * After The Character Movement Has Been Implemented,
         * The Else-If Can Be Removed,
         * As The Background Will Only Move Forward.
         * 
         * Remove: else if (temp < backgroundStartingPosition - backgroundLength)
         * 
        */

        //Else-If Statement - Check If The Temp Variable Is Greater Than The Background Starting Position Plus The Background Length
        if (cameraRelativePosition > backgroundStartingPosition + backgroundLength) {
            backgroundStartingPosition += backgroundLength; //Move The Background Starting Position To The Right By The Length Of The Background
        } else if (cameraRelativePosition < backgroundStartingPosition - backgroundLength) {
            backgroundStartingPosition -= backgroundLength; //Move The Background Starting Position To The Left By The Length Of The Background
        } //End of Else-If Statement

    } //End of LateUpdate Method

} //End of ParallaxBackgroundEffect Class
