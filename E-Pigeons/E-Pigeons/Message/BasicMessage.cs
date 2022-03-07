namespace E_Pigeons
{
    public abstract class BasicMessage : IGenerate
    {
        private string sync;

        public virtual void SetSync(string _sync)
        {
            this.sync = _sync;
        }

        public virtual string GetSync() => this.sync;

        public abstract byte[] Generate();
    }
}