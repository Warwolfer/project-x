using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public SpriteRenderer[] roomObjects;
    // Start is called before the first frame update
    void Start()
    {
        roomObjects = GetComponentsInChildren<SpriteRenderer>();
        Hide();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Hide()
    {
        Color color2 = roomObjects[0].color;
        foreach (SpriteRenderer roomObject in roomObjects)
        {
            color2.a = 0;
            roomObject.color = color2;
        }
    }

    public void Show()
    {
        Color color2 = roomObjects[0].color;
        foreach (SpriteRenderer roomObject in roomObjects)
        {
            color2.a = 1;
            roomObject.color = color2;
        }
    }

    public IEnumerator Fade()
    {
        Color color = roomObjects[0].color;
        while (color.a > -0)
        {
            foreach(SpriteRenderer roomObject in roomObjects)
            {
                color.a -= 2.8f * Time.deltaTime;
                roomObject.color = color;
                yield return null;
            }
        }

        Color color2 = roomObjects[0].color;
        foreach (SpriteRenderer roomObject in roomObjects)
        {
            color2.a = 0;
            roomObject.color = color2;
        }
    }

    public IEnumerator FadeIn()
    {
        Color color = roomObjects[roomObjects.Length-1].color;
        while (color.a < 1)
        {
            foreach (SpriteRenderer roomObject in roomObjects)
            {
                color.a += 2.8f * Time.deltaTime;
                roomObject.color = color;
                yield return null;
            }
        }

        Color color2 = roomObjects[0].color;
        foreach (SpriteRenderer roomObject in roomObjects)
        {
            color2.a = 1;
            roomObject.color = color2;
        }
    }


}
