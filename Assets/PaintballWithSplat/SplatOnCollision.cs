using UnityEngine;
using System.Collections;


public class SplatOnCollision : MonoBehaviour {

    public GameObject splatPrefab;

    void OnCollisionEnter(Collision collision)
    {
        var paintball = gameObject;
        Destroy(paintball);

        var otherObject = collision.gameObject;
        var hit = collision.contacts[0];
        var otherCollider = hit.otherCollider;
    
        var splatPosition = otherCollider.ClosestPointOnBounds(hit.point);
        var splatRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        var splat = Instantiate(splatPrefab, splatPosition, splatRotation) as GameObject;
        

        // set parent so that the splat will move with the object that was hit
        splat.transform.SetParent(otherCollider.transform);

        // use custom impact sound if other object has one set
        var otherObjectImpactSound = otherObject.GetComponent<PaintballImpactSound>();
        if (otherObjectImpactSound && otherObjectImpactSound.clip)
        {
            splat.GetComponent<Splat>().impactSound = otherObjectImpactSound.clip;
        }
        
        Destroy(splat, 30);
    }
}
