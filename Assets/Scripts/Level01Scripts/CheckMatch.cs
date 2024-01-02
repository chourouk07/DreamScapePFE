using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatch : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public bool canPlaceItem= false;
    [SerializeField] private GameObject crystal;

    PlayerInventory inventory;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_prompt);
        canPlaceItem = true;
        return true;
    }
    private void Start()
    {
        inventory = GameManager.instance.player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (!canPlaceItem || inventory.isFull != 1)
        {
            canPlaceItem = false;
            return;
        }

        OnPlaceItem();
    }

    public void OnPlaceItem()
    {
        if (gameObject.name == inventory.collectedItem.name)
        {
            crystal.SetActive(true);
        }

    }
    
}
