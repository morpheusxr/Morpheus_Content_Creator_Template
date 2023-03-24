using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLandingZone : BaseLandingZone
{
    [SerializeField]
    [Range(0, 10)]
    float radius = 1.5f;

    public override void GetPoint(out Vector3 pos, out Quaternion rot)
    {
        rot = transform.rotation;
        var r = radius * Mathf.Sqrt(Random.Range(.0f, 1f));
        var theta = Random.Range(.0f, 1f) * 2 * Mathf.PI;

        pos = new Vector3(transform.position.x + r * Mathf.Cos(theta), transform.position.y, transform.position.z + r * Mathf.Sin(theta));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
