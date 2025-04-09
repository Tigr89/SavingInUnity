using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private string filePath;
    public string fileToSearchFor;
    public List<string> scoreBoardRows;

    // Start is called before the first frame update
    void Start()
    {
        //We store the filepath's location by using the code below. We then print where it is stored. 
        filePath = Application.persistentDataPath + "/" + fileToSearchFor.ToLower() + ".txt";
        Debug.Log("Filepath is: " + filePath);

        scoreBoardRows = LoadScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFileData(string content)
    {
        File.WriteAllText(filePath, content);
    }

    public string LoadFileData()
    {
        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            return content;
        }
        else
        {
            return "Error; filepath not found!";
        }
    }

    public List<string> LoadScoreBoard()
    {
        List<string> listToReturn = new List<string>();

        if (File.Exists(filePath))
        {
            string[] fileContent = File.ReadAllLines(filePath); //Use ReadAllLines instead of ReadAllText; this makes it so that it stores a row into each element of the array.
            listToReturn.AddRange(fileContent); //Add all content to the listToReturn.
        }
        else
        {
            Debug.Log("Error: scoreboard.txt not found!");
        }
        return listToReturn;
    }
}
