using System.Collections.Generic;
using UnityEngine;

namespace Client
{
	public class SpawnTiles : MonoBehaviour
	{
		[SerializeField] private ModeSelector _modeSelector;
		[SerializeField] private TaskManager _taskGenerator;
		[SerializeField] private TileAppearance _slotAppearance;
		[SerializeField] private int _tileCount;
		[SerializeField] private TileInteraction _tileInteraction;
		[SerializeField] private TileDataItem _tileDataItem;

		private List<TileDataItem> _tilesList = new();
		private HashSet<int> _usedIndices = new();

		private void Start()
		{
			SpawnTileItems(_modeSelector.TileScriptableObjects);
			GetTaskText();
			ShowTilesSequentially();
		}

		private void SpawnTileItems(TileScriptableObject tileScriptableObject)
		{
			_usedIndices.Clear();

			for (int i = 0; i < _tileCount; i++)
			{
				if (i >= 0 && i < tileScriptableObject.TileDatas.Length)
				{
					int randomDataIndex = GetUniqueRandomIndex(tileScriptableObject.TileDatas.Length);

					var itemData = tileScriptableObject.TileDatas[randomDataIndex];
					var tileDataItem = Instantiate(_tileDataItem, transform);

					ProcessTileItem(tileScriptableObject, itemData, tileDataItem);
				}
			}
			_tileInteraction.GetTileButtons(_tilesList);
		}

		private int GetUniqueRandomIndex(int maxIndex)
		{
			int randomDataIndex;
			do
			{
				randomDataIndex = UnityEngine.Random.Range(0, maxIndex);
			}
			while (_usedIndices.Contains(randomDataIndex));

			_usedIndices.Add(randomDataIndex);

			return randomDataIndex;
		}

		private void ProcessTileItem(TileScriptableObject tileScriptableObject, TileData itemData, TileDataItem tileDataItem)
		{
			bool hasSameIdentifier = CheckForDuplicateIdentifier(itemData.TileIdentifier);

			if (!hasSameIdentifier)
			{
				tileDataItem.SetUpData(itemData);
				_tilesList.Add(tileDataItem);
			}
			else
			{
				HandleDuplicateTile(tileScriptableObject, itemData, tileDataItem);
			}
		}

		private bool CheckForDuplicateIdentifier(string identifier)
		{
			return _tilesList.Exists(tile => tile.Identifier == identifier);
		}

		private void HandleDuplicateTile(TileScriptableObject tileScriptableObject, TileData itemData, TileDataItem tileDataItem)
		{
			int randomDataIndex = UnityEngine.Random.Range(0, tileScriptableObject.TileDatas.Length);
			itemData = tileScriptableObject.TileDatas[randomDataIndex];
			tileDataItem.SetUpData(itemData);
			_tilesList.Add(tileDataItem);
		}

		private void GetTaskText()
		{
			int randomIndex = UnityEngine.Random.Range(0, _tilesList.Count);
			string taskText = _tilesList[randomIndex].Identifier;
			_taskGenerator.SetTaskText(taskText);
		}

		private void ShowTilesSequentially()
		{
			CanvasGroup[] canvasGroups = new CanvasGroup[_tilesList.Count];

			for (int i = 0; i < _tilesList.Count; i++)
			{
				canvasGroups[i] = _tilesList[i].TileCanvasGroup;
			}

			_slotAppearance.FadeOutSequentially(canvasGroups);
		}
	}
}