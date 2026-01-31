using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class ConeLight : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _range, _lightIntensity;

    [SerializeField] private GameObject _mesh;
    [SerializeField] private Light _light;

    private void Update()
    {
        _mesh.transform.localScale = new Vector3(_radius, _range, _radius);

        _light.innerSpotAngle = (_radius - 1.5f) * 4;
        _light.spotAngle = (_radius + 1.5f) * 6;
        _light.range = (_range + 2) * 2f;
        //_light.intensity = _lightIntensity;
    }
}
