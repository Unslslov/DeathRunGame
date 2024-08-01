using System.Collections.Generic;
using UnityEngine;

public class JumperIntermediary : MonoBehaviour
{
    [SerializeField] private Transform _jumpers;
    [SerializeField] private List<JumperTrigger> _jumperTriggers;
    [SerializeField] private Rigidbody _rbPlayer;

    private void OnValidate() 
    {
        if(_jumpers == null)
            _jumpers ??= transform;

    }

    private void Start() 
    {
        if(_jumperTriggers.Count == 0)
        {
            for(int i=0; i < _jumpers.childCount; i++)
            {
                _jumperTriggers.Add(_jumpers.GetChild(i).GetComponent<JumperTrigger>());
                
                if(_rbPlayer == null)
                    throw new System.Exception("Player's rigidbody is not set in JumperIntermediary");

                _jumperTriggers[i].SetRigidBodyForJumper(ref _rbPlayer);
            }
        }  
    }
    
    private void OnDestroy() 
    {
        for(int i=0; i < _jumpers.childCount; i++)
        {
            _jumperTriggers.Remove(_jumpers.GetChild(i).GetComponent<JumperTrigger>());
        }
    }
}
