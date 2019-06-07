using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public GameObject status;
    public Text scoreText;
	public Image backgroungImg;
    

	private bool isShowned = false;

	private float transition = 0.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

	// Update is called once per frame
	void Update () {
		if (!isShowned)
			return;

		transition += Time.deltaTime;
		backgroungImg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, transition);
	}

	public void ToggleEndMenu(float score, bool isDead, bool isWin)
	{
       //if player hits the car shows game over
        if (isDead) {
            status.GetComponent<Text>().text = "GAME OVER";
        }
        //if player reaches destination shows win
        if (isWin) {
            status.GetComponent<Text>().text = "YOU WON!";
        }
		gameObject.SetActive (true);
		scoreText.text = ((int)score).ToString ();
		isShowned = true;
      
    }

	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        GetComponent<ScoringSystem>().ResetScore();
    }

    public void ToSettingsPopup()
    {
       
            SceneManager.LoadScene("Options");
    }
    public void ToMenu()
	{
		SceneManager.LoadScene ("Menu");
        GetComponent<ScoringSystem>().ResetScore();
    }

} 
