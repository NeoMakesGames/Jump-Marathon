using System;
using UnityEngine;
using UnityEngine.UI;

// Include these namespaces to use BinaryFormatter
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

namespace GracesGames.SimpleFileBrowser.Scripts {
	// Demo class to illustrate the usage of the FileBrowser script
	// Able to save and load files containing serialized data (e.g. text)
	public class DemoCaller : MonoBehaviour {

        public FileStream verdurita;
        public static string archivo;

		// Use the file browser prefab
		public GameObject FileBrowserPrefab;

		// Define a file extension
		public string[] FileExtensions;

		public bool PortraitMode;

		// Find the input field, label objects and add a onValueChanged listener to the input field
		private void Start() {

			GameObject uiCanvas = GameObject.Find("Canvas");
			if (uiCanvas == null) {
				Debug.LogError("Make sure there is a canvas GameObject present in the Hierarcy (Create UI/Canvas)");
			}
            DontDestroyOnLoad(gameObject);
        }

		// Open the file browser using boolean parameter so it can be called in GUI
		public void OpenFileBrowser(bool saving) {
			OpenFileBrowser(saving ? FileBrowserMode.Save : FileBrowserMode.Load);
		}

		// Open a file browser to save and load files
		private void OpenFileBrowser(FileBrowserMode fileBrowserMode) {
			// Create the file browser and name it
			GameObject fileBrowserObject = Instantiate(FileBrowserPrefab, transform);
			fileBrowserObject.name = "FileBrowser";
			// Set the mode to save or load
			FileBrowser fileBrowserScript = fileBrowserObject.GetComponent<FileBrowser>();
			fileBrowserScript.SetupFileBrowser(PortraitMode ? ViewMode.Portrait : ViewMode.Landscape);
			if (fileBrowserMode == FileBrowserMode.Save) {
				// fileBrowserScript.SaveFilePanel("DemoText", FileExtensions);
				// Subscribe to OnFileSelect event (call SaveFileUsingPath using path) 
				// fileBrowserScript.OnFileSelect += SaveFileUsingPath;
			} else {
				fileBrowserScript.OpenFilePanel(FileExtensions);
				// Subscribe to OnFileSelect event (call LoadFileUsingPath using path) 
				fileBrowserScript.OnFileSelect += LoadFileUsingPath;
			}
		}

		
		// Loads a file using a path
		private void LoadFileUsingPath(string path) {
			if (path.Length != 0) {
                //BinaryFormatter bFormatter = new BinaryFormatter();
                // Open the file using the path
                // verdurita = File.OpenRead(path);
                // Convert the file from a byte array into a string
                // string fileData = bFormatter.Deserialize(file) as string;
                // We're done working with the file so we can close it
                // verdurita.Close();
                // Set the LoadedText with the value of the file
                // _loadedText.GetComponent<Text>().text = "Loaded data: \n" + fileData;
                archivo = path;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			} else {
				Debug.Log("Invalid path given");
			}
		}
	}
}