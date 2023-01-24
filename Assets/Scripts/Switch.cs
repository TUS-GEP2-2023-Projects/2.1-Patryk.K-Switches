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
    private CanUseSwitches canUseSwitches;

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
                if (Input.GetKeyDown(KeyCode.Space) && canUseSwitches.status == 1 && switchStatus == "OFF")
                {
                    switchStatus = "ON";
                }
                else if (Input.GetKeyDown(KeyCode.Space) && canUseSwitches.status == 1 && switchStatus == "ON")
                {
                    switchStatus = "OFF";
                }
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canUseSwitches = collision.GetComponent<CanUseSwitches>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUseSwitches = collision.GetComponent<CanUseSwitches>();

        if (switchType == "Automatic" && canUseSwitches.status == 1)
        {
            switchStatus = "ON";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canUseSwitches = collision.GetComponent<CanUseSwitches>();

        if (switchType == "Automatic" && canUseSwitches.status == 1)
        {
            switchStatus = "OFF";
        }
    }
}
