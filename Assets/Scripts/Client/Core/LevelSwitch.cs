using System.Collections.Generic;
using UnityEngine;

namespace Client 
{ 
	public class LevelSwitch : MonoBehaviour
	{
		[SerializeField] private TileInteraction _tileInteraction;
		[SerializeField] private List<SpawnTiles> _spawnTilesList;
		[SerializeField] private GameObject _restartPanel;

		private int _currentLevelIndex = 0;

		private void OnEnable()
		{
			_tileInteraction.TaskFinished += OnTaskFinished;
		}

		private void OnDisable()
		{
			_tileInteraction.TaskFinished -= OnTaskFinished;
		}

		private void OnTaskFinished()
		{
			if (_currentLevelIndex < _spawnTilesList.Count - 1)
			{
				SwitchToNextLevel();
			}
			else
			{
				ShowRestartPanel();
			}
		}

		private void SwitchToNextLevel()
		{
			_spawnTilesList[_currentLevelIndex].gameObject.SetActive(false);
			_currentLevelIndex++;
			_spawnTilesList[_currentLevelIndex].gameObject.SetActive(true);
		}

		private void ShowRestartPanel()
		{
			_restartPanel.SetActive(true);
		}
	}
}