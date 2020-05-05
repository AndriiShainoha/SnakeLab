using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnakeLab.Entities.Observer
{
    class ColorObservable : IObservable
    {
        private Color _Color = Colors.Blue;

        public Color Color
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
                Notify();
            }
        }

        private HashSet<IObserver> _observers = new HashSet<IObserver>();

        public void Notify()
        {
            _observers.ToList().ForEach(o => o.ColorChanged(Color));
        }

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }
    }
}
