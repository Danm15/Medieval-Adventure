using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WidgetDamageValue : MonoBehaviour
{
    [SerializeField] private Text _textValue;
    private void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    private void FixedUpdate()
    {
        Animation();
    }
    public void SetValue(string newValue)
    {
        _textValue.text = newValue;
    }

    public void SetColor(Color color)
    {
        _textValue.color = color;
    }

    private void Handle_AnimationOver()
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyDelay()
    {
        yield return new WaitForSecondsRealtime(0.4f);
        Handle_AnimationOver();
    }
    private void Animation()
    {
        transform.Translate(Vector3.up * Time.fixedDeltaTime * 2);
    }
}
