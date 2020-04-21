using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewMapPartA", menuName="Create/MapGenerator/Empty/Part", order=0)]
public class MapPart : ScriptableObject {

	[Tooltip("Assign Prefab To Generate here")]
	public GameObject Visual;

	[Tooltip("Character to use in the map generator")]
	public char Character;
}
