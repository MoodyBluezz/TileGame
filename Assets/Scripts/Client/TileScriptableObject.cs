using UnityEngine;

namespace Client 
{ 
	[CreateAssetMenu(fileName = "Tile Set", menuName = "Custom/Tile Set")]
	public class TileScriptableObject : ScriptableObject
	{
		[SerializeField] private TileData[] _tileData;

		public TileData[] TileDatas => _tileData;
	}
}