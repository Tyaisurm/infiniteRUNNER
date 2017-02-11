using UnityEngine;
using System.Collections;

public class destroyifcollide : MonoBehaviour
{

    public int scoreValue;
    private GameController gameController;
    private AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject = null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        
        }
        if (other.tag == "Finish")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Destroy(GameObject.FindWithTag("Player"));
            audiosource.Play();
            gameController.GameOver();
        }
        Destroy(other.gameObject);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary" && gameController.gameOver == false)
        {
            gameController.AddScore(scoreValue);

        }
    }


}