using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Client
{
	public class Restart : MonoBehaviour
	{
		[SerializeField] private Button _restartButton;

		private void OnEnable()
		{
			_restartButton.onClick.AddListener(RestartScene);
		}

		private void OnDisable()
		{
			_restartButton.onClick.RemoveListener(RestartScene);
		}

		private void RestartScene()
		{
			var sceneID = SceneManager.GetActiveScene();
			SceneManager.UnloadSceneAsync(sceneID);
			SceneManager.LoadSceneAsync(sceneID.buildIndex);
		}
	}
}