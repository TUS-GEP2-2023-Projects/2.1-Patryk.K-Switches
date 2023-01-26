using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public Switch connectedSwitch;

    public Sprite offSprite;
    public Sprite onSprite;
    private SpriteRenderer lightSpriteRenderer;

    private void Start()
    {
        lightSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        switch (connectedSwitch.switchStatus)
        {
            case SwitchStatus.OFF:
                lightSpriteRenderer.sprite = offSprite;
                break;
            case SwitchStatus.ON:
                lightSpriteRenderer.sprite = onSprite;
                break;
        }
    }
}
