using UnityEngine;
using System.Collections;


public class SplatOnCollision : MonoBehaviour {

    public GameObject[] splatTypes;

    void OnCollisionEnter(Collision collision)
    {
        var paintball = gameObject;
        var hit = collision.contacts[0];
        var otherObject = hit.otherCollider;

        var splatType = splatTypes[Random.Range(0, splatTypes.Length)];
        var splatPosition = otherObject.ClosestPointOnBounds(hit.point);
        var splatRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        var splat = Instantiate(splatType, splatPosition, splatRotation) as GameObject;

        // randomly rotate the splat to vary its appearance
        splat.transform.Rotate(0, Random.Range(0f, 360f), 0);

        Destroy(paintball);
        Destroy(splat, 30);
    }
}
