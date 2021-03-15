﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    //offset vars for the level position
    public float xOffset;
    public float yOffset;
    
    //Prefabs for the gameObjects we want to add to our scene
    public GameObject player;
    public GameObject wall;
    public GameObject enemy;
    public GameObject start;
    public GameObject finish;
    
    //var for the current player
    public GameObject currentPlayer;
    
    //var for player start position
    private Vector3 startPos;
    
    //name of the level file
    public string fileName;
    
    //current level var
    public int currentLevel = 0;
    
    //empty game object that holds the level
    public GameObject level;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(); // load first level
    }

    void LoadLevel()
    {
        Destroy(level); //destroy the current level
        level = new GameObject("Level"); //create a new level gameObject
        
        string current_file_path = //build path to the level file
            Application.dataPath + "/Levels/" + fileName.Replace("Num", currentLevel + "");

        //pull the contents of the file into a string array
        //each line in the file becomes an item in the array
        string[] fileLines = File.ReadAllLines(current_file_path);
        
        //loop through each line
        for (int y = 0; y < fileLines.Length; y++)
        {
            //get the current line
            string lineText = fileLines[y];

            //split the line into a char array
            char[] characters = lineText.ToCharArray();

            //loop through each char
            for (int x = 0; x < characters.Length; x++)
            {
                //grab the current char
                char c = characters[x];

                //var for newObj
                GameObject newObj;
                //GameObject newObj2;

                switch (c) //switch statement for the char
                {
                    case 'p': //if char is a 'p'
                        //make a player gameObject
                        newObj = Instantiate<GameObject>(player);
                        //newObj2 = Instantiate<GameObject>(start);
                        break;
                    case 'w': //if char is a 'w'
                        //make a wall
                        newObj = Instantiate<GameObject>(wall);
                        break;
                    default: //if the char is anything else
                        newObj = null; //make newObj null
                        //newObj2 = null; //make newObj2 null
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.position =
                        new Vector3(x + xOffset, 0, -y + yOffset);
                }

                /*if (newObj2 != null)
                {
                    newObj2.transform.position = 
                        new Vector3(x + xOffset, 0, -y + yOffset);
                    newObj2 == null;
                }*/
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
