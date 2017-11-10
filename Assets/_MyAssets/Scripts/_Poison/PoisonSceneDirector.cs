using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSceneDirector : BaseSceneDirector {

	// --------
	#region インスペクタ設定用フィールド
	/// <summary> 
	/// 
	/// </summary>
	#endregion

	// --------
	#region メンバフィールド
	/// <summary> 
	/// 
	/// </summary>
	#endregion

	// --------
	#region MonoBehaviourメソッド
	/// <summary> 
	/// 初期化処理
	/// </summary>
	void Awake() {

	}
	/// <summary> 
	/// 開始処理
	/// </summary>
	void Start () {

		base.Start(); // 親クラスのメソッドを呼ぶ

		ScreenFadeManager.Instance.FadeIn (fadeDurationTime, fadeColor, () => {
			
		});
	}
	/// <summary> 
	/// 更新処理
	/// </summary>
	void Update () {

	}

	/// <summary> 
	/// 更新処理
	/// </summary>
	void LateUpdate(){

	}
	#endregion

	// --------
	#region メンバメソッド
	#endregion
}
