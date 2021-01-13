using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonEmitter : MonoBehaviour
{
    public GameObject hexagon;
    private float NextSpawnTime = 1.5f;
    public float spawnDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.getIsStarted())
            return;

        if (Time.timeSinceLevelLoad == 30f)
            NextSpawnTime -= 0.3f;
        if (Time.timeSinceLevelLoad == 50f)
            NextSpawnTime -= 0.2f;
        if (Time.timeSinceLevelLoad == 75f)
            NextSpawnTime -= 0.3f;

        if (Time.time > NextSpawnTime)
        {
            Instantiate(hexagon, Vector3.zero, Quaternion.identity);
            NextSpawnTime = Time.time + spawnDeltaTime;
        }
    }
}
