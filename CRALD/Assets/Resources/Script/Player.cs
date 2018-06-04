using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	int positionX;
	int positionZ;
	int speed;
	// Use this for initialization
	void Start () {
		World.RefreshMap(0,0);
		Debug.Log(World.CreateMap[0,0]);
		positionX = 0;
		positionZ = 0;
		speed = 100;
	}
	
	// Update is called once per frame
	void Update () {
		int mapX = (int)Mathf.Round(transform.position.x/100);
		int mapZ = (int)Mathf.Round(transform.position.z/100);

		float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		
		transform.Translate(horizontal,0,vertical);
		if(mapX!=positionX|mapZ!=positionZ){
			positionX = mapX;
			positionZ = mapZ;
			World.RefreshMap(positionX,positionZ);
		}
	}
}
