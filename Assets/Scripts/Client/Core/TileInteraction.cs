using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
	public class TileInteraction : MonoBehaviour
	{
		public event Action TaskFinished;

		[SerializeField] private TaskManager _taskManager;
		[SerializeField] private TileAppearance _tileAppearance;

		public List<string> TileIdenfier { get; private set; } = new();

		public void GetTileButtons(List<TileDataItem> itemData)
		{
			if (itemData.Count == 0) return;

			foreach (var tile in itemData)
			{
				var currentTile = tile;
				currentTile.TileButton.onClick.RemoveAllListeners();
				currentTile.TileButton.onClick.AddListener(() => CheckAnswer(currentTile));
			}
		}

		private void CheckAnswer(TileDataItem tile)
		{
			if (_taskManager.GetTaskText().Equals(tile.Identifier))
			{
				TileIdenfier.Add(tile.Identifier);
				_tileAppearance.ScaleInBounce(tile.TileCanvasGroup);
				EnableParticle(tile.ParticleSystem, () => TaskFinished?.Invoke());
			}
			else
			{
				_tileAppearance.EaseInBounce(tile.TileRectTransform);
			}
		}

		private void EnableParticle(ParticleSystem particleSystem, Action onParticleFinished)
		{
			particleSystem.gameObject.SetActive(true);
			particleSystem.Play();

			StartCoroutine(WaitForParticleFinish(particleSystem, onParticleFinished));
		}

		private IEnumerator WaitForParticleFinish(ParticleSystem particleSystem, Action onParticleFinished)
		{
			while (particleSystem.isEmitting)
			{
				yield return null;
			}

			onParticleFinished?.Invoke();
		}
	}
}