using UnityEngine;
using System.Collections;

public class PaintballFirer : MonoBehaviour {
    public Transform firePosition;
    public AudioClip clip;
    public GameObject smokePrefab;

    private AudioSource audioSource;
    
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    public void FirePaintball(Rigidbody paintballPrefab)
    {
        Rigidbody paintball;
        paintball = Instantiate(paintballPrefab, firePosition.position, firePosition.rotation) as Rigidbody;
        paintball.AddForce(firePosition.forward * 2000);
        audioSource.PlayOneShot(clip);

        var smoke = Instantiate(smokePrefab, firePosition.position, firePosition.rotation) as GameObject;
        Destroy(smoke, 4);
    }
}
