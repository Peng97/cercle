﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonTest : MonoBehaviour {

	public void pressed () {
		SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}
}
