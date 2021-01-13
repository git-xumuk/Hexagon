using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject center;

    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!GameManager.instance.getIsStarted())
            return;
    }
    void FixedUpdate()
    {
        // moving
        float speed = 600f;
        float movement = Input.GetAxis("Horizontal");

        // rotation
        transform.RotateAround(center.transform.position, -Vector3.forward, movement * Time.fixedDeltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        isDead = true;

        GameObject[] hexagons = GameObject.FindGameObjectsWithTag("hexagon");
        foreach (GameObject hexagon in hexagons)
        {
            Destroy(hexagon);
        }
    }
}
