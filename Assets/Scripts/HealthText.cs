using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, 75, 0);
    public float timeToFade = 1f;
    private float _timeElapsed = 0f;
    private Color startColor;

    RectTransform textTransform;
    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
    }
    private void Update()
    {
        textTransform.position += moveSpeed * Time.deltaTime;

        _timeElapsed += Time.deltaTime;

        if(_timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a * (1 - (_timeElapsed / timeToFade));
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
