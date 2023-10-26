using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    public bool isFlickering;
    public float timeDelay;

    void Start()
    {
        isFlickering = false;
    }

    void Update()
    {
        if (isFlickering == false) {
            StartCoroutine(Flicker());
        }
    }

    IEnumerator Flicker() {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.2f, 0.8f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.1f, 0.25f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}
