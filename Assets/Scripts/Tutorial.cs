using UnityEngine;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] string videoName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
