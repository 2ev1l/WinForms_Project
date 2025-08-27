using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTimeCalc.Universal
{
    public class StateMachine<T> where T : class
    {
        private readonly Action<T, bool> changeStateActive;
        public IReadOnlyList<T> States => states!;
        private readonly List<T>? states = null;
        private readonly T? defaultState = null;
        public T? ActiveState => activeState;
        private T? activeState = null;

        /// <summary>
        /// Сменить состояние объекта на активное.
        /// Все остальные объекты будут рассмотрены как неактивные.
        /// </summary>
        /// <param name="state"></param>
        private void ChangeStateActive(T state)
        {
            if (activeState == state) return;
            int statesCount = states!.Count;
            for (int i = 0; i < statesCount; ++i)
            {
                T currentState = states[i];
                changeStateActive.Invoke(currentState, currentState == state);
            }
            activeState = state;
        }
        /// <summary>
        /// Изменить состояние на значение из списка (по индексу)
        /// </summary>
        /// <param name="index"></param>
        public void ApplyState(int index) => ChangeStateActive(states![index]);
        /// <summary>
        /// Изменить состояние на значение из списка (по элементу)
        /// </summary>
        /// <param name="state"></param>
        public void ApplyState(T state) => ChangeStateActive(state);
        /// <summary>
        /// Изменить состояние на стандартное
        /// </summary>
        public void ApplyDefaultState() => ChangeStateActive(defaultState!);

        public StateMachine(List<T> states, T defaultState, Action<T, bool> changeStateActive)
        {
            this.states = states;
            this.defaultState = defaultState;
            this.changeStateActive = changeStateActive;
        }
    }
}
