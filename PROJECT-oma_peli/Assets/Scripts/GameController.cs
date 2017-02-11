using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {


    public GameObject Este;
    public GameObject Treat;
    public Vector3 spawnValues1;
    public Vector3 spawnValues2;

    public int hazardCount1;
    public int hazardCount2;

    private float spawnWait1;
    private float spawnWait2;

    public float startWait1;
    public float startWait2;

    public float waveWait1;
    public float waveWait2;


    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text creditText;
    public Text returnText;
    public Text MainMenuText;

    public bool gameOver;
    private bool restart;
    private int score;
    private int vertailu2;
    private int menuavain;
    private AudioSource audiosource;


    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        creditText.text = "";
        returnText.text = "";
        MainMenuText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves1());
        StartCoroutine(SpawnWaves2());
        spawnWait1 = 2.0f;
        spawnWait2 = 2.0f;
        vertailu2 = 0;
        menuavain = 0;
    }

    void Update()
    {

        if (vertailu2 >= 100)
        {
            spawnWait1 = spawnWait1 - 0.2f;
            spawnWait2 = spawnWait2 - 0.1f;
            vertailu2 = 0;
        }
        if (Input.GetKeyDown(KeyCode.C) & restart == true && menuavain == 0)
        {
            audiosource.Play();
            
            gameOverText.text = "";
            restartText.text = "";
            scoreText.text = "";
            returnText.text = "Press 'V' to Return";
            creditText.text = "Maker - Jaakko Tuuri\nBGM - Oniku Loop, dl-sounds.com\nPickUpSFX - PickUp, www.superflashbros.net/as3sfxr/\nJumpSFX - Jump, www.superflashbros.net/as3sfxr/\nGameOverSFX - Bang1, www.pacdv.com\nMenuSFX - Page Turn1, www.pacdv.com";
            MainMenuText.text = "";
            menuavain = 1;
        }
        if (Input.GetKeyDown(KeyCode.V) & restart == true && menuavain == 1)
        {
            audiosource.Play();
            
            gameOverText.text = "Game Over";
            restartText.text = "Press 'R' for Restart, or 'C' for Credits";
            scoreText.text = "Your score: " + score;
            creditText.text = "";
            returnText.text = "";
            MainMenuText.text = "Press 'M' to return to the main menu";
            menuavain = 0;
        }
            {
            if (Input.GetKeyDown(KeyCode.R) && restart == true && menuavain == 0)
            {
                audiosource.Play();
                Application.LoadLevel(Application.loadedLevel);
            }
            if (Input.GetKeyDown(KeyCode.M) && restart == true && menuavain == 0)
            {
                audiosource.Play();
                Application.LoadLevel(0);
            }
        }
    }

    IEnumerator SpawnWaves1()
    {
        yield return new WaitForSeconds(startWait1);
        while (true)
        {
            for (int i = 0; i < hazardCount1; i++)
            {

                Vector3 spawnPosition1 = new Vector3(spawnValues1.x, spawnValues1.y, Random.Range(-spawnValues1.z, spawnValues1.z));
                Quaternion spawnRotation1 = Quaternion.identity;
                Instantiate(Este, spawnPosition1, spawnRotation1);
                yield return new WaitForSeconds(spawnWait1);

                if (gameOver)
                {
                  //  restartText.text = "Press 'R' for Restart, or 'C' for Credits";
                  //  restart = true;
                    break;
                }


            }
            yield return new WaitForSeconds(waveWait1);
        

        if (gameOver)
        {
       //
        //    restartText.text = "Press 'R' for Restart, or 'C' for Credits";
          //  restart = true;
            break;
        }
    }

   }
    IEnumerator SpawnWaves2()
    {
        yield return new WaitForSeconds(startWait2);
        while (true)
        {
            for (int i = 0; i < hazardCount2; i++)
            {

                Vector3 spawnPosition2 = new Vector3(spawnValues2.x, spawnValues2.y, Random.Range(-spawnValues2.z, spawnValues2.z));
                Quaternion spawnRotation2 = Quaternion.identity;
                Instantiate(Treat, spawnPosition2, spawnRotation2);
                yield return new WaitForSeconds(spawnWait2);

                if (gameOver)
                {
                    //restartText.text = "Press 'R' for Restart, or 'C' for Credits";
                    // restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait2);

            if (gameOver)
            {
                //
                //   restartText.text = "Press 'R' for Restart, or 'C' for Credits";
                // restart = true;
                break;
            }

        }
        if (gameOver)
        {

            restartText.text = "Press 'R' for Restart, or 'C' for Credits";
            MainMenuText.text = "Press 'M' to return to the main menu";
            restart = true;
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        vertailu2 += newScoreValue;
    }
    void UpdateScore()
    {
        scoreText.text = "Your score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
