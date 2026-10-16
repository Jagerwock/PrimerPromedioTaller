using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health target;
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        if (target != null) target.OnHealthChanged += Refresh;
    }

    private void OnDisable()
    {
        if (target != null) target.OnHealthChanged -= Refresh;
    }

    private void Refresh(float current, float max)
    {
        slider.value = current / max;
    }
}
