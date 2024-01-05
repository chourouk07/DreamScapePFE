using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucket : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    string IInteractable.InteractionPrompt => _prompt;

    bool IInteractable.Interact(Interactor interactor)
    {
        Debug.Log(_prompt);
        return true;
    }
}
