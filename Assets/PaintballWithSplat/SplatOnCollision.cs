using UnityEngine;
using System.Collections;


public class SplatOnCollision : MonoBehaviour {

    public GameObject splatPrefab;

    void OnCollisionEnter(Collision collision)
    {
        var paintball = gameObject;
        var hit = collision.contacts[0];
        var otherObject = hit.otherCollider;

        var splatPosition = otherObject.ClosestPointOnBounds(hit.point);
        var splatRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        var splat = Instantiate(splatPrefab, splatPosition, splatRotation) as GameObject;

        // set parent so that the splat will move with the object that was hit
        splat.transform.SetParent(otherObject.transform);
        
        Destroy(paintball);
        Destroy(splat, 30);
    }
}
