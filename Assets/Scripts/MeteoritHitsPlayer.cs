using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritHitsPlayer : MonoBehaviour
{
    private AudioSource meteoritAudioSource;
    [SerializeField] private AudioClip hitFloorAudioClip;
    [SerializeField] private AudioClip hitPlayerAudioClip;
    [SerializeField] private ParticleSystem hitFloorParticleSystem;
    [SerializeField] private ParticleSystem hitPlayerParticleSystem;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        meteoritAudioSource = this.gameObject.GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play hit player audio clip
            meteoritAudioSource.PlayOneShot(hitPlayerAudioClip, 1.0f);
            hitPlayerParticleSystem.Play();
            player.GetComponent<PlayerHealth>().TakeDamage(30f);
        }
        else
        {
            // Meteorit hits other
            // Play hits other audio clip
            meteoritAudioSource.PlayOneShot(hitFloorAudioClip, 1.0f);
            hitFloorParticleSystem.Play();
        }
        Destroy(gameObject, 1f);
    }
}
