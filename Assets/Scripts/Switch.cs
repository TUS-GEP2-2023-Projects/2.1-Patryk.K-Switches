using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //connect switch to a lightbulb
    public GameObject lightBulb;
    public string switchStatus;

    public Sprite offSprite;
    public Sprite onSprite;

    private SpriteRenderer switchSpriteRenderer;

    private void Start()
    {
        switchStatus = "OFF";
        switchSpriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (switchStatus)
        {
            case "OFF":
                switchSpriteRenderer.sprite = offSprite;
                break;
            case "ON":
                switchSpriteRenderer.sprite = onSprite;
                break;
        }
    }
}
