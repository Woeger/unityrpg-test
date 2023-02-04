using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText {

    //Defining variables for text
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    //Function for showing text, sets to true, gets the current time and make active
    public void Show() {

        active = true;
        lastShown = Time.time;
        go.SetActive(active);

    }

    //Function for hiding active text, simply sets to false and makes the text inactive
    public void Hide() {
        
        active = false;
        go.SetActive(active);

    }

    //Update function for currently active text
    public void UpdateFloatingText() {

        //If its active, keep showing the text
        if (!active) {
            return;
        }

        //Hide the text if the duration is over
        if (Time.time - lastShown > duration) {
            Hide();
        }

        //Move text by the defined motion for each frame
        go.transform.position += motion * Time.deltaTime;

    }


}
