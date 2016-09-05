using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextEventTrigger : MonoBehaviour, IPointerEnterHandler {

    public Text childText;

    private int scalingState = 0;

    public float targetScale = 1.1f;
    public float targetDeltaX = 10;
    private float currentDeltaX = 0;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (scalingState)
        {
            case -1:
                {
                    Vector3 scale = transform.localScale;
                    scale.x += (targetScale - scale.x) * 0.01f * Time.deltaTime;
                    scale.y += (targetScale - scale.y) * 0.01f * Time.deltaTime;
                    transform.localScale = scale;

                    Vector3 pos = transform.position;
                    float moveX = (targetDeltaX - currentDeltaX) * 0.01f * Time.deltaTime;
                    pos.x += moveX;
                    currentDeltaX += moveX;
                    transform.position = pos;
                }
                break;
            case 1:
                {
                    Vector3 scale = transform.localScale;
                    scale.x += (1 - scale.x) * 0.01f * Time.deltaTime;
                    scale.y += (1 - scale.y) * 0.01f * Time.deltaTime;
                    transform.localScale = scale;

                    Vector3 pos = transform.position;
                    float moveX = (-targetDeltaX - currentDeltaX) * 0.01f * Time.deltaTime;
                    pos.x += moveX;
                    currentDeltaX += moveX;
                    transform.position = pos;
                }
                break;

        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        print("gd");
        scalingState = 1;
    }
}
