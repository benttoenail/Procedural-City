using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCityGen : MonoBehaviour {

	[SerializeField]GameObject building;
	[SerializeField]GameObject[] buildings = new GameObject[4];

	[SerializeField] int countX;
	[SerializeField] int countZ;

	[SerializeField] float GlobalScale;

	private float xPos;
	private float zPos;

	public float spacing;
	public float height = 1f;

	private float randHieght;
	private int randCount;


	private int BlockCount = 1;

	private List<GameObject> CityBlocks = new List<GameObject>();

	void CreateCityBlock()
	{
		GameObject Block = new GameObject();
		Block.name = ("Block: " + BlockCount);
		
		for(int i = 0; i < countX; i++)
		{
			Vector3 placeX = new Vector3(xPos, 0, 0);
			randHieght = Random.Range(1f, height);
			randCount = Random.Range(0, 4);
			GameObject temp = Instantiate(buildings[randCount], placeX, Quaternion.identity) as GameObject;
			temp.transform.localScale = new Vector3(1, randHieght, 1);

			temp.transform.SetParent(Block.transform);

			for(int j = 0; j < countZ; j++)
			{
				Vector3 placeZ = new Vector3(xPos, 0, zPos);
				randHieght = Random.Range(1f, height);
				randCount = Random.Range(0, 4);
				GameObject _temp = Instantiate(buildings[randCount], placeZ, Quaternion.identity) as GameObject;
				_temp.transform.localScale = new Vector3(1, randHieght, 1);

				_temp.transform.SetParent(Block.transform);
				zPos = spacing * j;
			}

			xPos = spacing * i;

		}

		CityBlocks.Add(Block);
        Block.transform.SetParent(this.gameObject.transform);
		BlockCount ++;
	}



	public float blockSpacing;
	private int blockNum = 0;

	void CreateCity()
	{

		for(int i = 0; i < NumberOfBlocks; i++)
		{
			CreateCityBlock();
			float blockXposition = (spacing * countX + blockSpacing ) * i; 
			CityBlocks[blockNum].transform.position = new Vector3(blockXposition, 0, 0);

			for(int j = 1; j < NumberOfBlocks; j++)
			{
				blockNum++;
				CreateCityBlock();
				float blockZposition = (spacing * countX + blockSpacing ) * j; 
				CityBlocks[blockNum].transform.position = new Vector3(blockXposition, 0, blockZposition);
			}

			blockNum++;
		}
	}


	#region MONODEVELOP

	[SerializeField] int NumberOfBlocks;

	void Start () {

		CreateCity();
			
	}

	#endregion
}
