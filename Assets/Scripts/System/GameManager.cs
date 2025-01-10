using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

                if (FindObjectOfType<GameManager>())
                    instance = FindObjectOfType<GameManager>();
                else
                {
                    var newGameManager = new GameObject();
                    newGameManager.name = "Game Manager";
                    instance = newGameManager.AddComponent<GameManager>();
                }
            }
            DontDestroyOnLoad(instance.gameObject);
            return instance;
        }
    }


}
