using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwitchType
{
    Automatic = 0,
    Manual = 1
}

public class Switch : MonoBehaviour
{
    public string switchStatus;
    public SwitchType switchType;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer switchSpriteRenderer;
    private CanUseSwitches collisionCanUseSwitches;

    private void Start()
    {
        switchSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        switch (switchType)
        {
            case SwitchType.Automatic:
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

            case SwitchType.Manual:

                switch (switchStatus)
                {
                    case "OFF":
                        switchSpriteRenderer.sprite = offSprite;
                        break;
                    case "ON":
                        switchSpriteRenderer.sprite = onSprite;
                        break;
                }

                if (Input.GetKeyDown(KeyCode.Space) && collisionCanUseSwitches != null)
                {
                    if(collisionCanUseSwitches.status == 1)
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
            case SwitchType.Automatic:
                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = "ON";
                }
            break;

            case SwitchType.Manual:
                //Do Nothing, switch requires player input
            break;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCanUseSwitches = collision.GetComponent<CanUseSwitches>();
        switch (switchType)
        {
            case SwitchType.Automatic:
                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = "OFF";
                }
            break;

            case SwitchType.Manual:
                if (collisionCanUseSwitches.status == 1)
                {
                    collisionCanUseSwitches = null;
                }
            break;
        }
    }
}
