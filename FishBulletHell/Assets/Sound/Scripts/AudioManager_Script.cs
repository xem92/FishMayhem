using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager_Script : MonoBehaviour
{
    public static AudioManager_Script instance = null;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup sfxMixer;
    public AudioMixerGroup bulletsMixer;
    public AudioMixerGroup swordMixer;
    public AudioMixerGroup hitsMixer;
    public AudioMixerGroup powerupsMixer;
    private AudioSource musicSource;
    private AudioSource sfxSource;
    private AudioSource bulletsSource;
    private AudioSource swordSource;
    private AudioSource hitsSource;
    private AudioSource powerupsSource;


    private void Awake() {
        if (instance == null) {
            instance = this;

        }
        else if (instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.outputAudioMixerGroup = musicMixer;

        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.outputAudioMixerGroup = sfxMixer;

        bulletsSource = gameObject.AddComponent<AudioSource>();
        bulletsSource.outputAudioMixerGroup = bulletsMixer;

        swordSource = gameObject.AddComponent<AudioSource>();
        swordSource.outputAudioMixerGroup = swordMixer;

        hitsSource = gameObject.AddComponent<AudioSource>();
        hitsSource.outputAudioMixerGroup = hitsMixer;

        powerupsSource = gameObject.AddComponent<AudioSource>();
        powerupsSource.outputAudioMixerGroup = powerupsMixer;
    }

    public void PlayMusic(AudioClip musicClip) {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sfxClip) {
        sfxSource.PlayOneShot(sfxClip);
    }

    public void PlayBullet(AudioClip sfxClip) {
        bulletsSource.PlayOneShot(sfxClip);
    }

    public void PlaySword(AudioClip sfxClip) {
        swordSource.PlayOneShot(sfxClip);
    }

    public void PlayHits(AudioClip sfxClip) {
        hitsSource.PlayOneShot(sfxClip);
    }

    public void PlayPowerups(AudioClip sfxClip) {
        powerupsSource.PlayOneShot(sfxClip);
    }

    public void PlaySFX(AudioClip sfxClip, float volume) {
        sfxSource.volume = volume;
        sfxSource.PlayOneShot(sfxClip);
    }
}
