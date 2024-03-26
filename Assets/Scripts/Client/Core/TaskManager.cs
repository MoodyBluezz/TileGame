using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskTMP;
	[SerializeField] private TileAppearance _tileAppearance;
	[SerializeField] private CanvasGroup _taskTMPCanvasGroup;

	private void Start()
	{
		_tileAppearance.FadeOut(_taskTMPCanvasGroup);
	}

	public void SetTaskText(string text)
	{
		_taskTMP.text = $"Find: {text}";
	}

	public string GetTaskText()
	{
		return char.ToUpper(_taskTMP.text[_taskTMP.text.Length - 1]).ToString();
	}
}