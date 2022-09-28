using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button buttonSettings;
        [SerializeField] private Button buttonBack;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
        }

        public void InitSettings(UnityAction unityAction)
        {
            buttonSettings.onClick.AddListener(unityAction);
        }

        public void InitBack(UnityAction back)
        {
            buttonBack.onClick.AddListener(back);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            buttonSettings.onClick.RemoveAllListeners();
        }
    }
}
