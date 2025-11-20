using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBinder : MonoBehaviour
{
    private void Start()
    {
        Slider slider = GetComponent<Slider>();

        if (slider != null && SoundManager.Instance != null)
        {
            SoundManager.Instance.RegisterSlider(slider);
        }
    }
}
