using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square3 : MonoBehaviour
{
    private SpriteRenderer renderer;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
        renderer.color = new Color(255, 255, 255);
        audio.pitch = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            renderer.color = new Color(Random.value, Random.value , Random.value ,1);
            audio.pitch = renderer.color.r + renderer.color.g + renderer.color.b;
            audio.Play();
           
        }   
    }
}
