using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : MonoBehaviour
{
    [SerializeField] private SpawnTiles _spawnTiles;
	[SerializeField] private TaskManager _taskManager;
	[SerializeField] private TileAppearance _tileAppearance;

	public List<string> TileIdenfier { get; private set; } = new();

	private void OnEnable()
	{
		_spawnTiles.TileSpawned += GetTileButtons;
	}

	private void OnDisable()
	{
		_spawnTiles.TileSpawned -= GetTileButtons;
	}

	private void GetTileButtons()
	{
		if (_spawnTiles.tilesList.Count == 0) return;

		foreach (var tile in _spawnTiles.tilesList)
		{
			TileData currentTile = tile;
			currentTile.TileButton.onClick.AddListener(() => CheckAnswer(currentTile));
		}
	}

	private void CheckAnswer(TileData tile)
	{
		if (_taskManager.GetTaskText().Equals(tile.TileIdentifier))
		{
			TileIdenfier.Add(tile.TileIdentifier);
			_tileAppearance.ScaleInBounce(tile.TileCanvasGroup);
			EnableParticle(tile.ParticleSystem);
		}
		else
		{
			_tileAppearance.EaseInBounce(tile.TileRectTransform);
		}
	}

	private void EnableParticle(ParticleSystem particleSystem)
	{
		particleSystem.gameObject.SetActive(true);
		particleSystem.Play();
	}
}