using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour{

    //Defining variables
    public GameObject textContainer;
    public GameObject textPrefab;

    //Creating and initalising list of floating text objects
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    //Function to make sure floatingText objects are being updated every frame
    private void Update() {

        foreach(FloatingText txt in floatingTexts) {
            txt.UpdateFloatingText();
        }

    }

    //Function for showing text, params for text variables
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {

        //Call get method to get floating text instance
        FloatingText floatingText = GetFloatingText();

        //Set values based on params
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        //Convert game world space into screen space
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();

    }

    //Method to get unused floating texts
    private FloatingText GetFloatingText() {

        //Find any hidden floating text
        FloatingText txt = floatingTexts.Find(t => !t.active);

        //If there is no object...
        if (txt == null) {

            //create new FloatingText
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            //Add to list of floating texts
            floatingTexts.Add(txt);
        }

        //Otherwise return existing floating text
        return txt;
    }


}
