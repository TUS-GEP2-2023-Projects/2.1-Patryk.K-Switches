using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public GameObject lightSwitch;
    public Switch S;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer lightSpriteRenderer;

    private void Start()
    {
        S = lightSwitch.GetComponent<Switch>();
        lightSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        switch (S.switchStatus)
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
