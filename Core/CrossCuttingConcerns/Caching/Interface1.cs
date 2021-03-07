using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
	public interface ICacheManager
	{
		T Get<T>(string key);
		object Get(string key);
		void Add(string key, object value, int duration);
		void Remove(string key); //cacheden uçurma
		bool IsAdd(string key);
		//ismi get olanı uçur başı sonu önemli değil
		void RemoveByPattern(string pattern);

	}
}
