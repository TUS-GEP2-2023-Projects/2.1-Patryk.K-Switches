using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject lightBulb;
    public string switchStatus;
    public string switchType;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer switchSpriteRenderer;

    private void Start()
    {
        switchStatus = "OFF";
        switchSpriteRenderer = this.GetComponent<SpriteRenderer>();

        if(switchType == "")
        {
            switchType = "Automatic";
        }
    }

    private void Update()
    {
        switch (switchType)
        {
            case "Automatic":

                switch (switchStatus)
                {
                    case "OFF":
                        switchSpriteRenderer.sprite = offSprite;
                        break;
                    case "ON":
                        switchSpriteRenderer.sprite = onSprite;
                        break;
                }

                break;
            case "Manual":

                switch (switchStatus)
                {
                    case "OFF":
                        switchSpriteRenderer.sprite = offSprite;
                        break;
                    case "ON":
                        switchSpriteRenderer.sprite = onSprite;
                        break;
                }

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (switchType == "Automatic")
        {
            switchStatus = "ON";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (switchType == "Automatic")
        {
            switchStatus = "OFF";
        }
    }
}
