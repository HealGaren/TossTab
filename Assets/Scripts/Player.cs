using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{

    public Sprite standing, left, right;
    public GameObject boomPrefab;

    private SpriteRenderer spriteRenderer;

    private IEnumerator coroutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standing;
    }


    void Update()
    {
        InputMovement();
    }

    void InputMovement()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 pos = Input.GetTouch(i).position;    // 터치한 위치
            if (Input.GetTouch(0).phase == TouchPhase.Began)    // 딱 처음 터치 할때 발생한다
            {
                if(pos.x < 0) attack(AttackType.LEFT);
                else attack(AttackType.RIGHT);
            }

            //else if (Input.GetTouch(0).phase == TouchPhase.Moved)    // 터치하고 움직이믄 발생한다.
            //else if (Input.GetTouch(0).phase == TouchPhase.Ended)    // 터치 따악 떼면 발생한다.

        }

        //if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Mouse0)) attack(AttackType.LEFT);
        //else if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Mouse1)) attack(AttackType.RIGHT);


    }

    enum AttackType
    {
        LEFT, RIGHT
    };
    void attack(AttackType type)
    {
        switch (type)
        {
            case AttackType.LEFT:
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = ChangeSpriteSecond(left);
                StartCoroutine(coroutine);
                Instantiate(boomPrefab, transform.position + new Vector3(-0.6f, -1.5f, 1), Quaternion.identity);
                AudioManager.instance.PlaySnare();
                break;
            case AttackType.RIGHT:
                if (coroutine != null) StopCoroutine(coroutine);
                coroutine = ChangeSpriteSecond(right);
                StartCoroutine(coroutine);
                Instantiate(boomPrefab, transform.position + new Vector3(0.7f, -1.5f, 1), Quaternion.identity);
                AudioManager.instance.PlayKick();
                break;
        }
    }

    IEnumerator ChangeSpriteSecond(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = standing;
    }
}