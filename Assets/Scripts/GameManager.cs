using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Delete SaveState
        // PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    // public weapon...
    public FloatingTextManager floatingTextManager;

    // Logic
    public int gold;
    public int experience;


    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    /*
    * Int preferedSkin
    * Int gold
    * Int experience
    * Int weaponLevel
    */
    public void SaveState()
    {
        string save = "";

        save += "0" + "|";

        save += gold.ToString() + "|";
        save += experience.ToString() + "|";
        save += "0";

        // or string interpolation $"{0}|{gold}|{experience}|{0}";

        PlayerPrefs.SetString("SaveState", save);
        Debug.Log("Save State");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change preferedSkin
        gold = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // Change weaponLevel

        // SceneManager.sceneLoaded -= LoadState;
        Debug.Log("Load State");
    }
}
