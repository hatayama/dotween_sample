using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Cube : MonoBehaviour 
{
	IEnumerator Start () 
	{
		yield return new WaitForSeconds (0.1f);

		yield return transform.DOScale (new Vector3(2f, 2f, 2f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

		DateTime start = DateTime.Now;
		yield return transform.DOMove (new Vector3 (-5f, -5f, -5f), 2f).SetEase (Ease.OutBounce)
			.OnComplete(
				() => 
				{
					Debug.Log ("A: " + (DateTime.Now - start).TotalMilliseconds);
				})
			.WaitForPosition (0.5f);

		Debug.Log ("B: " + (DateTime.Now - start).TotalMilliseconds);

		yield return new WaitForSeconds (0.3f);

		yield return DOTween.Sequence ()
			.Append(transform.DOMove(new Vector3(5f, 0, 0), 1f))
			.Append(transform.DOMove(new Vector3(5f, 5f, 0), 1f))
			.Append(transform.DOMove(new Vector3(5f, 5f, 5f), 1f))
			.WaitForCompletion ();

		yield return transform.DOScale (new Vector3(1f, 1f, 1f), 1f).SetEase(Ease.OutBounce).WaitForCompletion();

		yield return transform.DOScale (new Vector3 (1f, 1f, 1f), 1f).SetEase (Ease.OutBounce);

		yield return transform.DORotate (new Vector3 (180, 0, 0), 1, RotateMode.WorldAxisAdd)
			.SetLoops (2)
			.SetEase (Ease.InExpo)
			.WaitForElapsedLoops (1);

		Debug.Log ("end.");
	}
}
