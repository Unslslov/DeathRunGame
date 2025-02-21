using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextFadeAndMove : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _duration = 1f; 
    [SerializeField] private float _offsetY = 1f;

    private Vector3 startPos;
    private bool isMoving;

    private void OnValidate() 
    {
        _textMeshPro ??=  GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() 
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        startPos = _textMeshPro.transform.position;

        isMoving = true;

        Color color = _textMeshPro.color;
        color.a = 1;
        _textMeshPro.color = color;

       Sequence sequence = DOTween.Sequence();

        sequence.Append(_textMeshPro.transform.DOMoveY(_textMeshPro.transform.position.y + _offsetY, _duration));

        sequence.Join(_textMeshPro.DOFade(0, _duration).SetEase(Ease.InOutQuad));

        sequence.OnComplete(() => {
            Debug.Log("Анимация завершена");
            isMoving = false;
            _textMeshPro.transform.position = startPos;
            gameObject.SetActive(false);
        });

        sequence.Play();
    }
}
