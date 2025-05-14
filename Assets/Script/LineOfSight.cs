using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField] float _range;
    [SerializeField] float _height;
    [SerializeField] LayerMask _mask;

    public GameObject Detection(GameObject target)
    {
        RaycastHit raycast;
        Vector3 direction = target.transform.position - transform.position;
        Physics.Raycast(transform.position + Vector3.up * _height, direction, out raycast, _range, _mask);
        if (raycast.collider != null && raycast.collider.gameObject == target)
        {
            return target;
        }
        else
        {
            return null;
        }
    }
}
