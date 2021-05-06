using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveHorizontal;
	public float moveVertical;
	public float speed;
	public float jumpHeight;
	public float playerNumber;
	public Text countText;
	public Text countText1;
	public Button restart;
	public Text winText;
	public int numPickups;

	private Rigidbody rb;
	private int count;
	private int count1;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
		restart.gameObject.SetActive(false);
	}

	void FixedUpdate()
	{
		if (playerNumber == 1) { 
		float moveHorizontal = Input.GetAxis("Horizontal");
		//moveHorizontal = NetworkServerUI.buttonPressed;
		float moveVertical = Input.GetAxis("Vertical");
		if (NetworkServerUI.direction == "Left")
		{
			moveHorizontal = NetworkServerUI.buttonPressed * -1;
		}
		if (NetworkServerUI.direction == "Right")
		{
			moveHorizontal = NetworkServerUI.buttonPressed;
		}
		if (NetworkServerUI.direction == "Up")
		{
			moveVertical = NetworkServerUI.buttonPressed;
				//Debug.Log("Up is working");
		}
		if (NetworkServerUI.direction == "Down")
		{
			moveVertical = NetworkServerUI.buttonPressed * -1;
				//Debug.Log("Down is working");
			}
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		if (Input.GetKeyDown("space"))
		{
			Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
			rb.AddForce(jump);
		}

	}
		if (playerNumber == 2)
		{
			//float moveHorizontal = Input.GetAxis("Horizontal");
			//moveHorizontal = NetworkServerUI.buttonPressed;
			//float moveVertical = Input.GetAxis("Vertical");
			if (NetworkServerUI.direction2 == "Left")
			{
				moveHorizontal = NetworkServerUI.buttonPressed2 * -1;
			}
			if (NetworkServerUI.direction2 == "Right")
			{
				moveHorizontal = NetworkServerUI.buttonPressed2;
			}
			if (NetworkServerUI.direction2 == "Up")
			{
				moveVertical = NetworkServerUI.buttonPressed2;
				//Debug.Log("Up is working");
			}
			if (NetworkServerUI.direction2 == "Down")
			{
				moveVertical = NetworkServerUI.buttonPressed2 * -1;
				//Debug.Log("Down is working");
			}
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			rb.AddForce(movement * speed);

			if (Input.GetKeyDown("space"))
			{
				Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
				rb.AddForce(jump);
			}

		}
		if (playerNumber == 3)
		{
			//float moveHorizontal = Input.GetAxis("Horizontal");
			//moveHorizontal = NetworkServerUI.buttonPressed;
			//float moveVertical = Input.GetAxis("Vertical");
			if (NetworkServerUI.direction3 == "Left")
			{
				moveHorizontal = NetworkServerUI.buttonPressed3 * -1;
			}
			if (NetworkServerUI.direction3 == "Right")
			{
				moveHorizontal = NetworkServerUI.buttonPressed3;
			}
			if (NetworkServerUI.direction3 == "Up")
			{
				moveVertical = NetworkServerUI.buttonPressed3;
				//Debug.Log("Up is working");
			}
			if (NetworkServerUI.direction3 == "Down")
			{
				moveVertical = NetworkServerUI.buttonPressed3 * -1;
				//Debug.Log("Down is working");
			}
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			rb.AddForce(movement * speed);

			if (Input.GetKeyDown("space"))
			{
				Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
				rb.AddForce(jump);
			}

		}
		if (playerNumber == 4)
		{
			//float moveHorizontal = Input.GetAxis("Horizontal");
			//moveHorizontal = NetworkServerUI.buttonPressed;
			//float moveVertical = Input.GetAxis("Vertical");
			if (NetworkServerUI.direction4 == "Left")
			{
				moveHorizontal = NetworkServerUI.buttonPressed4 * -1;
			}
			if (NetworkServerUI.direction4 == "Right")
			{
				moveHorizontal = NetworkServerUI.buttonPressed4;
			}
			if (NetworkServerUI.direction4 == "Up")
			{
				moveVertical = NetworkServerUI.buttonPressed4;
				Debug.Log("Up is working");
			}
			if (NetworkServerUI.direction4 == "Down")
			{
				moveVertical = NetworkServerUI.buttonPressed4 * -1;
				Debug.Log("Down is working");
			}
			Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

			rb.AddForce(movement * speed);

			if (Input.GetKeyDown("space"))
			{
				Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);
				rb.AddForce(jump);
			}

		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up")&&playerNumber==1)
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();

		}
		if (other.gameObject.CompareTag("Pick Up") && playerNumber == 2)
		{
			other.gameObject.SetActive(false);
			count1++;
			SetCountText();

		}
	}

	void SetCountText()
	{
		if(playerNumber==1)
		countText.text = "Count: " + count.ToString();
		if (playerNumber == 2)
			countText1.text = "Count: " + count1.ToString();
		if (count+count1 >= numPickups)
		{
			winText.text = "The Game is over";
			restart.gameObject.SetActive(true);
			PauseGame();
		}
	}
	public void OnRestarButtonClick()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Debug.Log("Click Worked");

	}
	void PauseGame()
	{
		Time.timeScale = 0;
	}
}