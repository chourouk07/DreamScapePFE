using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public GameObject player;
    void Awake()
    {
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Make sure the player reference is set
        if (player == null)
        {
            Debug.LogError("Player reference is not set in GameManager.");
        }
    }
}
