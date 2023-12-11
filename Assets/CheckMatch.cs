using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatch : MonoBehaviour
{
    public bool canPlaceItem= false;
    [SerializeField] private GameObject crystal;

    // Access the player through the GameManager
    public GameObject player;
    PlayerInventory inventory;
    private void Start()
    {
        inventory = player.gameObject.GetComponent<PlayerInventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            if (inventory.isFull == 1)
            {
                canPlaceItem= true;
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                canPlaceItem = false; 
        }
    }

    public void OnPlaceItem()
    {
        if (gameObject.name == inventory.collectedItem.name)
        {
            Debug.Log("Correct Item");
            crystal.SetActive(true);
        }

    }
}
