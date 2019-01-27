using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManangerBehaviour : MonoBehaviour
{
    RaycastHit ray;
    public Button Izy;
    public Button Fair;
    public Button Tough;
    public GameObject DifficultyPanel;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }   

    public void OnIzyButtonClick()
    {
        //Debug.Log("izy: " + gameObject.tag);
        PlayerPrefs.SetString("Difficulty", "IZY");
    }

    public void OnFairButtonClick()
    {
        //Debug.Log("fair: " + gameObject.tag);
        PlayerPrefs.SetString("Difficulty", "FAIR");
    }

    public void OnToughButtonClick()
    {
        //Debug.Log("tough: " + gameObject.tag);
        PlayerPrefs.SetString("Difficulty", "TOUGH");
    }

    public void OnDifficultyButtonClick()
    {
        DifficultyPanel.SetActive(!DifficultyPanel.active);   
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameMainScene");
    }
}
