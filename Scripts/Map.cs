using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewMap", menuName="Create/MapGenerator/NewMap",order=1)]
public class Map : ScriptableObject {

	[TextArea(10,20)]	
	public string Tiles;

	public List<MapPart> Parts;	
}
