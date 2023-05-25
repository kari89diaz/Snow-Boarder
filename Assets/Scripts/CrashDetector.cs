using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadSceneTimer = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = true;
            Invoke("ReloadScene", reloadSceneTimer);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
