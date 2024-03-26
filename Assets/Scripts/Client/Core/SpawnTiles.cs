using System.Collections.Generic;
using UnityEngine;

namespace Client
{
	public class SpawnTiles : MonoBehaviour
	{
		[SerializeField] private TaskManager taskGenerator;
		[SerializeField] private TileAppearance _slotAppearance;
		[SerializeField] private int _tileCount;
		[SerializeField] private TileScriptableObject visualizationSets;
		[SerializeField] private TileInteraction _tileInteraction;
		[SerializeField] private TileDataItem _tileDataItem;

		private List<TileDataItem> _tilesList = new();
		private HashSet<int> _usedIndices = new();

		private void Start()
		{
			SpawnTileItems();
			GetTaskText();
			ShowTilesSequentially();
		}

		private void SpawnTileItems()
		{
			_usedIndices.Clear();

			for (int i = 0; i < _tileCount; i++)
			{
				if (i >= 0 && i < visualizationSets.TileDatas.Length)
				{
					int randomDataIndex;
					do
					{
						randomDataIndex = UnityEngine.Random.Range(0, visualizationSets.TileDatas.Length);
					}
					while (_usedIndices.Contains(randomDataIndex));

					_usedIndices.Add(randomDataIndex);

					var itemData = visualizationSets.TileDatas[randomDataIndex];
					var tileDataItem = Instantiate(_tileDataItem, transform);

					if (!_tileInteraction.TileIdenfier.Contains(itemData.TileIdentifier))
					{
						tileDataItem.SetUpData(itemData);
						_tilesList.Add(tileDataItem);
					}
					else
					{
						var generate = UnityEngine.Random.Range(0, visualizationSets.TileDatas.Length);
						itemData = visualizationSets.TileDatas[generate];
						tileDataItem.SetUpData(itemData);
						_tilesList.Add(tileDataItem);
					}
				}
			}
			_tileInteraction.GetTileButtons(_tilesList);
		}


		private void GetTaskText()
		{
			int randomIndex = UnityEngine.Random.Range(0, _tilesList.Count);
			string taskText = _tilesList[randomIndex].Identifier;
			taskGenerator.SetTaskText(taskText);
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