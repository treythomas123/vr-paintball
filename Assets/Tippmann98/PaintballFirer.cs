using UnityEngine;
using System.Collections;

public class PaintballFirer : MonoBehaviour {
    public Transform firePosition;
    public AudioSource audioSource;
    public AudioClip clip;


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
    }
}
