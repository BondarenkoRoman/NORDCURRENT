using UnityEngine;

namespace Infrastructure.AssetManagement
{
  public interface IAssetProvider
  {
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Vector3 at, Quaternion quaternion);
    GameObject Instantiate(string path);

    T Load<T>(string path) where T : Object;
  }
}