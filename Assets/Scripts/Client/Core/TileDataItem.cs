using UnityEngine;
using UnityEngine.UI;

namespace Client
{
	public class TileDataItem : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _particleSystem;
		[SerializeField] private Button _tileButton;
		[SerializeField] private Image _tileImage;
		[SerializeField] private RectTransform _tileRectTransform;
		[SerializeField] private CanvasGroup _canvasGroup;

		public string Identifier { get; set; }
		public CanvasGroup TileCanvasGroup => _canvasGroup;
		public RectTransform TileRectTransform => _tileRectTransform;
		public ParticleSystem ParticleSystem => _particleSystem;
		public Button TileButton => _tileButton;

		public void SetUpData(TileData data)
		{
			Identifier = data.TileIdentifier;
			_tileImage.sprite = data.TileDataImage;
		}
	}
}