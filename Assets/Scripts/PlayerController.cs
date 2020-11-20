using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private int PowerUpCounter;
    private int Totalcounter;
    private int PowerUpleft;
    public GameObject PowerCollectedText;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        Totalcounter = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        PowerCollectedText.GetComponent<Text>().text = "Start Function";

        PowerCollectedText.GetComponent<Text>().text = "PowerUps collected: " + PowerUpCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpleft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total PowerUps: " + PowerUpleft.ToString());
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (PowerUpCounter == Totalcounter)
        {
            SceneManager.LoadScene("WinScene");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            PowerUpCounter++;
            PowerCollectedText.GetComponent<Text>().text = "PowerUpCollected: " + PowerUpCounter.ToString();
            Destroy(other.gameObject);


        }




        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }




}




