﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseSceneDirector : MonoBehaviour {

	// --------
	#region インスペクタ設定用フィールド
	[Header ("*Scene Translate Settings")]
	/// <summary>
	/// フェード時間
	/// </summary>
	public float fadeDurationTime;
	/// <summary>
	/// フェードカラー
	/// </summary>
	public Color fadeColor;
	#endregion

	// --------
	#region メンバフィールド
	/// <summary>
	/// The scene translate flag.
	/// </summary>
	protected bool sceneTranslatingFlag = false;
	/// <summary>
	/// delegate型を宣言
	/// </summary>
	protected delegate void OnComplete<T> (T value);
	#endregion

	// --------
	#region MonoBehaviourメソッド
	/// <summary> 
	/// 初期化処理
	/// </summary>
	virtual protected void Start () {

	}
	#endregion

	// --------
	#region メンバメソッド
	/// <summary>
	/// Translates the scene.
	/// </summary>
	/// <param name="_sceneName">Scene name.</param>
	public void translateScene(string _sceneName){

		if(!sceneTranslatingFlag){

			sceneTranslatingFlag = true;

			ScreenFadeManager.Instance.FadeOut (fadeDurationTime, fadeColor, () => {
				SceneManager.LoadScene(_sceneName);
				sceneTranslatingFlag = false;
			});
		}

	}

	/// <summary>
	/// Waits the timer.
	/// </summary>
	/// <returns>The timer.</returns>
	/// <param name="waitTime">Wait time.</param>
	/// <param name="callback">Callback.</param>
	protected IEnumerator waitTimer(float waitTime, OnComplete<bool> callback){
		yield return new WaitForSeconds (waitTime);
		callback (true);
	}
	#endregion
}