using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Created Date: 
 * Created By: 
 * Purpose: This class is responsible for controlling the main camera's behavior.
 */

//MainCameraController Class - Handles the main camera logic
public class MainCameraController : MonoBehaviour {

    [Header("Camera Movement")]
    public float cameraSpeed; //Float variable to set camera speed

    //Update Method - Called once per frame
    void Update() {

        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0); //Move the camera to the right based on camera speed

    } //End of Update Method

} //End of MainCameraController Class
