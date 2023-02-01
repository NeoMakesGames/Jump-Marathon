using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        var main = particleSystem.main;
        main.startColor = new Color(Random.value, Random.value, Random.value);
    }
}
