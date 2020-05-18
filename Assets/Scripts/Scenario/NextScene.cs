using UnityEngine;

public class NextScene : MonoBehaviour
{

	private void OnTriggerEnter2D()
	{
		GameManager.instance.ChangeScene();
	}
}
