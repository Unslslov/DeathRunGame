using UnityEngine;

public class UVMoving : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.3f;
    [SerializeField] private Renderer _rend;
    private float _offsetX;
    private float _offsetY;

    private void OnValidate() 
    {
        _rend ??= GetComponent<Renderer>();
    }

    private void Update() 
    {
        _offsetX += Time.deltaTime * _moveSpeed;
        _offsetY += Time.deltaTime * _moveSpeed;

        _rend.material.SetTextureOffset("_MainTex", new Vector2(_offsetX, _offsetY));

        if(_offsetX >= 500 || _offsetY  >= 500)
        {
            _offsetX = 0;
            _offsetY = 0;
        }    
    }
}
