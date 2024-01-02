using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    public GameObject player;
    void Awake()
    {
     instance = this;

        // Make sure the player reference is set
        if (player == null)
        {
            Debug.LogError("Player reference is not set in GameManager.");
        }
    }
}
