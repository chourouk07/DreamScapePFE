using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToRotate;
    [SerializeField] private float rotationSpeed;
    [SerializeField]private int targetRotation =0;
    [SerializeField] private float totalRotation;
    [SerializeField] private InteractionController interactionController;
    //[SerializeField] private bool isRotating = false;

    private void Start()
    {
        interactionController = FindObjectOfType<InteractionController>();
    }
    private void Update()
    {
         if (totalRotation <= targetRotation)
        {
            foreach (GameObject obj in objectsToRotate)
            {
                interactionController.SetMoving(true);
                obj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                totalRotation += rotationSpeed * Time.deltaTime;
            }
        }
        else
        {
            interactionController.SetMoving(false);
        }
    }

    public void SetTargetRotation(float newTargetRotation)
    {
        targetRotation+= (int)newTargetRotation;
    }

}
