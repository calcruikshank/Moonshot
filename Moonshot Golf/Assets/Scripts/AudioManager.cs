using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //player feedback
    public AudioSource _Win;
    public AudioSource _Lose;
    public AudioSource _EnterOrbit;
    public AudioSource _OrbitMeter;
    public AudioSource _Astroid;

    //UI
    public AudioSource _MouseOver;
    public AudioSource _Select;
    public AudioSource _Confirm;
    public AudioSource _Start;

    //environment
    public AudioSource _WhiteNoise1;
	public AudioSource _WhiteNoise2;

	//music
	public AudioSource _AmbientSynthLoop;

    //Orbit Meter
    public bool _InVictoryOrbit;
    private bool _StartOrbitMeter;
    private bool _OrbitMeterIsRunning;
    public float _OrbitMeterRate;
    Coroutine OrbitMeterCoroutine;

    //White Noise
    public float _WhiteNoiseVol;
    public float _ValueToConvert;

    public AudioSource[] _GameplayAudio;

    public static AudioManager _Main;
    public AudioMixer _Mixer;

    void Awake()
    {
        if (_Main != null)
        {
            Destroy(gameObject);
            return;
        }
        _Main = this;
        DontDestroyOnLoad(gameObject);

        Invoke("FadeInMusic", 0.5f);
        _AmbientSynthLoop.Play();

        Invoke("PlayWhiteNoise1", 1f);

        foreach (AudioSource _AudioSource in _GameplayAudio)
        {
            _AudioSource.mute = true;
        }
    }

    public void FadeInMusic()
    {
        StartCoroutine(FadeMixerGroup.StartFade(_Mixer, "MusicFader", 3f, 1f));
    }

    public void FadeOutMusic()
    {
        StartCoroutine(FadeMixerGroup.StartFade(_Mixer, "MusicFader", 3f, 0f));
    }

    public void SetMasterVol(float sliderVal)
    {
        sliderVal = Mathf.Clamp(sliderVal, 0.0001f, 1);
        sliderVal = Mathf.Log10(sliderVal) * 20;
        _Mixer.SetFloat("MasterFader", sliderVal);
    }

    public void StartGameDelay()
    {
        Invoke("StartGame", 0.5f);
    }

    private void StartGame()
    {
        foreach (AudioSource _AudioSource in _GameplayAudio)
        {
            _AudioSource.mute = false;
        }
    }

    private IEnumerator OrbitRatchet()
    {
        float _CurrentPitch = 1f;

        PlayEnterOrbit();

        while (_InVictoryOrbit)
        {
            _OrbitMeterIsRunning = true;
            _OrbitMeter.pitch = _CurrentPitch;
            PlayOrbitMeter();
            _CurrentPitch += 0.05f;
            yield return new WaitForSeconds(_OrbitMeterRate);
            yield return null;
        }
        _OrbitMeterIsRunning = false;
    }

    public void SetOrbitMeterRate(float distanceFromPlanet)
    {
        _OrbitMeterRate = distanceFromPlanet;
        _OrbitMeterRate = _OrbitMeterRate / 50f;
    }

    public void RestartOrbitMeter()
    {
        if (_InVictoryOrbit)
        {
            StopCoroutine(OrbitMeterCoroutine);
            _OrbitMeterIsRunning = false;

            if (!_OrbitMeterIsRunning)
            {
                OrbitMeterCoroutine = StartCoroutine(OrbitRatchet());
            }
        }
    }

    public void StopOrbitMeter()
    {
        if (OrbitMeterCoroutine != null)
        {
            StopCoroutine(OrbitMeterCoroutine);
        }
        _OrbitMeterIsRunning = false;
    }

    public void SetWhiteNoiseVol(float distanceFromPlanet, float massOfPlanet)
    {
        float massCoefficient;

        massCoefficient = massOfPlanet / 100;

        //DH: this didn't work the way I'd hoped
        //_ValueToConvert = 1 - (distanceFromPlanet / (15 * massCoefficient));

        _ValueToConvert = 1 - (distanceFromPlanet / 15 );

        _ValueToConvert = _ValueToConvert * massCoefficient;

        _ValueToConvert = Mathf.Clamp(_ValueToConvert, 0.0001f, 1);

        _WhiteNoiseVol = Mathf.Log10(_ValueToConvert) * 20;

    }

    public void PlayMouseOver()
    {
        _MouseOver.Play();
    }

    public void PlaySelect()
    {
        _Select.Play();
    }

    public void PlayConfirm()
    {
        _Confirm.Play();
    }

    public void PlayStart()
    {
        _Start.Play();
    }

    private void PlayOrbitMeter()
    {
        _OrbitMeter.Play();
    }

    private void PlayEnterOrbit()
    {
        _EnterOrbit.Play();
    }

    public void PlayWin()
    {
        _Win.Play();
    }

    public void PlayLose()
    {
        _Lose.Play();
    }

    public void PlayAstroid()
	{
		_Astroid.Play();
	}

    public void PlayWhiteNoise1()
	{
		_WhiteNoise1.Play();
        Invoke("PlayWhiteNoise2", 0.5f);
    }

	public void PlayWhiteNoise2()
	{
		_WhiteNoise2.Play();
	}

    public void StopWhiteNoise()
    {
        _WhiteNoise1.Stop();
        _WhiteNoise2.Stop();
    }

	// Update is called once per frame
	void Update()
    {
        if (_InVictoryOrbit)
        {
            if (!_StartOrbitMeter)
            {
               OrbitMeterCoroutine = StartCoroutine(OrbitRatchet());
                _StartOrbitMeter = true;
            }
        }

        if (!_InVictoryOrbit)
        {
            _StartOrbitMeter = false;
        }

        _Mixer.SetFloat("WhiteNoiseFader", _WhiteNoiseVol);

    }
}
