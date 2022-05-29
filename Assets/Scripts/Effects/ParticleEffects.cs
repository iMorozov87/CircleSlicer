using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleTemplate;
    [SerializeField] private Color _color = Color.cyan;
    [SerializeField] private bool _isSetedColor = true;
    
    public void Play(Vector3 position)
    {
        ParticleSystem parentEffect = Instantiate(_particleTemplate, position, Quaternion.identity);

        if (_isSetedColor == false)
            return;

        ParticleSystem[] allEffects = parentEffect.GetComponentsInChildren<ParticleSystem>();
        foreach (var effect in allEffects)
        {
            var main = effect.main;           
            main.startColor = _color;          
        }
    }

    public void PlayAsChild(Transform transform)
    {
        ParticleSystem parentEffect = Instantiate(_particleTemplate, transform);
    }
}
