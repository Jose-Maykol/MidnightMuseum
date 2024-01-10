using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalFlock : MonoBehaviour
{
    public GameObject FlyPrefab;
    public static int tankSize = 10;
    static int numFly = 100;
    public static GameObject[] allFly = new GameObject[numFly];

    public static Vector3 goalPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numFly; i++){
            Vector3 pos = new Vector3(Random.Range(-tankSize,tankSize),
                                    Random.Range(-tankSize,tankSize),
                                    Random.Range(-tankSize,tankSize));  
            allFly[i] = (GameObject) Instantiate(FlyPrefab,pos,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize,tankSize),
                                    Random.Range(-tankSize,tankSize),
                                    Random.Range(-tankSize,tankSize));
        }
        
    }
}
