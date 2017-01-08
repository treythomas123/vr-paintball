using UnityEngine;
using System.Collections;

public class Splat : MonoBehaviour
{
    public AudioClip impactSound;
    public Texture2D[] textures;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(impactSound);

        var renderer = GetComponentInChildren<Renderer>();
        
        // choose a random texture from the list of available splat textures
        renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];

        // set a shader that supports transparency
        renderer.material.shader = Shader.Find("Transparent/Diffuse");

        // randomly rotate the splat to vary splat appearances
        transform.Rotate(0, Random.Range(0f, 360f), 0);        
    }
}
