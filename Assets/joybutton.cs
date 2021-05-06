using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class joybutton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //PlayerController plco;
    public string direction;
    //public float playernumber = 1;

    [HideInInspector]
    public float Pressed;
    // Use this for initialization

    // Update is called once per frame
    void Start()
    { //Debug.Log(Pressed); 
        //playernumber = 1;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        Pressed = 1.0f;
       // if (float.Parse(NetworkClientUI.playerz) == 2)
        //{
         //   playernumber = 1;
        Debug.Log(Pressed);
        NetworkClientUI.SendJoystickInfo(Pressed, direction, NetworkClientUI.playernumber);
    
    }
    public void OnPointerUp(PointerEventData eventData)
    {

        Pressed = 0;
        //if (float.Parse(NetworkClientUI.playerz) == 2)
        //{
            //playernumber = 1;
            Debug.Log(Pressed);
            NetworkClientUI.SendJoystickInfo(Pressed, direction, NetworkClientUI.playernumber);
        

    }
    

}