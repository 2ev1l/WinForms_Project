using ProcessingTimeCalc.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    public class ObjectPool<T> where T : class, IPoolableObject, new()
    {
        public IReadOnlyCollection<T> Objects => objects;
        private readonly HashSet<T> objects = new();

        /// <summary>
        /// Получить доступный объект
        /// </summary>
        /// <returns></returns>
        public T GetObject()
        {
            if (ExistInactiveObject(out T? inactive))
            {
                return ObjectPool<T>.ReactivateObject(inactive!);
            }
            return InstantiateObject<T>();
        }
        /// <summary>
        /// Получить доступный объект
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <returns></returns>
        public S GetObject<S>() where S : T, new()
        {
            if (ExistInactiveObject(out S? inactive))
            {
                return (S)ObjectPool<T>.ReactivateObject(inactive!);
            }
            return InstantiateObject<S>();
        }
        /// <summary>
        /// Найти объект
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public T? Find(System.Predicate<T> predicate, bool includeInactive = true)
        {
            foreach (T obj in objects)
            {
                if (!includeInactive)
                {
                    if (!obj.IsActive) continue;
                }
                if (predicate.Invoke(obj)) return obj;
            }
            return null;
        }
        /// <summary>
        /// Существует ли неактивный объект
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="exist"></param>
        /// <returns></returns>
        private bool ExistInactiveObject<S>(out S? exist) where S : T
        {
            foreach (T obj in objects)
            {
                if (!obj.IsActive)
                {
                    if (obj is not S sObj) continue;
                    exist = sObj;
                    return true;
                }
            }
            exist = default;
            return false;
        }
        /// <summary>
        /// Создать новый объект
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <returns></returns>
        private S InstantiateObject<S>() where S : T, new()
        {
            S obj = new();
            objects.Add(obj);
            return (S)ReactivateObject(obj);
        }
        /// <summary>
        /// Активировать объект
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static T ReactivateObject(T obj)
        {
            if (obj.IsActive) return obj;
            obj.OnPoolEnable();
            obj.IsActive = true;
            return obj;
        }
        /// <summary>
        /// Деактивировать объект
        /// </summary>
        /// <param name="obj"></param>
        private static void DisableObject(T obj)
        {
            obj.IsActive = false;
            obj.OnPoolDisable();
        }
        /// <summary>
        /// Деактивировать все объекты
        /// </summary>
        public void DisableObjects()
        {
            foreach (T obj in objects)
            {
                DisableObject(obj);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Число активных объектов</returns>
        public int GetActiveObjectsCount()
        {
            int result = 0;
            foreach (T obj in objects)
            {
                if (obj.IsActive)
                    ++result;
            }
            return result;
        }
    }
}
