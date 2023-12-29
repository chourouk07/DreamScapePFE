using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platMoveSpeed;
    [SerializeField] private Transform intialPoint;
    [SerializeField] private Transform finalPoint;
    public bool isSlowed = false;

    private void Start()
    {
        transform.position = intialPoint.position;
    }
    private void Update()
    {

        if (transform.position.z< finalPoint.position.z || transform.position.y >finalPoint.position.y)
        {
            if (!isSlowed)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPoint.position, platMoveSpeed*Time.deltaTime);
                //transform.Translate(new Vector3(0, 0, platMoveSpeed * Time.deltaTime));
            }
            if (isSlowed)
            {
                transform.position = Vector3.MoveTowards(transform.position, finalPoint.position, platMoveSpeed *0.05f* Time.deltaTime);
            }
        }
        

        else
        {
            gameObject.transform.position = intialPoint.position;
        }
    }

    public void OnSlowed()
    {
        isSlowed = true;
    }

    public void OnEndSlowed()
    {
        isSlowed = false;
    }

}
