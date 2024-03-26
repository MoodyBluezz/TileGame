using UnityEngine;
using UnityEngine.UI;

public class TileData : MonoBehaviour
{
    [SerializeField] private string _identifier;
	[SerializeField] private CanvasGroup _canvasGroup;
	[SerializeField] private Image _borderImage;
	[SerializeField] private Image _dataImage;
	[SerializeField] private Button _tileButton;
	[SerializeField] private RectTransform _tileRectTransform;
	[SerializeField] private ParticleSystem _particleSystem;

	public string TileIdentifier => _identifier;
	public CanvasGroup TileCanvasGroup => _canvasGroup;
	public Image TileBorderImage => _borderImage;
	public Image TileDataImage => _dataImage;
	public Button TileButton => _tileButton;
	public RectTransform TileRectTransform => _tileRectTransform;
	public ParticleSystem ParticleSystem => _particleSystem;

	public void SetData()
	{
		_identifier = char.ToUpper(gameObject.name[gameObject.name.Length - 1]).ToString();
		_borderImage = GetComponent<Image>();
		_canvasGroup = GetComponent<CanvasGroup>();
		_dataImage = transform.GetChild(0).GetComponent<Image>();
		_tileButton = transform.GetChild(0).GetComponent<Button>();
		_tileRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
		_tileRectTransform.sizeDelta = new Vector2(96, 96);
		_tileRectTransform.anchoredPosition = Vector2.zero;
		_particleSystem = transform.GetChild(1).GetComponent<ParticleSystem>();
	}
}