using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string switchStatus;
    public string switchType;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer switchSpriteRenderer;
    private CanUseSwitches collisionCanUseSwitches;

    private void Start()
    {
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
                if(Input.GetKeyDown(KeyCode.Space) && collisionCanUseSwitches.status == 1)
                {
                    if (switchStatus == "OFF")
                    {
                        switchStatus = "ON";
                    }
                    else if (switchStatus == "ON")
                    {
                        switchStatus = "OFF";
                    }
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collisionCanUseSwitches = collision.GetComponent<CanUseSwitches>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionCanUseSwitches = collision.GetComponent<CanUseSwitches>();
        switch(switchType)
        {
            case "Automatic":
                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = "ON";
                }
                break;
            case "Manual":
                //Do Nothing, switch requires player input
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCanUseSwitches = collision.GetComponent<CanUseSwitches>();
        switch (switchType)
        {
            case "Automatic":
                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = "OFF";
                }
                break;
            case "Manual":
                //Do Nothing, switch requires player input
                break;
        }
    }
}
