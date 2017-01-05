using UnityEngine;
using System.Collections;


public class SplatOnCollision : MonoBehaviour {

    public GameObject[] splatTypes;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        
        Instantiate(
            splatTypes[Random.Range(0, splatTypes.Length - 1)],
            collision.contacts[0].point,
            Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal)
        );
    }
}
