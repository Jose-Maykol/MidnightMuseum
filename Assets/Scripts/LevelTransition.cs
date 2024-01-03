using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public LevelLoader levelLoader;
    [Header("Tag")]
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag = " + tag);
        if (other.CompareTag(tag))
        {
            levelLoader.LoadNextLevel();
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Tag = " + tag);
        if (other.gameObject.CompareTag(tag))
        {
            levelLoader.LoadNextLevel();
        }
    }
}
