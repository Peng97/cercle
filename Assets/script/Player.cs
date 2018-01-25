using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject Start_text;
	public Text countText;
	public Text BestScore;
	public bool isPaused;
	public bool isOver;

	private Rigidbody2D rb;
	private int count = 0;
	private bool isStart = false;
	private float speed = 80;

	public void saveScore()
	{
		if (count > PlayerPrefs.GetInt("Record"))
		{
    		PlayerPrefs.SetInt("Record", count);
    		BestScore.text = "Best : " + PlayerPrefs.GetInt("Record");
		}
	}

	void Start () {
		isPaused = true;
		isOver = false;
		rb = GetComponent<Rigidbody2D>();
		countText.text = count.ToString();
		BestScore.text = "Best : " + PlayerPrefs.GetInt("Record");
	}
	
	void Update () {
		if (Input.GetButtonUp("Fire1") && (isOver == false))
		{
			if (!isStart)
			{
				isStart = !isStart;
				Start_text.SetActive(false);
			}
			if (isPaused)
				isPaused = !isPaused;

			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector3(0, 2, 0) * speed);
			count += 1;
			countText.text = count.ToString();	
		}

		if( Input.GetKeyDown(KeyCode.R) )
    	{
       		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
       		saveScore();
     	}

     	if (!isOver && Input.GetKeyDown(KeyCode.P)) {
           isPaused = !isPaused;
      	}
      	Time.timeScale = isPaused ? 0 : 1;
	}
}
