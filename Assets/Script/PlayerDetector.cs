using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectionRadius;
    [SerializeField] private LayerMask _detectionMask;
    [SerializeField] private GameObject _detectedTarget;

    public GameObject DetectedTarget 
    { 
        get => _detectedTarget;
        set
        {
            if (value&&value.tag != "Player")
            {
                value = null;
            }
            _detectedTarget = value;
        }
    }

    public GameObject UpdateDetector()
    {
        List<Collider> colliders = Physics.OverlapSphere(transform.position, _detectionRadius,_detectionMask).Where(collider => collider.gameObject.CompareTag("Player") == true).ToList();
        if (colliders.Count > 0)
        {
            DetectedTarget = colliders[0].gameObject;
        }
        else
        {
            DetectedTarget = null;
        }
        return DetectedTarget;
    }


}
