using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject MenuButtons;
    public GameObject MenuWindows;
    public GameObject scoreBoardScreen;
    public GameObject backButton;
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScoreBoard()
    {
        scoreBoardScreen.SetActive(true);
        string displayText = string.Join("\n", GameManager.scoreBoardRows);

        scoreBoardScreen.GetComponent<TMP_Text>().text = displayText;

        BackButtonLogic(true);
        //Get public List<string> LoadScoreBoard() from GameManager and store in displayText! Print it out in the TMP_text!
    }

    //BACKBUTTON logic will only work if it is the last child object in the hierarchy.
    public void BackButtonLogic(bool inactivateAll)
    {
        if (inactivateAll)
        {
            //Inactivate all other buttons
            for (int i = 0; i < MenuButtons.transform.childCount; i++)
            {
                Transform button = MenuButtons.transform.GetChild(i);
                if (i == transform.childCount - 1)
                {
                    button.gameObject.SetActive(true);
                }
                else button.gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < MenuButtons.transform.childCount; i++)
            {
                Transform button = MenuButtons.transform.GetChild(i);
                if (i == transform.childCount - 1)
                {
                    button.gameObject.SetActive(false);
                }
                else button.gameObject.SetActive(true);
            }

            for (int i = 0; i < MenuWindows.transform.childCount; i++)
            {
                Transform window = MenuWindows.transform.GetChild(i);
                window.gameObject.SetActive(false);
            }
        }
       
    }
}
