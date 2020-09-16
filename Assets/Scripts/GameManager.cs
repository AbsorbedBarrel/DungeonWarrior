using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f) 
        { 
        //Add more enemies
            if (Random.Range(0, 250) == 5)
            {
                Instantiate(enemy, new Vector3(Random.Range(-3f, 3f), Random.Range(-3, 3f), 0f), new Quaternion(0, 0, 0, 0));
            }
        
        }
    }
}
