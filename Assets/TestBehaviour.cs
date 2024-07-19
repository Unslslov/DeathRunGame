using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    public Transform ObjectToMove;
    public MeshRenderer ObjectToMoveMeshRenderer;
    public Transform StartPosition;
    public MeshRenderer StartPositionMeshRenderer;
    public Transform EndPosition;
    public MeshRenderer EndPositionMeshRenderer;

    private Color startColor;
    private Color endColor;
    [SerializeField] private Color objectColor; 

    [Range(0, 1)]
    public float T;

    private void Start() 
    {
        startColor = StartPositionMeshRenderer.material.GetColor("_EmissionColor");
        endColor = EndPositionMeshRenderer.material.GetColor("_EmissionColor");
    }

    private void Update() 
    {
        ObjectToMove.position = Vector3.Lerp(StartPosition.position, EndPosition.position, T);    
        objectColor = Color.Lerp(startColor, endColor, T);
        ObjectToMoveMeshRenderer.material.SetColor("_EmissionColor", objectColor);
    }
}
