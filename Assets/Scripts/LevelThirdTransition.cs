using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThirdTransition : MonoBehaviour
{
    public LevelLoader levelLoader;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag" + other.tag);
        if (other.CompareTag("key"))
        {
            Debug.Log("Level 3");
            levelLoader.LoadLevelByIndex(2);
        }
    }
}
