using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioClip resetButtonSound;
    
    

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void TrashPickUpSound()
    {
        _audioSource.PlayOneShot(_audioClips[0]);
    }

    public void TrashDropSound()
    {
        _audioSource.PlayOneShot(_audioClips[1]);
    }
    public void DumpSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.PlayOneShot(_audioClips[2]);
        }
    }

    public void GetClock()
    {
        _audioSource.PlayOneShot(_audioClips[3]);
    }

    public void CapacityWarningSound(bool soundLoop)
    {
        if (soundLoop)
        {
            _audioSource.clip=_audioClips[4];
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else
        {
            _audioSource.loop = false;
        }
    }

    public void ResetButtonSound()
    {
        _audioSource.PlayOneShot(resetButtonSound);
    }
    
       
    
    
}
