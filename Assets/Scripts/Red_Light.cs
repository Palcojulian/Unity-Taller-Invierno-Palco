
using UnityEngine;
using System.Collections;

public class Red_Light : MonoBehaviour
{
    [Header("Configuración de luz")]
    [SerializeField] private Light policeLight;

    [Header("Intensidad")]
    [SerializeField] private float intensity = 1000f;
    [SerializeField] private float transitionSpeed = 15f;

    [Header("Parpadeo")]
    [SerializeField] private float onDuration = 0.25f;
    [SerializeField] private float offDuration = 0.15f;

    private void Start()
    {
        if (policeLight == null)
            policeLight = GetComponentInChildren<Light>();

        if (policeLight != null)
        {
            policeLight.color = Color.red;
            StartCoroutine(BlinkLight());
        }
    }

    private IEnumerator BlinkLight()
    {
        while (true)
        {
            policeLight.enabled = true;
            policeLight.intensity = intensity;

            yield return new WaitForSeconds(onDuration);

            policeLight.intensity = 0f;

            yield return new WaitForSeconds(offDuration);
        }
    }
}
