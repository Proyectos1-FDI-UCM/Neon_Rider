using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBetweenScenes : MonoBehaviour
{

	private void OnTriggerEnter2D()
	{		
		GameManager.instance.ChangeScenePatras();		
	}
}
