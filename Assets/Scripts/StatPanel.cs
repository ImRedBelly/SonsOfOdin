using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    [SerializeField] private CharacterConfig characterConfig;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform arrow;
    [SerializeField] private TMP_Text testStat;
    [SerializeField] private float statValue;

    private void OnValidate()
    {
        if (slider != null) slider.value = statValue * 0.01f;
        if (arrow != null) arrow.transform.rotation = statValue > 50 ? Quaternion.Euler(0, 0, 180) : Quaternion.Euler(0, 0, 0);
        if (testStat != null) testStat.SetText(statValue + "%");

        if (characterConfig)
            {
            }
    }
}