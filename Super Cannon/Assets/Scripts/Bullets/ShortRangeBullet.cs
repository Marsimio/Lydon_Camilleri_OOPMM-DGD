using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangeBullet : Bullet
{
    [SerializeField] float fadeDuration = 1.0f;
    private Color startColor;
    private SpriteRenderer spriteRenderer;

    protected override void OnEnable()
    {
        base.OnEnable();

        spriteRenderer = GetComponent <SpriteRenderer>();
        startColor = spriteRenderer.color;

        StartCoroutine(FadeOutBullet());
    }

    private IEnumerator FadeOutBullet()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            Color newColor = new Color(startColor.r, startColor.g, startColor.b, alpha);

            spriteRenderer.color = newColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = startColor;
        gameObject.SetActive(false);
    }
}