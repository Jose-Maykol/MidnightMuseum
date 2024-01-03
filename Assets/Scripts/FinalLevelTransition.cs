using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelTransition : MonoBehaviour
{
    
    public LevelLoader levelLoader;
    [Header("Tag")]
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag = " + tag);
        if (other.CompareTag(tag))
        {
            levelLoader.LoadLevelByIndex(4);
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Tag = " + tag);
        if (other.gameObject.CompareTag(tag))
        {
            levelLoader.LoadLevelByIndex(4);
        }
    }
}
