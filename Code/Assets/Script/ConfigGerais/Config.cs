using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Config : MonoBehaviour
{

    public void SetVolume (float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetQualidade(int qualidade)
    {
        QualitySettings.SetQualityLevel(qualidade);
    }
}
