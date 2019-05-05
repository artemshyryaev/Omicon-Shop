using OmiconShop.Persistence;
using System;

namespace OmiconShop.Application.Repository
{
    public class ContextHelper
    {
        [ThreadStatic]
        Wrapper Current;

        public ShopDBContext Create()
        {
            if (Current != null)
            {
                Current.Incr();
                return Current;
            }

            return Current = new Wrapper(() => Current = null);
        }

        class Wrapper : ShopDBContext, IDisposable
        {
            private readonly Action onDispose;

            private int count = 1;

            public Wrapper(Action onDispose)
            {
                this.onDispose = onDispose;
            }

            public void Incr()
            {
                count++;
            }

            protected override void Dispose(bool disposing)
            {
                count--;
                if (count > 0)
                    return;
                onDispose();
                base.Dispose(disposing);
            }
        }
    }
}
