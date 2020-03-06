using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private MLInputController _controller = null;

    void Start()
    {
        if (!MLInput.IsStarted)
            MLInput.Start();
        _controller = MLInput.GetController(MLInput.Hand.Left);
        MLInput.OnTriggerUp += OnTriggerUp;
    }

    private void OnDisable()
    {
        MLInput.OnTriggerUp -= OnTriggerUp;
        MLInput.Stop();
    }

    void OnTriggerUp(byte controllerId, float pressure)
    {
        if (controllerId == _controller.Id)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
