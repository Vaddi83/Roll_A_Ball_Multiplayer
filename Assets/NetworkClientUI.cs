using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class NetworkClientUI : NetworkBehaviour
{
    public Text countClients;
    public Text connectionStatus;
    public InputField iPAdress;
    public GameObject connectButton;
    public GameObject sorryToLate;
    string test;
    public GameObject BigButton;
    public Text debbugField;
    public GameObject toggleGroup;
    public GameObject UpButton;
    public GameObject DownButton;
    public GameObject LeftButton;
    public GameObject RightButton;
    static public string playerAndDirection;
    static public float playernumber;
    static public bool player1Up;
    static public bool player1Down;
    static public bool player1Left;
    static public bool player1Right;
    static public bool player2Up;
    static public bool player2Down;
    static public bool player2Left;
    static public bool player2Right;
    static public bool player3Up;
    static public bool player3Down;
    static public bool player3Left;
    static public bool player3Right;
    static public bool player4Up;
    static public bool player4Down;
    static public bool player4Left;
    static public bool player4Right;
    public string stillWaiting = "true";
    bool waitingForothterPlayers_State = true;
    bool runthisOnce;

    static NetworkClient client;
    // Start is called before the first frame update
    void Start()
    {
        iPAdress.text = "192.168.0.213";
        //playerz = "noch nix";
        client = new NetworkClient();
        connectionStatus.text = "You are not connected to a Server, enter Server IP and click Connect";
        //client.Connect("192.168.0.213", 25000);
        debbugField.text = "start";
        
        
        
    }
    public void ButtonConnectToServer()
    {
        client.Connect("ws://"+iPAdress.text, 9997);
        client.RegisterHandler(887, ClientReceiveMessage);
        client.RegisterHandler(554, ClientReceiveGameState);
        Debug.Log(iPAdress.text);
       

    }
    private void ClientReceiveGameState(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;
        Debug.Log("Message:" + msg.value);
        stillWaiting = msg.value.ToString();

    }
        private void ClientReceiveMessage(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;
        Debug.Log("Message:" + msg.value);
        playerAndDirection = msg.value.ToString();
        if (playerAndDirection == "1Up") {
            player1Up = true;
        }
        if (playerAndDirection == "1Down")
        {
            player1Down = true;
        }
        if (playerAndDirection == "1Left")
        {
            player1Left = true;
        }
        if (playerAndDirection == "1Right")
        {
            player1Right = true;
        }
        if (playerAndDirection == "2Up")
        {
            player2Up = true;
        }
        if (playerAndDirection == "2Down")
        {
            player2Down = true;
        }
        if (playerAndDirection == "2Left")
        {
            player2Left = true;
        }
        if (playerAndDirection == "2Right")
        {
            player2Right = true;
        }
    }
        static public void SendJoystickInfo (float pressed, string direction, float player)
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = pressed+"|"+direction+"|"+player;
            client.Send(888, msg);
            


        }




    }
    static public void SendAskForGameState()
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = "";
            client.Send(555, msg);



        }




    }
    static public void SendPlayerInfo(string direction, float player)
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = direction + "|" + player;
            client.Send(885, msg);



        }




    }

    // Update is called once per frame
    void Update()
    {
        debbugField.text = stillWaiting;
        if(stillWaiting=="False")
        {
            sorryToLate.SetActive(true);

        }
        if (!runthisOnce)
        {//Debug.Log("Achtung:"+playerAndDirection);
            if (client.isConnected)
            {
                connectionStatus.text = "Yeah, you are connected to " + iPAdress.text;
                connectButton.SetActive(false);
                toggleGroup.SetActive(true);
                runthisOnce = true;


            }
        }
        if (!client.isConnected)
        {
            connectionStatus.text = "Could not find that Server!";


        }

        if (waitingForothterPlayers_State)
        {

            if (!player1Up && playernumber == 1)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                UpButton.SetActive(true);
            }

            if (!player1Down && playernumber == 1)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                DownButton.SetActive(true);

            }
            if (!player1Left && playernumber == 1)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                LeftButton.SetActive(true);

            }
            if (!player1Right && playernumber == 1)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                RightButton.SetActive(true);

            }
            if (!player2Up && playernumber == 2)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                UpButton.SetActive(true);

            }
            if (!player2Down && playernumber == 2)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                DownButton.SetActive(true);

            }
            if (!player2Left && playernumber == 2)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                LeftButton.SetActive(true);

            }
            if (!player2Right && playernumber == 2)
            {
                //debbugField.GetComponent<Text>().text = playerAndDirection + "Test"; // countClients.text = client.allClients.ToString();
                RightButton.SetActive(true);

            }
        }

    }
    public void OnUpButtonClick()
    {
        BigButton.GetComponent<joybutton>().direction = "Up";
        SendPlayerInfo("Up", playernumber);
        
        BigButton.SetActive(true);
        toggleGroup.SetActive(false);
        waitingForothterPlayers_State = false;
        


    }
    public void OnToggleClick1()
    { playernumber = 1;
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        DownButton.SetActive(false);
        UpButton.SetActive(false);
        SendAskForGameState();


    }
    public void OnToggleClick2()
    { playernumber = 2;
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        DownButton.SetActive(false);
        UpButton.SetActive(false);
        SendAskForGameState();
    }
    public void OnToggleClick3()
    { playernumber = 3;
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        DownButton.SetActive(false);
        UpButton.SetActive(false);
        SendAskForGameState();
    }
    public void OnToggleClick4()
    { playernumber = 4;
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
        DownButton.SetActive(false);
        UpButton.SetActive(false);
        SendAskForGameState();
    }

    public void OnDownButtonClick()
    {
        
        BigButton.GetComponent<joybutton>().direction = "Down";
        SendPlayerInfo("Down", playernumber);

        BigButton.SetActive(true);
        toggleGroup.SetActive(false);
        Debug.Log(iPAdress.text);
        //debbugField.SetActive(true);
        test = iPAdress.text;
        waitingForothterPlayers_State = false;
    }

    public void OnLeftButtonClick()
    {
        
        BigButton.GetComponent<joybutton>().direction = "Left";
        SendPlayerInfo("Left", playernumber);

        BigButton.SetActive(true);
        toggleGroup.SetActive(false);
        Debug.Log(iPAdress.text);
        //debbugField.SetActive(true);
        test = iPAdress.text;
        waitingForothterPlayers_State = false;
    }

    public void OnRightButtonClick()
    {
        
        BigButton.GetComponent<joybutton>().direction = "Right";
        SendPlayerInfo("Right", playernumber);

        BigButton.SetActive(true);
        toggleGroup.SetActive(false);
        Debug.Log(iPAdress.text);
       // debbugField.SetActive(true);
        test = iPAdress.text;
        waitingForothterPlayers_State = false;
    }
}
