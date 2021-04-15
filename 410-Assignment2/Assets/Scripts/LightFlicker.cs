using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public enum FlickerMode
    {
        Random,
        AnimationCurve
    }
    
    public Light flickeringLight;
    public Renderer flickeringRenderer;
    public FlickerMode flickerMode;
    public float lightIntensityMin = 1.25f;
    public float lightIntensityMax = 8.0f;
   
   // public float flickerDuration = 0.075f;
    public AnimationCurve intensityCurve;
    public bool up = true;
    public float testnum = 0;

    public float lightincrease = 0.5f;
    public float lightintestity = 10f;
  
    Material m_FlickeringMaterial;
    Color m_EmissionColor;
    float m_Timer;
    float m_FlickerLightIntensity;
    
    static readonly int k_EmissionColorID = Shader.PropertyToID (k_EmissiveColorName);
    
    const string k_EmissiveColorName = "_EmissionColor";
    const string k_EmissionName = "_Emission";
    const float k_LightIntensityToEmission = 2f / 3f;

    void Start()
    {
        m_FlickeringMaterial = flickeringRenderer.material;
        m_FlickeringMaterial.EnableKeyword(k_EmissionName);
        m_EmissionColor = m_FlickeringMaterial.GetColor(k_EmissionColorID);
    }

    void Update()
    {
        //Added linear interpolation for the light intesity to go back and forth.  


        if (lightintestity > (lightIntensityMax - 0.5f))
        {
            up = false;
        }
        if (lightintestity < (lightIntensityMin + 0.5f)) 
        {
            up = true;
        }

        if(up == true)
        {
            //LightintDirection = lightIntensityMin;
            lightintestity = Mathf.Lerp(lightintestity, lightIntensityMax, lightincrease * Time.deltaTime);
            m_FlickeringMaterial.SetColor(k_EmissionColorID, m_EmissionColor * lightintestity); 
        }
        else
        {
           // LightintDirection = lightIntensityMax;

            lightintestity = Mathf.Lerp(lightintestity, lightIntensityMin, lightincrease * Time.deltaTime);
            m_FlickeringMaterial.SetColor(k_EmissionColorID, m_EmissionColor * lightintestity);
            testnum += 1;
        }


        //lightintestity = Mathf.Lerp(lightintestity, LightintDirection, lightincrease * Time.deltaTime);
        //m_FlickeringMaterial.SetColor(k_EmissionColorID, m_EmissionColor * lightintestity);
           
        
        
        /*
        m_Timer += Time.deltaTime;

        if (flickerMode == FlickerMode.Random)
        {
            if (m_Timer >= flickerDuration)
            {
                ChangeRandomFlickerLightIntensity ();
            }
        }
        else if(flickerMode == FlickerMode.AnimationCurve)
        {
            ChangeAnimatedFlickerLightIntensity ();
        }
            
        flickeringLight.intensity = m_FlickerLightIntensity;
        m_FlickeringMaterial.SetColor (k_EmissionColorID, m_EmissionColor * m_FlickerLightIntensity * k_LightIntensityToEmission);
        */

        
        
    }
    /*
    void ChangeRandomFlickerLightIntensity ()
    {
        m_FlickerLightIntensity = Random.Range(lightIntensityMin, lightIntensityMax);

        m_Timer = 0f;
    }

    void ChangeAnimatedFlickerLightIntensity ()
    {
        m_FlickerLightIntensity = intensityCurve.Evaluate (m_Timer);

        if (m_Timer >= intensityCurve[intensityCurve.length - 1].time)
            m_Timer = intensityCurve[0].time;
    }
    */
}

