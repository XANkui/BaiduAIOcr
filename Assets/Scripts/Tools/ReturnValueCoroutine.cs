using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnValueCoroutine  {

	private object result;
	public object Result
	{
		get {return result;}
	}
	public UnityEngine.Coroutine Coroutine;

	public IEnumerator InternalRoutine(IEnumerator coroutine)
	{
		while(true)
		{
			if(!coroutine.MoveNext()){
				yield break;
			}
			object yielded = coroutine.Current;

			if(yielded != null){
				result = yielded;
				yield break;
			}
			else{
				yield return coroutine.Current;
			}
		}
	}
}
