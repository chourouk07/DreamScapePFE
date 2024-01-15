using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour, IInteractable
{
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _waterBucket;
    private bool _isFilled=false;

    string _prompt = "Water";
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_prompt);
        HandleFillBucket();
        return true;
    }
    private void Start()
    {
        _playerInventory = GameManager.instance.player.GetComponent<PlayerInventory>();
    }
    private void Update()
    {
        
    }
    void HandleFillBucket()
    {
        if (_playerInventory.collectedItem == _waterBucket)
        {
            _isFilled = true;
            Debug.Log("Fill Bucket");
        }
    }

    public bool GetIsFilled()
    {
        return _isFilled;
    }
}
