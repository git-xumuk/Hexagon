using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonMoving : MonoBehaviour
{
    public Rigidbody2D hexagon;
    public float scaleSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        hexagon.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 13f;
    }   


    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad == 20f)
            scaleSpeed += 1f;
        if (Time.timeSinceLevelLoad == 40f)
            scaleSpeed += 1f;
        
        transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;

        if (transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
            GameManager.instance.increaseScore(10); 
        }
    }
}
