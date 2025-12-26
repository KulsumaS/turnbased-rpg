using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager _instance;
    private static AudioSource audioSource;
    private static AudioSource randomPitchaudioSource;
    private static SoundEffectLibary soundEffectLibary;
    [SerializeField] private Slider volumeSlider;

    private void Awake()//means that there is only one instance at a time
    {
        if (_instance == null)
        {
            _instance = this;
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0];
            randomPitchaudioSource = audioSources[1]; //gets the audio source off the game object 
            soundEffectLibary = GetComponent<SoundEffectLibary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void Play(string soundName, bool randomPitch = false)
    {
        AudioClip audioClip = soundEffectLibary.GetRandomClip(soundName);
        if (audioClip != null)
        {
            if (randomPitch)
            {
                randomPitchaudioSource.pitch = Random.Range(1f, 1.5f);//changes pitch
                randomPitchaudioSource.PlayOneShot(audioClip);
            }
            else
            {
                audioSource.PlayOneShot(audioClip); 
            }
            
        }
    }

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
    }

    public static void Setvolume(float volume)
    {
        audioSource.volume = volume;
        randomPitchaudioSource.volume = volume;
    }

    public  void OnValueChanged()
    {
        Setvolume(volumeSlider.value);
    }
}
    