using System;
using MuffinFramework.Muffins;

namespace SampleApplication3.Muffins
{
    public sealed class Muffin1 : Muffin
    {
        protected override void Enable()
        {
            // When trying to access lower layers (ex. Muffin accessing a Service) you
            // can be sure that all Services are loaded. But this is not the case here.
            // We can not assume that Muffin2 is already loaded, as muffins are loaded 
            // one after the other and Muffin1 might be the only loaded Muffin at this
            // time. The following might result in a KeyNotFoundException:

            // Muffin2 muffin2 = MuffinLoader.Get<Muffin2>();

            // Instead, we must first wait for all Muffins to load...
            this.MuffinLoader.EnableComplete += this.MuffinLoader_EnableComplete;
        }

        void MuffinLoader_EnableComplete(object sender, EventArgs e)
        {
            // It is now safe to access Muffin2
            var muffin2 = this.MuffinLoader.Get<Muffin2>();

            muffin2.Text = "New Text!";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            base.Dispose();
            this.MuffinLoader.EnableComplete -= this.MuffinLoader_EnableComplete;
        }
    }
}
