namespace MuffinFramework.Tests.LayerBase
{
    class LayerBaseTester<TArgs> : LayerBase<TArgs>
    {
        public bool EnableWasCalled;
        protected override void Enable()
        {
            this.EnableWasCalled = true;
        }

        public TPart TestEnablePart<TPart, TProtocol>(TProtocol host) where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            return this.EnablePart<TPart, TProtocol>(host);
        }

        public TPart TestEnablePart<TPart, TProtocol>() where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            return this.EnablePart<TPart, TProtocol>();
        }
    }
}
