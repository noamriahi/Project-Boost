using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    bool isTransitioning = false;
    bool collisionDisabled = false;
    AudioSource audioSource;
    [SerializeField] float delay=1f;
    [SerializeField] AudioClip landingAudio, crashAudio;

    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled){
        return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                lendingSequence();
                break;
            default:
                StartCrashingSequence();
                break;
        }
    }
    void StartCrashingSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
        crashParticle.Play();
        GetComponent<Movemant>().enabled = false;
        Invoke("ReloadLevel", delay);
        
    }
    void lendingSequence(){
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(landingAudio);
        successParticle.Play();
        GetComponent<Movemant>().enabled=false;
        Invoke("LoadNextLevel", delay);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
