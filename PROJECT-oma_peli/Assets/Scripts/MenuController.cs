using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    public Button PLAY;
    public Button EXIT;
    public Canvas QuitMenu;

	// Use this for initialization
	void Start () {
        QuitMenu = QuitMenu.GetComponent<Canvas>();
        PLAY = PLAY.GetComponent<Button>();
        EXIT = EXIT.GetComponent<Button>();
        QuitMenu.enabled = false;

    }

    public void ExitPress()
    {
        QuitMenu.enabled = true;
        EXIT.enabled = false;
        PLAY.enabled = false;
    }

    public void NoPress()
    {
        QuitMenu.enabled = false;
        EXIT.enabled = true;
        PLAY.enabled = true;
    }
	
    public void StartLevel()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
