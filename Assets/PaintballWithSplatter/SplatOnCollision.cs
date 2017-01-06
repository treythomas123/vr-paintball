using UnityEngine;
using System.Collections;


public class SplatOnCollision : MonoBehaviour {

    public GameObject[] splatTypes;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        
        var splat = Instantiate(
            splatTypes[Random.Range(0, splatTypes.Length)],
            collision.contacts[0].point,
            Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal)
        ) as GameObject;
        splat.transform.Rotate(0, Random.Range(0f, 360f), 0);
    }
}
