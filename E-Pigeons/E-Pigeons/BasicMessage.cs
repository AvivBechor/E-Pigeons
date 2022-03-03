namespace E_Pigeons
{
    public class BasicMessage
    {
        private string sync;

        public virtual void SetSync(string _sync)
        {
            this.sync = _sync;
        }

        public virtual string GetSync() => this.sync;
    }
}