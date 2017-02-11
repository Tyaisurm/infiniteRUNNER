using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
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
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        gameController.AddScore(scoreValue);
    }


}
