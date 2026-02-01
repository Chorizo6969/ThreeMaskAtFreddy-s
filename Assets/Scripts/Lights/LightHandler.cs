using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHandler : MonoBehaviour
{
    [field: SerializeField] public BlinkingObject _backLaneLight;
    [field: SerializeField] public BlinkingObject _leftLaneLight;
    [field: SerializeField] public BlinkingObject _rightLaneLight;
    [field: SerializeField] public BlinkingObject _deskLight;

    [SerializeField] private List<GameObject> _pointLightList;


    public IEnumerator BlinkPointLight(float blinkTime)
    {
        foreach (GameObject pointLight in _pointLightList) pointLight.SetActive(false);
        yield return new WaitForSeconds(blinkTime);
        foreach (GameObject pointLight in _pointLightList) pointLight.SetActive(true);


    }

}
