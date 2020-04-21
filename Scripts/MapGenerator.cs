using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class MapGenerator : MonoBehaviour {

	[Tooltip("Assign the map asset here.")]	
	public Map _map;

	[Tooltip("Length of one side of the object in metres.")]
	public float _objectLength = 10f;

	[Tooltip("The tag for the object.")]
	public string _objectTag = "MapPart";
	public void Generate()
	{
		string map = _map.Tiles;
		Vector3 position = Vector3.zero;
		foreach( char id in map)
		{

			switch(id.ToString())
			{				
				case " ":
					position += new Vector3(_objectLength, 0f,0F);
				break;
				case "\n":
					position = new Vector3(0f, 0f, position.z + _objectLength);
				break;
				default:
					CreateTile(id, position);
					position += new Vector3(_objectLength,0f,0f);
				break;
			}
		}
	}

	private void CreateTile(char id, Vector3 position)
	{
		try
		{
			if(_map.Parts.Where((p) => p.Character == id).FirstOrDefault() == null)
				return;
			GameObject part = Instantiate( _map.Parts.Where((p) => p.Character == id).First().Visual, position, Quaternion.identity );
			if(part.tag == "Key")
			{
				part.GetComponentInChildren<Key>().door = FindObjectOfType<Door>();
			}
			
			part.transform.parent = this.gameObject.transform;
			if(id == 'S')
			{
				var playerGameObject = GameObject.FindGameObjectWithTag("Player");
				playerGameObject.transform.position = part.transform.position + new Vector3(0f, 3f,0f);
			}
			part.tag = _objectTag;
			
		}
		catch( Exception e)
		{
			Debug.LogError(e);
			Debug.LogFormat("Part {0} Failed to be created.", id);
		}
	}

	public void RemoveObjects()
	{
		var objects = GameObject.FindGameObjectsWithTag(_objectTag);
		foreach(var o in objects)
			DestroyImmediate(o);
	}
}
