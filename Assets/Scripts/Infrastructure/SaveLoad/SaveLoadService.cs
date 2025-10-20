using System;
using Infrastructure.Data;
using Infrastructure.GameFactories;
using Infrastructure.GameSession;
using UnityEngine;
using Zenject;

namespace Infrastructure.SaveLoad
{
    public class SaveLoadService : ISaveLoadService, IDisposable
    {
        [Inject] private readonly IGameSessionService _gameSessionService;
        [Inject] private readonly IGameFactory _gameFactory;
        private const string ProgressKey = "Progress";
        
        public void Initialize()
        {
            LoadProgress();
        }
    
        public void Dispose()
        {
            SaveProgress();
        }

        private void SaveProgress()
        {
            _gameSessionService.ClearProgressData();
            Debug.LogError(_gameFactory.ProgressSavers.Count);
            foreach (IProgressSaver progressSaver in _gameFactory.ProgressSavers)
            {
                if (progressSaver != null && (progressSaver as MonoBehaviour) != null)
                {
                    progressSaver.Save(_gameSessionService.GameProgressData);
                }
            }
            Debug.LogError(_gameSessionService.GameProgressData.ToJson());
            PlayerPrefs.SetString(ProgressKey, _gameSessionService.GameProgressData.ToJson());
        }

        private void LoadProgress()
        {
            string savedData = PlayerPrefs.GetString(ProgressKey);
            if (!string.IsNullOrEmpty(savedData))
            {
                var loadedData = savedData.ToDeserialized<GameProgressData>();
                Debug.LogError(loadedData);
                if (loadedData != null)
                {
                    _gameSessionService.GameProgressData = loadedData;
                }
            }
        }
    }
}
