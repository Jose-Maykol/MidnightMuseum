using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelLoadder : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelLoader levelLoader;
    [Header("Tag")]
    public string tag;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag = " + tag);
        if (other.CompareTag(tag))
        {
            levelLoader.QuitGame();
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Tag = " + tag);
        if (other.gameObject.CompareTag(tag))
        {
            levelLoader.QuitGame();
        }
    }
}
