using UnityEngine;
using System.Collections;

public class Destroyandloot : MonoBehaviour
{

    public int scoreValue;
    private GameController gameController;
    //private AudioSource audiosource;
    void Start()
    {
        //audiosource = GetComponent<AudioSource>();
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
            return; }
        if (other.tag == "Finish")
            {
                return;
            }
        
        if (other.tag == "Player")
        {
            //audiosource.Play();
            gameObject.SetActive(false);
            gameController.AddScore(scoreValue);
        }
    }


}
