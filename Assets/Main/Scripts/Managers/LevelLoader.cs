using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{
        [SerializeField] GameObject LoadingScreen;
        [SerializeField] private Slider loadingSlider;
        
        public void LoadLevel(int LevelIndex)
        {
            StartCoroutine(Loading(LevelIndex));
        }

        private IEnumerator Loading(int LevelIndex)
        {
                LoadingScreen.SetActive(true);
                AsyncOperation operation = SceneManager.LoadSceneAsync(LevelIndex);
                float progress = Mathf.Clamp01(operation.progress/.9f);
                while (!operation.isDone)
                {
                    loadingSlider.value = progress;
                    yield return null;
                }
        }
}
