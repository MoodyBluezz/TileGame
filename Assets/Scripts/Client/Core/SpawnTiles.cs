using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour
{
	public event Action TileSpawned;

	[SerializeField] private TaskManager taskGenerator;
	[SerializeField] private TileAppearance _slotAppearance;
    [SerializeField] private int _tileCount;
	[SerializeField] private TileScriptableObject visualizationSets;
	[SerializeField] private TileInteraction _tileInteraction;

	public List<TileData> tilesList { get; private set; } = new();

	private TileData _currentTileData;
	private string _taskText = "";

	private void Start()
	{
		SwitchVisualizationSet();
		GetTaskText();
		ShowTiles();
		ShowTilesBounced();
	}

	private void SwitchVisualizationSet()
	{
		for(int i = 0; i < _tileCount; i++)
		{
			if (i >= 0 && i < visualizationSets.Tiles.Length)
			{
				_currentTileData = Instantiate(visualizationSets.Tiles[i], transform);
				tilesList.Add(_currentTileData);
			}
		}
		TileSpawned?.Invoke();
	}

	private void ShowTiles()
	{
		CanvasGroup[] canvasGroups = new CanvasGroup[tilesList.Count];

		for (int i = 0; i < tilesList.Count; i++)
		{
			canvasGroups[i] = tilesList[i].TileCanvasGroup;
		}

		_slotAppearance.FadeOutSequentially(canvasGroups);
	}

	private void ShowTilesBounced()
	{
		CanvasGroup[] canvasGroups = new CanvasGroup[tilesList.Count];

		for (int i = 0; i < tilesList.Count; i++)
		{
			canvasGroups[i] = tilesList[i].TileCanvasGroup;
			_slotAppearance.ScaleInBounce(canvasGroups[i]);
		}
	}

	private void GetTaskText()
	{
		var generatedID = GetRandomNumber();

		_taskText = tilesList[generatedID].TileIdentifier;

		if (_tileInteraction.TileIdenfier.Count > 0)
		{
			foreach (var identifier in _tileInteraction.TileIdenfier)
			{
				if (identifier == _taskText)
				{
					_taskText = tilesList[generatedID].TileIdentifier;
				}
			}
		}

		taskGenerator.SetTaskText(_taskText);
	}

	private int GetRandomNumber()
	{
		return UnityEngine.Random.Range(0, tilesList.Count);
	}
}