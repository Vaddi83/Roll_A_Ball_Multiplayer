using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine;
public class NetworkServerUI : NetworkBehaviour
{
    static public float buttonPressed;
    static public string direction;
    static public float buttonPressed2;
    static public string direction2;
    static public float buttonPressed3;
    static public string direction3;
    static public float buttonPressed4;
    static public string direction4;
    static public float player;

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

    bool waitingForotherPlayers_State = true;
    public static NetworkServerUI instance;

    [SyncVar]
    public int countClients;
    void ONGUI()
    {


        GUI.Label(new Rect(20, Screen.height - 20, 100, 20), "Connected:" + NetworkServer.connections.Count);
        GUI.Label(new Rect(20, Screen.height - 35, 100, 20), "Status:" + NetworkServer.active);
    }

    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        { Destroy(gameObject); }
        else
        {

            instance = this;

        }
        DontDestroyOnLoad(this.gameObject);
    }
        void Start()
    {
        

        NetworkServer.useWebSockets=true;
        NetworkServer.Listen(9997);
        Debug.Log(NetworkServer.active);
        Debug.Log(NetworkServer.connections.Count);
        NetworkServer.RegisterHandler(888, ServerReceiveMessage);
        NetworkServer.RegisterHandler(885, ServerReceivePlayerMessage);
        NetworkServer.RegisterHandler(555, ServerReceiveGamestate);
        PauseGame();
    }
    private void ServerReceiveMessage(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = message.ReadMessage<StringMessage>().value;
        Debug.Log("Message:" + msg.value);

        string[] infos = msg.value.Split('|');
        player = float.Parse(infos[2]);
        if (player == 1)
        {
            buttonPressed = float.Parse(infos[0]);
            direction = infos[1];

        }
        if (player == 2)
        {
            buttonPressed2 = float.Parse(infos[0]);
            direction2 = infos[1];
        }
        if (player == 3)
        {
            buttonPressed3 = float.Parse(infos[0]);
            direction3 = infos[1];
        }
        if (player == 4)
        {
            buttonPressed4 = float.Parse(infos[0]);
            direction4 = infos[1];
        }














    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    private void ServerReceiveGamestate(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
        msg.value = waitingForotherPlayers_State.ToString();
        NetworkServer.SendToAll(554, msg);
    }
        
    
    
    
    
    private void ServerReceivePlayerMessage(NetworkMessage message)
    {
        StringMessage msg = new StringMessage();
    msg.value = message.ReadMessage<StringMessage>().value;
        Debug.Log("Message:" + msg.value);

        string[] infos = msg.value.Split('|');
    player = float.Parse(infos[1]);
        if (player == 1)
        {
            
    direction = infos[0];
            if (direction == "Up")
            { player1Up = true;
                Debug.Log(player1Up);
            }
            if (direction == "Down")
            { player1Down = true;
                Debug.Log(player1Down);
            }
            if (direction == "Left")
            { player1Left = true; }
            if (direction == "Right")
            { player1Right = true; }


        }
if (player == 2)
{
    
    direction2 = infos[0];
            if (direction2 == "Up")
            {
                player2Up = true;
                
            }
            if (direction2 == "Down")
            {
                player2Down = true;
                
            }
            if (direction2 == "Left")
            { player2Left = true; }
            if (direction2 == "Right")
            { player2Right = true; }


        }
    
if (player == 3)
{
    
    direction3 = infos[1];
}
if (player == 4)
{
    
    direction4 = infos[1];
}














    }
    static public void SendPlayerandDirection(float player, string direction)
    {
        StringMessage msg = new StringMessage();
        msg.value = player + direction;
        NetworkServer.SendToAll(887, msg);

    }

    
    // Update is called once per frame
    void Update()
            {

        if (waitingForotherPlayers_State)
        {
            if (player1Up)
            {
                SendPlayerandDirection(1, "Up");
                Debug.Log("Send 1Up");
            }
            if (player1Down)
            {
                SendPlayerandDirection(1, "Down");
                Debug.Log("Send 1 Down");
            }
            if (player1Left)
            {
                SendPlayerandDirection(1, "Left");
                //Debug.Log("Send");
            }
            if (player1Right)
            {
                SendPlayerandDirection(1, "Right");
                //Debug.Log("Send");
            }
            if (player2Up)
            {
                SendPlayerandDirection(2, "Up");
                //Debug.Log("Send");
            }
            if (player2Down)
            {
                SendPlayerandDirection(2, "Down");
                //Debug.Log("Send");
            }
            if (player2Left)
            {
                SendPlayerandDirection(2, "Left");
                //Debug.Log("Send");
            }
            if (player2Right)
            {
                SendPlayerandDirection(2, "Right");
                //Debug.Log("Send");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            waitingForotherPlayers_State = false;
            ResumeGame();
            Debug.Log(NetworkServer.connections.Count);
            //SendPlayerAnzahl(NetworkServer.connections.Count);
            Debug.Log(direction);
        }
    }
        }