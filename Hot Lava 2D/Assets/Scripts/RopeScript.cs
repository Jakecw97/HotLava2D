using UnityEngine;
using System.Collections;

public class RopeScript : MonoBehaviour
{

    public GameObject ropeShootPoint;
    private DistanceJoint2D rope;
    private int ropeFramCount;

    public LineRenderer lineRenderer;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShootPoint.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);
        {
            DistanceJoint2D newRope = ropeShootPoint.AddComponent<DistanceJoint2D>();
            newRope.enableCollision = false;
           
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
        }
    }
}