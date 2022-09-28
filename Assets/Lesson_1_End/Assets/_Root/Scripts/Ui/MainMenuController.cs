using Profile;
using Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ui
{
    internal class MainMenuController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;
        private GameObject objectView;


        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
            _view.InitSettings(Setting);
            _view.InitBack(Back);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        public void LoadSetting()
        {
            if (_profilePlayer.CurrentState.Value == GameState.Settings)
            {
                objectView.transform.Find("ButtonStart").gameObject.SetActive(false);
                objectView.transform.Find("ButtonBack").gameObject.SetActive(true);
                objectView.transform.Find("ButtonSettings").gameObject.SetActive(false);
            }
        }

        private void StartGame() =>
            _profilePlayer.CurrentState.Value = GameState.Game;

        private void Setting() =>
            _profilePlayer.CurrentState.Value = GameState.Settings;

        private void Back()
        {
            objectView.transform.Find("ButtonBack").gameObject.SetActive(false);
            objectView.transform.Find("ButtonStart").gameObject.SetActive(true);
            objectView.transform.Find("ButtonSettings").gameObject.SetActive(true);
        }
    }
}
