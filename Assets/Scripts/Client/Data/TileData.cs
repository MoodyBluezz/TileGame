using UnityEngine;

namespace Client
{
	[CreateAssetMenu(fileName = "TileData", menuName = "Custom/Create Tile Data", order = 0)]
	public class TileData : ScriptableObject
	{
		[SerializeField] private string _identifier;
		[SerializeField] private Sprite _dataImage;

		public string TileIdentifier => _identifier;
		public Sprite TileDataImage => _dataImage;
	}
}