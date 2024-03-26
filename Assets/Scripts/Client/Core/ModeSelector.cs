using Client;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelector : MonoBehaviour
{
	[SerializeField] private List<TileScriptableObject> _tilesSO;
	[SerializeField] private SpawnTiles _spawnTiles;
	[SerializeField] private GameObject _selectionPanel;
	[SerializeField] private Button _lettersButton;
	[SerializeField] private Button _numbersButton;

	public TileScriptableObject TileScriptableObjects {  get; private set; }


	private void OnEnable()
	{
		_lettersButton.onClick.AddListener(LettersMode);
		_numbersButton.onClick.AddListener(NumbersMode);
	}

	private void OnDisable()
	{
		_lettersButton.onClick.RemoveListener(LettersMode);
		_numbersButton.onClick.RemoveListener(NumbersMode);
	}

	private void LettersMode()
	{
		EnableGameView();
		TileScriptableObjects = _tilesSO[0];
	}

	private void NumbersMode()
	{
		EnableGameView();    
		TileScriptableObjects = _tilesSO[1];
	}

	private void EnableGameView()
	{
		_selectionPanel.SetActive(false);
		_spawnTiles.gameObject.SetActive(true);
	}
}