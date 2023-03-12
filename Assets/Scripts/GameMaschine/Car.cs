using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public int SpriteNumber
    {
        set
        {
            spriteRenderer.sprite = sprites[value];
            StartCoroutine(Lifetime());
        }
    }


    private void Update()
    {
        transform.Translate(Vector2.left * 5 * Time.deltaTime);
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
