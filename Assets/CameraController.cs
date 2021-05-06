using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public static int rotPosition = 0;

    private Vector3 offset;
    private bool rotating = false;

    //adding new stuff from: https://answers.unity.com/questions/655896/rotating-a-camera-90-degrees-around-an-object.html

    private float targetAngle = 0;
    const float rotationAmount = 10.0f;

    // Update is called once per frame
    void Update()
    {

        // Trigger functions if Rotate is requested
        if (Input.GetKeyDown("z"))
        {
            targetAngle -= 90.0f;
        }
        else if (Input.GetKeyDown("x"))
        {
            targetAngle += 90.0f;
        }

        if (targetAngle != 0)
        {
            rotating = true;
            Rotate();
        }
    }

    protected void Rotate()
    {

        if (targetAngle > 0)
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            transform.RotateAround(player.transform.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }

        if (targetAngle == 0)
        {
            rotating = false;
        }

    }

    //end of modified new stuff


    // Use this for initialization
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown("z"))
        {
            rotPosition++;
            if (rotPosition > 3)
                rotPosition = 0;
        }
        else if (Input.GetKeyDown("x"))
        {
            rotPosition--;
            if (rotPosition < 0)
                rotPosition = 3;
        }

        switch (rotPosition)
        {
            case 0:
                offset = new Vector3(0, 7, -10);
                break;

            case 1:
                offset = new Vector3(-10, 7, 0);
                break;

            case 2:
                offset = new Vector3(0, 7, 10);
                break;

            case 3:
                offset = new Vector3(10, 7, 0);
                break;
        }

        if (rotating == false)
        {
            transform.position = player.transform.position + offset;
        }
    }
}