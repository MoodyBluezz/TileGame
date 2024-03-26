using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class TileAppearance : MonoBehaviour
{
    private float _fadeDuration = 1f;
	private float _sequenceFadeDuration = 0.3f;
	private TweenerCore<float, float, FloatOptions> _fadeTween;
	private Sequence _sequence;

	public void FadeIn(CanvasGroup canvasGroup)
    {
        Fade(canvasGroup, 0, _fadeDuration);
    }

    public void FadeOut(CanvasGroup canvasGroup) 
    {
		Fade(canvasGroup, 1, _fadeDuration);
	}

	public void FadeInSequentially(CanvasGroup[] canvasGroups)
	{
		_sequence?.Kill();
		_sequence = DOTween.Sequence();

		foreach (CanvasGroup canvasGroup in canvasGroups)
		{
			_sequence.Append(canvasGroup.DOFade(0, _sequenceFadeDuration));
		}
	}

	public void FadeOutSequentially(CanvasGroup[] canvasGroups)
	{
		_sequence?.Kill();
		_sequence = DOTween.Sequence();

		foreach (CanvasGroup canvasGroup in canvasGroups)
		{
			_sequence.Append(canvasGroup.DOFade(1, _sequenceFadeDuration))
				.OnComplete(() => BounceOnComplete(canvasGroups));
		}
	}

	public void EaseInBounce(RectTransform rectTransform)
	{
		float initialX = rectTransform.anchoredPosition.x;
		float targetX = initialX + 10f;

		rectTransform.DOAnchorPosX(targetX, 0.3f)
			.SetEase(Ease.InBounce)
			.OnComplete(() => rectTransform.DOAnchorPosX(initialX, 0.3f));
	}

	public void ScaleInBounce(CanvasGroup canvasGroup)
	{
		canvasGroup.transform.DOScale(Vector3.one * 1.2f, 0.3f)
			.SetEase(Ease.InBounce)
			.OnComplete(() => canvasGroup.transform.DOScale(Vector3.one, 0.3f));
	}

	private void BounceOnComplete(CanvasGroup[] canvasGroups)
	{
		foreach (CanvasGroup canvasGroup in canvasGroups)
		{
			ScaleInBounce(canvasGroup);
		}
	}

	private void Fade(CanvasGroup canvasGroup, float targetAlpha, float duration)
	{
		_fadeTween?.Kill();
		_fadeTween = canvasGroup.DOFade(targetAlpha, duration);
	}
}