using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    #region rotation variables
    [SerializeField] private GameObject[] objectsToRotate;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int targetRotation = 0;
    [SerializeField] private float totalRotation;
    [SerializeField] private bool isMoving=false;
    #endregion
    string IInteractable.InteractionPrompt => _prompt;

    bool IInteractable.Interact(Interactor interactor)
    {
        Debug.Log("Interacting with Wheel");
        isMoving= true;
        return true;
    }

    private void Update()
    {
        if (isMoving)
        {
            RotateObjects();
        }
    }

    void RotateObjects()
    {
        if (totalRotation <= targetRotation)
        {
            foreach (GameObject obj in objectsToRotate)
            {
                obj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                totalRotation += rotationSpeed * Time.deltaTime;
            }
        }
        else
        {
            isMoving = false;
            totalRotation = 0;
        }
    }
}

