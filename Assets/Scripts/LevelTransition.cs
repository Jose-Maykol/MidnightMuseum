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
        if (other.CompareTag(tag))
        {
            levelLoader.LoadNextLevel();
        }
    }
}
