using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    //Make sure only one instance of GameManager exists
    private void Awake() {

        //Turn GameManager into a singleton
        if (GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        //Deletes all save data on run (comment out when needed)
        PlayerPrefs.DeleteAll();
        
        instance = this;
        //When scene is loaded, load the game
        SceneManager.sceneLoaded += LoadState;
        //Dont destroy instance when scenes are changed
        DontDestroyOnLoad(gameObject);
    }

    //Declaring global game object lists
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    public FloatingTextManager floatingTextManager;

    //Declaring player variables
    public int gold;
    public int xp;


    //Methods

    //Global text creation method (using methods defined in floatingTextManager, but placed in Game Manager so can have one one reference)
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {

        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);

    }

    //Saving function
    public void SaveState() {

        //Initialising string
        string s = "";

        //Adding value for character, gold, xp and weapon to string
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += xp.ToString() + "|";
        s += "0";

        //Save string to state
        PlayerPrefs.SetString("SaveState", s);
    }

    //Loading function
    public void LoadState(Scene s, LoadSceneMode mode) {

        //Do nothing if no save data exists
        if(!PlayerPrefs.HasKey("SaveState")) {
            return;
        }
        
        //Split save data into a readable array
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Set variables
        gold = int.Parse(data[1]);
        xp = int.Parse(data[2]);

    }



}
