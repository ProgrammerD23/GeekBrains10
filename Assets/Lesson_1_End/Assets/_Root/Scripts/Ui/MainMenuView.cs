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
        [SerializeField] private Button buttonShed;

        public void Init(UnityAction startGame, UnityAction openShed)
        {
            _buttonStart.onClick.AddListener(startGame);
            buttonShed.onClick.AddListener(openShed);
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
            buttonShed.onClick.RemoveAllListeners();
        }
    }
}
