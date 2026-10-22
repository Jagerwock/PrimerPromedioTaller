using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health target;
    [SerializeField] private Slider slider;
    [SerializeField] private Text value;
    [SerializeField] private GameObject content;
    [SerializeField] private bool hideWhenEmpty;
    [SerializeField] private bool faceCamera;

    private bool hadTarget;
    private Camera view;

    private void OnEnable()
    {
        Bind(target);
    }

    private void OnDisable()
    {
        if (target != null) target.OnHealthChanged -= UpdateValue;
    }

    private void LateUpdate()
    {
        if (hadTarget && target == null) Hide();
        if (!faceCamera) return;
        if (view == null) view = Camera.main;
        if (view != null) transform.rotation = view.transform.rotation;
    }

    public void Bind(Health health)
    {
        if (target != null) target.OnHealthChanged -= UpdateValue;
        target = health;
        hadTarget = target != null;

        if (target == null)
        {
            content.SetActive(false);
            return;
        }

        if (isActiveAndEnabled) target.OnHealthChanged += UpdateValue;
        UpdateValue(target.CurrentHealth, target.MaxHealth);
    }

    public void UpdateValue(float current, float max)
    {
        slider.maxValue = max;
        slider.value = current;
        content.SetActive(max > 0f && (!hideWhenEmpty || slider.value > 0f));

        if (value != null)
            value.text = $"{Mathf.CeilToInt(slider.value)} / {Mathf.CeilToInt(max)}";
    }

    public void Hide()
    {
        Bind(null);
    }
}
