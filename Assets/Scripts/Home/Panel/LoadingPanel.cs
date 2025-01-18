using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : Panel
{
    [SerializeField] private float timeLoading = 0.1f;
    [SerializeField] private Image loading;

    private void Start()
    {
        loading.fillAmount = 0;
    }
    private void Update()
    {
        
        loading.fillAmount += Time.deltaTime * timeLoading;
        if (loading.fillAmount >= 1)
        {
            SceneManager.LoadScene(Scene.HOME);
        }
    }
}
