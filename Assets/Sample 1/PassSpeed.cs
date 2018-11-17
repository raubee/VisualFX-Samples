
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class PassSpeed : MonoBehaviour
{
    [SerializeField] Lasp.FilterType _filterType;

    [SerializeField] private VisualEffect _visualEffect;

    [SerializeField] float _amplify;
    public float Amplify
    {
        get { return _amplify; }
        set { _amplify = value; }
    }

    void Update()
    {
        var rms = Lasp.AudioInput.CalculateRMSDecibel(_filterType) + _amplify;
        var level = 1 + rms * 0.1f;
        level = Mathf.Clamp01(level);

        _visualEffect.SetFloat(Shader.PropertyToID("LowPassSpeed"), level);
    }
}
