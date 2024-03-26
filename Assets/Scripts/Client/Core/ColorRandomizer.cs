using UnityEngine;
using UnityEngine.UI;

namespace Clinet
{
	[RequireComponent(typeof(Image))]
	public class ColorRandomizer : MonoBehaviour
	{
		private Image _image;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		private void Start()
		{
			Randomize();
		}

		private void Randomize()
		{
			_image.color = Random.ColorHSV();
		}
	}
}