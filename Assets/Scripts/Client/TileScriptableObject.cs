using UnityEngine;

[CreateAssetMenu(fileName = "Tile Set", menuName = "Custom/Tile Set")]
public class TileScriptableObject : ScriptableObject
{
	[SerializeField] private TileData[] _tiles;

	public TileData[] Tiles => _tiles;
}