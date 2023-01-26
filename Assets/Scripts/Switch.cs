using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwitchType
{
    Automatic = 0,
    Manual = 1
}

public enum SwitchStatus
{
    OFF = 0,
    ON = 1
}

public class Switch : MonoBehaviour
{
    public SwitchStatus switchStatus;
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
            // Automatic Switch Type Logic
            case SwitchType.Automatic:

                switch (switchStatus)
                {
                    case SwitchStatus.OFF:
                        switchSpriteRenderer.sprite = offSprite;
                        break;
                    case SwitchStatus.ON:
                        switchSpriteRenderer.sprite = onSprite;
                        break;
                }
            break;

            // Manual Switch Type Logic
            case SwitchType.Manual:

                switch (switchStatus)
                {
                    case SwitchStatus.OFF:
                        switchSpriteRenderer.sprite = offSprite;
                        break;
                    case SwitchStatus.ON:
                        switchSpriteRenderer.sprite = onSprite;
                        break;
                }
                if (Input.GetKeyDown(KeyCode.Space) && collisionCanUseSwitches != null)
                {
                    if(collisionCanUseSwitches.status == 1)
                    {
                        if (switchStatus == SwitchStatus.OFF)
                        {
                            switchStatus = SwitchStatus.ON;
                        }
                        else if (switchStatus == SwitchStatus.ON)
                        {
                            switchStatus = SwitchStatus.OFF;
                        }
                    }
                }
            break;

            //Next Switch Type would go below here
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
            // Automatic Switch Type Logic
            case SwitchType.Automatic:

                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = SwitchStatus.ON;
                }
            break;

            // Manual Switch Type Logic
            case SwitchType.Manual:
                //Do Nothing, switch requires player input so this functions is not needed
            break;

            //Next Switch Type would go below here
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCanUseSwitches = collision.GetComponent<CanUseSwitches>();

        switch (switchType)
        {
            // Automatic Switch Type Logic
            case SwitchType.Automatic:

                if (collisionCanUseSwitches.status == 1)
                {
                    switchStatus = SwitchStatus.OFF;
                }
            break;

            // Manual Switch Type Logic
            case SwitchType.Manual:

                if (collisionCanUseSwitches.status == 1)
                {
                    collisionCanUseSwitches = null;
                }
            break;

            //Next Switch Type would go below here
        }
    }
}
