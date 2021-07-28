using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorAction_script : Action_script
{
    public GameObject   cameraObj;
    public float        minScanArea,
                        maxScanArea,
                        minVramShift,
                        maxVramShift,
                        minUnsyncSpeed,
                        maxUnsyncSpeed,
                        minBleedIntensity,
                        maxBleedIntensity,
                        minBleedShift,
                        maxBleedShift,
                        errorDuration,
                        errorFrequency,
                        waitDuration;

    private ShaderEffect_Scanner _scanner;
    private ShaderEffect_Unsync _unsync;
    private ShaderEffect_CorruptedVram _vram;
    private ShaderEffect_BleedingColors _bleed;

    private void Start()
    {
        _scanner = cameraObj.GetComponent<ShaderEffect_Scanner>();
        _unsync = cameraObj.GetComponent<ShaderEffect_Unsync>();
        _vram = cameraObj.GetComponent<ShaderEffect_CorruptedVram>();
        _bleed = cameraObj.GetComponent<ShaderEffect_BleedingColors>();
    }

    public override void Act()
    {
        StartCoroutine(GlitchIEnum());
    }

    private IEnumerator GlitchIEnum()
    {
        float counter = 0f,
            waitAmount = errorDuration / errorFrequency;

        yield return new WaitForSeconds(waitDuration);

        do
        {
            counter += waitAmount;

            switch (Random.Range(1, 4))
            {
                case 1:
                    _scanner.enabled = true;
                    _scanner.area = Random.Range(minScanArea, maxScanArea);
                    _unsync.enabled = false;
                    _vram.enabled = false;
                    _bleed.enabled = false;
                    break;
                case 2:
                    _vram.enabled = true;
                    _vram.shift = Random.Range(minVramShift, maxVramShift);
                    _scanner.enabled = false;
                    _unsync.enabled = false;
                    _bleed.enabled = false;
                    break;
                case 3:
                    _unsync.enabled = true;
                    _unsync.speed = Random.Range(minUnsyncSpeed, maxUnsyncSpeed);
                    _scanner.enabled = false;
                    _vram.enabled = false;
                    _bleed.enabled = false;
                    break;
                default:
                    _bleed.enabled = true;
                    _bleed.intensity = Random.Range(minBleedIntensity, maxBleedIntensity);
                    _bleed.shift = Random.Range(minBleedShift, maxBleedShift);
                    _scanner.enabled = false;
                    _unsync.enabled = false;
                    _vram.enabled = false;
                    break;
            }
            
            yield return new WaitForSeconds(waitAmount);
        } while (counter < errorDuration);

        _scanner.enabled = false;
        _unsync.enabled = false;
        _vram.enabled = false;
        _bleed.enabled = false;
    }
}
