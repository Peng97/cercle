using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collid : MonoBehaviour {

	public GameObject OverUI;
	public GameObject player;
	public GameObject hat;

	private Player p;
	private float EffectEnd;
	private float count;
	private float size;

    void Start()
    {
    	EffectEnd = 0;
    	count = 0;
    	size = 0;
        OverUI.SetActive(false);
        hat.SetActive(false);
    }

    public void TaskOnClick()
    {
    	p = player.GetComponent<Player>();
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
       	p.saveScore();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Road"))
		{
			p = player.GetComponent<Player>();
			Time.timeScale = 0;
			p.saveScore();
			p.isPaused = true;
			p.isOver = true;
			OverUI.SetActive(true);
		}
		else if (other.gameObject.CompareTag("shrooms"))
		{
			Destroy(other.gameObject);
			size += 0.3f;
			player.transform.localScale += new Vector3(0, 0.3f, 0);
			EffectEnd = Time.time + 3;
			count = Time.time;
	        hat.SetActive(true);
		}
	}

	void Update()
	{
		if (EffectEnd > count)
		{
			count += Time.deltaTime;
			if (count >= EffectEnd)
			{
       			hat.SetActive(false);
				player.transform.localScale += new Vector3(0, -size, 0);
				size = 0;
			}
		}
	}
}
