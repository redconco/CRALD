using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class World {

	static int MapArrSize = 10;
	static int MapArrHalf = MapArrSize/2;

	static int MapSize = 100;
	static int MapHalf = MapSize/2;

	static int MapLoadingSize = 2;
	static public GameObject world = GameObject.Find("World");
	static int MapClearSize = 3;
	static public bool[,] CreateMap = new bool [MapArrSize+1,MapArrSize+1];

    static public void RefreshMap(int x, int z){
		
		ClearMap(x,z);

		GameObject map = Resources.Load("Prefabs/Map") as GameObject;
		Debug.Log(x+","+z);
		for(int i = x-MapLoadingSize;i<=x+MapLoadingSize;i++){
			for(int j = z-MapLoadingSize;j<=z+MapLoadingSize;j++){
				if(i+MapArrHalf>MapArrSize|j+MapArrHalf>MapArrSize|i+MapArrHalf<0|j+MapArrHalf<0) continue;
				if(CreateMap[i+MapArrHalf,j+MapArrHalf]) continue;
				CreateMap[i+MapArrHalf,j+MapArrHalf]=true;
				//GameObject map = Resources.Load("Prefabs/Map") as GameObject;
				//Debug.Log((i*100));
				Vector3 position = new Vector3((i*100)-MapHalf,0,(j*100)-MapHalf);
				GameObject newMap = GameObject.Instantiate(map,position, Quaternion.identity);
				newMap.name = "map:"+i+""+j;
				newMap.transform.parent = world.transform;
			}
		}
	}
	static void ClearMap(int x, int z){

		int Clear = MapLoadingSize+MapClearSize;
		for(int i = x-Clear;i<=x+Clear;i++){
			for(int j = z-Clear;j<=z+Clear;j++){
				if(i+MapArrHalf>MapArrSize|j+MapArrHalf>MapArrSize|i+MapArrHalf<0|j+MapArrHalf<0) continue;
				Debug.Log(i+","+j);
				if((i==x-Clear | i==x+Clear | j==z-Clear | j==z+Clear)&CreateMap[i+MapArrHalf,j+MapArrHalf]) {
					CreateMap[i+MapArrHalf,j+MapArrHalf]=false;
					GameObject.Destroy(GameObject.Find("map:"+i+""+j));
				}
			}
		}
	}
}
