using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable{

    //Array for random dungeons
    public string[] sceneNames;

    //Portal collision logic
    protected override void OnCollide(Collider2D coll) {

        //If portal collides with Player, move player
        if (coll.name == "Player") {
            //Save the game on scene change
            GameManager.instance.SaveState();
            //Pick a random dungeon from list of scenes
            string sceneName = sceneNames[Random.Range(0,sceneNames.Length)];
            //Load the string obtained above
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

    }

}
