using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public GameObject lightSwitch;
    public Switch connectedSwitch;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer lightSpriteRenderer;

    private void Start()
    {
        connectedSwitch = lightSwitch.GetComponent<Switch>();
        lightSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        switch (connectedSwitch.switchStatus)
        {
            case "OFF":
                lightSpriteRenderer.sprite = offSprite;
                break;
            case "ON":
                lightSpriteRenderer.sprite = onSprite;
                break;
        }
    }
}
