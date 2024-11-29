using UnityEngine;
using System;
using TMPro;


public class GameMap : MonoBehaviour
{
	[SerializeField] Transform[] levels;
	Transform cam;
	int currentIndex = 0;
	[SerializeField] float speed = .5f;
	
	void Start ()
	{
		cam = Camera.main.transform.parent;
	}
	void LateUpdate ()
	{
		cam.position = Vector2.Lerp (cam.position, levels[currentIndex].position, speed) ;
	}

	public void ClickRight ()
	{
		Move (1); //1:right    -1:Left
	}

	public void ClickLeft ()
	{
		Move (-1); //1:right    -1:Left
	}

	void Move (int dir)
	{
		currentIndex += dir;

		currentIndex = (currentIndex < 0) ? levels.Length - 1 : currentIndex;
		currentIndex = (currentIndex >= levels.Length) ? 0 : currentIndex;
	}

}