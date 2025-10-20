using System;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Infrastructure.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        [Inject] private readonly IGameSessionService _gameSessionService;
        [Inject] private readonly IGameFactory _gameFactory;
        private const string ProgressKey = "Progress";
        
        public void Initialize()
        {
            LoadProgress();
            Application.quitting += QuittingHandler;
        }

        private void QuittingHandler()
        {
            SaveProgress();
            Application.quitting -= QuittingHandler;
        }

        private void SaveProgress()
        {
            _gameSessionService.ClearProgressData();
            foreach (IProgressSaver progressSaver in _gameFactory.ProgressSavers)
            {
                if (progressSaver != null && (progressSaver as MonoBehaviour) != null)
                {
                    progressSaver.Save(_gameSessionService.GameProgressData);
                }
            }
            PlayerPrefs.SetString(ProgressKey, _gameSessionService.GameProgressData.ToJson());
        }

        private void LoadProgress()
        {
            string savedData = PlayerPrefs.GetString(ProgressKey);
            if (!string.IsNullOrEmpty(savedData))
            {
                var loadedData = savedData.ToDeserialized<GameProgressData>();
                if (loadedData != null)
                {
                    _gameSessionService.GameProgressData = loadedData;
                }
            }
        }
    }
}
