using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] obj;
	public GameObject prefab;
	public GameObject shrooms;

	private Vector2 pos;
	private float prev = 0;

	float	GetX(float prev, float rand)
	{
		float rt = pos.x + (obj[5].GetComponent<Collider2D>().bounds.size.x / 2) + 
				(obj[6].GetComponent<Collider2D>().bounds.size.x / 2);

		if (Mathf.Abs(prev - rand) > 55)
			return (rt - 0.25f);
		else if (Mathf.Abs(prev - rand) > 45)
			return (rt - 0.2f);
		else if (Mathf.Abs(prev - rand) > 30)
			return (rt - 0.16f);
		else if (Mathf.Abs(prev - rand) > 10)
			return (rt - 0.12f);
		else
			return (rt - 0.08f);
	}

	float	GetY(float prev, float rand)
	{

		if (rand > 0)
		{
			return  (pos.y + ((obj[6].GetComponent<Collider2D>().bounds.size.y) / 2) + 
						((-obj[5].GetComponent<Collider2D>().bounds.size.y) / 2));
		}
		else
			return 	(pos.y + ((-obj[6].GetComponent<Collider2D>().bounds.size.y) / 2) + 
						((obj[5].GetComponent<Collider2D>().bounds.size.y) / 2));
	}

	void	spawn()
	{
		float rand = 0;
		int i = -1;
		pos = new Vector2(obj[6].transform.position.x, obj[6].transform.position.y);	
		Destroy(obj[0]);
		while (++i < 6)
			obj[i] = obj[i + 1];

		if ((pos.y > 0.0f && pos.y > 2f) || (pos.y < 0.0f  && pos.y < -2f))
		{
			if (pos.y > 0)
				rand = (prev > 0) ? Random.Range(-30f, -45f) : 1;					// to range the game.. not going too high or too low;
			else
				rand = (prev < 0) ? Random.Range(30f, 45f) : -1;
		}
		else
		{
			if (prev > 0)
				rand = Random.Range(-2f, -45f);
			else
				rand = Random.Range(2f, 45f);
		}

		obj[6] = Instantiate(prefab,
				new Vector3(30, 0,0),Quaternion.identity);										//init
		obj[6].transform.localScale = new Vector3(Random.Range(
					((pos.y > 0.0f && pos.y > 2f) || (pos.y < 0.0f  && pos.y < -2f)) ? 2.5f : 1.0f,
					3.5f), 0.2f, 0f);															//random lengh
		obj[6].transform.Rotate(new Vector3(0, 0, rand));    								//rotate
		obj[6].transform.position = new Vector3(GetX(prev, rand), GetY(prev, rand), 0); 	//trans to right position
		if ((Mathf.RoundToInt(Random.Range(0f, 6f)) == 0))
		{
			Instantiate(shrooms, new Vector3(obj[6].transform.position.x,
							obj[6].transform.position.y + Random.Range(0.5f, 1.5f), 0),
							Quaternion.identity);
		}
		prev = rand;

	}

	void Update () {
		if (obj[0].transform.position.x < -5f)
			spawn();
	}
}
